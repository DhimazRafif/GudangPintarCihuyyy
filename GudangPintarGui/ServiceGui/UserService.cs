using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using GudangPintarGui.ConfigDatabase;
using GudangPintarGui.Models;
using GudangPintarGui.Utils;
using MySql.Data.MySqlClient;

namespace GudangPintarGui.ServiceGUI
{
    public class UserService : IUserService
    {
        private readonly DBConnection _dbConnection;
        private readonly IRoleService _roleService;
        private List<User> _usersCache;

        public UserService()
        {
            _dbConnection = DBConnection.GetInstance();
            _roleService = new RoleService();
            _usersCache = new List<User>();
            LoadUsers();
        }

        // ===================== LOAD & CACHE =====================
        private void LoadUsers()
        {
            _usersCache.Clear();
            const string query = "SELECT userid, name, username, password, role, isActive, created_at, updated_at FROM user";

            try
            {
                using (var conn = _dbConnection.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            _usersCache.Add(new User
                            {
                                UserId = reader.GetInt32("userid"),
                                Name = reader.GetString("name"),
                                Username = reader.GetString("username"),
                                Password = reader.GetString("password"),
                                Role = reader.GetInt32("role"),
                                IsActive = reader.GetBoolean("isActive"),
                                CreatedAt = reader.GetDateTime("created_at"),
                                UpdatedAt = reader.GetDateTime("updated_at")
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading users: {ex.Message}");
                throw;
            }
        }

        private void SaveToDatabase(User user, bool isUpdate = false)
        {
            try
            {
                using (var conn = _dbConnection.GetConnection())
                {
                    conn.Open();
                    if (isUpdate)
                    {
                        const string query = @"
                            UPDATE user 
                            SET name = @name, username = @username, password = @password, 
                                role = @role, isActive = @isActive, updated_at = NOW()
                            WHERE userid = @userId";

                        using (var cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@userId", user.UserId);
                            cmd.Parameters.AddWithValue("@name", user.Name);
                            cmd.Parameters.AddWithValue("@username", user.Username);
                            cmd.Parameters.AddWithValue("@password", user.Password);
                            cmd.Parameters.AddWithValue("@role", user.Role);
                            cmd.Parameters.AddWithValue("@isActive", user.IsActive);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        const string query = @"
                            INSERT INTO user (name, username, password, role, isActive, created_at, updated_at)
                            VALUES (@name, @username, @password, @role, @isActive, NOW(), NOW())";

                        using (var cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@name", user.Name);
                            cmd.Parameters.AddWithValue("@username", user.Username);
                            cmd.Parameters.AddWithValue("@password", user.Password);
                            cmd.Parameters.AddWithValue("@role", user.Role);
                            cmd.Parameters.AddWithValue("@isActive", user.IsActive);
                            cmd.ExecuteNonQuery();
                            user.UserId = (int)cmd.LastInsertedId;
                        }
                    }
                }
                LoadUsers(); // refresh cache
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error saving user: {ex.Message}");
                throw;
            }
        }

        // ===================== VALIDATION HELPERS =====================
        private bool IsStrongPassword(string password)
        {
            return password.Length >= 8 &&
                   password.Any(char.IsUpper) &&
                   password.Any(char.IsDigit);
        }

        private bool IsValidPasswordForRole(string password, int roleId)
        {
            if (roleId == RoleService.ROLE_ADMIN)
                return IsStrongPassword(password);
            else if (roleId == RoleService.ROLE_PEGAWAI)
                return password.Length >= 6;
            else
                return false;
        }

        // ===================== CRUD OPERATIONS =====================
        public bool Add(string name, string username, string password, int roleId)
        {
            // Precondition validation
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Nama tidak boleh kosong");
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username tidak boleh kosong");
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password tidak boleh kosong");
            if (!_roleService.RoleExists(roleId))
                throw new ArgumentException("Role tidak valid");

            if (!IsValidPasswordForRole(password, roleId))
            {
                string msg = (roleId == RoleService.ROLE_ADMIN)
                    ? "Password Admin minimal 8 karakter, harus ada huruf besar dan angka!"
                    : "Password Pegawai minimal 6 karakter!";
                throw new ArgumentException(msg);
            }

            if (IsUsernameExists(username))
                throw new InvalidOperationException("Username sudah digunakan");

            try
            {
                var hashedPassword = PasswordHelper.HashPassword(password);
                var newUser = new User(0, name, username, hashedPassword, roleId, true);
                SaveToDatabase(newUser, isUpdate: false);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in Add: {ex.Message}");
                return false;
            }
        }

        public bool Update(int userId, string name, string username, string password, int roleId)
        {
            var user = GetById(userId);
            if (user == null)
                throw new InvalidOperationException("User tidak ditemukan");

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Nama tidak boleh kosong");
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username tidak boleh kosong");
            if (!_roleService.RoleExists(roleId))
                throw new ArgumentException("Role tidak valid");

            // Cek duplikat username (exclude current user)
            if (IsUsernameExists(username, userId))
                throw new InvalidOperationException("Username sudah digunakan oleh user lain");

            // Jika password diisi, validasi sesuai role
            bool passwordChanged = !string.IsNullOrWhiteSpace(password);
            if (passwordChanged && !IsValidPasswordForRole(password, roleId))
            {
                string msg = (roleId == RoleService.ROLE_ADMIN)
                    ? "Password Admin minimal 8 karakter, harus ada huruf besar dan angka!"
                    : "Password Pegawai minimal 6 karakter!";
                throw new ArgumentException(msg);
            }

            try
            {
                user.Name = name;
                user.Username = username;
                user.Role = roleId;
                if (passwordChanged)
                {
                    user.Password = PasswordHelper.HashPassword(password);
                }
                // Jika password tidak diisi, biarkan password lama tetap ada

                SaveToDatabase(user, isUpdate: true);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in Update: {ex.Message}");
                return false;
            }
        }

        // Soft delete (set IsActive = false)
        public bool Delete(int userId)
        {
            var user = GetById(userId);
            if (user == null)
                return false;

            // Proteksi: admin utama (ID 1) atau username "admin" tidak boleh dihapus
            if (user.UserId == 1 || user.Username.Equals("admin", StringComparison.OrdinalIgnoreCase))
                return false;

            try
            {
                user.IsActive = false;
                SaveToDatabase(user, isUpdate: true);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in Delete: {ex.Message}");
                return false;
            }
        }

        // ===================== QUERIES =====================
        public List<User> GetAllActive()
        {
            return _usersCache.FindAll(u => u.IsActive);
        }

        public List<User> GetAll()
        {
            return _usersCache;
        }

        public User GetById(int userId)
        {
            return _usersCache.Find(u => u.UserId == userId);
        }

        public User GetByUsername(string username)
        {
            return _usersCache.Find(u => u.Username == username);
        }

        public bool IsUsernameExists(string username, int excludeUserId = -1)
        {
            return _usersCache.Exists(u => u.Username == username && u.UserId != excludeUserId);
        }

        // ===================== LOGIN =====================
        public (User user, int roleId)? Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return null;

            var user = GetByUsername(username);
            if (user == null || !user.IsActive)
                return null;

            if (PasswordHelper.VerifyPassword(password, user.Password))
            {
                return (user, user.Role);
            }

            return null;
        }

        // ===================== ADDITIONAL HELPERS =====================
        public string GetUserRoleName(int userId)
        {
            var user = GetById(userId);
            if (user == null) return "Unknown";
            return _roleService.GetRoleName(user.Role);
        }

        public bool IsValidRole(int roleId)
        {
            return _roleService.RoleExists(roleId);
        }
    }
}
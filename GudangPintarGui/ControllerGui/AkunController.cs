using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GudangPintarGui.ControllerGui;
using GudangPintarGui.Models;
using GudangPintarGui.ServiceGUI;

namespace GudangPintarGui.ControllerGui
{
    public class AkunController
    {
        private readonly UserService _userService;
        private readonly IRoleService _roleService; // gunakan interface

        public AkunController(UserService userService)
        {
            _userService = userService;
            _roleService = new RoleService(); // dari ServiceGUI
        }

        public List<User> GetAllUsers() => _userService.GetAll();

        public User GetUserById(int id) => _userService.GetById(id);

        public bool CreateUser(string name, string username, string password, int roleId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                    throw new ArgumentException("Nama tidak boleh kosong!");
                if (string.IsNullOrWhiteSpace(username))
                    throw new ArgumentException("Username tidak boleh kosong!");
                if (string.IsNullOrWhiteSpace(password))
                    throw new ArgumentException("Password tidak boleh kosong!");

                // Validasi password berdasarkan role
                if (!ValidatePasswordByRole(password, roleId))
                {
                    string msg = roleId == RoleService.ROLE_ADMIN
                        ? "Password Admin minimal 8 karakter, harus ada huruf besar dan angka!"
                        : "Password Pegawai minimal 6 karakter!";
                    throw new ArgumentException(msg);
                }

                if (!_roleService.RoleExists(roleId))
                    throw new ArgumentException("Role tidak valid!");

                // Factory pattern
                var newUser = UserFactory.CreateNewUser(name, username, password, roleId);

                return _userService.Add(name, username, password, roleId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public bool UpdateUser(int userId, string name, string username, string password, int roleId)
        {
            try
            {
                var existing = _userService.GetById(userId);
                if (existing == null)
                    throw new ArgumentException("User tidak ditemukan!");

                return _userService.Update(userId, name, username, password, roleId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Update Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public bool DeleteUser(int userId)
        {
            var user = _userService.GetById(userId);
            if (user == null)
            {
                MessageBox.Show("User tidak ditemukan!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Cegah hapus admin utama (ID 1 atau username admin)
            if (user.UserId == 1 || user.Username.Equals("admin", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Tidak dapat menghapus akun admin utama!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return _userService.Delete(userId);
        }

        public bool HasPermission(int roleId, string permission)
        {
            // Gunakan permission dari RoleService database jika ada, atau fallback ke dictionary
            // Untuk sementara, kita buat method sederhana
            if (roleId == RoleService.ROLE_ADMIN)
                return true;
            if (roleId == RoleService.ROLE_PEGAWAI)
                return permission == "lihat_barang" || permission == "lihat_history";
            return false;
        }

        private bool ValidatePasswordByRole(string password, int roleId)
        {
            if (roleId == RoleService.ROLE_ADMIN)
                return password.Length >= 8 && password.Any(char.IsUpper) && password.Any(char.IsDigit);
            else
                return password.Length >= 6;
        }

        public void LoadUsersToGrid(DataGridView dgv)
        {
            var users = _userService.GetAll(); // sudah termasuk semua user (aktif & nonaktif)
            dgv.DataSource = null;
            dgv.DataSource = users;

            if (dgv.Columns.Contains("UserId"))
                dgv.Columns["UserId"].HeaderText = "ID";
            if (dgv.Columns.Contains("Name"))
                dgv.Columns["Name"].HeaderText = "Nama";
            if (dgv.Columns.Contains("Username"))
                dgv.Columns["Username"].HeaderText = "Username";
            if (dgv.Columns.Contains("Role"))
                dgv.Columns["Role"].HeaderText = "Role";
            if (dgv.Columns.Contains("IsActive"))
                dgv.Columns["IsActive"].Visible = false;
            if (dgv.Columns.Contains("Password"))
                dgv.Columns["Password"].Visible = false;
            if (dgv.Columns.Contains("CreatedAt"))
                dgv.Columns["CreatedAt"].Visible = false;
            if (dgv.Columns.Contains("UpdatedAt"))
                dgv.Columns["UpdatedAt"].Visible = false;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
        }
    }
}
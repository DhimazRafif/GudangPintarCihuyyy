using GudangPintarGui.ConfigDatabase;
using GudangPintarGui.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace GudangPintarGui.ServiceGUI
{
    public class RoleService : IRoleService
    {
        private readonly DBConnection _dbConnection;
        private List<Role> _rolesCache;

        // Constants untuk menghindari magic number (Clean Code)
        public const int ROLE_ADMIN = 1;
        public const int ROLE_PEGAWAI = 2;

        public RoleService()
        {
            _dbConnection = DBConnection.GetInstance();
            _rolesCache = new List<Role>();
            LoadRoles();
        }

        // Load semua role dari database ke cache (DRY Principle)
        private void LoadRoles()
        {
            _rolesCache.Clear();
            const string query = "SELECT roleid, name FROM role WHERE isActive = 1";

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
                            _rolesCache.Add(new Role
                            {
                                RoleId = reader.GetInt32("roleid"),
                                Name = reader.GetString("name")
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading roles: {ex.Message}");
                // Fallback ke default roles jika database error
                LoadDefaultRoles();
            }
        }

        // Fallback default roles (Design by Contract - defensive programming)
        private void LoadDefaultRoles()
        {
            _rolesCache.Clear();
            _rolesCache.Add(new Role { RoleId = ROLE_ADMIN, Name = "Admin" });
            _rolesCache.Add(new Role { RoleId = ROLE_PEGAWAI, Name = "Pegawai" });
        }

        public List<Role> GetAllRoles()
        {
            return _rolesCache.ToList();
        }

        public Role GetRoleById(int roleId)
        {
            // Design by Contract: Precondition
            Debug.Assert(roleId > 0, "RoleId harus positif");

            return _rolesCache.FirstOrDefault(r => r.RoleId == roleId);
        }

        public string GetRoleName(int roleId)
        {
            var role = GetRoleById(roleId);
            return role?.Name ?? "Unknown";
        }

        public bool RoleExists(int roleId)
        {
            return _rolesCache.Any(r => r.RoleId == roleId);
        }

        public int GetDefaultRoleId()
        {
            return ROLE_PEGAWAI; // Default role untuk user baru adalah Pegawai
        }
    }
}
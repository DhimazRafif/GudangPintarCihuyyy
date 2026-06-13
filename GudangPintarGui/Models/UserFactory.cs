using System;
using System.Diagnostics;
using GudangPintarGui.Models;

namespace GudangPintarGui.Models
{
    /// <summary>
    /// Factory pattern untuk membuat User berdasarkan role.
    /// Memisahkan logika pembuatan user Admin dan Pegawai.
    /// </summary>
    public static class UserFactory
    {
        public const int ROLE_ADMIN = 1;
        public const int ROLE_PEGAWAI = 2;

        public static User CreateUser(int userId, string name, string username, string password, int role, bool isActive = true)
        {
            // Design by Contract: Precondition
            Debug.Assert(!string.IsNullOrWhiteSpace(name), "Nama tidak boleh kosong");
            Debug.Assert(!string.IsNullOrWhiteSpace(username), "Username tidak boleh kosong");
            Debug.Assert(role == ROLE_ADMIN || role == ROLE_PEGAWAI, "Role tidak valid");

            var user = new User
            {
                UserId = userId,
                Name = name,
                Username = username,
                Password = password,
                Role = role,
                IsActive = isActive,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            // Set properti tambahan berdasarkan role (jika diperlukan)
            if (role == ROLE_ADMIN)
            {
                user.RoleUser = "Admin";
            }
            else if (role == ROLE_PEGAWAI)
            {
                user.RoleUser = "Pegawai";
            }

            return user;
        }

        // Overload untuk membuat user baru (tanpa ID)
        public static User CreateNewUser(string name, string username, string password, int role, bool isActive = true)
        {
            return CreateUser(0, name, username, password, role, isActive);
        }
    }
}
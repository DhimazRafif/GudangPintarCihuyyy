<<<<<<< HEAD

﻿using GudangPintarKPL.Models;
using System.Diagnostics;
using System;
=======
﻿using GudangPintarGui.ServiceGUI;
using System;
using System.Diagnostics;
>>>>>>> b0efac4adebeb458b52d3afe22d7479eb22ab63d

namespace GudangPintarGui.Models
{
    [TableHeader("ID", "Nama", "Username", "Role", "Status")]
    public class User : ITablePrint
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
<<<<<<< HEAD
        public string Password { get; set; }  // Store as SHA256 hash
        public int Role { get; set; }
        public string RoleUser {  get; set; } // Penyimpanan data nama berdasarkan foreign key role
=======
        public string Password { get; set; }
        public int Role { get; set; }
>>>>>>> b0efac4adebeb458b52d3afe22d7479eb22ab63d
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Design by Contract: Constructor dengan validasi
        public User(int userId, string name, string username, string password, int role, bool isActive = true)
        {
            // Design by Contract: Precondition checks
            Debug.Assert(userId >= 0, "UserId tidak boleh negatif");
            Debug.Assert(!string.IsNullOrWhiteSpace(name), "Nama tidak boleh kosong");
            Debug.Assert(!string.IsNullOrWhiteSpace(username), "Username tidak boleh kosong");
            Debug.Assert(!string.IsNullOrWhiteSpace(password), "Password tidak boleh kosong");
            Debug.Assert(role == 1 || role == 2, "Role harus 1 (Admin) atau 2 (Pegawai)");

            UserId = userId;
            Name = name;
            Username = username;
            Password = password;
            Role = role;
            IsActive = isActive;
        }

        // Default constructor untuk GUI binding
        public User() { }

<<<<<<< Updated upstream
<<<<<<< HEAD
        public string[] getRowData() => new[] {

=======
        public string[] GetRowData() => new[] {
>>>>>>> b0efac4adebeb458b52d3afe22d7479eb22ab63d
=======
        public string[] GetRowData() => new[] {
>>>>>>> Stashed changes
            UserId.ToString(),
            Name,
            Username,
            Role == 1 ? "Admin" : "Pegawai",
            IsActive ? "Aktif" : "Nonaktif"
        };

<<<<<<< Updated upstream
<<<<<<< HEAD
        public static string[] getHeader() => new[] { "ID", "Nama", "Username", "Role", "Status" };
=======
        // Implementasi GetHeader() dari ITablePrint — sumber kebenaran tunggal via TableHeaderAttribute
        public string[] GetHeader()
        {
            var attr = (TableHeaderAttribute)Attribute.GetCustomAttribute(typeof(User), typeof(TableHeaderAttribute));
            return attr?.Headers ?? new[] { "ID", "Nama", "Username", "Role", "Status" };
        }

        public string RoleName => Role == RoleService.ROLE_ADMIN ? "Admin" : "Pegawai";
        public string StatusText => IsActive ? "Aktif" : "Nonaktif";
>>>>>>> b0efac4adebeb458b52d3afe22d7479eb22ab63d
=======
        public string[] GetHeader() => new[] { "ID", "Nama", "Username", "Role", "Status" };
>>>>>>> Stashed changes
    }
}
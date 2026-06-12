using GudangPintarGui.ServiceGUI;
using System;
using System.Diagnostics;

namespace GudangPintarGui.Models
{
    [TableHeader("ID", "Nama", "Username", "Role", "Status")]
    public class User : ITablePrint
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
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

        public string[] GetRowData() => new[] {
            UserId.ToString(),
            Name,
            Username,
            Role == 1 ? "Admin" : "Pegawai",
            IsActive ? "Aktif" : "Nonaktif"
        };

        // Implementasi GetHeader() dari ITablePrint — sumber kebenaran tunggal via TableHeaderAttribute
        public string[] GetHeader()
        {
            var attr = (TableHeaderAttribute)Attribute.GetCustomAttribute(typeof(User), typeof(TableHeaderAttribute));
            return attr?.Headers ?? new[] { "ID", "Nama", "Username", "Role", "Status" };
        }

        public string RoleName => Role == RoleService.ROLE_ADMIN ? "Admin" : "Pegawai";
        public string StatusText => IsActive ? "Aktif" : "Nonaktif";
    }
}
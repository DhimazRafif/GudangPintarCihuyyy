using GudangPintarKPL.Models;
using System.Diagnostics;
using System;

namespace GudangPintarGui.Models
{
    [TableHeader("ID", "Nama", "Username", "Role", "Status")]
    public class User : ITablePrint
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }  // Store as SHA256 hash
        public int Role { get; set; }
        public string RoleUser { get; set; } // Penyimpanan data nama berdasarkan foreign key role
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

        public string[] GetRowData()
        {
            return new[] {
            UserId.ToString(),
            Name,
            Username,
            Role == 1 ? "Admin" : "Pegawai",
            IsActive ? "Aktif" : "Nonaktif"
        };
        }

        public string[] GetHeader()
        {
            return new[] { "ID", "Nama", "Username", "Role", "Status" };
        }
    }
}
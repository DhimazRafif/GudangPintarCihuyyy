using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GudangPintarKPL.Models
{
    [TableHeader("ID", "Username", "Email", "Role")]
    public class User : ITablePrint
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public Role RoleUser { get; set; }


        //Constructor default (untuk testing dan object initializer)
        public User() { }

        public User(int id, string username, string email, Role role)
        {
            Id = id;
            Username = username;
            Email = email;
            RoleUser = role;
        }

        // Menthod untuk bagian testing
        public static string[] getHeader()
        {
            return new[] { "ID", "Username", "Email", "Role" };
        }


        public string[] getRowData() => new[] { Id.ToString(), Username, Email,RoleUser.ToString()};
    }
}

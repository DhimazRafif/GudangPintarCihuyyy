using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace GudangPintarKPL.Models
{
    public class User : ITablePrint
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public Role RoleUser { get; set; }

        public static string[] getHeader() => 
            new[] {"ID", "Username", "Email", "Role"};

        public string[] getRowData() => new[] { Id.ToString(), Username, Email,RoleUser.ToString()};


    }
}

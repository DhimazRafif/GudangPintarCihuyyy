<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
=======
<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Identity;
using System;
=======
﻿using System;
>>>>>>> main
using System.Collections.Generic;
>>>>>>> 0befa517fd67ab1b05564b2334ef1276f04c4a37
using System.Text;

namespace GudangPintarKPL.Models
{
<<<<<<< HEAD
    [TableHeader("ID", "Username", "Email", "Role")]
    public class User : ITablePrint
=======
<<<<<<< HEAD
    public class User : ITablePrint
=======
    public class User
>>>>>>> main
>>>>>>> 0befa517fd67ab1b05564b2334ef1276f04c4a37
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
<<<<<<< HEAD
        public string Password { get; set; }
        public Role RoleUser { get; set; }


        //Constructor default (untuk testing dan object initializer)
        public User() { }

        public User(int id, string username,string password, string email, Role role)
        {
            Id = id;
            Username = username;
            Password = password;
            Email = email;
            RoleUser = role;
        }

        // Menthod untuk bagian testing
   
        public string[] getRowData() => new[] { Id.ToString(), Username, Email,RoleUser.ToString()};
=======
<<<<<<< HEAD
        public Role RoleUser { get; set; }

        public static string[] getHeader() => 
            new[] {"ID", "Username", "Email", "Role"};

        public string[] getRowData() => new[] { Id.ToString(), Username, Email,RoleUser.ToString()};
=======
>>>>>>> main
>>>>>>> 0befa517fd67ab1b05564b2334ef1276f04c4a37
    }
}

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Identity;
using System;
=======
﻿using System;
>>>>>>> main
=======
﻿using System;
>>>>>>> 0befa517fd67ab1b05564b2334ef1276f04c4a37
using System.Collections.Generic;
=======
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
>>>>>>> a8b62e2d6144355e4b71cb7d24b87ec53897866e
using System.Text;

namespace GudangPintarKPL.Models
{
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    public class User : ITablePrint
=======
    public class User
>>>>>>> main
=======
    public class User
>>>>>>> 0befa517fd67ab1b05564b2334ef1276f04c4a37
=======
    [TableHeader("ID", "Username", "Email", "Role")]
    public class User : ITablePrint
>>>>>>> a8b62e2d6144355e4b71cb7d24b87ec53897866e
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        public Role RoleUser { get; set; }

        public static string[] getHeader() => 
            new[] {"ID", "Username", "Email", "Role"};

        public string[] getRowData() => new[] { Id.ToString(), Username, Email,RoleUser.ToString()};
=======
>>>>>>> main
=======
>>>>>>> 0befa517fd67ab1b05564b2334ef1276f04c4a37
=======
        public string Password { get; set; }
        public Role RoleUser { get; set; }


        //Constructor default (untuk testing dan object initializer)
        public User() { }

        public User(int id, string username, string password, string email, Role role)
        {
            Id = id;
            Username = username;
            Password = password;
            Email = email;
            RoleUser = role;
        }

        // Menthod untuk bagian testing

        public string[] getRowData() => new[] { Id.ToString(), Username, Email, RoleUser.ToString() };
>>>>>>> a8b62e2d6144355e4b71cb7d24b87ec53897866e
    }
}

<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Identity;
using System;
=======
﻿using System;
>>>>>>> main
using System.Collections.Generic;
using System.Text;

namespace GudangPintarKPL.Models
{
<<<<<<< HEAD
    public class User : ITablePrint
=======
    public class User
>>>>>>> main
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
<<<<<<< HEAD
        public Role RoleUser { get; set; }

        public static string[] getHeader() => 
            new[] {"ID", "Username", "Email", "Role"};

        public string[] getRowData() => new[] { Id.ToString(), Username, Email,RoleUser.ToString()};
=======
>>>>>>> main
    }
}

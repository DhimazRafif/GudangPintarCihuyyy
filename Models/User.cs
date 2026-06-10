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
using System.Text;

namespace GudangPintarKPL.Models
{
<<<<<<< HEAD
<<<<<<< HEAD
    public class User : ITablePrint
=======
    public class User
>>>>>>> main
=======
    public class User
>>>>>>> 0befa517fd67ab1b05564b2334ef1276f04c4a37
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
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
    }
}

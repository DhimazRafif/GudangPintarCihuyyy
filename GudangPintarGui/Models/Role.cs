using GudangPintarKPL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GudangPintarGui.Models
{
<<<<<<< Updated upstream
<<<<<<< HEAD
    internal class Role
    {
        public int roleid {  get; set; }
        public string name { get; set; }
=======
        public class Role
        {
            public int RoleId {  get; set; } 
            public string Name { get; set; } = string.Empty;
>>>>>>> Stashed changes

            public const int ADMIN = 1;
            public const int PEDAWAI = 2;

            //Contructor default
            public Role() { }
            public Role(int roleId, string name)
            {
                RoleId = roleId;
                Name = name;
            }

        }
    }
<<<<<<< Updated upstream
}

=======
    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; }

        // Konstanta dipusatkan di RoleService.ROLE_ADMIN dan RoleService.ROLE_PEGAWAI
        // untuk menghindari duplikasi definisi (DRY Principle)
    }
}

>>>>>>> b0efac4adebeb458b52d3afe22d7479eb22ab63d
=======
>>>>>>> Stashed changes

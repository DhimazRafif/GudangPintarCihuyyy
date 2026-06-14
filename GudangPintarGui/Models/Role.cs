using GudangPintarKPL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GudangPintarGui.Models
{
        public class Role
        {
            public int RoleId {  get; set; } 
            public string Name { get; set; } = string.Empty;


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
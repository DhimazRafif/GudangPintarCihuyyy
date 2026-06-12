using System;
using System.Collections.Generic;
using System.Text;

namespace GudangPintarGui.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; }

        // Konstanta dipusatkan di RoleService.ROLE_ADMIN dan RoleService.ROLE_PEGAWAI
        // untuk menghindari duplikasi definisi (DRY Principle)
    }
}


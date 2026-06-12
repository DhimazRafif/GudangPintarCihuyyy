using System;
using System.Collections.Generic;
using System.Text;

namespace GudangPintarGui.Models
{
    internal class Role
    {
        public int roleid {  get; set; }
        public string name { get; set; }

        public const int ADMIN = 1;
        public const int PEDAWAI = 2;

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace GudangPintarGui.Models
{
    public class Barang
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public string Category {  get; set; }
        public double Harga { get; set; }
        public int Jumlah { get; set; }
    }
}

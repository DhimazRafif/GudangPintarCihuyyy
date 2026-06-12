using GudangPintarKPL.Models;
using System;

namespace GudangPintar.Model
{
<<<<<<< HEAD
=======
    [TableHeader("Tanggal ubah", "Nama Barang", "Aksi", "Jumlah", "User")]
>>>>>>> a8b62e2d6144355e4b71cb7d24b87ec53897866e
    public class StockHistory : ITablePrint
    {
        public string NamaBarang { get; set; }
        public string Aksi { get; set; }
        public int Jumlah { get; set; }
        public string UserPelaku { get; set; }
        public DateTime Tanggal { get; set; }

        public StockHistory(string namaBarang, string aksi, int jumlah, string user)
        {
            NamaBarang = namaBarang;
            Aksi = aksi;
            Jumlah = jumlah;
            UserPelaku = user;
            Tanggal = DateTime.Now;
        }

<<<<<<< HEAD
=======
        public StockHistory(string nama, string aksi, int jumlah, string pengguna, DateTime tanggal)
        {
            NamaBarang = nama;
            Aksi = aksi;
            Jumlah = jumlah;
            UserPelaku = pengguna;
            Tanggal = tanggal;
        }

>>>>>>> a8b62e2d6144355e4b71cb7d24b87ec53897866e
        public void Tampilkan()
        {
            Console.WriteLine($"{Tanggal} | {NamaBarang} | {Aksi} {Jumlah} | Oleh: {UserPelaku}");
        }

<<<<<<< HEAD
        public static string[] getHeader() => 
            new[] { "Waktu", "Barang", "Aksi", "Jumlah", "User"};

=======
        //Method untuk bagian Testing 
>>>>>>> a8b62e2d6144355e4b71cb7d24b87ec53897866e
        public string[] getRowData() => new[]{
            Tanggal.ToString("dd/MM/yyyy HH:mm"),
            NamaBarang,
            Aksi,
            Jumlah.ToString(),
            UserPelaku
        };
    }
}

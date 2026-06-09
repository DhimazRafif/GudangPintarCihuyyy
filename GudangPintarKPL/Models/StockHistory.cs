using GudangPintarKPL.Models;
using System;

namespace GudangPintar.Model
{
<<<<<<< HEAD
    [TableHeader("Tanggal ubah", "Nama Barang", "Aksi", "Jumlah", "User")]
=======
>>>>>>> 0befa517fd67ab1b05564b2334ef1276f04c4a37
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
        public StockHistory(string nama, string aksi, int jumlah, string pengguna, DateTime tanggal)
        {
            NamaBarang = nama;
            Aksi = aksi;
            Jumlah = jumlah;
            UserPelaku = pengguna;
            Tanggal = tanggal;
        }

=======
>>>>>>> 0befa517fd67ab1b05564b2334ef1276f04c4a37
        public void Tampilkan()
        {
            Console.WriteLine($"{Tanggal} | {NamaBarang} | {Aksi} {Jumlah} | Oleh: {UserPelaku}");
        }

<<<<<<< HEAD
        //Method untuk bagian Testing 
=======
        public static string[] getHeader() => 
            new[] { "Waktu", "Barang", "Aksi", "Jumlah", "User"};

>>>>>>> 0befa517fd67ab1b05564b2334ef1276f04c4a37
        public string[] getRowData() => new[]{
            Tanggal.ToString("dd/MM/yyyy HH:mm"),
            NamaBarang,
            Aksi,
            Jumlah.ToString(),
            UserPelaku
        };
    }
}

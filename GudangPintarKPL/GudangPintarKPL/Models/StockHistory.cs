using GudangPintarKPL.Models;
using System;

namespace GudangPintar.Model
{
    [TableHeader("Tanggal ubah", "Nama Barang", "Aksi", "Jumlah", "User")]
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

        public StockHistory(string nama, string aksi, int jumlah, string pengguna, DateTime tanggal)
        {
            NamaBarang = nama;
            Aksi = aksi;
            Jumlah = jumlah;
            UserPelaku = pengguna;
            Tanggal = tanggal;
        }

        public void Tampilkan()
        {
            Console.WriteLine($"{Tanggal} | {NamaBarang} | {Aksi} {Jumlah} | Oleh: {UserPelaku}");
        }

        //Method untuk bagian Testing 
        public string[] getRowData() => new[]{
            Tanggal.ToString("dd/MM/yyyy HH:mm"),
            NamaBarang,
            Aksi,
            Jumlah.ToString(),
            UserPelaku
        };
    }
}

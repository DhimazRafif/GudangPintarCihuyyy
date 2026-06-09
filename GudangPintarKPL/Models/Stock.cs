using GudangPintarKPL.Models;
<<<<<<< HEAD
using System.Diagnostics;
=======
>>>>>>> 0befa517fd67ab1b05564b2334ef1276f04c4a37
using System;
using System.Collections.Generic;
using System.Text;

namespace GudangPintar.Model
{
<<<<<<< HEAD
    [TableHeader("Nama", "Kategori", "Jumlah", "Harga", "Status")]
    public class Stock : ITablePrint
    {
        public int Id {  get; set; }
        public string NamaBarang { get; set; }
        public string Kategori { get; set; }
        public int Jumlah { get; set; }
        public double Harga { get; set; }

        public Stock(int id, string nama, string kategori, double harga, int jumlah)
        {
            Id = id;
            NamaBarang = nama;
            Kategori = kategori;
            Harga = harga;
            Jumlah = jumlah;
        }

        public Stock( string nama, Category kategori, int jumlah, double harga)
        {
            Debug.Assert(jumlah >= 0, "Jumlah stok tidak boleh negatif");
            Debug.Assert(harga >= 0, "Harga tidak boleh negatif");
            int Id = 0;
            NamaBarang = nama;
            this.Kategori = kategori.ToString();
=======
    public class Stock : ITablePrint
    {
        public string NamaBarang { get; set; }
        public Category Kategori { get; set; }
        public int Jumlah { get; set; }
        public double Harga { get; set; }

        public Stock(string nama, Category kategori, int jumlah, double harga)
        {
            NamaBarang = nama;
            Kategori = kategori;
>>>>>>> 0befa517fd67ab1b05564b2334ef1276f04c4a37
            Jumlah = jumlah;
            Harga = harga;
        }

        public void TambahStok(int jumlah)
        {
            Jumlah += jumlah;
        }

        public void KurangiStok(int jumlah)
        {
            if (Jumlah >= jumlah)
                Jumlah -= jumlah;
            else
                Console.WriteLine("Stok tidak cukup!");
        }

        public void EditStock(string nama, Category kategori, double harga)
        {
            NamaBarang = nama;
<<<<<<< HEAD
            Kategori = kategori.ToString();
            Harga = harga;
        }
        public string[] getRowData()
        {

            var cfg = GudangConfig.LoadConfigFile();
            string hargaFormatted = string.Format(cfg.format_harga, Harga);


            // Status sekarang dihasilkan oleh StockAlertStatus (diakses melalui Notification)
            string status = Notification.GetNotifikasi(this);

            return new[] {
                NamaBarang,
                Kategori.ToString(),
                Jumlah.ToString(),
                hargaFormatted,
                status
            };
        }
    }
}
=======
            Kategori = kategori;
            Harga = harga;
        }

        public static string[] getHeader() => 
            new[] { "Nama", "Kategori", "Jumlah", "Harga", "Status"};

        public string[] getRowData() {

            string hargaFormatted = string.Format(GudangConfig.LoadConfigFile().format_harga, Harga);

            return new[] { NamaBarang, 
                Kategori.ToString(), 
                Jumlah.ToString(), 
                hargaFormatted, 
                Notification.GetNotifikasi(this) };
        }
    }
}
>>>>>>> 0befa517fd67ab1b05564b2334ef1276f04c4a37

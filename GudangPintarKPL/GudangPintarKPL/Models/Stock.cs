using GudangPintarKPL.Models;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GudangPintar.Model
{
    [TableHeader("Nama", "Kategori", "Jumlah", "Harga","Kadaluarsa", "Status")]
    public class Stock : ITablePrint
    {
        public string NamaBarang { get; set; }
        public Category Kategori { get; set; }
        public int Jumlah { get; set; }
        public double Harga { get; set; }
        public DateTime? Kadaluarsa { get; set; }

        public Stock(string nama, Category kategori, int jumlah, double harga, DateTime? kadaluarsa)
        {
            Debug.Assert(jumlah >= 0, "Jumlah stok tidak boleh negatif");
            Debug.Assert(harga >= 0, "Harga tidak boleh negatif");

            NamaBarang = nama;
            Kategori = kategori;
            Jumlah = jumlah;
            Harga = harga;
            Kadaluarsa = kadaluarsa;
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

        public void EditStock(string nama, Category kategori, double harga, DateTime? kadaluarsa)
        {
            NamaBarang = nama;
            Kategori = kategori;
            Harga = harga;
            Kadaluarsa = kadaluarsa;
        }
        public string[] getRowData()
        {

            var cfg = GudangConfig.LoadConfigFile();
            string hargaFormatted = string.Format(cfg.format_harga, Harga);

            string kadaluarsaDisplay = Kadaluarsa.HasValue ? Kadaluarsa.Value.ToString("yyyy-MM-dd") : "-";

            // Status sekarang dihasilkan oleh StockAlertStatus (diakses melalui Notification)
            string status = Notification.GetNotifikasi(this);

            return new[] {
                NamaBarang,
                Kategori.ToString(),
                Jumlah.ToString(),
                hargaFormatted,
                kadaluarsaDisplay,
                status
            };
        }
    }
}
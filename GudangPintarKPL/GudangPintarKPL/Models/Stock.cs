using GudangPintarKPL.Models;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GudangPintar.Model
{
    [TableHeader("Nama", "Kategori", "Jumlah", "Harga", "Status")]
    public class Stock : ITablePrint
    {
        public string NamaBarang { get; set; }
        public Category Kategori { get; set; }
        public int Jumlah { get; set; }
        public double Harga { get; set; }

        public Stock(string nama, Category kategori, int jumlah, double harga)
        {
            Debug.Assert(jumlah >= 0, "Jumlah stok tidak boleh negatif");
            Debug.Assert(harga >= 0, "Harga tidak boleh negatif");

            NamaBarang = nama;
            Kategori = kategori;
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
            Kategori = kategori;
            Harga = harga;
        }

        //Method untuk bagian Testing
        public static string[] getHeader()
        {
            return new[] { "Nama", "Kategori", "Jumlah", "Harga", "Status" };
        }


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

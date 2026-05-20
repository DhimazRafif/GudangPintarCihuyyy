using GudangPintarKPL.Models;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GudangPintar.Model
{
    public class Stock : ITablePrint
    {
        public string NamaBarang { get; set; }
        public Category Kategori { get; set; }
        public int Jumlah { get; set; }
        public double Harga { get; set; }

        // ngedefinisiin kadaluarsa tidak statis
        public DateTime? TanggalKadaluarsa { get; set; }

        public Stock(string nama, Category kategori, int jumlah, double harga, DateTime? tanggalKadaluarsa = null)
        {
            Debug.Assert(jumlah >= 0, "Jumlah stok tidak boleh negatif");
            Debug.Assert(harga >= 0, "Harga tidak boleh negatif");

            // validasi runtime pake exception
            if (jumlah < 0)
                throw new ArgumentException("Jumlah stok tidak boleh negatif.", nameof(jumlah));
            if (harga < 0)
                throw new ArgumentException("Harga tidak boleh negatif.", nameof(harga));
            if (string.IsNullOrWhiteSpace(nama))
                throw new ArgumentException("Nama barang tidak boleh kosong.", nameof(nama));

            NamaBarang = nama;
            Kategori = kategori;
            Jumlah = jumlah;
            Harga = harga;
            TanggalKadaluarsa = tanggalKadaluarsa;
        }

        // mengecek status kadaluarsa
        public bool IsExpired()
        {
            if (!TanggalKadaluarsa.HasValue) return false;
            return DateTime.Now >= TanggalKadaluarsa.Value;
        }

        public void TambahStok(int jumlah)
        {
            if (jumlah <= 0) throw new ArgumentException("Jumlah yang ditambah harus lebih dari 0.");
            Jumlah += jumlah;
        }

        public void KurangiStok(int jumlah)
        {
            if (jumlah <= 0) throw new ArgumentException("Jumlah yang dikurangi harus lebih dari 0.");

            if (Jumlah >= jumlah)
                Jumlah -= jumlah;
            else
                throw new InvalidOperationException("Stok tidak cukup!");
        }

        public void EditStock(string nama, Category kategori, double harga, DateTime? tanggalKadaluarsa = null)
        {
            if (harga < 0) throw new ArgumentException("Harga tidak boleh negatif.");
            if (string.IsNullOrWhiteSpace(nama)) throw new ArgumentException("Nama barang tidak boleh kosong.");

            NamaBarang = nama;
            Kategori = kategori;
            Harga = harga;
            TanggalKadaluarsa = tanggalKadaluarsa;
        }

        public static string[] getHeader() =>
            new[] { "Nama", "Kategori", "Jumlah", "Harga", "Status Kadaluarsa", "Status" };

        public string[] getRowData()
        {
            // ngatasin jika confignya bernilai null
            var config = GudangConfig.LoadConfigFile();
            string formatHarga = config != null ? config.format_harga : "{0:C}";
            string hargaFormatted = string.Format(formatHarga, Harga);

            // nentuin status kadaluarsa
            string statusKadaluarsa = TanggalKadaluarsa.HasValue
                ? (IsExpired() ? "KADALUARSA" : TanggalKadaluarsa.Value.ToString("yyyy-MM-dd"))
                : "Tidak Ada";

            // return data dalam bentuk array string sesuai dengan header
            return new[] {
                NamaBarang,
                Kategori.ToString(),
                Jumlah.ToString(),
                hargaFormatted,
                statusKadaluarsa,
                Notification.GetNotifikasi(this)
            };
        }
    }
}
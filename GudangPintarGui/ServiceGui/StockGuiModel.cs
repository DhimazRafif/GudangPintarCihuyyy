using System;
using System.Diagnostics;
using GudangPintar.Model;

namespace GudangPintarGui.Models
{
    // Model khusus untuk keperluan GUI yang mewarisi dari model
    public class StockGuiModel : Stock
    {
        // Properti tambahan untuk keperluan UI dan pemetaan database
        public int BarangId { get; set; }
        public int CategoryId { get; set; }
        public int NotificationThreshold { get; set; }
        public bool IsActive { get; set; }

        // Konstruktor default untuk keperluan deserialisasi atau inisialisasi awal.
        public StockGuiModel() : base(string.Empty, Category.ATK, 0, 0)
        {
            IsActive = true;
        }

        // Konstruktor utama untuk keperluan tambah data (tanpa BarangId).
        public StockGuiModel(string nama, int categoryId, int jumlah, double harga, int threshold)
            : base(nama, Category.ATK, jumlah, harga)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(nama), "Nama barang tidak boleh kosong!");
            Debug.Assert(categoryId > 0, "ID Kategori tidak valid!");
            Debug.Assert(jumlah >= 0, "Jumlah tidak boleh negatif!");
            Debug.Assert(harga >= 0, "Harga tidak boleh negatif!");
            Debug.Assert(threshold >= 0, "Threshold tidak boleh negatif!");

            CategoryId = categoryId;
            NotificationThreshold = threshold;
            IsActive = true;
        }

        // Konstruktor tambahan untuk keperluan edit data (dengan BarangId).
        public StockGuiModel(int barangId, string nama, int categoryId, int jumlah, double harga, int threshold)
            : this(nama, categoryId, jumlah, harga, threshold)
        {
            Debug.Assert(barangId > 0, "ID Barang tidak valid!");
            BarangId = barangId;
        }
    }
}
using System;
using System.Diagnostics;
using GudangPintar.Model;

namespace GudangPintarGui.ServiceGui
{
    public class StockGuiModel : Stock
    {
        // ini untuk menambahkan properti tambahan yang diperlukan untuk tampilan GUI, seperti ID barang, ID kategori, threshold notifikasi, dan status aktif
        public int BarangId { get; set; }
        public int CategoryId { get; set; }
        public int NotificationThreshold { get; set; }
        public bool IsActive { get; set; } 

        public StockGuiModel() : base(string.Empty, Category.ATK, 0, 0)
        {
            IsActive = true;
        }

        // ini untuk memastikan data yang diterima valid sejak awal
        public StockGuiModel(string nama, int categoryId, int jumlah, double harga, int threshold)
            : base(nama, Category.ATK, jumlah, harga)
        {
            // Design by Contract: Memastikan data valid sejak lahir
            Debug.Assert(!string.IsNullOrWhiteSpace(nama), "Nama barang tidak boleh kosong!");
            Debug.Assert(categoryId > 0, "ID Kategori tidak valid!");
            Debug.Assert(jumlah >= 0, "Jumlah tidak boleh negatif!");
            Debug.Assert(harga >= 0, "Harga tidak boleh negatif!");
            Debug.Assert(threshold >= 0, "Threshold tidak boleh negatif!");

            CategoryId = categoryId;
            NotificationThreshold = threshold;
            IsActive = true;
        }
    }
}
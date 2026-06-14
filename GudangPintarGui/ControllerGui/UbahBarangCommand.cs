using System;
using MySql.Data.MySqlClient;
using GudangPintarGui.ConfigDatabase;

namespace GudangPintarGui.ControllerGui
{
    // Command ini untuk menangani logika pembaruan data barang yang sudah ada di database, termasuk validasi input dan penanganan error yang lebih baik
    public class UbahBarangCommand : ICommand
    {
        private readonly int _barangId;
        private readonly string _namaBaru;
        private readonly int _categoryId;
        private readonly double _harga;
        private readonly int _threshold;

        // ini agar konstruktor command menerima data yang diperlukan untuk pembaruan barang, termasuk validasi input awal untuk memastikan data yang diterima valid sebelum mencoba menyimpan ke database
        public UbahBarangCommand(int barangId, string namaBaru, int categoryId, double harga, int threshold)
        {
            if (barangId <= 0)
                throw new ArgumentException("Kontrak Gagal: ID Barang tidak valid!");
            if (string.IsNullOrWhiteSpace(namaBaru))
                throw new ArgumentException("Kontrak Gagal: Nama barang tidak boleh kosong!");
            if (categoryId <= 0)
                throw new ArgumentException("Kontrak Gagal: ID Kategori harus valid!");
            if (harga < 0)
                throw new ArgumentException("Kontrak Gagal: Harga tidak boleh negatif!");
            if (threshold < 0)
                throw new ArgumentException("Kontrak Gagal: Threshold tidak boleh negatif!");

            _barangId = barangId;
            _namaBaru = namaBaru;
            _categoryId = categoryId;
            _harga = harga;
            _threshold = threshold;
        }

        public bool Execute(out string message)
        {
            // // query yang diperbarui untuk memastikan hanya barang yang aktif yang dapat diperbarui, dan menambahkan penanganan error yang lebih spesifik 
            string query = @"UPDATE barang 
                             SET name = @namaBaru, 
                                 categoryid = @categoryId, 
                                 price = @price, 
                                 notification_threshold = @threshold 
                             WHERE barangid = @barangId AND isActive = 1";

            try
            {
                using (MySqlConnection conn = DBConnection.GetInstance().GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@namaBaru", MySqlDbType.VarChar).Value = _namaBaru;
                        cmd.Parameters.Add("@categoryId", MySqlDbType.Int32).Value = _categoryId;
                        cmd.Parameters.Add("@price", MySqlDbType.Double).Value = _harga;
                        cmd.Parameters.Add("@threshold", MySqlDbType.Int32).Value = _threshold;
                        cmd.Parameters.Add("@barangId", MySqlDbType.Int32).Value = _barangId;

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            message = "Data master barang berhasil diperbarui.";
                            return true;
                        }
                    }
                }
            }
            // penanganan error yang lebih spesifik untuk menangkap kesalahan database dan sistem, memberikan pesan yang lebih informatif kepada pengguna
            catch (MySqlException ex)
            {
                message = $"[Database Error] Gagal memperbarui data: {ex.Message}";
                return false;
            }
            catch (Exception ex)
            {
                message = $"[System Error] Terjadi kesalahan: {ex.Message}";
                return false;
            }

            message = "Gagal memperbarui data. Barang tidak ditemukan atau sudah tidak aktif.";
            return false;
        }
    }
}
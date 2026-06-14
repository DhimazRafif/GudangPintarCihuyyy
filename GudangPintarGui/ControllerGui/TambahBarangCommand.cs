using GudangPintarGui.ConfigDatabase;
using GudangPintarGui.Models;
using GudangPintarGui.ServiceGui;
using MySql.Data.MySqlClient;
using System;

namespace GudangPintarGui.ControllerGui
{
    public class TambahBarangCommand : ICommand
    {
        private readonly StockGuiModel _barangBaru;
        private readonly int _currentUserId;

        // ini untuk menginisialisasi command dengan data barang baru yang akan ditambahkan dan ID pengguna yang melakukan operasi
        public TambahBarangCommand(StockGuiModel barangBaru, int currentUserId)
        {
            _barangBaru = barangBaru ?? throw new ArgumentNullException(nameof(barangBaru), "Data barang tidak boleh null.");
            _currentUserId = currentUserId;
        }

        // ini untuk mengeksekusi logika penambahan barang ke database dengan validasi input dan penanganan error yang lebih baik
        public bool Execute(out string message)
        {
            // ini untuk memastikan bahwa nama barang tidak kosong dan kategori valid sebelum mencoba menyimpan ke database
            if (string.IsNullOrWhiteSpace(_barangBaru.NamaBarang) || _barangBaru.CategoryId <= 0)
            {
                message = "Validasi Gagal: Nama barang dan Kategori wajib diisi.";
                return false;
            }

            string query = @"INSERT INTO barang 
                            (name, quantity, price, notification_threshold, categoryid, isActive, created_by, created_at) 
                            VALUES 
                            (@name, @qty, @price, @threshold, @categoryId, 1, @userId, NOW())";

            try
            {
                using (var conn = DBConnection.GetInstance().GetConnection())
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        // ini untuk menggunakan parameterized query untuk mencegah SQL Injection dan memastikan data tersimpan dengan benar
                        cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = _barangBaru.NamaBarang;
                        cmd.Parameters.Add("@qty", MySqlDbType.Int32).Value = _barangBaru.Jumlah;
                        cmd.Parameters.Add("@price", MySqlDbType.Double).Value = _barangBaru.Harga;
                        cmd.Parameters.Add("@threshold", MySqlDbType.Int32).Value = _barangBaru.NotificationThreshold;
                        cmd.Parameters.Add("@categoryId", MySqlDbType.Int32).Value = _barangBaru.CategoryId;
                        cmd.Parameters.Add("@userId", MySqlDbType.Int32).Value = _currentUserId;

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            message = "Barang berhasil didaftarkan ke sistem.";
                            return true;
                        }
                    }
                }
            }
            // ini untuk menangani error yang mungkin terjadi saat koneksi ke database atau eksekusi query, memberikan pesan yang jelas untuk pengguna
            catch (MySqlException ex)
            {
                message = $"Database Error: {ex.Message}";
                return false;
            }
            catch (Exception ex)
            {
                message = $"System Error: {ex.Message}";
                return false;
            }

            message = "Operasi gagal: Tidak ada data yang tersimpan.";
            return false;
        }
    }
}
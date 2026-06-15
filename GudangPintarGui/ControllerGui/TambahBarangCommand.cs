using GudangPintarGui.ConfigDatabase;
using GudangPintarGui.ControllerGui;
using GudangPintarGui.Models;
using GudangPintarGui.ServiceGui;
using MySql.Data.MySqlClient;
using System;

namespace GudangPintarGui.ControllerGui
{

    // Interface ICommand untuk konsistensi pola Command Pattern
    public class TambahBarangCommand : ICommand
    {
        private readonly StockGuiModel _barang;
        private readonly int _userId;

        public TambahBarangCommand(StockGuiModel barang, int userId)
        {
            // Validasi di konstruktor (Fail-Fast Principle)
            _barang = barang ?? throw new ArgumentNullException(nameof(barang), "Data barang tidak boleh null.");
            if (userId <= 0) throw new ArgumentException("ID User tidak valid.");

            _barang = barang;
            _userId = userId;
        }

        public bool Execute(out string message)
        {
            // Query untuk memasukkan data barang baru dengan audit kolom created_by dan created_at
            string query = @"INSERT INTO barang 
                            (name, quantity, price, notification_threshold, categoryid, isActive, created_by, created_at) 
                            VALUES 
                            (@name, @qty, @price, @threshold, @catId, 1, @userId, NOW())";

            try
            {
                using (var conn = DBConnection.GetInstance().GetConnection())
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        // Parameterisasi untuk mencegah SQL Injection
                        cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = _barang.NamaBarang;
                        cmd.Parameters.Add("@qty", MySqlDbType.Int32).Value = _barang.Jumlah;
                        cmd.Parameters.Add("@price", MySqlDbType.Double).Value = _barang.Harga;
                        cmd.Parameters.Add("@threshold", MySqlDbType.Int32).Value = _barang.NotificationThreshold;
                        cmd.Parameters.Add("@catId", MySqlDbType.Int32).Value = _barang.CategoryId;
                        cmd.Parameters.Add("@userId", MySqlDbType.Int32).Value = _userId;

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            message = "Barang berhasil didaftarkan ke sistem.";
                            return true;
                        }
                        else
                        {
                            message = "Operasi gagal: Tidak ada data yang tersimpan.";
                            return false;
                        }
                    }
                }
            }
            // Penanganan khusus untuk MySQL exceptions untuk memberikan feedback yang lebih informatif
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
        }
    }
}
using System;
using MySql.Data.MySqlClient;
using GudangPintarGui.ConfigDatabase;
using GudangPintarGui.ControllerGui;

namespace GudangPintarGui.ControllerGui
{
    // Command untuk menangani logika perubahan data barang yang sudah ada di database.
    public class UbahBarangCommand : ICommand
    {
        private readonly int _id;
        private readonly string _nama;
        private readonly int _catId;
        private readonly double _harga;
        private readonly int _threshold;

        public UbahBarangCommand(int id, string nama, int catId, double harga, int threshold)
        {
            // Validasi input dasar (Fail-Fast)
            if (id <= 0) throw new ArgumentException("ID Barang tidak valid.");
            if (string.IsNullOrWhiteSpace(nama)) throw new ArgumentException("Nama barang wajib diisi.");

            _id = id;
            _nama = nama;
            _catId = catId;
            _harga = harga;
            _threshold = threshold;
        }

        public bool Execute(out string message)
        {
            // Query untuk memperbarui data barang dengan parameterized query untuk mencegah SQL Injection
            string query = @"UPDATE barang 
                             SET name = @nama, 
                                 categoryid = @cat, 
                                 price = @harga, 
                                 notification_threshold = @t, 
                                 updated_at = NOW() 
                             WHERE barangid = @id AND isActive = 1";

            try
            {
                using (var conn = DBConnection.GetInstance().GetConnection())
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        // Menambahkan parameter dengan tipe data yang sesuai
                        cmd.Parameters.Add("@nama", MySqlDbType.VarChar).Value = _nama;
                        cmd.Parameters.Add("@cat", MySqlDbType.Int32).Value = _catId;
                        cmd.Parameters.Add("@harga", MySqlDbType.Double).Value = _harga;
                        cmd.Parameters.Add("@t", MySqlDbType.Int32).Value = _threshold;
                        cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = _id;

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            message = "Data barang berhasil diperbarui.";
                            return true;
                        }
                        else
                        {
                            message = "Gagal memperbarui: Barang tidak ditemukan atau sudah tidak aktif.";
                            return false;
                        }
                    }
                }
            }
            // Menangani kesalahan database dan sistem secara terpisah untuk memberikan pesan yang lebih spesifik
            catch (MySqlException ex)
            {
                message = $"Database error: {ex.Message}";
                return false;
            }
            catch (Exception ex)
            {
                message = $"System error: {ex.Message}";
                return false;
            }
        }
    }
}
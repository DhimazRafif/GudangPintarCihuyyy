using System;
using MySql.Data.MySqlClient;
using GudangPintarGui.ConfigDatabase;
using GudangPintarGui.ControllerGui;

namespace GudangPintarGui.ControllerGui
{
    // Command untuk melakukan soft delete pada data barang dengan mengubah status isActive menjadi 0.
    public class HapusBarangCommand : ICommand
    {
        private readonly int _barangId;

        // Validasi data di konstruktor (Fail-Fast Principle)
        public HapusBarangCommand(int barangId)
        {
            if (barangId <= 0) throw new ArgumentException("ID Barang tidak valid.");
            _barangId = barangId;
        }

        public bool Execute(out string message)
        {
            // Query untuk melakukan soft delete dengan mengubah isActive menjadi 0
            // Penggunaan parameterized query untuk mencegah SQL Injection (Secure Code)
            string query = "UPDATE barang SET isActive = 0 WHERE barangid = @id AND isActive = 1";

            try
            {
                using (var conn = DBConnection.GetInstance().GetConnection())
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        // Penggunaan tipe data eksplisit (Secure Code)
                        cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = _barangId;

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            message = "Barang berhasil dihapus (diarsipkan) dari sistem.";
                            return true;
                        }
                        else
                        {
                            message = "Gagal menghapus: Barang tidak ditemukan atau sudah tidak aktif.";
                            return false;
                        }
                    }
                }
            }
            // Penanganan kesalahan yang spesifik untuk database dan umum untuk sistem (Robust Error Handling)
            catch (MySqlException ex)
            {
                message = $"Database error saat menghapus data: {ex.Message}";
                return false;
            }
            catch (Exception ex)
            {
                message = $"Terjadi kesalahan sistem: {ex.Message}";
                return false;
            }
        }
    }
}
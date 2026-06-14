using System;
using MySql.Data.MySqlClient;
using GudangPintarGui.ConfigDatabase;

namespace GudangPintarGui.ControllerGui
{
    public class HapusBarangCommand : ICommand
    {
        private readonly int _barangId;

        // ini untuk menginisialisasi command dengan ID barang yang akan dihapus
        public HapusBarangCommand(int barangId)
        {
            _barangId = barangId;
        }

        public bool Execute(out string message)
        {
            // ini untuk melakukan soft delete dengan mengubah status isActive menjadi 0 (tidak aktif)
            string query = "UPDATE barang SET isActive = 0 WHERE barangid = @id AND isActive = 1";

            try
            {
                using (MySqlConnection conn = DBConnection.GetInstance().GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", _barangId);

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            message = "Barang berhasil dihapus (diarsipkan) dari sistem.";
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                message = "Gagal menghapus data dari database: " + ex.Message;
                return false;
            }

            message = "Gagal menghapus barang. Barang tidak ditemukan atau sudah tidak aktif.";
            return false;
        }
    }
}
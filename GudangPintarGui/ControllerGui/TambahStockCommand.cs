using System;
using MySql.Data.MySqlClient;
using GudangPintarGui.ConfigDatabase;

namespace GudangPintarGui.ControllerGui
{
    // Command ini untuk menangani logika penambahan stok barang yang sudah ada di database, termasuk validasi input dan pencatatan riwayat transaksi
    public class TambahStokCommand : ICommand
    {
        private readonly int _barangId;
        private readonly int _supplierId;
        private readonly int _jumlahTambah;
        private readonly int _userId;

        // ini untuk menginisialisasi command
        public TambahStokCommand(int barangId, int supplierId, int jumlahTambah, int userId)
        {
            _barangId = barangId;
            _supplierId = supplierId;
            _jumlahTambah = jumlahTambah;
            _userId = userId;
        }

        // ini untuk mengeksekusi logika penambahan stok termasuk validasi input dll
        public bool Execute(out string message)
        {
            // ini validasi awal untuk memastikan jumlah tambah stok valid
            if (_jumlahTambah <= 0)
            {
                message = "Jumlah tambah stok harus lebih dari 0.";
                return false;
            }

            using (MySqlConnection conn = DBConnection.GetInstance().GetConnection())
            {
                conn.Open();
                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // ini untuk update stok barang di tabel barang
                        string queryUpdate = @"UPDATE barang 
                                               SET quantity = quantity + @jumlah 
                                               WHERE barangid = @id AND isActive = 1";

                        using (MySqlCommand cmd = new MySqlCommand(queryUpdate, conn, transaction))
                        {
                            cmd.Parameters.Add("@jumlah", MySqlDbType.Int32).Value = _jumlahTambah;
                            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = _barangId;

                            int affectedRows = cmd.ExecuteNonQuery();
                            if (affectedRows == 0)
                                throw new Exception("Barang tidak ditemukan atau tidak aktif.");
                        }

                        // ini untuk mencatat riwayat transaksi penambahan stok di tabel stock_history
                        string queryHistory = @"INSERT INTO stock_history 
                                              (barangid, changed_quantity, changed_by, supplierid, change_date) 
                                              VALUES 
                                              (@id, @qty, @user, @supp, NOW())";

                        using (MySqlCommand cmd = new MySqlCommand(queryHistory, conn, transaction))
                        {
                            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = _barangId;
                            cmd.Parameters.Add("@qty", MySqlDbType.Int32).Value = _jumlahTambah;
                            cmd.Parameters.Add("@user", MySqlDbType.Int32).Value = _userId;
                            cmd.Parameters.Add("@supp", MySqlDbType.Int32).Value = _supplierId;

                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        message = "Stok berhasil diperbarui dan riwayat transaksi telah dicatat.";
                        return true;
                    }

                    // ini untuk menangani jika terjadi error selama proses update stok atau pencatatan riwayat transaksi
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        message = "Gagal memperbarui stok: " + ex.Message;
                        return false;
                    }
                }
            }
        }
    }
}
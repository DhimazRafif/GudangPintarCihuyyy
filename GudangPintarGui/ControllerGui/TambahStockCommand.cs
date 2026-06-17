using System;
using MySql.Data.MySqlClient;
using GudangPintarGui.ConfigDatabase;
using GudangPintarGui.ControllerGui;
using GudangPintarGui.Utils;

namespace GudangPintarGui.ControllerGui
{

    // Command untuk menangani logika penambahan stok barang dari supplier.
    public class TambahStokCommand : ICommand
    {
        private readonly int _barangId;
        private readonly int _supplierId;
        private readonly int _jumlahTambah;
        private readonly int _userId;

        public TambahStokCommand(int barangId, int supplierId, int jumlahTambah, int userId)
        {
            // Validasi data di konstruktor (Fail-Fast Principle)
            if (barangId <= 0) throw new ArgumentException("ID Barang tidak valid.");
            if (jumlahTambah <= 0) throw new ArgumentException("Jumlah tambah stok harus lebih dari 0.");
            if (userId <= 0) throw new ArgumentException("ID User tidak valid.");

            _barangId = barangId;
            _supplierId = supplierId;
            _jumlahTambah = jumlahTambah;
            _userId = userId;
        }

        // Implementasi metode Execute untuk menambahkan stok barang
        public bool Execute(out string message)
        {
            using (var conn = DBConnection.GetInstance().GetConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Update stok barang
                        string queryUpdate = @"UPDATE barang 
                                               SET quantity = quantity + @jumlah 
                                               WHERE barangid = @id AND isActive = 1";

                        using (var cmd = new MySqlCommand(queryUpdate, conn, transaction))
                        {
                            cmd.Parameters.Add("@jumlah", MySqlDbType.Int32).Value = _jumlahTambah;
                            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = _barangId;

                            if (cmd.ExecuteNonQuery() == 0)
                                throw new Exception("Barang tidak ditemukan atau tidak aktif.");
                        }

                        // 2. Insert ke tabel stock_history untuk mencatat riwayat perubahan stok
                        var subject = new StockSubject();
                        subject.Attach(new StockHistoryObserver());
                        subject.Attach(new StockNotificationObserver());

                        // OBSERVER: Mencatat riwayat dan memonitor perubahan state ketika tambah stok berhasil dijalankan.
                        subject.Notify(conn, transaction, _barangId, _jumlahTambah, _userId, _supplierId);

                        transaction.Commit();
                        message = "Stok berhasil diperbarui dan riwayat transaksi telah dicatat.";
                        return true;
                    }
                    // Jika terjadi kesalahan, rollback transaksi dan kembalikan pesan error
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        message = $"Gagal memperbarui stok: {ex.Message}";
                        return false;
                    }
                }
            }
        }
    }
}
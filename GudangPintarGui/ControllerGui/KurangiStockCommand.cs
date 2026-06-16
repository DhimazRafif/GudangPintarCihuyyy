using System;
using MySql.Data.MySqlClient;
using GudangPintarGui.ConfigDatabase;
using GudangPintarGui.ControllerGui;
using GudangPintarGui.Utils;

namespace GudangPintarGui.ControllerGui
{
    // Command untuk menangani logika pengurangan stok barang.
    public class KurangiStokCommand : ICommand
    {
        private readonly int _barangId;
        private readonly int _jumlahKurang;
        private readonly int _userId;

        // Validasi data di konstruktor (Fail-Fast Principle)
        public KurangiStokCommand(int barangId, int jumlahKurang, int userId)
        {
            if (barangId <= 0) throw new ArgumentException("ID Barang tidak valid.");
            if (jumlahKurang <= 0) throw new ArgumentException("Jumlah kurang harus > 0.");
            if (userId <= 0) throw new ArgumentException("ID User tidak valid.");

            _barangId = barangId;
            _jumlahKurang = jumlahKurang;
            _userId = userId;
        }

        // Eksekusi perintah untuk mengurangi stok barang dengan transaksi yang aman dan mencatat riwayatnya.
        public bool Execute(out string message)
        {
            using (var conn = DBConnection.GetInstance().GetConnection())
            {
                conn.Open();
                // Memulai transaksi untuk menjamin integritas data (ACID)
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Cek ketersediaan stok saat ini dengan lock untuk m
                        int stokSekarang = 0;
                        string queryCek = "SELECT quantity FROM barang WHERE barangid = @id AND isActive = 1 FOR UPDATE";

                        using (var cmdCek = new MySqlCommand(queryCek, conn, transaction))
                        {
                            cmdCek.Parameters.Add("@id", MySqlDbType.Int32).Value = _barangId;
                            var result = cmdCek.ExecuteScalar();

                            if (result == null)
                                throw new Exception("Barang tidak ditemukan atau tidak aktif.");

                            stokSekarang = Convert.ToInt32(result);
                        }

                        // Validasi stok cukup sebelum mengurangi
                        if (stokSekarang < _jumlahKurang)
                            throw new Exception($"Stok tidak mencukupi! (Tersedia: {stokSekarang})");

                        // 2. Kurangi stok barang
                        string queryUpdate = "UPDATE barang SET quantity = quantity - @jumlah WHERE barangid = @id AND isActive = 1";
                        using (var cmdUpdate = new MySqlCommand(queryUpdate, conn, transaction))
                        {
                            cmdUpdate.Parameters.Add("@jumlah", MySqlDbType.Int32).Value = _jumlahKurang;
                            cmdUpdate.Parameters.Add("@id", MySqlDbType.Int32).Value = _barangId;
                            cmdUpdate.ExecuteNonQuery();
                        }

                        // 3. Catat riwayat perubahan stok
                        var subject = new StockSubject();
                        subject.Attach(new StockHistoryObserver());

                        // OBSERVER: Mencatat riwayat ketika kurangi stok berhasil dijalankan.
                        subject.Notify(conn, transaction, _barangId, -_jumlahKurang, _userId, null);

                        // Commit transaksi jika semua operasi berhasil (data tersimpan permanen)
                        transaction.Commit();
                        message = "Stok berhasil dikurangi dan riwayat dicatat.";
                        return true;
                    }
                    catch (Exception ex)
                    {
                        // Rollback transaksi jika terjadi error (mengembalikan data ke kondisi semula)
                        transaction.Rollback();
                        message = $"Gagal mengurangi stok: {ex.Message}";
                        return false;
                    }
                }
            }
        }
    }
}
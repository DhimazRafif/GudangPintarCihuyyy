using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using GudangPintarGui.ConfigDatabase;
using GudangPintarGui.Models;

namespace GudangPintarGui.ServiceGui
{
    // Service untuk menangani logika bisnis terkait data barang yang akan digunakan oleh GUI.
    public class BarangGuiService
    {
        public BarangGuiService() { }

        // 1. Validasi Nama Barang Unik (untuk Tambah dan Edit)
        public bool ApakahNamaBarangAda(string nama, int idKecuali = -1)
        {
            try
            {
                using (var conn = DBConnection.GetInstance().GetConnection())
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM barang WHERE name = @nama AND barangid <> @id AND isActive = 1";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@nama", MySqlDbType.VarChar).Value = nama;
                        cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = idKecuali;
                        return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                    }
                }
            }
            catch { return false; }
        }

        // 2. Mengambil Data Barang untuk Ditampilkan di DataGridView
        public List<StockGuiModel> AmbilBarangSiapTampil()
        {
            var daftarBarang = new List<StockGuiModel>();
            string query = "SELECT barangid, name, quantity, price, notification_threshold, categoryid FROM barang WHERE isActive = 1";

            // Menggunakan koneksi database untuk mengambil data barang yang aktif dan mengisi list dengan model yang sesuai untuk GUI.
            using (var conn = DBConnection.GetInstance().GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        daftarBarang.Add(new StockGuiModel
                        {
                            BarangId = reader.GetInt32("barangid"),
                            NamaBarang = reader.GetString("name"),
                            Jumlah = reader.GetInt32("quantity"),
                            Harga = reader.GetDouble("price"),
                            NotificationThreshold = reader.GetInt32("notification_threshold"),
                            CategoryId = reader.GetInt32("categoryid")
                        });
                    }
                }
            }
            return daftarBarang;
        }

        // 3. Pencarian Barang Berdasarkan Nama
        public List<StockGuiModel> CariBarang(string keyword)
        {
            var daftarBarang = new List<StockGuiModel>();
            string query = "SELECT barangid, name, quantity, price, notification_threshold, categoryid FROM barang WHERE isActive = 1 AND name LIKE @keyword";

            using (var conn = DBConnection.GetInstance().GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@keyword", MySqlDbType.VarChar).Value = "%" + keyword + "%";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            daftarBarang.Add(new StockGuiModel
                            {
                                BarangId = reader.GetInt32("barangid"),
                                NamaBarang = reader.GetString("name"),
                                Jumlah = reader.GetInt32("quantity"),
                                Harga = reader.GetDouble("price"),
                                NotificationThreshold = reader.GetInt32("notification_threshold"),
                                CategoryId = reader.GetInt32("categoryid")
                            });
                        }
                    }
                }
            }
            return daftarBarang;
        }

        // 4. Mengambil Data Kategori untuk ComboBox
        public DataTable AmbilDaftarKategori()
        {
            var dt = new DataTable();
            using (var conn = DBConnection.GetInstance().GetConnection())
            {
                string query = "SELECT categoryid, name FROM category";
                using (var adapter = new MySqlDataAdapter(query, conn)) adapter.Fill(dt);
            }
            return dt;
        }

        // 5. Mengambil Data Supplier untuk ComboBox
        public DataTable AmbilDaftarSupplier()
        {
            var dt = new DataTable();
            using (var conn = DBConnection.GetInstance().GetConnection())
            {
                string query = "SELECT supplierid, name FROM supplier";
                using (var adapter = new MySqlDataAdapter(query, conn)) adapter.Fill(dt);
            }
            return dt;
        }

        public (int totalBarang, int totalStok) AmbilRingkasanStok()
        {
            int totalBarang = 0;
            int totalStok = 0;

            // Menghitung jumlah baris (count) dan total quantity (sum) dalam satu query
            string query = "SELECT COUNT(*), IFNULL(SUM(quantity), 0) FROM barang WHERE isActive = 1";

            try
            {
                using (var conn = DBConnection.GetInstance().GetConnection())
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            totalBarang = reader.GetInt32(0);
                            totalStok = reader.GetInt32(1);
                        }
                    }
                }
            }
            catch (Exception) { }

            return (totalBarang, totalStok);
        }
    }
}
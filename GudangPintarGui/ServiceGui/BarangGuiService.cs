using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using GudangPintarGui.ConfigDatabase;
using GudangPintarGui.Models;

namespace GudangPintarGui.ServiceGui
{
    public class BarangGuiService
    {
        public BarangGuiService() { }

        // ini untuk mengambil daftar barang yang siap ditampilkan di GUI, hanya barang yang aktif (isActive = 1) yang akan diambil dari database
        public List<StockGuiModel> AmbilBarangSiapTampil()
        {
            List<StockGuiModel> daftarBarang = new List<StockGuiModel>();
            string query = "SELECT barangid, name, quantity, price, notification_threshold, categoryid FROM barang WHERE isActive = 1";

            // gunakan try-catch untuk menangani potensi error saat koneksi ke database atau eksekusi query
            try
            {
                using (MySqlConnection conn = DBConnection.GetInstance().GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
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
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show($"Database Error: {ex.Message}", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return daftarBarang;
        }

        // ini untuk memperbarui data master barang di database berdasarkan input dari GUI, termasuk nama, kategori, harga, dan threshold notifikasi. Metode ini juga mengembalikan pesan sukses atau error melalui parameter output.
        public bool UpdateMasterBarang(StockGuiModel data, out string message)
        {
            // gunakan try-catch untuk menangani potensi error saat koneksi ke database atau eksekusi query
            try
            {
                using (MySqlConnection conn = DBConnection.GetInstance().GetConnection())
                {
                    conn.Open();
                    string query = @"UPDATE barang 
                                     SET name = @nama, 
                                         categoryid = @cat, 
                                         price = @harga, 
                                         notification_threshold = @threshold 
                                     WHERE barangid = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = data.BarangId;
                        cmd.Parameters.Add("@nama", MySqlDbType.VarChar).Value = data.NamaBarang;
                        cmd.Parameters.Add("@cat", MySqlDbType.Int32).Value = data.CategoryId;
                        cmd.Parameters.Add("@harga", MySqlDbType.Double).Value = data.Harga;
                        cmd.Parameters.Add("@threshold", MySqlDbType.Int32).Value = data.NotificationThreshold;

                        cmd.ExecuteNonQuery(); 
                    }
                }
                message = "Data master barang berhasil diperbarui.";
                return true;
            }
            catch (Exception ex)
            {
                message = "Gagal memperbarui data: " + ex.Message;
                return false;
            }
        }

        // metode untuk mengambil daftar kategori dari database, yang akan digunakan untuk mengisi dropdown kategori di GUI
        public DataTable AmbilDaftarKategori()
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = DBConnection.GetInstance().GetConnection())
                {
                    string query = "SELECT categoryid, name FROM category";
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error memuat kategori: " + ex.Message);
            }
            return dt;
        }

        // ini untuk mengambil daftar supplier dari database, yang akan digunakan untuk mengisi dropdown supplier di GUI jika diperlukan di masa depan
        public DataTable AmbilDaftarSupplier()
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = DBConnection.GetInstance().GetConnection())
                {
                    string query = "SELECT supplierid, name FROM supplier";
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error memuat supplier: " + ex.Message);
            }
            return dt;
        }

        // ini untuk mencari barang berdasarkan nama atau keyword tertentu, yang akan digunakan untuk fitur pencarian di GUI. Metode ini mengembalikan daftar barang yang sesuai dengan keyword yang dimasukkan.
        public List<StockGuiModel> CariBarang(string keyword)
        {
            // gunakan try-catch untuk menangani potensi error saat koneksi ke database atau eksekusi query
            List<StockGuiModel> daftarBarang = new List<StockGuiModel>();
            string query = "SELECT barangid, name, quantity, price, notification_threshold, categoryid " +
                           "FROM barang WHERE isActive = 1 AND name LIKE @keyword";

            // tambahkan wildcard % untuk pencarian parsial sehingga pengguna dapat mencari dengan sebagian nama barang
            try
            {
                using (MySqlConnection conn = DBConnection.GetInstance().GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Menambahkan wildcard % untuk pencarian parsial
                        cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                        using (MySqlDataReader reader = cmd.ExecuteReader())
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
            }
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error pencarian: {ex.Message}");
            }
            return daftarBarang;
        }
    }
}
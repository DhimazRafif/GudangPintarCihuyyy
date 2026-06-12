using GudangPintar.Model;
<<<<<<< HEAD:GudangPintarKPL/GudangPintarKPL/Controllers/StockService.cs
using GudangPintarKPL.Models;
using System;
=======
using System.Diagnostics;
using System.Xml.Linq;
using GudangPintar.Model;
using GudangPintarKPL.Models;
>>>>>>> a8b62e2d6144355e4b71cb7d24b87ec53897866e:GudangPintarKPL/Controllers/StockService.cs
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
<<<<<<< HEAD:GudangPintarKPL/GudangPintarKPL/Controllers/StockService.cs
using MySql.Data.MySqlClient;
using GudangPintarKPL.ConfigDatabase;
=======
>>>>>>> a8b62e2d6144355e4b71cb7d24b87ec53897866e:GudangPintarKPL/Controllers/StockService.cs

namespace GudangPintar.Controllers
{
    public class StockService
    {
        private List<Stock> stocks = new();

<<<<<<< HEAD:GudangPintarKPL/GudangPintarKPL/Controllers/StockService.cs
        public List<Stock> GetAll()
        {
            List<Stock> listBarang = new List<Stock>();

            using (MySqlConnection connection = DBConnection.GetInstance().GetConnection())
            {
                string query = "SELECT b.barangid,b.name,c.name AS 'Category Name',b.quantity,b.price\r\n" +
                    "FROM barang b\r\n" +
                    "JOIN category c ON b.categoryid = c.categoryid";

                using (MySqlCommand command = new MySqlCommand(query,connection))
                {
                    try
                    {
                        connection.Open();
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = Convert.ToInt32(reader["barangid"]);
                                string nama = reader["name"].ToString();
                                int kuantitas = Convert.ToInt32(reader["quantity"]);
                                double harga = Convert.ToDouble(reader["price"]);
                                string categoryName = reader["Category Name"].ToString();

                                Stock newStock = new Stock(id, nama, categoryName, harga, kuantitas); ;

                                listBarang.Add(newStock);
                            }
                        }
                    }
                    catch(MySqlException ex)
                    {
                        System.Diagnostics.Debug.WriteLine("Database Error: " + ex.Message);
                    }
                }
            }

            return listBarang;
=======
        public List<Stock> GetAll() => stocks;

        public StockService()
        {
            Add(new Stock("Buku Tulis", Category.ATK, 20, 5000));
            Add(new Stock("Pulpen", Category.ATK, 20, 2000));


            Add(new Stock("Buku Gambar", Category.ATK, 100, 5000));
            Add(new Stock("Pulpen Gel Black", Category.ATK, 200, 3500));
            Add(new Stock("Penghapus Putih", Category.ATK, 50, 2000));
            Add(new Stock("Penggaris 30cm", Category.ATK, 30, 7500));

            Add(new Stock("Beras Premium 5kg", Category.Sembako, 40, 75000));
            Add(new Stock("Minyak Goreng 2L", Category.Sembako, 60, 34000));
            Add(new Stock("Gula Pasir 1kg", Category.Sembako, 100, 17500));
            Add(new Stock("Telur Ayam 1kg", Category.Sembako, 30, 28000));
            Add(new Stock("Tepung Terigu 1kg", Category.Sembako, 80, 12000));
            Add(new Stock("Susu Kental Manis", Category.Sembako, 120, 11500));
>>>>>>> a8b62e2d6144355e4b71cb7d24b87ec53897866e:GudangPintarKPL/Controllers/StockService.cs
        }

        public bool Add(Stock s)
        {
            if (stocks.Any(x => x.NamaBarang == s.NamaBarang))
            {
                Console.WriteLine("Nama barang sudah ada!");
                return false;
            }

            if (s.Jumlah <= 0)
            {
                Console.WriteLine("Jumlah harus lebih dari 0!");
                return false;
            }

            Debug.Assert(s.Jumlah > 0);

            stocks.Add(s);
            return true;
        }
        public bool Delete(string nama)
        {
            var s = Get(nama);

            if (s == null)
            {
                Console.WriteLine("Barang tidak ditemukan!");
                return false;
            }

            stocks.Remove(s);
            return true;
        }

        public Stock? Get(string nama)
        {
            return stocks.FirstOrDefault(s => s.NamaBarang == nama);
        }

<<<<<<< HEAD:GudangPintarKPL/GudangPintarKPL/Controllers/StockService.cs
        // Update sekarang menerima tanggal kadaluarsa
        public void Update(string nama, string newNama, Category kategori, double harga, DateTime? kadaluarsa)
=======
        public void Update(string nama, string newNama, Category kategori, double harga)
>>>>>>> a8b62e2d6144355e4b71cb7d24b87ec53897866e:GudangPintarKPL/Controllers/StockService.cs
        {
            var s = Get(nama);

            if (stocks.Any(x => x.NamaBarang == newNama && x.NamaBarang != nama))
            {
                Console.WriteLine("Nama barang sudah digunakan!");
                return;
            }

            if (s != null)
            {
                s.EditStock(newNama, kategori, harga);
            }
        }

        public bool TambahStok(string nama, int jumlah)
        {
            if (jumlah <= 0)
            {
                Console.WriteLine("Input harus berupa bilangan positif!");
                return false;
            }

            var s = Get(nama);

            if (s == null)
            {
                Console.WriteLine("Barang tidak ditemukan!");
                return false;
            }

            Debug.Assert(jumlah > 0);

            s.TambahStok(jumlah);
            return true;
        }

        public bool KurangiStok(string nama, int jumlah)
        {
            var s = Get(nama);

            if (s == null)
            {
                Console.WriteLine("Barang tidak ditemukan!");
                return false;
            }

            if (jumlah > s.Jumlah)
            {
                Console.WriteLine("Stok tidak cukup!");
                return false;
            }

            if (jumlah <= 0)
            {
                Console.WriteLine("Jumlah harus lebih dari 0!");
                return false;
            }

            Debug.Assert(s.Jumlah >= 0);

            s.KurangiStok(jumlah);
            return true;
        }


    }
}
using System;
using System.Data;
using GudangPintarGui.ConfigDatabase;
using MySql.Data.MySqlClient;
using GudangPintarGui.Models;

namespace GudangPintarGui.ServiceGui
{
    public class BarangService
    {

        public List<Barang> GetDaftarBarang()
        {
            var listBarang = new List<Barang>();

            using (var connection = DBConnection.GetInstance().GetConnection())
            {
                connection.Open();

                string query = "SELECT b.barangid,b.name,c.name AS 'category',b.quantity,b.price\r\n" +
                    "FROM barang b\r\n" +
                    "JOIN category c ON b.categoryid = c.categoryid " +
                    "ORDER BY b.barangid ASC";

                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var barang = new Barang
                            {
                                Id = reader.GetInt32("barangid"),
                                Nama = reader.GetString("name"),
                                Category = reader.GetString("category"),
                                Harga = reader.GetDouble("price"),
                                Jumlah = reader.GetInt32("quantity")
                            };
                            listBarang.Add(barang);
                        }
                    }
                }

            }
            return listBarang;
        }
    }
}
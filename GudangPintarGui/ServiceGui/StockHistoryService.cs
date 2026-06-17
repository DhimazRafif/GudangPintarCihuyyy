using System.Collections.Generic;
using MySql.Data.MySqlClient;
using GudangPintarGui.ConfigDatabase;
using GudangPintarGui.Models;

namespace GudangPintarGui.ServiceGui
{
    public class StockHistoryService
    {
        public List<StockHistory> AmbilRiwayat()
        {
            var list = new List<StockHistory>();

            string query = @"
                SELECT 
                    sh.historyid,
                    b.name AS nama_barang,
                    sh.changed_quantity,
                    u.name AS changed_by,
                    IFNULL(s.name, '-') AS supplier_name,
                    sh.change_date
                FROM stock_history sh
                JOIN barang b ON sh.barangid = b.barangid
                JOIN user u ON sh.changed_by = u.userid
                LEFT JOIN supplier s ON sh.supplierid = s.supplierid
                ORDER BY sh.change_date DESC";

            using (var conn = DBConnection.GetInstance().GetConnection())
            {
                conn.Open();

                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new StockHistory
                        {
                            HistoryId = reader.GetInt32("historyid"),
                            NamaBarang = reader.GetString("nama_barang"),
                            ChangedQuantity = reader.GetInt32("changed_quantity"),
                            ChangedBy = reader.GetString("changed_by"),
                            SupplierName = reader.GetString("supplier_name"),
                            ChangeDate = reader.GetDateTime("change_date")
                        });
                    }
                }
            }

            return list;
        }
    }
}
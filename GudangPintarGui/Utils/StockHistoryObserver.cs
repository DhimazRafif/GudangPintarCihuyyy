using System;
using MySql.Data.MySqlClient;

namespace GudangPintarGui.Utils
{
    public class StockHistoryObserver : IStockObserver
    {
        // OBSERVER: Method ini dipanggil otomatis saat tambah stok atau kurangi stok dijalankan.
        public void Update(
            MySqlConnection conn,
            MySqlTransaction transaction,
            int barangId,
            int changedQuantity,
            int changedBy,
            int? supplierId
        )
        {
            string query = @"
                INSERT INTO stock_history
                (barangid, changed_quantity, changed_by, supplierid, change_date)
                VALUES
                (@barangid, @changed_quantity, @changed_by, @supplierid, NOW())";

            using (var cmd = new MySqlCommand(query, conn, transaction))
            {
                cmd.Parameters.Add("@barangid", MySqlDbType.Int32).Value = barangId;
                cmd.Parameters.Add("@changed_quantity", MySqlDbType.Int32).Value = changedQuantity;
                cmd.Parameters.Add("@changed_by", MySqlDbType.Int32).Value = changedBy;

                if (supplierId.HasValue)
                    cmd.Parameters.Add("@supplierid", MySqlDbType.Int32).Value = supplierId.Value;
                else
                    cmd.Parameters.Add("@supplierid", MySqlDbType.Int32).Value = DBNull.Value;

                cmd.ExecuteNonQuery();
            }
        }
    }
}
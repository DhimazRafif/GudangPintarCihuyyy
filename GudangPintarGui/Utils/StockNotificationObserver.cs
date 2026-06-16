using GudangPintarGui.ServiceGui;
using MySql.Data.MySqlClient;

namespace GudangPintarGui.Utils
{
    public class StockNotificationObserver : IStockObserver
    {
        // OBSERVER: Method ini memonitor perubahan quantity dan notification_threshold barang.
        public void Update(
            MySqlConnection conn,
            MySqlTransaction transaction,
            int barangId,
            int changedQuantity,
            int changedBy,
            int? supplierId
        )
        {
            var notificationService = new StockNotificationService();
            notificationService.CekSatuBarangDalamTransaksi(conn, transaction, barangId);
        }
    }
}
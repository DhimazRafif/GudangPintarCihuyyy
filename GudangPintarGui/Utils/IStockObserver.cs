using MySql.Data.MySqlClient;

namespace GudangPintarGui.Utils
{
    public interface IStockObserver
    {
        void Update(
            MySqlConnection conn,
            MySqlTransaction transaction,
            int barangId,
            int changedQuantity,
            int changedBy,
            int? supplierId
        );
    }
}
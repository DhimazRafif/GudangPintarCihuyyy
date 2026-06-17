using System.Collections.Generic;
using MySql.Data.MySqlClient;
using GudangPintarGui.Utils;

namespace GudangPintarGui.ControllerGui
{
    public class StockSubject
    {
        private readonly List<IStockObserver> _observers = new List<IStockObserver>();

        public void Attach(IStockObserver observer)
        {
            _observers.Add(observer);
        }

        public void Notify(
            MySqlConnection conn,
            MySqlTransaction transaction,
            int barangId,
            int changedQuantity,
            int changedBy,
            int? supplierId
        )
        {
            foreach (var observer in _observers)
            {
                observer.Update(conn, transaction, barangId, changedQuantity, changedBy, supplierId);
            }
        }
    }
}
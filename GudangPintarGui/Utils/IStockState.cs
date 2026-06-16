using GudangPintarGui.Models;

namespace GudangPintarGui.Utils
{
    public interface IStockState
    {
        StockAlertState State { get; }
        void ShowNotification(string namaBarang);
    }
}
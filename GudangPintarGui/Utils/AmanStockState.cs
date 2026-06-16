using GudangPintarGui.Models;

namespace GudangPintarGui.Utils
{
    public class AmanStockState : IStockState
    {
        public StockAlertState State => StockAlertState.Aman;

        public void ShowNotification(string namaBarang)
        {
            // State Aman tidak menampilkan pop up.
        }
    }
}
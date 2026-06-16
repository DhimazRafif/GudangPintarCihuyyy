using GudangPintarGui.Models;
using GudangPintarGui.View;

namespace GudangPintarGui.Utils
{
    public class HabisStockState : IStockState
    {
        public StockAlertState State => StockAlertState.Habis;

        public void ShowNotification(string namaBarang)
        {
            using (var form = new NotifHabis(namaBarang))
            {
                form.ShowDialog();
            }
        }
    }
}
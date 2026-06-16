using GudangPintarGui.Models;
using GudangPintarGui.View;

namespace GudangPintarGui.Utils
{
    public class MenipisStockState : IStockState
    {
        public StockAlertState State => StockAlertState.Menipis;

        public void ShowNotification(string namaBarang)
        {
            using (var form = new NotifMenipis(namaBarang))
            {
                form.ShowDialog();
            }
        }
    }
}
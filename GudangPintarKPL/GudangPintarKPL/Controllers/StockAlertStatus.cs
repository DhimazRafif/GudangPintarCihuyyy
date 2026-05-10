using System;

namespace GudangPintar.Model
{
    public enum AlertState
    {
        Aman,
        Menipis,
        Habis
    }

    public class StockAlertStatus
    {
        public static AlertState GetState(int jumlah)
        {
            if (jumlah == 0)
                return AlertState.Habis;
            else if (jumlah < 10)
                return AlertState.Menipis;
            else
                return AlertState.Aman;
        }

        public static string GetMessage(Stock stock)
        {
            var state = GetState(stock.Jumlah);

            return state switch
            {
                AlertState.Aman => "[AMAN]",
                AlertState.Menipis => "[MENIPIS]",
                AlertState.Habis => "[HABIS]",
                _ => "[UNKNOWN]"
            };
        }
    }
}
using System;

namespace GudangPintar.Model
{
    public class Notification
    {
        public static string GetNotifikasi(Stock stock)
        {
            return StockAlertStatus.GetMessage(stock);
        }
    }
}
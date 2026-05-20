using GudangPintarKPL.Models;
using System;

namespace GudangPintar.Model
{
    public enum AlertState
    {
        Aman,
        Menipis,
        Habis,
        Kadaluarsa
    }

    public class StockAlertStatus
    {
        public static AlertState GetState(Stock stock)
        {
            if (stock == null) throw new ArgumentNullException(nameof(stock), "Data stock tidak boleh null");

            // validasi kadaluarsa dulu karena itu prioritas utama
            if (stock.IsExpired())
                return AlertState.Kadaluarsa;

            if (stock.Jumlah == 0)
                return AlertState.Habis;

            // validasi menipis dengan nilai dinamis yang bisa berubah berdasarkan konfigurasi runtime
            int batasMenipis = 10;

            var config = GudangConfig.LoadConfigFile();
            if (config != null)
            {
                // jika format_harga tidak valid, kita berikan peringatan di log dan tetap gunakan batas default
                if (string.IsNullOrWhiteSpace(config.format_harga))
                {
                    Console.WriteLine("[VALIDASI RUNTIME] Peringatan: format_harga di config tidak valid! Menggunakan batas default.");
                    batasMenipis = 5; // set batas terakhir yang masih bisa dianggap menipis
                }
                else if (config.mata_uang == "USD")
                {
                    batasMenipis = 5;
                }
            }

            // automata state untuk menentukan status alert berdasarkan jumlah stok
            if (stock.Jumlah < batasMenipis)
                return AlertState.Menipis;
            else
                return AlertState.Aman;
        }

        public static string GetMessage(Stock stock)
        {
            if (stock == null) return "[ERROR: DATA NULL]";

            var state = GetState(stock);

            return state switch
            {
                AlertState.Aman => "[AMAN]",
                AlertState.Menipis => "[MENIPIS]",
                AlertState.Habis => "[HABIS]",
                AlertState.Kadaluarsa => "[KADALUARSA]",
                _ => "[UNKNOWN]"
            };
        }
    }
}
using System;
using GudangPintarKPL.Models;

namespace GudangPintar.Model
{
    public enum AlertState
    {
        Aman,
        Menipis,
        Habis,
        AkanKadaluarsa,
        Kadaluarsa
    }

    public static class StockAlertStatus
    {
        public static AlertState GetState(Stock stock)
        {
            var cfg = GudangConfig.LoadConfigFile();

            int ambangMenipis = cfg.AmbangMenipis;
            int ambangHabis = cfg.AmbangHabis;
            int hariPeringatan = cfg.PeringatanKadaluarsa;

            var now = DateTime.Now;

            if (stock.Kadaluarsa.HasValue)
            {
                var tgl = stock.Kadaluarsa.Value.Date;
                if (tgl < now.Date) return AlertState.Kadaluarsa;
                if (tgl <= now.Date.AddDays(hariPeringatan)) return AlertState.AkanKadaluarsa;
            }

            if (stock.Jumlah <= ambangHabis) return AlertState.Habis;
            if (stock.Jumlah < ambangMenipis) return AlertState.Menipis;
            return AlertState.Aman;
        }

        public static string GetMessage(Stock stock)
        {
            var state = GetState(stock);
            return state switch
            {
                AlertState.Aman => "[AMAN]",
                AlertState.Menipis => "[MENIPIS]",
                AlertState.Habis => "[HABIS]",
                AlertState.AkanKadaluarsa => "[AKAN KADALUARSA]",
                AlertState.Kadaluarsa => "[KADALUARSA]",
                _ => "[UNKNOWN]"
            };
        }
    }
}
using System;
<<<<<<< HEAD
=======
using GudangPintarKPL.Models;
>>>>>>> a8b62e2d6144355e4b71cb7d24b87ec53897866e

namespace GudangPintar.Model
{
    public enum AlertState
    {
        Aman,
        Menipis,
<<<<<<< HEAD
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
=======
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

            //if (stock.Kadaluarsa.HasValue)
            //{
            //    var tgl = stock.Kadaluarsa.Value.Date;
            //    if (tgl < now.Date) return AlertState.Kadaluarsa;
            //    if (tgl <= now.Date.AddDays(hariPeringatan)) return AlertState.AkanKadaluarsa;
            //}

            if (stock.Jumlah <= ambangHabis) return AlertState.Habis;
            if (stock.Jumlah < ambangMenipis) return AlertState.Menipis;
            return AlertState.Aman;
>>>>>>> a8b62e2d6144355e4b71cb7d24b87ec53897866e
        }

        public static string GetMessage(Stock stock)
        {
<<<<<<< HEAD
            var state = GetState(stock.Jumlah);

=======
            var state = GetState(stock);
>>>>>>> a8b62e2d6144355e4b71cb7d24b87ec53897866e
            return state switch
            {
                AlertState.Aman => "[AMAN]",
                AlertState.Menipis => "[MENIPIS]",
                AlertState.Habis => "[HABIS]",
<<<<<<< HEAD
=======
                AlertState.AkanKadaluarsa => "[AKAN KADALUARSA]",
                AlertState.Kadaluarsa => "[KADALUARSA]",
>>>>>>> a8b62e2d6144355e4b71cb7d24b87ec53897866e
                _ => "[UNKNOWN]"
            };
        }
    }
}
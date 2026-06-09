using System;
<<<<<<< HEAD
using GudangPintarKPL.Models;
=======
>>>>>>> 0befa517fd67ab1b05564b2334ef1276f04c4a37

namespace GudangPintar.Model
{
    public enum AlertState
    {
        Aman,
        Menipis,
<<<<<<< HEAD
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
=======
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
>>>>>>> 0befa517fd67ab1b05564b2334ef1276f04c4a37
        }

        public static string GetMessage(Stock stock)
        {
<<<<<<< HEAD
            var state = GetState(stock);
=======
            var state = GetState(stock.Jumlah);

>>>>>>> 0befa517fd67ab1b05564b2334ef1276f04c4a37
            return state switch
            {
                AlertState.Aman => "[AMAN]",
                AlertState.Menipis => "[MENIPIS]",
                AlertState.Habis => "[HABIS]",
<<<<<<< HEAD
                AlertState.AkanKadaluarsa => "[AKAN KADALUARSA]",
                AlertState.Kadaluarsa => "[KADALUARSA]",
=======
>>>>>>> 0befa517fd67ab1b05564b2334ef1276f04c4a37
                _ => "[UNKNOWN]"
            };
        }
    }
}
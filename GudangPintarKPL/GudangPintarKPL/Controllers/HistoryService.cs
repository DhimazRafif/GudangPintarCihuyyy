using GudangPintar.Model;
using System.Collections.Generic;

namespace GudangPintar.Controllers
{
    public class HistoryService
    {
        private List<StockHistory> histories = new();

        public void Add(StockHistory h)
        {
            histories.Add(h);
        }

        public List<StockHistory> GetAll() => histories;

        //METHOD INI untuk filter by date range
        public List<StockHistory> GetByDateRange(DateTime? startDate, DateTime? endDate)
        {
            var allHistory = GetAll(); 

            if (startDate.HasValue)
                allHistory = allHistory.Where(h => h.Tanggal >= startDate.Value).ToList();

            if (endDate.HasValue)
                allHistory = allHistory.Where(h => h.Tanggal <= endDate.Value).ToList();

            return allHistory;
        }

        // METHOD INI untuk filter by stock id
        public List<StockHistory> GetByStockId(int stockId)
        {
            var allHistory = GetAll();
            return allHistory.Where(h => h.Stockid == stockId).ToList();
        }

    }
}
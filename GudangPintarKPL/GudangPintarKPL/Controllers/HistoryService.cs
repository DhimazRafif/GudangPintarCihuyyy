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
    }
}
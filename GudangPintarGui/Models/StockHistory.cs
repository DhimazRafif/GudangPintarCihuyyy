using System;

namespace GudangPintarGui.Models
{
    public class StockHistory
    {
        public int HistoryId { get; set; }
        public string NamaBarang { get; set; }
        public int ChangedQuantity { get; set; }
        public string ChangedBy { get; set; }
        public string SupplierName { get; set; }
        public DateTime ChangeDate { get; set; }
    }
}
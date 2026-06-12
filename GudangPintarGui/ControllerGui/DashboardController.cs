using System;
using System.Collections.Generic;
using System.Text;
using GudangPintar.Controllers;
using GudangPintarKPL.Controllers;

namespace GudangPintarGui.ControllerGui
{
    internal class DashboardController
    {
        private readonly StockService _stockService;
        private readonly HistoryService _historyService;

        public DashboardController(StockService stockService, HistoryService historyService)
        {
            _stockService = stockService;
            _historyService = historyService;
        }

        public void LoadDataBarang(DataGridView dgv)
        {
            var dataBarang = _stockService.GetAll();

            dgv.DataSource = null;

            dgv.DataSource = dataBarang;

            FormatTable(dgv);
        }

        private void FormatTable(DataGridView dgv)
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AllowUserToAddRows = false;
            dgv.ReadOnly = true;
        }

        public void UpdateSummaryCards(Label lblTotalBarang, Label lblTotalStok)
        {
            var data = _stockService.GetAll();

            int totalJenis = data.Count;
            int totalStok = 0;

            foreach (var item in data)
            {
                totalStok += item.Jumlah; // Menghitung total seluruh kuantitas stok
            }

            lblTotalBarang.Text = totalJenis.ToString();
            lblTotalStok.Text = totalStok.ToString();
        }
    }
}

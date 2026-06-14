using GudangPintarGui.ServiceGui;
using GudangPintarGui.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace GudangPintarGui.ControllerGui
{
    internal class DashboardController
    {
        private readonly BarangService _barangService;

        public DashboardController()
        {
            _barangService = new BarangService();
        }

        public void LoadDataBarang(DataGridView dgv)
        {
            dgv.DataSource = null;

            dgv.DataSource = _barangService.GetDaftarBarang();

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
            List<Barang> dataBarang = _barangService.GetDaftarBarang();

            int totalJenis = dataBarang.Count;
            int totalStok = 0;

            foreach (var barang in dataBarang)
            {
                totalStok += barang.Jumlah;
            }

            lblTotalBarang.Text = totalJenis.ToString();
            lblTotalStok.Text = totalStok.ToString();

        }
    }
}

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

        // Fungsi untuk mengambil Data Barang
        public List<Barang> AmbilSemuaDataBarang()
        {
            return _barangService.GetDaftarBarang();
        }

        // Fungsi untuk mengisi data tabel
        public void LoadDataBarang(DataGridView dgv, List<Barang> dataBarang)
        {
            dgv.DataSource = null;

            dgv.DataSource = dataBarang;

            FormatTable(dgv);
        }

        // Fungsi untuk memperbarui Summary Card
        public void UpdateSummaryCards(Label lblTotalBarang, Label lblTotalStok, List<Barang> dataBarang)
        {

            int totalJenis = dataBarang.Count;
            int totalStok = 0;

            foreach (var barang in dataBarang)
            {
                totalStok += barang.Jumlah;
            }

            lblTotalBarang.Text = totalJenis.ToString();
            lblTotalStok.Text = totalStok.ToString();
        }

        private void FormatTable(DataGridView dgv)
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AllowUserToAddRows = false;
            dgv.ReadOnly = true;

            //  Matikan tema bawaan windows
            dgv.EnableHeadersVisualStyles = false;

            // Ganti warna Header
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;

            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        } 
    }
}

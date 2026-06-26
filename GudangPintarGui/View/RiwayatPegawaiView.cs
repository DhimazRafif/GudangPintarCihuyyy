using System;
using System.Windows.Forms;
using GudangPintarGui.ServiceGui;
using GudangPintarGui.Models;
using GudangPintarGui.ControllerGui;

namespace GudangPintarGui.View
{
    public partial class RiwayatPegawaiView : Form
    {
        private readonly DashboardController _dashboardController;
        private readonly StockHistoryService _historyService;
        private readonly User _user;

        public RiwayatPegawaiView()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _historyService = new StockHistoryService();

            _dashboardController = new DashboardController();
        }

        private void RiwayatPegawaiView_Load(object sender, EventArgs e)
        {
            RefreshSummaryCards();
            LoadRiwayat();
        }

        private void RefreshSummaryCards()
        {
            try
            {
                var dataGudang = _dashboardController.AmbilSemuaDataBarang();
                _dashboardController.UpdateSummaryCards(lblTotalBarang, lblTotalStok, dataGudang);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gagal memuat statistik di halaman riwayat: {ex.Message}");
            }
        }

        private void LoadRiwayat()
        {
            dgvRiwayat.Rows.Clear();

            var data = _historyService.AmbilRiwayat();

            foreach (var item in data)
            {
                dgvRiwayat.Rows.Add(
                    item.HistoryId,
                    item.NamaBarang,
                    item.ChangedQuantity,
                    item.ChangedBy,
                    item.SupplierName
                );
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KelolaBarangPegawaiView kelolaBarangPegawai = new KelolaBarangPegawaiView(_user);
            kelolaBarangPegawai.Show();
            this.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Sudah di halaman riwayat
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
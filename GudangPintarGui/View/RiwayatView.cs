using GudangPintarGui.ControllerGui;
using GudangPintarGui.Models;
using GudangPintarGui.ServiceGui;
using System;
using System.Windows.Forms;

namespace GudangPintarGui.View
{
    public partial class RiwayatView : Form
    {
        private readonly StockHistoryService _historyService;
        private readonly DashboardController _dashboardController;
        User _user;

        public RiwayatView()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _historyService = new StockHistoryService();

            _dashboardController = new DashboardController();
        }

        private void RiwayatView_Load(object sender, EventArgs e)
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

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KelolaBarangView barang = new KelolaBarangView(_user);
            barang.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var userService = new GudangPintarGui.ServiceGUI.UserService();
            var akunController = new AkunController(userService);

            PengelolahanAkun akun = new PengelolahanAkun(akunController);
            akun.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Sudah di halaman riwayat
        }
    }
}
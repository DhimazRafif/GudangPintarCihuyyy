using GudangPintar.Controllers;
using GudangPintarGui.ControllerGui;
using GudangPintarGui.Models;
using GudangPintarGui.View;
using GudangPintarKPL.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;
using GudangPintarGui.ServiceGui;

namespace GudangPintarGui
{
    public partial class Dashboard : Form
    {
        private readonly DashboardController _dashboardController;
        private readonly User _user;
        private readonly StockNotificationService _notificationService;

       

        public Dashboard(User user)
        {
            try
            {
                InitializeComponent();

                _user = user;

                this.StartPosition = FormStartPosition.CenterScreen;

                _dashboardController = new DashboardController();

                _notificationService = new StockNotificationService();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal inisialisasi komponen di Constructor:\n{ex.Message}",
                            "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // Fungsi terpusat DRY : proses pengupdatean layar menggunakan fungsi ini
        private void RefreshDashboard()
        {
            try
            {
                List<Barang> dataGudang = _dashboardController.AmbilSemuaDataBarang();

                // Daur ulang dataGudang untuk tabel dan summary card
                _dashboardController.LoadDataBarang(dgvBarang, dataGudang);
                _dashboardController.UpdateSummaryCards(lblTotalBarang, lblTotalStok, dataGudang);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi eror saat mengambil data Barang:\n\nPesan: {ex.Message}",
                            "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            RefreshDashboard();

            BeginInvoke(new Action(() =>
            {
                _notificationService.CekSemuaBarangSetelahLogin();
            }));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KelolaBarangView kelolaBarang = new KelolaBarangView(_user);
            kelolaBarang.ShowDialog();

            RefreshDashboard();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var userService = new GudangPintarGui.ServiceGUI.UserService();
            var akunController = new AkunController(userService);

            PengelolahanAkun akun = new PengelolahanAkun(akunController);
            akun.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RiwayatView riwayat = new RiwayatView();
            riwayat.ShowDialog();
        }
    }
}

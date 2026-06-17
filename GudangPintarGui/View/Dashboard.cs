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

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            try
            {
                _dashboardController.LoadDataBarang(dgvBarang);
                _dashboardController.UpdateSummaryCards(lblTotalBarang, lblTotalStok);

                BeginInvoke(new Action(() =>
                {
                    _notificationService.CekSemuaBarangSetelahLogin();
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi eror saat mengambil data Barang:\n\nPesan: {ex.Message}\n\nDetail: {ex.StackTrace}",
                            "Database Error di Load Event", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            KelolaBarangView kelolaBarang = new KelolaBarangView(_user);
            kelolaBarang.Show();

            _dashboardController.UpdateSummaryCards(lblTotalBarang, lblTotalStok);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var userService = new GudangPintarGui.ServiceGUI.UserService();
            var akunController = new AkunController(userService);

            PengelolahanAkun akun = new PengelolahanAkun(akunController);
            akun.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RiwayatView riwayat = new RiwayatView();
            riwayat.Show();
        }
    }
}

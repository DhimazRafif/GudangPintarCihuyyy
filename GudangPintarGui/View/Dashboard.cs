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

namespace GudangPintarGui
{
    public partial class Dashboard : Form
    {
        private readonly DashboardController _dashboardController;

        public Dashboard(User user)
        {
            try
            {
                InitializeComponent();

                this.StartPosition = FormStartPosition.CenterScreen;

                _dashboardController = new DashboardController();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi eror saat mengambil data Barang:\n\nPesan: {ex.Message}\n\nDetail: {ex.StackTrace}",
                            "Database Error di Load Event", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            KelolaBarangView kelolaBarang = new KelolaBarangView();
            kelolaBarang.ShowDialog();
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
            MessageBox.Show("Fitur riwayat belum tersedia.");
        }
    }
}

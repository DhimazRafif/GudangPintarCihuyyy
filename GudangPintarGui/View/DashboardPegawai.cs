using GudangPintar.Controllers;
using GudangPintarGui.ControllerGui;
using GudangPintarKPL.Controllers;
using GudangPintarGui.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;

namespace GudangPintarGui.View
{
    public partial class DashboardPegawai : Form
    {
        private readonly DashboardController _dashboardController;
        public DashboardPegawai(User user)
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

        private void DashboardPegawai_Load(object sender, EventArgs e)
        {
            try
            {
                _dashboardController.LoadDataBarang(dgvBarangPegawai);
                _dashboardController.UpdateSummaryCards(lblTotalBarangPegawai, lblTotalStokPegawai);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi eror saat mengambil data Barang:\n\nPesan: {ex.Message}\n\nDetail: {ex.StackTrace}",
                            "Database Error di Load Event", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KelolaBarangPegawaiView kelolaBarangPegawai = new KelolaBarangPegawaiView();
            kelolaBarangPegawai.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Fitur riwayat belum tersedia.");
        }
    }
}

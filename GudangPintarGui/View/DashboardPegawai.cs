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
using GudangPintarGui.ServiceGui;

namespace GudangPintarGui.View
{
    public partial class DashboardPegawai : Form
    {
        private readonly DashboardController _dashboardController;
        private readonly User _user;
        private readonly StockNotificationService _notificationService;
        public DashboardPegawai(User user)
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

        // FUNGSI TERPUSAT DRY: proses pengupdatean layar menggunakan fungsi ini
        private void RefreshDashboardPegawai()
        {
            try
            {
                var dataGudang = _dashboardController.AmbilSemuaDataBarang();

                // Daur ulang dataGudang untuk tabel dan kartu statistik
                _dashboardController.LoadDataBarang(dgvBarangPegawai, dataGudang);
                _dashboardController.UpdateSummaryCards(lblTotalBarangPegawai, lblTotalStokPegawai, dataGudang);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi eror saat memperbarui data Barang:\n\nPesan: {ex.Message}",
                            "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DashboardPegawai_Load(object sender, EventArgs e)
        {
            RefreshDashboardPegawai();

            BeginInvoke(new Action(() =>
            {
                _notificationService.CekSemuaBarangSetelahLogin();
            }));
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KelolaBarangPegawaiView kelolaBarangPegawai = new KelolaBarangPegawaiView(_user);
            kelolaBarangPegawai.DataTelahDiubah += () => RefreshDashboardPegawai();
            kelolaBarangPegawai.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RiwayatPegawaiView riwayat = new RiwayatPegawaiView();
            riwayat.Show();
        }
    }
}

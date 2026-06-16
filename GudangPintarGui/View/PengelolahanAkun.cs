using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using GudangPintarGui.ControllerGui;
using GudangPintarGui.Models;
using GudangPintarGui.ServiceGUI;

namespace GudangPintarGui.View
{
    public partial class PengelolahanAkun : Form
    {
        private readonly AkunController _akunController;
        private User _selectedUser;
        private readonly User _user;

        // Deklarasi Variabel timer
        private System.Windows.Forms.Timer _refreshTimer;

        public PengelolahanAkun(AkunController akunController)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            _akunController = akunController;
            LoadUsers();

            InisialisasiAutoRefresh();
        }

        private void InisialisasiAutoRefresh()
        {
            _refreshTimer = new System.Windows.Forms.Timer();

            // Atur interval update (2000 milidetik = 2 detik)
            _refreshTimer.Interval = 2000;

            // Sambungkan timer ke fungsi pemicu update
            _refreshTimer.Tick += RefreshTimer_Tick;

            _refreshTimer.Start();
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            UpdateSummaryCard();
        }

        private void UpdateSummaryCard()
        {
            try
            {
                var dashboardController = new DashboardController();
                dashboardController.UpdateSummaryCards(lblTotalBarang, lblTotalStok);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gagal auto-update summary: {ex.Message}");
            }
        }


        private void LoadUsers()
        {
            try
            {
                var users = _akunController.GetAllUsers();
                dgvPengelolahanAkun.Rows.Clear();
                foreach (var user in users)
                {
                    // Hanya tampilkan user aktif? Atau semua? Kita tampilkan semua tapi statusnya.
                    string status = user.IsActive ? "Aktif" : "Nonaktif";
                    string roleName = user.Role == RoleService.ROLE_ADMIN ? "Admin" : "Pegawai";
                    dgvPengelolahanAkun.Rows.Add(user.UserId, user.Name, user.Username, roleName, status);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error memuat data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnDasboard_Click(object sender, EventArgs e)
        {

        }

        private void btnBarang_Click(object sender, EventArgs e)
        {

        }

        private void btnRiwayat_Click(object sender, EventArgs e)
        {

        }

        private void btnAkun_Click(object sender, EventArgs e)
        {

        }

        private void dgvPengelolahanAkun_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            var addEditForm = new AddEditAkuncs(_akunController, mode: "tambah");
            if (addEditForm.ShowDialog() == DialogResult.OK)
            {
                LoadUsers(); // refresh
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPengelolahanAkun.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih user yang akan diedit.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int userId = Convert.ToInt32(dgvPengelolahanAkun.SelectedRows[0].Cells["ClmID"].Value);
            var user = _akunController.GetUserById(userId);
            if (user == null)
            {
                MessageBox.Show("User tidak ditemukan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var addEditForm = new AddEditAkuncs(_akunController, mode: "edit", user: user);
            if (addEditForm.ShowDialog() == DialogResult.OK)
            {
                LoadUsers();
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dgvPengelolahanAkun.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih user yang akan dihapus.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int userId = Convert.ToInt32(dgvPengelolahanAkun.SelectedRows[0].Cells["ClmID"].Value);
            var confirm = MessageBox.Show("Apakah Anda yakin ingin menghapus user ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                bool success = _akunController.DeleteUser(userId);
                if (success)
                {
                    MessageBox.Show("User berhasil dihapus.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUsers();
                }
                else
                {
                    MessageBox.Show("Gagal menghapus user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (_refreshTimer != null)
            {
                _refreshTimer.Stop();     
                _refreshTimer.Dispose();  
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KelolaBarangView barang = new KelolaBarangView(_user);
            barang.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RiwayatView riwayat = new RiwayatView();
            riwayat.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Sudah di halaman akun
        }
    }
}

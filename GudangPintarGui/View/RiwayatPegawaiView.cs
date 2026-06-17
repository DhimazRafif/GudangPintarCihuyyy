using System;
using System.Windows.Forms;
using GudangPintarGui.ServiceGui;
using GudangPintarGui.Models;

namespace GudangPintarGui.View
{
    public partial class RiwayatPegawaiView : Form
    {
        private readonly StockHistoryService _historyService;
        private readonly User _user;

        public RiwayatPegawaiView()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _historyService = new StockHistoryService();
        }

        private void RiwayatPegawaiView_Load(object sender, EventArgs e)
        {
            LoadRiwayat();
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
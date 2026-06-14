using System;
using System.Data;
using System.Windows.Forms;
using GudangPintarGui.ServiceGui;
using GudangPintarGui.Models;

namespace GudangPintarGui.View
{
    public partial class InputBarangView : Form
    {
        public StockGuiModel BarangHasilInput { get; private set; }

        private readonly BarangGuiService _guiService = new BarangGuiService();
        private bool _isEditMode = false;
        private int _editingBarangId = 0;

        public InputBarangView()
        {
            InitializeComponent();
            SetupValidation();
            LoadKategori();
        }

        private void SetupValidation()
        {
            // Mengatur batasan nilai untuk numeric up-down controls
            numHarga.Minimum = 0;
            numHarga.Maximum = 1_000_000_000;

            numThreshold.Minimum = 0;
            numThreshold.Maximum = 999_999;

            numJumlah.Minimum = 0;
            numJumlah.Maximum = 999_999;
        }

        // Mengisi form dengan data barang yang akan diedit. Stok dikunci untuk menjaga integritas history transaksi.
        public void SetEditMode(int id, string nama, int katId, double harga, int threshold, int jumlah)
        {
            _isEditMode = true;
            _editingBarangId = id;

            txtNamaBarang.Text = nama;
            cmbKategori.SelectedValue = katId;
            numHarga.Value = (decimal)harga;
            numThreshold.Value = threshold;
            numJumlah.Value = jumlah;

            numJumlah.Enabled = false;

            this.Text = "Edit Data Barang";
        }

        private void LoadKategori()
        {
            try
            {
                DataTable dtKategori = _guiService.AmbilDaftarKategori();
                cmbKategori.DataSource = dtKategori;
                cmbKategori.DisplayMember = "name";
                cmbKategori.ValueMember = "categoryid";
                cmbKategori.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat kategori: {ex.Message}", "System Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Validasi Form (Fail-Fast Principle)
                if (string.IsNullOrWhiteSpace(txtNamaBarang.Text))
                    throw new ArgumentException("Nama barang wajib diisi.");

                if (cmbKategori.SelectedValue == null)
                    throw new ArgumentException("Pilih kategori barang terlebih dahulu.");

                // 2. Validasi Unik Nama Barang
                string namaInput = txtNamaBarang.Text.Trim();
                if (_guiService.ApakahNamaBarangAda(namaInput, _isEditMode ? _editingBarangId : -1))
                    throw new InvalidOperationException("Nama barang sudah terdaftar. Gunakan nama lain!");

                // 3. Validasi Nilai Numerik
                if (!_isEditMode && numJumlah.Value <= 0)
                    throw new ArgumentException("Stok awal harus lebih besar dari 0 untuk barang baru!");

                if (numHarga.Value <= 0)
                    throw new ArgumentException("Harga harus lebih besar dari 0.");

                if (numThreshold.Value <= 0)
                    throw new ArgumentException("Batas minimum stok harus lebih dari 0.");

                // 4. Jika semua validasi lolos, buat objek StockGuiModel untuk dikirim ke Form utama
                BarangHasilInput = new StockGuiModel(
                    namaInput,
                    Convert.ToInt32(cmbKategori.SelectedValue),
                    (int)numJumlah.Value,
                    (double)numHarga.Value,
                    (int)numThreshold.Value
                );

                if (_isEditMode) BarangHasilInput.BarangId = _editingBarangId;

                // 5. Set DialogResult dan tutup form
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validasi Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Tombol batal hanya menutup form tanpa mengubah DialogResult, sehingga Form utama tahu bahwa operasi dibatalkan.
        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
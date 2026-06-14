using System;
using System.Data;
using System.Windows.Forms;
using GudangPintarGui.ServiceGui;

namespace GudangPintarGui.View
{
    public partial class InputBarangView : Form
    {
        public StockGuiModel BarangHasilInput { get; private set; }

        private readonly BarangGuiService _guiService = new BarangGuiService();

        public InputBarangView()
        {
            InitializeComponent();
            SetupValidation();
            LoadKategori();
        }

        private void SetupValidation()
        {
            numHarga.Minimum = 0;
            numThreshold.Minimum = 0;
            numJumlah.Minimum = 0;
            numHarga.Maximum = 1_000_000_000; 
        }

        private void LoadKategori()
        {
            // ini untuk memuat daftar kategori dari database dan menampilkan di ComboBox dengan penanganan error yang lebih baik
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
                MessageBox.Show($"Gagal memuat kategori: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                // ini validasi input sebelum membuat model, dengan pesan error yang lebih spesifik untuk setiap kasus
                if (string.IsNullOrWhiteSpace(txtNamaBarang.Text))
                    throw new Exception("Nama barang wajib diisi.");

                if (cmbKategori.SelectedValue == null)
                    throw new Exception("Pilih kategori barang terlebih dahulu.");

                // Inisialisasi Model
                BarangHasilInput = new StockGuiModel(
                    txtNamaBarang.Text.Trim(),
                    Convert.ToInt32(cmbKategori.SelectedValue),
                    (int)numJumlah.Value,
                    (double)numHarga.Value,
                    (int)numThreshold.Value
                );

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validasi Input",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
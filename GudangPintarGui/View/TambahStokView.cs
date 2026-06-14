using System;
using System.Data;
using System.Windows.Forms;
using GudangPintarGui.ServiceGui;

namespace GudangPintarGui.View
{
    public partial class TambahStokView : Form
    {
        private readonly BarangGuiService _guiService;
        private readonly int _barangId;

        public int SupplierId { get; private set; }
        public int Jumlah { get; private set; }

        public TambahStokView(int barangId, string namaBarang)
        {
            InitializeComponent(); 

            _guiService = new BarangGuiService();
            _barangId = barangId;

            // Sekarang numJumlah sudah aman untuk diakses
            lblNamaBarang.Text = $"Barang: {namaBarang}";
            numJumlah.Minimum = 1;
            numJumlah.Maximum = 9999;
            numJumlah.Value = 1;

            LoadSupplier();
        }

        private void LoadSupplier()
        {
            try
            {
                // ini untuk memuat daftar supplier dari database dan menampilkan di ComboBox dengan penanganan error yang lebih baik
                DataTable dtSupplier = _guiService.AmbilDaftarSupplier();
                if (dtSupplier != null && dtSupplier.Rows.Count > 0)
                {
                    cmbSupplier.DataSource = dtSupplier;
                    cmbSupplier.DisplayMember = "name";
                    cmbSupplier.ValueMember = "supplierid";
                    cmbSupplier.SelectedIndex = -1; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat daftar supplier: {ex.Message}", "System Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                // validasi input sebelum menyimpan, dengan pesan error yang lebih spesifik untuk setiap kasus
                if (cmbSupplier.SelectedValue == null)
                    throw new Exception("Silakan pilih supplier terlebih dahulu!");

                if (numJumlah.Value <= 0)
                    throw new Exception("Jumlah tambahan harus lebih dari 0!");

                // ini untuk menginisialisasi properti SupplierId dan Jumlah dengan nilai yang valid sebelum menutup form dengan DialogResult.OK
                SupplierId = Convert.ToInt32(cmbSupplier.SelectedValue);
                Jumlah = (int)numJumlah.Value;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validasi Gagal",
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
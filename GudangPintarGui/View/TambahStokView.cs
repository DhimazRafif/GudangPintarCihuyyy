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
        private bool _isModeKurangi = false;

        public int SupplierId { get; private set; }
        public int Jumlah { get; private set; }

        // Konstruktor untuk inisialisasi form dengan data barang yang akan ditambah atau dikurangi stoknya.
        public TambahStokView(int barangId, string namaBarang)
        {
            InitializeComponent();
            _guiService = new BarangGuiService();
            _barangId = barangId;

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
                // Mengambil daftar supplier dari database dan mengisi ComboBox. Jika terjadi error, tampilkan pesan yang jelas kepada user.
                DataTable dtSupplier = _guiService.AmbilDaftarSupplier();
                if (dtSupplier != null)
                {
                    cmbSupplier.DataSource = dtSupplier;
                    cmbSupplier.DisplayMember = "name";
                    cmbSupplier.ValueMember = "supplierid";
                    cmbSupplier.SelectedIndex = -1; // Memaksa user untuk memilih
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat supplier: {ex.Message}", "System Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Metode untuk mengubah form menjadi mode pengurangan stok. Menyesuaikan UI dan logika validasi sesuai kebutuhan.
        public void SetModeKurangi()
        {
            _isModeKurangi = true;
            this.Text = "Kurangi Stok Barang";

            if (lblHeader != null) lblHeader.Text = "Kurangi Stok Barang";
            lblJumlah.Text = "Jumlah dikurangi:";

            // Menyembunyikan elemen UI yang tidak relevan untuk mode pengurangan stok (Best Practice untuk UX yang lebih baik)
            if (lblSupplier != null) lblSupplier.Visible = false;
            if (cmbSupplier != null) cmbSupplier.Visible = false;

            // Menyesuaikan posisi elemen UI untuk menjaga tata letak yang rapi setelah menyembunyikan elemen supplier
            if (lblSupplier != null) lblJumlah.Top = lblSupplier.Top;
            if (cmbSupplier != null) numJumlah.Top = cmbSupplier.Top;
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_isModeKurangi)
                {
                    if (cmbSupplier.SelectedValue == null)
                        throw new ArgumentException("Silakan pilih supplier terlebih dahulu!");

                    SupplierId = Convert.ToInt32(cmbSupplier.SelectedValue);
                }
                else
                {
                    SupplierId = 0; 
                }

                // Validasi Jumlah
                if (numJumlah.Value <= 0)
                    throw new ArgumentException("Jumlah harus lebih dari 0!");

                Jumlah = (int)numJumlah.Value;

                // Konfirmasi Aksi
                string aksi = _isModeKurangi ? "mengurangi" : "menambah";
                var dr = MessageBox.Show($"Apakah Anda yakin ingin {aksi} stok sebanyak {Jumlah}?",
                    "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
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
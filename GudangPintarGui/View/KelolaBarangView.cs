using System;
using System.Windows.Forms;
using GudangPintarGui.ControllerGui;
using GudangPintarGui.ServiceGui;
using GudangPintarGui.Models;

namespace GudangPintarGui.View
{
    public partial class KelolaBarangView : Form
    {
        private readonly BarangGuiService _guiService;
        private readonly BarangGuiController _guiController;
        private int _idBarangTerpilih = -1;

        public KelolaBarangView()
        {
            InitializeComponent();
            _guiService = new BarangGuiService();
            _guiController = new BarangGuiController();
        }

        private void KelolaBarangView_Load(object sender, EventArgs e) => RefreshTabel();

        private void RefreshTabel()
        {
            try
            {
                dgvBarang.Rows.Clear();
                var daftarBarang = _guiService.AmbilBarangSiapTampil();

                foreach (var barang in daftarBarang)
                {
                    int index = dgvBarang.Rows.Add(
                        barang.NamaBarang,
                        barang.CategoryId,
                        barang.Jumlah,
                        barang.Harga,
                        barang.NotificationThreshold
                    );
                    // ID disimpan di Tag untuk akses backend yang aman
                    dgvBarang.Rows[index].Tag = barang.BarangId;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ResetPilihan();
        }

        private void btnBukaTambah_Click(object sender, EventArgs e)
        {
            using (InputBarangView popUp = new InputBarangView())
            {
                // Setelah mendapatkan data dari pop-up, buat command untuk menambahkan barang baru ke database, dengan penanganan error yang lebih baik
                if (popUp.ShowDialog() == DialogResult.OK)
                {
                    ICommand cmdTambah = new TambahBarangCommand(popUp.BarangHasilInput, 1);
                    if (_guiController.JalankanPerintah(cmdTambah, out string pesan))
                    {
                        MessageBox.Show(pesan, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshTabel();
                    }
                }
            }
        }

        private void btnTambahStok_Click(object sender, EventArgs e)
        {
            if (_idBarangTerpilih == -1)
            {
                MessageBox.Show("Silakan pilih barang di tabel!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string namaBarang = dgvBarang.CurrentRow.Cells[0].Value.ToString();
            using (TambahStokView formStok = new TambahStokView(_idBarangTerpilih, namaBarang))
            {
                // Setelah mendapatkan data dari pop-up, buat command untuk menambahkan stok baru ke database, dengan penanganan error yang lebih baik
                if (formStok.ShowDialog() == DialogResult.OK)
                {
                    ICommand cmdStok = new TambahStokCommand(_idBarangTerpilih, formStok.SupplierId, formStok.Jumlah, 1);
                    if (_guiController.JalankanPerintah(cmdStok, out string pesan))
                    {
                        MessageBox.Show(pesan, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshTabel();
                    }
                }
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (_idBarangTerpilih == -1)
            {
                MessageBox.Show("Silakan pilih barang yang akan dihapus!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Konfirmasi sebelum menghapus (mengarsipkan) barang
            if (MessageBox.Show("Yakin ingin menghapus (mengarsipkan) barang ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ICommand cmdHapus = new HapusBarangCommand(_idBarangTerpilih);
                if (_guiController.JalankanPerintah(cmdHapus, out string pesan))
                {
                    MessageBox.Show(pesan, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshTabel();
                }
            }
        }

        // ini akan dipanggil setiap kali teks di txtCariNama berubah, untuk melakukan pencarian barang berdasarkan nama secara real-time
        private void txtCariNama_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtCariNama.Text.Trim();

            // jika keyword kosong, tampilkan semua barang, jika tidak, cari barang berdasarkan nama yang mengandung keyword, dengan penanganan error yang lebih baik
            List<StockGuiModel> hasilPencarian;
            if (string.IsNullOrEmpty(keyword))
            {
                hasilPencarian = _guiService.AmbilBarangSiapTampil();
            }
            else
            {
                hasilPencarian = _guiService.CariBarang(keyword);
            }

            // ini untuk menampilkan hasil pencarian di DataGridView, dengan menyimpan ID barang di Tag untuk operasi selanjutnya
            dgvBarang.Rows.Clear();
            foreach (var barang in hasilPencarian)
            {
                int index = dgvBarang.Rows.Add(
                    barang.NamaBarang,
                    barang.CategoryId,
                    barang.Jumlah,
                    barang.Harga,
                    barang.NotificationThreshold
                );
                dgvBarang.Rows[index].Tag = barang.BarangId;
            }
        }

        // Saat pengguna klik pada baris di DataGridView, simpan ID barang yang dipilih untuk operasi selanjutnya (tambah stok atau hapus)
        private void dgvBarang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvBarang.Rows[e.RowIndex].Tag != null)
            {
                _idBarangTerpilih = (int)dgvBarang.Rows[e.RowIndex].Tag;
            }
        }

        // Reset pilihan ID barang terpilih saat data di-refresh untuk mencegah operasi pada barang yang sudah tidak ada atau berubah
        private void ResetPilihan() => _idBarangTerpilih = -1;
        private void btnRefresh_Click(object sender, EventArgs e) => RefreshTabel();
    }
}
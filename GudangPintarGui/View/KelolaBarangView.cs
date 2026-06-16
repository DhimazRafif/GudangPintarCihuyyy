using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GudangPintarGui.ControllerGui;
using GudangPintarGui.ServiceGui;
using GudangPintarGui.Models;

namespace GudangPintarGui.View
{
    public partial class KelolaBarangView : Form
    {
        private readonly BarangGuiService _guiService;
        private readonly CommandInvoker _invoker;
        private int _idBarangTerpilih = -1;
        private readonly User _user;

        public KelolaBarangView(User user)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            _user = user;
            _guiService = new BarangGuiService();
            _invoker = new CommandInvoker();
        }

        private void KelolaBarangView_Load(object sender, EventArgs e) => RefreshTabel();

        private void RefreshTabel()
        {
            // Mengambil data barang siap tampil dari service dan menampilkannya di DataGridView.
            try
            {
                dgvBarang.Rows.Clear();
                var daftarBarang = _guiService.AmbilBarangSiapTampil();

                int totalJenis = daftarBarang.Count;
                int totalStok = 0;

                foreach (var barang in daftarBarang)
                {
                    int index = dgvBarang.Rows.Add(
                        barang.NamaBarang,
                        barang.CategoryId,
                        barang.Jumlah,
                        barang.Harga,
                        barang.NotificationThreshold
                    );
                    dgvBarang.Rows[index].Tag = barang.BarangId;

                    totalStok += barang.Jumlah;
                }

                lblTotalBarang.Text = totalJenis.ToString();
                lblTotalStok.Text = totalStok.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ResetPilihan();
        }

        // Metode untuk mengeksekusi command dan menampilkan hasilnya kepada user, serta menyegarkan tabel jika operasi berhasil.
        private void ExecuteCommand(ICommand command)
        {
            if (_invoker.Execute(command, out string pesan))
            {
                MessageBox.Show(pesan, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshTabel();
            }
            else
            {
                MessageBox.Show(pesan, "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBukaTambah_Click(object sender, EventArgs e)
        {
            using (var popUp = new InputBarangView())
            {
                if (popUp.ShowDialog() == DialogResult.OK)
                {
                    ExecuteCommand(new TambahBarangCommand(popUp.BarangHasilInput, 1));
                }
            }
        }

        private void btnEditBarang_Click(object sender, EventArgs e)
        {
            if (_idBarangTerpilih == -1)
            {
                MessageBox.Show("Pilih barang yang ingin diedit!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mengambil data dari baris yang dipilih untuk mengisi form edit.
            var row = dgvBarang.CurrentRow;
            using (var editForm = new InputBarangView())
            {
                editForm.SetEditMode(_idBarangTerpilih,
                                     row.Cells[0].Value.ToString(),
                                     Convert.ToInt32(row.Cells[1].Value),
                                     Convert.ToDouble(row.Cells[3].Value),
                                     Convert.ToInt32(row.Cells[4].Value),
                                     Convert.ToInt32(row.Cells[2].Value));

                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    var m = editForm.BarangHasilInput;
                    ExecuteCommand(new UbahBarangCommand(_idBarangTerpilih, m.NamaBarang, m.CategoryId, m.Harga, m.NotificationThreshold));
                }
            }
        }

        private void btnTambahStok_Click(object sender, EventArgs e)
        {
            if (_idBarangTerpilih == -1) return;

            // Mengambil nama barang dari baris yang dipilih untuk menampilkan di form tambah stok.
            string namaBarang = dgvBarang.CurrentRow.Cells[0].Value.ToString();
            using (var formStok = new TambahStokView(_idBarangTerpilih, namaBarang))
            {
                if (formStok.ShowDialog() == DialogResult.OK)
                {
                    ExecuteCommand(new TambahStokCommand(_idBarangTerpilih, formStok.SupplierId, formStok.Jumlah, _user.UserId));
                }
            }
        }

        private void btnKurangStock_Click(object sender, EventArgs e)
        {
            if (_idBarangTerpilih == -1) return;

            string namaBarang = dgvBarang.CurrentRow.Cells[0].Value.ToString();
            using (var formKurang = new TambahStokView(_idBarangTerpilih, namaBarang))
            {
                formKurang.SetModeKurangi();
                if (formKurang.ShowDialog() == DialogResult.OK)
                {
                    ExecuteCommand(new KurangiStokCommand(_idBarangTerpilih, formKurang.Jumlah, _user.UserId));
                }
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            // Memastikan bahwa ada barang yang dipilih sebelum mencoba mengarsipkannya, dan menampilkan konfirmasi kepada user.
            if (_idBarangTerpilih == -1) return;

            if (MessageBox.Show("Yakin ingin mengarsipkan barang ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ExecuteCommand(new HapusBarangCommand(_idBarangTerpilih));
            }
        }

        private void txtCariNama_TextChanged(object sender, EventArgs e)
        {
            // Mengambil keyword dari textbox pencarian dan menampilkan hasil pencarian di DataGridView. Jika keyword kosong, tampilkan semua barang.
            string keyword = txtCariNama.Text.Trim();
            List<StockGuiModel> hasil = string.IsNullOrEmpty(keyword) ? _guiService.AmbilBarangSiapTampil() : _guiService.CariBarang(keyword);

            dgvBarang.Rows.Clear();
            foreach (var barang in hasil)
            {
                // Menambahkan baris ke DataGridView untuk setiap barang yang ditemukan, dan menyimpan ID barang di properti Tag untuk referensi selanjutnya.
                int index = dgvBarang.Rows.Add(barang.NamaBarang, barang.CategoryId, barang.Jumlah, barang.Harga, barang.NotificationThreshold);
                dgvBarang.Rows[index].Tag = barang.BarangId;
            }
        }

        private void dgvBarang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Menyimpan ID barang yang dipilih berdasarkan baris yang diklik, sehingga operasi selanjutnya (edit, tambah stok, dll) tahu barang mana yang sedang dipilih.
            if (e.RowIndex >= 0 && dgvBarang.Rows[e.RowIndex].Tag != null)
                _idBarangTerpilih = (int)dgvBarang.Rows[e.RowIndex].Tag;
        }

        private void ResetPilihan() => _idBarangTerpilih = -1;
        private void btnRefresh_Click(object sender, EventArgs e) => RefreshTabel();

        private void button2_Click(object sender, EventArgs e)
        {
            // Sudah di halaman barang
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var userService = new GudangPintarGui.ServiceGUI.UserService();
            var akunController = new AkunController(userService);

            PengelolahanAkun akun = new PengelolahanAkun(akunController);
            akun.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RiwayatView riwayat = new RiwayatView();
            riwayat.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
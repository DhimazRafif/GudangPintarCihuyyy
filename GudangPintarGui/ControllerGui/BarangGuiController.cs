using System;
using GudangPintarGui.ControllerGui;

namespace GudangPintarGui.ControllerGui
{
    public class BarangGuiController
    {
        //         private readonly CommandInvoker _commandInvoker;
        public bool JalankanPerintah(ICommand perintah, out string pesanHasil)
        {
            if (perintah == null)
            {
                pesanHasil = "Perintah tidak valid atau null.";
                return false;
            }

            try
            {
                // Eksekusi langsung melalui kontrak ICommand
                return perintah.Execute(out pesanHasil);
            }
            catch (Exception ex)
            {
                // Penanganan error tingkat atas agar UI tidak crash
                pesanHasil = $"Terjadi kesalahan sistem pada eksekusi perintah: {ex.Message}";
                return false;
            }
        }

        // Validasi input untuk operasi terkait barang, seperti tambah atau edit
        public bool ValidasiInputBarang(string nama, int jumlah, double harga, out string pesanError)
        {
            pesanError = string.Empty;

            if (string.IsNullOrWhiteSpace(nama))
            {
                pesanError = "Nama barang tidak boleh kosong!";
                return false;
            }

            // Validasi karakter ilegal untuk mencegah SQL Injection atau XSS
            if (nama.IndexOfAny(new char[] { '\'', ';', '-', '<', '>' }) >= 0)
            {
                pesanError = "Nama barang mengandung karakter ilegal!";
                return false;
            }

            if (jumlah < 0)
            {
                pesanError = "Jumlah barang tidak boleh negatif!";
                return false;
            }

            if (harga < 0)
            {
                pesanError = "Harga barang tidak boleh bernilai negatif!";
                return false;
            }

            return true;
        }
    }
}
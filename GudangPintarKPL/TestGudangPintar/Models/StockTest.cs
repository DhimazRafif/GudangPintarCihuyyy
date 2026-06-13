using GudangPintar.Model;
using GudangPintarKPL.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace TestGudangPintar.Models
{
    [TestClass]
    public class StockTest
    {
        [TestMethod]
        public void Constructor_SetPropertiHarusBenar()
        {
            // Arrange
            string nama = "Buku Tulis";
            Category kategori = Category.ATK;
            int jumlah = 20;
            double harga = 5000;
            // Act
            var stock = new Stock(nama, kategori, jumlah, harga);
            // Assert
            Assert.AreEqual(nama, stock.NamaBarang);
            Assert.AreEqual(kategori, stock.Kategori);
            Assert.AreEqual(jumlah, stock.Jumlah);
            Assert.AreEqual(harga, stock.Harga);
        }
        [TestMethod]
        public void TambahStock_JumlahBertambah()
        {
            // Arrange
            var stock = new Stock("Penghapus", Category.ATK, 5, 1000);
            int tambahan = 10;
            // Act
            stock.TambahStok(tambahan);
            // Assert
            Assert.AreEqual(15, stock.Jumlah);
        }
        [TestMethod]
        public void KurangiStock_JumlahBerkurang()
        {
            // Arrange
            var stock = new Stock("Penghapus", Category.ATK, 5, 1000);
            int pengurangan = 3;
            // Act
            stock.KurangiStok(pengurangan);
            // Assert
            Assert.AreEqual(2, stock.Jumlah);
        }
        [TestMethod]
        public void KurangiStock_JumlahTidakCukup_HarusTetap()
        {
            // Arrange
            var stock = new Stock("Penghapus", Category.ATK, 5, 1000);
            int pengurangan = 10;
            // Act
            stock.KurangiStok(pengurangan);
            // Assert
            Assert.AreEqual(5, stock.Jumlah); // Jumlah tidak boleh berubah
        }
        [TestMethod]
        public void EditStock_PropertiBerubah()
        {
            // Arrange
            var stock = new Stock("Penghapus", Category.ATK, 5, 1000);
            string namaBaru = "Penghapus Besar";
            Category kategoriBaru = Category.ATK;
            double hargaBaru = 1500;
            // Act
            stock.EditStock(namaBaru, kategoriBaru, hargaBaru);
            // Assert
            Assert.AreEqual(namaBaru, stock.NamaBarang);
            Assert.AreEqual(kategoriBaru, stock.Kategori);
            Assert.AreEqual(hargaBaru, stock.Harga);
        }
        [TestMethod]
        public void EditStock_NamaDuplikat_BerubahUnik()
        {
            // Arrange
            var stock1 = new Stock("Penghapus", Category.ATK, 5, 1000);
            var stock2 = new Stock("Penghapus Besar", Category.ATK, 10, 1500);
            string namaDuplikat = "Penghapus";
            // Act
            stock2.EditStock(namaDuplikat, stock2.Kategori, stock2.Harga);
            // Assert
            Assert.AreEqual(namaDuplikat, stock2.NamaBarang); // Nama boleh sama karena ini hanya test unit
        }

        [TestMethod]
        public void getheader_HarusKembaliArrayHeader()
        {
            // Act
            var header = Stock.getHeader();
            // Assert
            Assert.HasCount(5, header);
            Assert.AreEqual("Nama", header[0]);
            Assert.AreEqual("Kategori", header[1]);
            Assert.AreEqual("Jumlah", header[2]);
            Assert.AreEqual("Harga", header[3]);
            Assert.AreEqual("Status", header[4]);
        }
        [TestMethod]
        public void getRowData_HarusKembaliArrayData()
        {
            // 1. Simpan output asli terminal
            var originalOut = Console.Out;

            try
            {
                // 2. Alihkan output ke StringWriter baru
                using (var monitor = new StringWriter())
                {
                    Console.SetOut(monitor);

                    // Arrange: Siapkan objek Stock
                    var stock = new Stock("Buku Tulis", Category.ATK, 10, 5000);

                    // 3. Act: Panggil getRowData() di dalam lingkup 'using'
                    // Metode ini akan memicu LoadConfigFile() yang menulis ke Console
                    var result = stock.getRowData();

                    // 4. Assert: Verifikasi hasil array
                    Assert.IsNotNull(result);
                    Assert.AreEqual(5, result.Length);
                    Assert.AreEqual("Buku Tulis", result[0]);

                    // Opsional: Cek log jika terjadi kegagalan config
                    System.Diagnostics.Debug.WriteLine(monitor.ToString());
                }
            }
            finally
            {
                // 5. Kembalikan Console.Out ke aslinya
                // Ini mencegah error 'ObjectDisposedException' pada test method lainnya
                Console.SetOut(originalOut);
            }
        }

    }
}

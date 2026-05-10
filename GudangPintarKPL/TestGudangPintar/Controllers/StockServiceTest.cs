using GudangPintar.Controllers;
using GudangPintar.Model;
using GudangPintarKPL.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace TestGudangPintar.Controllers
{
    [TestClass]
    public class StockServiceTests
    {
        private StockService _service;

        [TestInitialize]
        public void Setup()
        {
            // Inisialisasi service baru setiap kali test dijalankan
            _service = new StockService();
        }
        [TestMethod]
        public void Add_BarangBaru_HarusBerhasil()
        {
            // Arrange
            var baru = new Stock("Pulpen", Category.ATK, 10, 2000);
            // Act
            bool hasil = _service.Add(baru);

            // Assert
            Assert.IsTrue(hasil);
            Assert.AreEqual(1, _service.GetAll().Count);
        }
        [TestMethod]
        public void Add_NamaDuplikat_HarusGagal()
        {
            // Arrange
            _service.Add(new Stock("Penghapus", Category.ATK, 5, 1000));
            var duplikat = new Stock("Penghapus", Category.ATK, 10, 2000);

            // Act
            bool hasil = _service.Add(duplikat);

            // Assert
            Assert.IsFalse(hasil);
            Assert.AreEqual(1, _service.GetAll().Count); // Jumlah tidak boleh bertambah
        }
        [TestMethod]
        public void Delete_BarangAda_HarusTerhapus()
        {
            // Arrange
            _service.Add(new Stock("Minyak", Category.ATK, 4, 1000));

            // Act
            bool hasil = _service.Delete("Minyak");

            // Assert
            Assert.IsTrue(hasil);
            Assert.IsNull(_service.Get("Minyak"));
        }
        [TestMethod]
        public void Delete_BarangTidakAda_HarusGagal()
        {
            // Act
            bool hasil = _service.Delete("NonExistent");
            // Assert
            Assert.IsFalse(hasil);
        }
        [TestMethod]
        public void Update_BarangAda_HarusTerupdate()
        {
            // Arrange
            _service.Add(new Stock("Minyak", Category.ATK, 3, 1000));
            // Act
            _service.Update("Minyak", "Minyak 4L", Category.ATK, 1500);
            // Assert
            var barang = _service.Get("Minyak 4L");
            Assert.IsNotNull(barang);
            Assert.AreEqual(Category.ATK, barang.Kategori);
            Assert.AreEqual(1500, barang.Harga);
        }
        [TestMethod]
        public void Update_NamaDuplikat_HarusGagal()
        {
            // Arrange
            _service.Add(new Stock("Pulpen", Category.ATK, 2, 1000));
            _service.Add(new Stock("Pensil", Category.ATK, 1, 500));
            // Act
            _service.Update("Pulpen", "Pensil", Category.ATK, 500); // Coba ganti nama Pulpen jadi Pensil yang sudah ada
            // Assert
            var pulpen = _service.Get("Pulpen");
            var pensil = _service.Get("Pensil");
            Assert.IsNotNull(pulpen); // Pulpen tetap ada
            Assert.IsNotNull(pensil); // Pensil tetap ada
        }
        [TestMethod]
        public void Update_BarangTidakAda_HarusGagal()
        {
            // Act
            _service.Update("NonExistent", "BarangBaru", Category.ATK, 1000);
            // Assert
            var barang = _service.Get("BarangBaru");
            Assert.IsNull(barang); // Barang baru tidak boleh muncul karena update gagal
        }
        [TestMethod]
        public void TambahStok_InputPositif_HarusBertambah()
        {
            // Arrange
            _service.Add(new Stock("Kerupuk", Category.Sembako, 5, 1000));

            // Act
            bool hasil = _service.TambahStok("Kerupuk", 3);
            var barang = _service.Get("Kerupuk");
            // Assert
            Assert.IsTrue(hasil);
            Assert.AreEqual(8, barang.Jumlah);
        }
        [TestMethod]
        public void TambahStok_InputNegatif_HarusGagal()
        {
            // Arrange
            _service.Add(new Stock("Kerupuk", Category.Sembako, 5, 1000));
            // Act
            bool hasil = _service.TambahStok("Kerupuk", -2); // Coba tambah stok dengan angka negatif
            var barang = _service.Get("Kerupuk");
            // Assert
            Assert.IsFalse(hasil);
            Assert.AreEqual(5, barang.Jumlah); // Stok tidak boleh berubah
        }
        [TestMethod]
        public void TambahStok_BarangTidakAda_HarusGagal()
        {
            // Act
            bool hasil = _service.TambahStok("NonExistent", 5); // Coba tambah stok untuk barang yang tidak ada
            // Assert
            Assert.IsFalse(hasil);
        }
        [TestMethod]
        public void KurangiStok_MelebihiBatas_HarusGagal()
        {
            // Arrange
            _service.Add(new Stock("Sapu", Category.ATK, 2, 1000));

            // Act
            bool hasil = _service.KurangiStok("Sapu", 5); // Kurangi 5 padahal stok cuma 2

            // Assert
            Assert.IsFalse(hasil);
            Assert.AreEqual(2, _service.Get("Sapu").Jumlah); // Stok tetap
        }
        [TestMethod]
        public void KurangiStok_Cukup_HarusBerkurang()
        {
            // Arrange
            _service.Add(new Stock("Sapu", Category.ATK, 5, 1000));
            // Act
            bool hasil = _service.KurangiStok("Sapu", 3); // Kurangi 3 dari 5
            // Assert
            Assert.IsTrue(hasil);
            Assert.AreEqual(2, _service.Get("Sapu").Jumlah); // Stok harus berkurang menjadi 2
        }
        [TestMethod]
        public void Get_BarangAda_HarusDitemukan()
        {
            // Arrange
            _service.Add(new Stock("Gula", Category.Sembako, 10, 5000));
            // Act
            var barang = _service.Get("Gula");
            // Assert
            Assert.IsNotNull(barang);
            Assert.AreEqual("Gula", barang.NamaBarang);
        }
        [TestMethod]
        public void Get_BarangTidakAda_HarusNull()
        {
            // Act
            var barang = _service.Get("NonExistent");
            // Assert
            Assert.IsNull(barang);
        }

    }
}
using GudangPintar.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestGudangPintar.Models
{
    [TestClass]
    public class StockHistoryTests
    {
        [TestMethod]
        public void Constructor_MengisiPropertiDenganBenar()
        {
            // Arrange
            string nama = "Laptop";
            string aksi = "Tambah";
            int jumlah = 10;
            string user = "admin";

            // Act
            var history = new StockHistory(nama, aksi, jumlah, user);

            // Assert
            Assert.AreEqual(nama, history.NamaBarang);
            Assert.AreEqual(aksi, history.Aksi);
            Assert.AreEqual(jumlah, history.Jumlah);
            Assert.AreEqual(user, history.UserPelaku);
        }

        [TestMethod]
        public void Constructor_TanggalDiisiOtomatisDenganWaktuSekarang()
        {
            // Arrange
            DateTime sebelum = DateTime.Now;

            // Act
            var history = new StockHistory("Test", "Tambah", 1, "admin");
            DateTime sesudah = DateTime.Now;

            // Assert
            Assert.IsTrue(history.Tanggal >= sebelum);
            Assert.IsTrue(history.Tanggal <= sesudah);
        }

        [TestMethod]
        public void Tampilkan_MencetakKeKonsol_TidakThrowException()
        {
            // Arrange
            var history = new StockHistory("Monitor", "Kurang", 2, "user");

            // Act & Assert - Pastikan tidak exception saat dipanggil
            try
            {
                history.Tampilkan();
                Assert.IsTrue(true); // Berhasil jika sampai sini
            }
            catch (Exception ex)
            {
                Assert.Fail($"Seharusnya tidak error: {ex.Message}");
            }
        }

        [TestMethod]
        public void GetHeader_MengembalikanHeaderYangBenar()
        {
            // Arrange
            string[] expected = { "Waktu", "Barang", "Aksi", "Jumlah", "User" };

            // Act
            string[] actual = StockHistory.getHeader();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetRowData_MengembalikanDataHistoryDalamArray()
        {
            // Arrange
            var fixedTime = new DateTime(2024, 1, 15, 10, 30, 0);
            var history = new StockHistory("Keyboard", "Tambah", 3, "budi");

            // Gunakan reflection untuk mengganti Tanggal (atau buat properti setter)
            typeof(StockHistory).GetProperty(nameof(StockHistory.Tanggal))
                ?.SetValue(history, fixedTime);

            string[] expected = { "15/01/2024 10:30", "Keyboard", "Tambah", "3", "budi" };

            // Act
            string[] actual = history.getRowData();

            // Assert
            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void GetRowData_JumlahNegatif_TetapTercetak()
        {
            // Arrange
            var history = new StockHistory("Item Rusak", "Kurang", -5, "admin");

            // Act
            string[] actual = history.getRowData();

            // Assert - Nilai negatif tetap ditampilkan
            Assert.AreEqual("-5", actual[3]);
        }
    }
}
using GudangPintar.Model;

namespace TestGudangPintar.Controllers
{
    [TestClass]
    public class NotificationTest
    {
        [TestMethod]
        public void TestGetNotifikasi_StockBanyak_Aman()
        {
            // Arrange
            var stock = new Stock("Buku", Category.ATK, 20, 2000);
            var expectedMessage = "[AMAN]";
            // Act
            var result = Notification.GetNotifikasi(stock);
            // Assert
            Assert.AreEqual(expectedMessage, result);
        }
        [TestMethod]
        public void TestGetNotifikasi_StockSedikit_Menipis()
        {
            // Arrange
            var stock = new Stock("Penghapus", Category.ATK, 5, 1000);
            var expectedMessage = "[MENIPIS]";
            // Act
            var result = Notification.GetNotifikasi(stock);
            // Assert
            Assert.AreEqual(expectedMessage, result);
        }
        [TestMethod]
        public void TestGetNotifikasi_StockHabis_Habis()
        {
            // Arrange
            var stock = new Stock("Pensil", Category.ATK, 0, 500);
            var expectedMessage = "[HABIS]";
            // Act
            var result = Notification.GetNotifikasi(stock);
            // Assert
            Assert.AreEqual(expectedMessage, result);
        }
        [TestMethod]
        public void TestGetNotifikasi_SetelahStokDikurangi_StatusHarusBerubah()
        {
            // Arrange
            // Mulai dengan kondisi Aman (10)
            var stock = new Stock("Buku", Category.ATK, 10, 500000);

            // Act 1: Cek status awal
            string statusAwal = Notification.GetNotifikasi(stock);

            // Act 2: Kurangi stok sampai jadi "Menipis" (< 10)
            stock.KurangiStok(5);
            string statusAkhir = Notification.GetNotifikasi(stock);

            // Assert
            Assert.AreEqual("[AMAN]", statusAwal);
            Assert.AreEqual("[MENIPIS]", statusAkhir);
        }
        [TestMethod]
        public void TestGetNotifikasi_SetelahStokDikurangiHabis_StatusHarusBerubah()
        {
            // Arrange
            // Mulai dengan kondisi Menipis (5)
            var stock = new Stock("Penghapus", Category.ATK, 5, 1000);
            // Act 1: Cek status awal
            string statusAwal = Notification.GetNotifikasi(stock);
            // Act 2: Kurangi stok sampai habis (0)
            stock.KurangiStok(5);
            string statusAkhir = Notification.GetNotifikasi(stock);
            // Assert
            Assert.AreEqual("[MENIPIS]", statusAwal);
            Assert.AreEqual("[HABIS]", statusAkhir);
        }
    }
}
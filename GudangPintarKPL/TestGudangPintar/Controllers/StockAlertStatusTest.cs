using GudangPintar.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestGudangPintar.Controllers
{
    [TestClass]
    public class StockAlertStatusTest
    {
        #region Test GetState (Logic)
        [TestMethod]
        public void TestGetState_Habis_HarusReturnHabis()
        {
            // Act
            var result = StockAlertStatus.GetState(0);

            // Assert
            Assert.AreEqual(AlertState.Habis, result);
        }

        [TestMethod]
        public void TestGetState_Menipis_HarusReturnMenipis()
        {
            // Mengetes angka di bawah 10 (tapi bukan 0)
            Assert.AreEqual(AlertState.Menipis, StockAlertStatus.GetState(1));
            Assert.AreEqual(AlertState.Menipis, StockAlertStatus.GetState(9));
            // Angka negatif juga akan masuk ke 'Menipis' berdasarkan if (jumlah < 10)
            Assert.AreEqual(AlertState.Menipis, StockAlertStatus.GetState(-1));
        }

        [TestMethod]
        public void TestGetState_Aman_HarusReturnAman()
        {
            // Mengetes angka 10 dan di atasnya
            Assert.AreEqual(AlertState.Aman, StockAlertStatus.GetState(10));
            Assert.AreEqual(AlertState.Aman, StockAlertStatus.GetState(100));
        }
        [TestMethod]
        public void TestGetMessage_NormalStates_HarusBerhasil()
        {
            // Arrange
            var sHabis = new Stock("Barang1", Category.ATK, 0, 100);
            var sMenipis = new Stock("Barang2", Category.ATK, 5, 100);
            var sAman = new Stock("Barang3", Category.ATK, 15, 100);

            // Act & Assert
            Assert.AreEqual("[HABIS]", StockAlertStatus.GetMessage(sHabis));
            Assert.AreEqual("[MENIPIS]", StockAlertStatus.GetMessage(sMenipis));
            Assert.AreEqual("[AMAN]", StockAlertStatus.GetMessage(sAman));
        }
    }
}
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
            Stock dummyStock = new Stock(1, "Pulpen", "ATK", 3500, 0);
            var result = StockAlertStatus.GetState(dummyStock);

            // Assert
            Assert.AreEqual(AlertState.Habis, result);
        }

        [TestMethod]
        public void TestGetState_Menipis_HarusReturnMenipis()
        {
            // Mengetes angka di bawah 10 (tapi bukan 0)
            Stock dummy1 = new Stock(1, "Pulpen", "ATK", 3500, 1);
            Stock dummy9 = new Stock(2, "Pensil", "ATK", 2500, 9);
            Stock dummyMinus = new Stock(3, "Buku", "ATK", 5000, -1);

            // Act & Assert
            Assert.AreEqual(AlertState.Menipis, StockAlertStatus.GetState(dummy1));
            Assert.AreEqual(AlertState.Menipis, StockAlertStatus.GetState(dummy9));
            Assert.AreEqual(AlertState.Menipis, StockAlertStatus.GetState(dummyMinus));
        }

        [TestMethod]
        public void TestGetState_Aman_HarusReturnAman()
        {
            // Mengetes angka 10 dan di atasnya
            Stock dummy10 = new Stock(1, "Pulpen", "ATK", 3500, 10);
            Stock dummy100 = new Stock(2, "Pensil", "ATK", 2500, 100);

            // Act & Assert
            Assert.AreEqual(AlertState.Aman, StockAlertStatus.GetState(dummy10));
            Assert.AreEqual(AlertState.Aman, StockAlertStatus.GetState(dummy100));
        }
        [TestMethod]
        public void TestGetMessage_NormalStates_HarusBerhasil()
        {
            // Arrange
            var sHabis = new Stock(1, "Barang1", "ATK", 100.0, 0);
            var sMenipis = new Stock(2, "Barang2", "ATK", 100.0, 5);
            var sAman = new Stock(3, "Barang3", "ATK", 100.0, 15);

            // Act & Assert
            Assert.AreEqual("[HABIS]", StockAlertStatus.GetMessage(sHabis));
            Assert.AreEqual("[MENIPIS]", StockAlertStatus.GetMessage(sMenipis));
            Assert.AreEqual("[AMAN]", StockAlertStatus.GetMessage(sAman));
        }
        #endregion
    }
}
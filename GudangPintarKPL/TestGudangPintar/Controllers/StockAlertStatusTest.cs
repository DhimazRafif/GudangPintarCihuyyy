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
    public class StockAlertStatusTest
    {
        [TestMethod]
        public void TestGetState_Habis()
        {
            // Arrange
            int jumlah = 0;
            // Act
            var result = StockAlertStatus.GetState(jumlah);
            // Assert
            Assert.AreEqual(AlertState.Habis, result);
        }
        [TestMethod]
        public void TestGetState_Menipis()
        {
            // Arrange
            int jumlah = 5;
            // Act
            var result = StockAlertStatus.GetState(jumlah);
            // Assert
            Assert.AreNotEqual(AlertState.Menipis, result);
        }
        [TestMethod]
        public void TestGetState_Aman()
        {
            // Arrange
            int jumlah = 15;
            // Act
            var result = StockAlertStatus.GetState(jumlah);
            // Assert
            Assert.AreEqual(AlertState.Aman, result);
        }
        [TestMethod]
        public void TestGetMessage_Formatting()
        {
            // Arrange
            var stockHabis = new Stock("Pensil", Category.ATK, 0, 500);
            var stockMenipis = new Stock("Penghapus", Category.ATK, 5, 1000);
            var stockAman = new Stock("Buku", Category.ATK, 20, 2000);
            // Act
            var messageHabis = StockAlertStatus.GetMessage(stockHabis);
            var messageMenipis = StockAlertStatus.GetMessage(stockMenipis);
            var messageAman = StockAlertStatus.GetMessage(stockAman);
            // Assert
            Assert.AreEqual("[HABIS]", messageHabis);
            Assert.AreEqual("[MENIPIS]", messageMenipis);
            Assert.AreEqual("[AMAN]", messageAman);
        }
        [TestMethod]
        public void TestGetMessage_UnknownState()
        {
            // Arrange
            var stockUnknown = new Stock("BarangUnik", Category.ATK, -1, 1000); // Jumlah negatif untuk memicu state tidak dikenal
            // Act
            var messageUnknown = StockAlertStatus.GetMessage(stockUnknown);
            // Assert
            Assert.AreEqual("[UNKNOWN]", messageUnknown);
        }
        [TestMethod]
        public void TestGetMessage_InvalidState()
        {
            // Arrange
            var stockInvalid = new Stock("BarangInvalid", Category.ATK, 100, 1000); // Jumlah besar untuk memastikan state aman
            // Act
            var messageInvalid = StockAlertStatus.GetMessage(stockInvalid);
            // Assert
            Assert.AreEqual("[AMAN]", messageInvalid);
        }
    }
}

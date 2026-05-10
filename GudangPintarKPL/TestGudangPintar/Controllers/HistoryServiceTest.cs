using GudangPintar.Controllers;
using GudangPintar.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace TestGudangPintar.Controllers
{
    [TestClass]
    public class HistoryServiceTests
    {
        private HistoryService _historyService;

        [TestInitialize]
        public void Setup()
        {
            _historyService = new HistoryService();
        }

        [TestMethod]
        public void Add_MenambahkanHistory_HistoryTersimpan()
        {
            // Arrange
            var history = new StockHistory("Laptop", "Tambah", 5, "admin");

            // Act
            _historyService.Add(history);
            var allHistories = _historyService.GetAll();

            // Assert
            Assert.AreEqual(1, allHistories.Count);
            Assert.AreEqual("Laptop", allHistories[0].NamaBarang);
        }

        [TestMethod]
        public void Add_MultipleHistory_SemuaTersimpan()
        {
            // Arrange
            var history1 = new StockHistory("Laptop", "Tambah", 5, "admin");
            var history2 = new StockHistory("Mouse", "Kurang", 2, "user");

            // Act
            _historyService.Add(history1);
            _historyService.Add(history2);
            var allHistories = _historyService.GetAll();

            // Assert
            Assert.AreEqual(2, allHistories.Count);
        }

        [TestMethod]
        public void GetAll_AwalKosong_ReturnsEmptyList()
        {
            // Act
            var result = _historyService.GetAll();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GetAll_SetelahAdd_ReturnsCorrectData()
        {
            // Arrange
            _historyService.Add(new StockHistory("Monitor", "Tambah", 3, "admin"));

            // Act
            var result = _historyService.GetAll();

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Monitor", result.First().NamaBarang);
        }
    }
}
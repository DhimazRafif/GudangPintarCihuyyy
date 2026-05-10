using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Text.Json;
using GudangPintarKPL.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestGudangPintar.Models
{
    [TestClass]
    public class GudangConfictTest
    {
        [TestMethod]
        public void TestLoadConfigFile()
        {
            // Arrange
            var expectedMataUang = "IDR";
            var expectedFormatHarga = "Rp{0:N2}";
            // Act
            var config = GudangPintarKPL.Models.GudangConfig.LoadConfigFile();
            // Assert
            Assert.IsNotNull(config);
            Assert.AreEqual(expectedMataUang, config.mata_uang);
            Assert.AreEqual(expectedFormatHarga, config.format_harga);
        }
        [TestMethod]
        public void TestLoadConfigFile_FileNotFound()
        {
            // Arrange
            var originalPath = "config.json";
            var tempPath = "temp_config.json";
            if (File.Exists(tempPath))
                File.Delete(tempPath);
            File.Move(originalPath, tempPath);
            // Act & Assert
            try
            {
                Assert.Throws<FileNotFoundException>(() => GudangPintarKPL.Models.GudangConfig.LoadConfigFile());
            }
            finally
            {
                File.Move(tempPath, originalPath);
            }
        }
        [TestMethod]
        public void TestLoadConfigFile_InvalidJson()
        {
            // Arrange
            var originalPath = "config.json";
            var tempPath = "temp_config.json";
            if (File.Exists(tempPath))
                File.Delete(tempPath);
            File.Move(originalPath, tempPath);
            File.WriteAllText(originalPath, "Invalid JSON");
            // Act & Assert
            try
            {
                Assert.Throws<JsonException>(() => GudangPintarKPL.Models.GudangConfig.LoadConfigFile());
            }
            finally
            {
                File.Move(tempPath, originalPath);
            }
        }
        [TestMethod]
        public void TestLoadConfigFile_MissingProperties()
        {
            // Arrange
            var originalPath = "config.json";
            var tempPath = "temp_config.json";
            if (File.Exists(tempPath))
                File.Delete(tempPath);
            File.Move(originalPath, tempPath);
            File.WriteAllText(originalPath, "{}");
            // Act
            var config = GudangPintarKPL.Models.GudangConfig.LoadConfigFile();
            // Assert
            Assert.IsNotNull(config);
            Assert.IsNull(config.mata_uang);
            Assert.IsNull(config.format_harga);
        }
        [TestMethod]
        public void TestProperty_SetGet()
        {
            // Arrange
            var config = new GudangPintarKPL.Models.GudangConfig();
            var expectedMataUang = "USD";
            var expectedFormatHarga = "${0:N2}";
            // Act
            config.mata_uang = expectedMataUang;
            config.format_harga = expectedFormatHarga;
            // Assert
            Assert.AreEqual(expectedMataUang, config.mata_uang);
            Assert.AreEqual(expectedFormatHarga, config.format_harga);
        }
    }
}
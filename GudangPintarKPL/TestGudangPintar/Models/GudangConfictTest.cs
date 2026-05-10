using Microsoft.VisualStudio.TestTools.UnitTesting;
using GudangPintarKPL.Models;
using System;
using System.IO;
using System.Text.Json;

namespace TestGudangPintar.Models
{
    [TestClass]
    public class GudangConfictTest
    {
        private const string ConfigFolder = "ConfigGudang";
        private const string ConfigFile = @"ConfigGudang\config_gudang.json";

        [TestInitialize]
        public void Setup()
        {
            // Menjamin folder ConfigGudang selalu ada sebelum test dijalankan
            if (!Directory.Exists(ConfigFolder))
            {
                Directory.CreateDirectory(ConfigFolder);
            }
        }

        [TestMethod]
        public void TestLoadConfigFile_BerhasilMembacaFile()
        {
            // Arrange: Buat file JSON valid di folder ConfigGudang
            var customConfig = new { mata_uang = "USD", format_harga = "${0:N2}" };
            string jsonContent = JsonSerializer.Serialize(customConfig);
            File.WriteAllText(ConfigFile, jsonContent);

            // Act
            var result = GudangConfig.LoadConfigFile();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("USD", result.mata_uang);
            Assert.AreEqual("${0:N2}", result.format_harga);
        }

        [TestMethod]
        public void TestLoadConfigFile_FileNotFound_HarusReturnDefault()
        {
            // Arrange: Pastikan file tidak ada
            if (File.Exists(ConfigFile))
            {
                File.Delete(ConfigFile);
            }

            // Act
            // Karena kode aslimu pake try-catch, dia gak bakal crash, tapi return IDR
            var result = GudangConfig.LoadConfigFile();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("IDR", result.mata_uang);
            Assert.AreEqual("Rp{0:N2}", result.format_harga);
        }

        [TestMethod]
        public void TestLoadConfigFile_InvalidJson_HarusReturnDefault()
        {
            // Arrange: Buat file tapi isinya rusak (bukan JSON)
            File.WriteAllText(ConfigFile, "INI BUKAN JSON FORMAT");

            // Act
            var result = GudangConfig.LoadConfigFile();

            // Assert
            // Masuk ke catch dan mengembalikan nilai default
            Assert.AreEqual("IDR", result.mata_uang);
            Assert.AreEqual("Rp{0:N2}", result.format_harga);
        }

        [TestMethod]
        public void TestProperty_SetGet()
        {
            // Arrange
            var config = new GudangConfig();

            // Act
            config.mata_uang = "JPY";
            config.format_harga = "¥{0}";

            // Assert
            Assert.AreEqual("JPY", config.mata_uang);
            Assert.AreEqual("¥{0}", config.format_harga);
        }
    }
}
using GudangPintar.Model;
using GudangPintarKPL.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text.Json;

namespace TestGudangPintar.Models
{
    [DoNotParallelize]
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
            var originalOut = Console.Out;

            try
            {
                // Arrange: Hapus File jika ada
                if (File.Exists(ConfigFile))
                {
                    File.Delete(ConfigFile);
                }

                using (var monitor = new StringWriter())
                {
                    // Alihkan output ke monitor
                    Console.SetOut(monitor);

                    // Act: Panggil fungsi di dalam lingkup 'using'
                    // Ini akan memicu catch di LoadConfigFile dan Console.WriteLine
                    var result = GudangConfig.LoadConfigFile();

                    // Assert
                    Assert.IsNotNull(result);
                    Assert.AreEqual("IDR", result.mata_uang);
                    Assert.AreEqual("Rp{0:N2}", result.format_harga);

                    // Verifikasi pesan error muncul di monitor
                    Assert.IsTrue(monitor.ToString().Contains("Gagal memuat konfigurasi"));
                }
            }
            finally
            {
                Console.SetOut(originalOut);
            }
        }

        [TestMethod]
        public void TestLoadConfigFile_InvalidJson_HarusReturnDefault()
        {
            var originalOut = Console.Out;

            try
            {
                
                File.WriteAllText(ConfigFile, "{ invalid json }");

                using (var monitor = new StringWriter())
                {
                    //  Alihkan output ke monitor
                    Console.SetOut(monitor);

                    //  Panggil fungsi yang akan memicu error dan menulis ke Console
                    var result = GudangConfig.LoadConfigFile();

                    //  Verifikasi hasil default
                    Assert.IsNotNull(result);
                    Assert.AreEqual("IDR", result.mata_uang);

                    // Opsional: Cek apakah pesan gagal muncul di layar palsu
                    Assert.IsTrue(monitor.ToString().Contains("Gagal memuat konfigurasi"),
    $"\n--- DEBUG LOG ---\nIsi monitor kosong atau berbeda!\nIsi layar: [{monitor.ToString()}]\n-----------------");
                }
            }
            finally
            {
                Console.SetOut(originalOut);
            }
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
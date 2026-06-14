using System.Text.Json;
namespace GudangPintarKPL.Models
{
    public class GudangConfig
    {
<<<<<<< HEAD:GudangPintarKPL/GudangPintarKPL/Models/GudangConfig.cs
        public string mata_uang { get; set; }
        public string format_harga { get; set; }

        public int AmbangMenipis { get; set; }
        public int AmbangHabis { get; set; }
        public int PeringatanKadaluarsa { get; set; }

        //Konstanta terpusat
        private const string DefaultMataUang = "IDR";
        private const string DefaultFormatHarga = "Rp{0:N2}";
        private const int DefaultAmbangMenipis = 10;
        private const int DefaultAmbangHabis = 0;
        private const int DefaultPeringatanKadaluarsa = 3;

        public static GudangConfig LoadConfigFile()
        {
            string folderPath = "ConfigGudang";
            string filename = $@"{folderPath}\config_gudang.json";
=======
<<<<<<< HEAD
        public string mata_uang { get; set; }
        public string format_harga { get; set; }

        public static GudangConfig LoadConfigFile()
        {
            string filename = @"ConfigGudang\config_gudang.json";
=======
        public string mata_uang {  get; set; }
        public string format_harga {  get; set; }

        public static GudangConfig LoadConfigFile()
        {
            string filename = "config_gudang.json";
>>>>>>> 0befa517fd67ab1b05564b2334ef1276f04c4a37
>>>>>>> a8b62e2d6144355e4b71cb7d24b87ec53897866e:Models/GudangConfig.cs

            try
            {
                if (!File.Exists(filename))
                {
                    Console.WriteLine("\n[ INFO: File konfigurasi tidak ditemukan. Sistem menginisialisasi file default");
                    return GenerateDefaultJsonFile(folderPath, filename);
                }
                string jsonString = File.ReadAllText(filename);

                return JsonSerializer.Deserialize<GudangConfig>(jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gagal memuat konfigurasi: {ex.Message}");
<<<<<<< HEAD:GudangPintarKPL/GudangPintarKPL/Models/GudangConfig.cs
                return GenerateDefaultJsonFile(folderPath, filename);
            }
        }
=======
                return new GudangConfig
                {
<<<<<<< HEAD
                    mata_uang = "IDR",
                    format_harga = "Rp{0:N2}"
                };

            }
        }
    }
}
=======
                    mata_uang = "Akses ditolak.",
                    format_harga = "Akses diterima"
                };
>>>>>>> a8b62e2d6144355e4b71cb7d24b87ec53897866e:Models/GudangConfig.cs

        //Method untuk menulis ulang file JSON
        private static GudangConfig GenerateDefaultJsonFile(string folderPath, string filename)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var defaultConfig = new GudangConfig
            {
                mata_uang = DefaultMataUang,
                format_harga = DefaultFormatHarga,
                AmbangMenipis = DefaultAmbangMenipis,
                AmbangHabis = DefaultAmbangHabis,
                PeringatanKadaluarsa = DefaultPeringatanKadaluarsa
            };

            //Serialisasi menjadi JSON
            string jsonOutput = JsonSerializer.Serialize(defaultConfig, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filename, jsonOutput);

            return defaultConfig;
        }
    }
}
>>>>>>> 0befa517fd67ab1b05564b2334ef1276f04c4a37

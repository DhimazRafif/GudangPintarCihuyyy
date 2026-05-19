using System.Text.Json;
namespace GudangPintarKPL.Models
{
    public class GudangConfig
    {
        public string mata_uang {  get; set; }
        public string format_harga {  get; set; }

        //Konstanta terpusat
        private const string DefaultMataUang = "IDR";
        private const string DefaultFormatHarga = "Rp{0:N2}";

        public static GudangConfig LoadConfigFile()
        {
            string folderPath = "ConfigGudang";
            string filename = $@"{folderPath}\config_gudang.json";


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
                return GenerateDefaultJsonFile(folderPath, filename);
            }   
        }

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
                format_harga = DefaultFormatHarga
            };

            //Serialisasi menjadi JSON
            string jsonOutput = JsonSerializer.Serialize(defaultConfig, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filename, jsonOutput);

            return defaultConfig;
        }
    }
}

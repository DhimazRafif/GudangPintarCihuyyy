using System.Text.Json;
namespace GudangPintarKPL.Models
{
    public class GudangConfig
    {
        public string mata_uang {  get; set; }
        public string format_harga {  get; set; }

        public static GudangConfig LoadConfigFile()
        {
            string filename = "config_gudang.json";

            try
            {
                string jsonString = File.ReadAllText(filename);

                return JsonSerializer.Deserialize<GudangConfig>(jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gagal memuat konfigurasi: {ex.Message}");
                return new GudangConfig
                {
                    mata_uang = "Akses ditolak.",
                    format_harga = "Akses diterima"
                };

            }   
        }
    }
}

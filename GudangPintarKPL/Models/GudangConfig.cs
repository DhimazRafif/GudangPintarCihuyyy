using System.Text.Json;
namespace GudangPintarKPL.Models
{
    public class GudangConfig
    {
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

            }   
        }
    }
}
>>>>>>> 0befa517fd67ab1b05564b2334ef1276f04c4a37

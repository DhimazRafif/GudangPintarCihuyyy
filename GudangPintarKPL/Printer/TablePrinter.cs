using GudangPintarKPL.Models;
<<<<<<< HEAD
=======
using System.Linq;
using System.Reflection;
>>>>>>> a8b62e2d6144355e4b71cb7d24b87ec53897866e

namespace GudangPintarKPL.Printer
{
    public class TablePrinter
    {
        public static void Print<T>(IEnumerable<T> data, string judul) where T : ITablePrint
        {
            Console.WriteLine($"\n=== {judul.ToUpper()} ===");

<<<<<<< HEAD
            string[] headers = T.getHeader();
=======
            if (data == null || !data.Any())
            {
                Console.WriteLine("[ INFO: Data kosong atau belum tersedia ]");
                Console.WriteLine("\nTekan ENTER untuk kembali");
                Console.ReadLine();
                return;
            }
            //menambil atribut 
            var attribute = (TableHeaderAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(TableHeaderAttribute));

            string[] headers = attribute.Headers;
>>>>>>> a8b62e2d6144355e4b71cb7d24b87ec53897866e

            List<string> formatParts = new List<string>();
            for (int i = 0; i < headers.Length; i++)
            {
<<<<<<< HEAD
                formatParts.Add("{" + i + ",-18}");
            }
            string format = string.Join(" ", formatParts);

            Console.WriteLine(format,headers);
            Console.WriteLine(new string('-',headers.Length * 19));
=======
                formatParts.Add("{" + i + ",-25}");
            }
            string format = string.Join(" ", formatParts);

            Console.WriteLine(format, headers);
            Console.WriteLine(new string('-', headers.Length * 23));
>>>>>>> a8b62e2d6144355e4b71cb7d24b87ec53897866e

            foreach (var item in data)
            {
                Console.WriteLine(format, item.getRowData());
            }

            Console.WriteLine("Tekan ENTER untuk kembali");
            Console.ReadLine();
<<<<<<< HEAD
        } 
=======
        }
>>>>>>> a8b62e2d6144355e4b71cb7d24b87ec53897866e
    }
}

using GudangPintarKPL.Models;
using System.Linq;
using System.Reflection;

namespace GudangPintarKPL.Printer
{
    public class TablePrinter
    {
        public static void Print<T>(IEnumerable<T> data, string judul) where T : ITablePrint
        {
            Console.WriteLine($"\n=== {judul.ToUpper()} ===");

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

            List<string> formatParts = new List<string>();
            for (int i = 0; i < headers.Length; i++)
            {
                formatParts.Add("{" + i + ",-25}");
            }
            string format = string.Join(" ", formatParts);

            Console.WriteLine(format, headers);
            Console.WriteLine(new string('-', headers.Length * 23));

            foreach (var item in data)
            {
                Console.WriteLine(format, item.getRowData());
            }

            Console.WriteLine("Tekan ENTER untuk kembali");
            Console.ReadLine();
        }
    }
}

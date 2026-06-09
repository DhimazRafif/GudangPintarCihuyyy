using GudangPintarKPL.Models;
<<<<<<< HEAD
using System.Linq;
using System.Reflection;
=======
>>>>>>> 0befa517fd67ab1b05564b2334ef1276f04c4a37

namespace GudangPintarKPL.Printer
{
    public class TablePrinter
    {
        public static void Print<T>(IEnumerable<T> data, string judul) where T : ITablePrint
        {
            Console.WriteLine($"\n=== {judul.ToUpper()} ===");

<<<<<<< HEAD
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
=======
            string[] headers = T.getHeader();
>>>>>>> 0befa517fd67ab1b05564b2334ef1276f04c4a37

            List<string> formatParts = new List<string>();
            for (int i = 0; i < headers.Length; i++)
            {
<<<<<<< HEAD
                formatParts.Add("{" + i + ",-25}");
=======
                formatParts.Add("{" + i + ",-18}");
>>>>>>> 0befa517fd67ab1b05564b2334ef1276f04c4a37
            }
            string format = string.Join(" ", formatParts);

            Console.WriteLine(format,headers);
<<<<<<< HEAD
            Console.WriteLine(new string('-',headers.Length * 23));
=======
            Console.WriteLine(new string('-',headers.Length * 19));
>>>>>>> 0befa517fd67ab1b05564b2334ef1276f04c4a37

            foreach (var item in data)
            {
                Console.WriteLine(format, item.getRowData());
            }

            Console.WriteLine("Tekan ENTER untuk kembali");
            Console.ReadLine();
        } 
    }
}

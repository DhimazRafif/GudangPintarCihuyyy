using GudangPintarKPL.Models;

namespace GudangPintarKPL.Printer
{
    public class TablePrinter
    {
        public static void Print<T>(IEnumerable<T> data, string judul) where T : ITablePrint
        {
            Console.WriteLine($"\n=== {judul.ToUpper()} ===");

            string[] headers = T.getHeader();

            List<string> formatParts = new List<string>();
            for (int i = 0; i < headers.Length; i++)
            {
                formatParts.Add("{" + i + ",-18}");
            }
            string format = string.Join(" ", formatParts);

            Console.WriteLine(format,headers);
            Console.WriteLine(new string('-',headers.Length * 19));

            foreach (var item in data)
            {
                Console.WriteLine(format, item.getRowData());
            }

            Console.WriteLine("Tekan ENTER untuk kembali");
            Console.ReadLine();
        } 
    }
}

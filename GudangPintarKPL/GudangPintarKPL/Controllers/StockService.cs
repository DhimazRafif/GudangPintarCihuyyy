using GudangPintar.Model;
using System.Collections.Generic;
using System.Linq;

namespace GudangPintar.Controllers
{
    public class StockService
    {
        private List<Stock> stocks = new();

        public List<Stock> GetAll() => stocks;

        public void Add(Stock s)
        {
            stocks.Add(s);
        }

        public void Delete(string nama)
        {
            stocks.RemoveAll(s => s.NamaBarang == nama);
        }

        public Stock? Get(string nama)
        {
            return stocks.FirstOrDefault(s => s.NamaBarang == nama);
        }

        public void Update(string nama, string newNama, Category kategori, double harga)
        {
            var s = Get(nama);
            if (s != null)
            {
                s.EditStock(newNama, kategori, harga);
            }
        }

        public void TambahStok(string nama, int jumlah)
        {
            Get(nama)?.TambahStok(jumlah);
        }

        public void KurangiStok(string nama, int jumlah)
        {
            Get(nama)?.KurangiStok(jumlah);
        }

        // tambahan 
        public object GetFiltered(object parameters)
        {
            // Dynamic unwrap parameters
            var nama = parameters.GetType().GetProperty("Nama")?.GetValue(parameters) as string;
            var minStok = (int?)parameters.GetType().GetProperty("MinStok")?.GetValue(parameters);
            var maxStok = (int?)parameters.GetType().GetProperty("MaxStok")?.GetValue(parameters);
            var kategori = parameters.GetType().GetProperty("Kategori")?.GetValue(parameters) as string;

            var query = stocks.AsEnumerable();

            if (!string.IsNullOrEmpty(nama))
                query = query.Where(s => s.NamaBarang.Contains(nama, StringComparison.OrdinalIgnoreCase));

            if (minStok.HasValue)
                query = query.Where(s => s.Jumlah >= minStok.Value);

            if (maxStok.HasValue)
                query = query.Where(s => s.Jumlah <= maxStok.Value);

            if (!string.IsNullOrEmpty(kategori) && Enum.TryParse<Category>(kategori, true, out var cat))
                query = query.Where(s => s.Kategori == cat);

            return query.ToList();
        }

        public bool UpdateStock(int id, int jumlah)
        {
            // Cari stock berdasarkan id (asumsi ada properti Id, jika tidak pakai indeks)
            if (id >= 0 && id < stocks.Count)
            {
                stocks[id].TambahStok(jumlah);
                return true;
            }

            // Alternatif: cari berdasarkan posisi atau tambahkan properti Id ke class Stock
            return false;
        }
    }
}
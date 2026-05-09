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
    }
}
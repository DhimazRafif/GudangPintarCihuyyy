using GudangPintar.Model;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace GudangPintar.Controllers
{
    public class StockService
    {
        private List<Stock> stocks = new();

        public List<Stock> GetAll() => stocks;

        public bool Add(Stock s)
        {
            if (stocks.Any(x => x.NamaBarang == s.NamaBarang))
            {
                Console.WriteLine("Nama barang sudah ada!");
                return false;
            }

            if (s.Jumlah <= 0)
            {
                Console.WriteLine("Jumlah harus lebih dari 0!");
                return false;
            }

            Debug.Assert(s.Jumlah > 0);

            stocks.Add(s);
            return true;
        }
        public bool Delete(string nama)
        {
            var s = Get(nama);

            if (s == null)
            {
                Console.WriteLine("Barang tidak ditemukan!");
                return false;
            }

            stocks.Remove(s);
            return true;
        }

        public Stock? Get(string nama)
        {
            return stocks.FirstOrDefault(s => s.NamaBarang == nama);
        }

        public void Update(string nama, string newNama, Category kategori, double harga)
        {
            var s = Get(nama);

            if (stocks.Any(x => x.NamaBarang == newNama && x.NamaBarang != nama))
            {
                Console.WriteLine("Nama barang sudah digunakan!");
                return;
            }

            if (s != null)
            {
                s.EditStock(newNama, kategori, harga);
            }
        }

        public bool TambahStok(string nama, int jumlah)
        {
            if (jumlah <= 0)
            {
                Console.WriteLine("Input harus berupa bilangan positif!");
                return false;
            }

            var s = Get(nama);

            if (s == null)
            {
                Console.WriteLine("Barang tidak ditemukan!");
                return false;
            }

            Debug.Assert(jumlah > 0);

            s.TambahStok(jumlah);
            return true;
        }

        public bool KurangiStok(string nama, int jumlah)
        {
            var s = Get(nama);

            if (s == null)
            {
                Console.WriteLine("Barang tidak ditemukan!");
                return false;
            }

            if (jumlah > s.Jumlah)
            {
                Console.WriteLine("Stok tidak cukup!");
                return false;
            }

            if (jumlah <= 0)
            {
                Console.WriteLine("Jumlah harus lebih dari 0!");
                return false;
            }

            Debug.Assert(s.Jumlah >= 0);

            s.KurangiStok(jumlah);
            return true;
        }
    }
}
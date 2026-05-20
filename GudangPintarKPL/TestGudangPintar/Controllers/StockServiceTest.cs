using GudangPintar.Controllers;
using GudangPintar.Model;

namespace TestGudangPintar.Controllers
{
    [TestClass]
    public class StockServiceTests
    {
        private StockService _service;

        [TestInitialize]
        public void Setup()
        {
            // Inisialisasi service baru setiap kali test dijalankan agar data bersih
            _service = new StockService();
        }
        [TestMethod]
        public void Add_BarangBaru_HarusBerhasil()
        {
            var baru = new Stock("Pulpen", Category.ATK, 10, 2000);
            bool hasil = _service.Add(baru);

            Assert.IsTrue(hasil);
            Assert.AreEqual(1, _service.GetAll().Count);
        }
        [TestMethod]
        public void Add_NamaDuplikat_HarusGagal()
        {
            _service.Add(new Stock("Penghapus", Category.ATK, 5, 1000));
            var duplikat = new Stock("Penghapus", Category.ATK, 10, 2000);

            bool hasil = _service.Add(duplikat);

            Assert.IsFalse(hasil);
            Assert.AreEqual(1, _service.GetAll().Count);
        }
        [TestMethod]
        public void Add_JumlahNolAtauNegatif_HarusGagal()
        {
            // Mencakup baris: if (s.Jumlah <= 0)
            var stokNol = new Stock("BarangGagal", Category.ATK, 0, 1000);
            bool hasil = _service.Add(stokNol);

            Assert.IsFalse(hasil);
            Assert.AreEqual(0, _service.GetAll().Count);
        }
        [TestMethod]
        public void Get_BarangAda_HarusDitemukan()
        {
            _service.Add(new Stock("Gula", Category.Sembako, 10, 5000));
            var barang = _service.Get("Gula");

            Assert.IsNotNull(barang);
            Assert.AreEqual("Gula", barang.NamaBarang);
        }
        [TestMethod]
        public void Get_BarangTidakAda_HarusNull()
        {
            var barang = _service.Get("NonExistent");
            Assert.IsNull(barang);
        }
        [TestMethod]
        public void Update_BarangAda_HarusTerupdate()
        {
            _service.Add(new Stock("Minyak", Category.ATK, 3, 1000));
            _service.Update("Minyak", "Minyak 4L", Category.ATK, 1500);

            var barang = _service.Get("Minyak 4L");
            Assert.IsNotNull(barang);
            Assert.AreEqual(1500, barang.Harga);
        }
        [TestMethod]
        public void Update_NamaDuplikat_HarusGagal()
        {
            // Mencakup baris: if (stocks.Any(x => x.NamaBarang == newNama ...))
            _service.Add(new Stock("Pulpen", Category.ATK, 2, 1000));
            _service.Add(new Stock("Pensil", Category.ATK, 1, 500));

            _service.Update("Pulpen", "Pensil", Category.ATK, 500);

            Assert.IsNotNull(_service.Get("Pulpen"));
            Assert.IsNotNull(_service.Get("Pensil"));
        }
        [TestMethod]
        public void Update_BarangTidakAda_HarusGagal()
        {
            _service.Update("NonExistent", "BarangBaru", Category.ATK, 1000);
            Assert.IsNull(_service.Get("BarangBaru"));
        }
        [TestMethod]
        public void Delete_BarangAda_HarusTerhapus()
        {
            _service.Add(new Stock("Minyak", Category.ATK, 4, 1000));
            bool hasil = _service.Delete("Minyak");

            Assert.IsTrue(hasil);
            Assert.IsNull(_service.Get("Minyak"));
        }
        [TestMethod]
        public void Delete_BarangTidakAda_HarusGagal()
        {
            // Mencakup baris: if (s == null) di Delete
            bool hasil = _service.Delete("NonExistent");
            Assert.IsFalse(hasil);
        }
        [TestMethod]
        public void TambahStok_InputPositif_HarusBertambah()
        {
            _service.Add(new Stock("Kerupuk", Category.Sembako, 5, 1000));
            bool hasil = _service.TambahStok("Kerupuk", 3);

            Assert.IsTrue(hasil);
            Assert.AreEqual(8, _service.Get("Kerupuk").Jumlah);
        }
        [TestMethod]
        public void TambahStok_InputNegatif_HarusGagal()
        {
            // Mencakup baris: if (jumlah <= 0) di TambahStok
            _service.Add(new Stock("Kerupuk", Category.Sembako, 5, 1000));
            bool hasil = _service.TambahStok("Kerupuk", -2);

            Assert.IsFalse(hasil);
            Assert.AreEqual(5, _service.Get("Kerupuk").Jumlah);
        }
        [TestMethod]
        public void TambahStok_BarangTidakAda_HarusGagal()
        {
            bool hasil = _service.TambahStok("NonExistent", 5);
            Assert.IsFalse(hasil);
        }
        [TestMethod]
        public void KurangiStok_Cukup_HarusBerkurang()
        {
            _service.Add(new Stock("Sapu", Category.ATK, 5, 1000));
            bool hasil = _service.KurangiStok("Sapu", 3);

            Assert.IsTrue(hasil);
            Assert.AreEqual(2, _service.Get("Sapu").Jumlah);
        }
        [TestMethod]
        public void KurangiStok_MelebihiBatas_HarusGagal()
        {
            // Mencakup baris: if (jumlah > s.Jumlah)
            _service.Add(new Stock("Sapu", Category.ATK, 2, 1000));
            bool hasil = _service.KurangiStok("Sapu", 5);

            Assert.IsFalse(hasil);
            Assert.AreEqual(2, _service.Get("Sapu").Jumlah);
        }
        [TestMethod]
        public void KurangiStok_InputNegatifAtauNol_HarusGagal()
        {
            // Mencakup baris: if (jumlah <= 0) di KurangiStok
            _service.Add(new Stock("Sapu", Category.ATK, 5, 1000));
            bool hasil = _service.KurangiStok("Sapu", 0);

            Assert.IsFalse(hasil);
        }
        [TestMethod]
        public void KurangiStok_BarangTidakAda_HarusGagal()
        {
            // Mencakup baris: if (s == null) di KurangiStok
            bool hasil = _service.KurangiStok("BarangGaib", 1);
            Assert.IsFalse(hasil);
        }
    }
}
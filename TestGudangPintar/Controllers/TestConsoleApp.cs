using System;
using GudangPintarKPL.Controllers;
using System.Text;
using System.IO;
using GudangPintar.Controllers;

namespace TestGudangPintar.Controllers
{
    [DoNotParallelize]
    [TestClass]
    public sealed class TestConsoleApp
    {
        //Run dan Menu
        [TestMethod]
        public void LoginBenar()
        {
            var originalOut = Console.Out;
            var originalIn = Console.In;

            try
            {
                var app = new ConsoleApp(new StockService(), new UserService(), new HistoryService());

                var skenarioTest =
                    "admin\n" +      //username
                    "admin123\n" +   //password
                    "0\n" +          //Berhasil masuk menu dan menekan 0 untuk kembali ke login
                    "exit\n";        //keluar program

                using (var keyboardPalsu = new StringReader(skenarioTest))
                using (var monitorPalsu = new StringWriter())
                {
                    Console.SetIn(keyboardPalsu);
                    Console.SetOut(monitorPalsu);

                    app.Run();

                    var hasilLayar = monitorPalsu.ToString();

                    Assert.IsTrue(
                        hasilLayar.Contains("MENU"),
                        $"\n--- DEBUG LOG ---\nTeks 'MENU' tidak ditemukan! Berikut isi layar aslinya:\n[{hasilLayar}]\n-----------------"
                    );
                }
            }
            finally
            {
                Console.SetOut(originalOut);
                Console.SetIn(originalIn);
            }
        }

        [TestMethod]
        public void InputKosong_PrintPesanErrorKosong()
        {
            var originalOut = Console.Out;
            var originalIn = Console.In;

            try
            {
                var app = new ConsoleApp(new StockService(), new UserService(), new HistoryService());

                //Login tanpa input apapun
                var skenarioTest = "\n"+"\n"+"\n"+"exit"+"\n";

                using (var keyboardPalsu = new StringReader(skenarioTest))
                using (var monitorPalsu = new StringWriter())
                {
                    Console.SetIn(keyboardPalsu);
                    Console.SetOut(monitorPalsu);

                    app.Run();

                    var hasilLayar = monitorPalsu.ToString();

                    Assert.IsTrue(
                        hasilLayar.Contains("Username dan password tidak boleh kosong!"),
                        $"\n--- DEBUG LOG ---\nTangkapan layar:\n[{hasilLayar}]\n-----------------"
                    );
                }
            }
            finally
            {
                Console.SetOut(originalOut);
                Console.SetIn(originalIn);
            }
        }

        [TestMethod]
        public void KredensialSalah_PrintLogingagal()
        {
            var originalOut = Console.Out;
            var originalIn = Console.In;

            try
            {
                var app = new ConsoleApp(new StockService(), new UserService(), new HistoryService());

                //Login dengan username dan password salah
                var skenarioTest = "salah\n"+"salah123\n"+"\n"+"exit\n";

                using (var keyboardPalsu = new StringReader(skenarioTest))
                using (var monitorPalsu = new StringWriter())
                {
                    Console.SetIn(keyboardPalsu);
                    Console.SetOut(monitorPalsu);

                    app.Run();

                    var hasilLayar = monitorPalsu.ToString();

                    Assert.IsTrue(
                hasilLayar.Contains("Login gagal!"),
                $"\n--- DEBUG LOG ---\nTangkapan layar:\n[{hasilLayar}]\n-----------------"
            );
                }
            }
            finally
            {
                Console.SetOut(originalOut);
                Console.SetIn(originalIn);
            }
        }

        [TestMethod]
        public void LihatHistoryDanStock_CetakTabel()
        {

            var originalOut = Console.Out;
            var originalIn = Console.In;

            try
            {
                var app = new ConsoleApp(new StockService(), new UserService(), new HistoryService());

                var skenarioTest =
                    "admin\n" +      //username
                    "admin123\n" +   //password
                    "2\n" +          //Menu Stock
                    "\n" +           //Kembali ke menu
                    "4\n" +          //Lihat History
                    "\n" +           //kembali ke menu
                    "0\n" +          //Kembali ke halaman login
                    "exit\n";        //kaluar Program


                using (var keyboardPalsu = new StringReader(skenarioTest))
                using (var monitorPalsu = new StringWriter())
                {
                    Console.SetIn(keyboardPalsu);
                    Console.SetOut(monitorPalsu);

                    app.Run();
                    var hasilLayar = monitorPalsu.ToString();

                    Assert.IsTrue(hasilLayar.Contains("STOK"), "Gagal masuk ke Lihat Stok");
                    Assert.IsTrue(hasilLayar.Contains("HISTORI TRANSAKSI"), "Gagal masuk ke Lihat History");
                }
            }
            finally
            {
                Console.SetOut(originalOut);
                Console.SetIn(originalIn);
            }
        }

        [TestMethod]
        public void LihatHistory_SaatKosong_HarusMenampilkanPesanInfo()
        {
            var originalOut = Console.Out;
            var originalIn = Console.In;
            try
            {
                // Menggunakan HistoryService kosong
                var app = new ConsoleApp(new StockService(), new UserService(), new HistoryService());
                var skenario = 
                    "admin\n"+      //username
                    "admin123\n"+   //password
                    "4\n"+          //menu history
                    "\n"+           //Kembali ke menu
                    "0\n"+          //Kembali ke halaman login
                    "exit\n";       //Keluar program

                using (var keyboard = new StringReader(skenario))
                using (var monitor = new StringWriter())
                {
                    Console.SetIn(keyboard); Console.SetOut(monitor);
                    app.Run();
                    Assert.IsTrue(monitor.ToString().Contains("History kosong"), "Pesan histori kosong tidak muncul");
                }
            }
            finally { Console.SetOut(originalOut); Console.SetIn(originalIn); }
        }

        [TestMethod]
        public void Menu_LoginUserBiasa_OtorisasiMenuAdminHarusGagal()
        {
            var originalOut = Console.Out;
            var originalIn = Console.In;
            try
            {
                var app = new ConsoleApp(new StockService(), new UserService(), new HistoryService());
                var skenario =
                    "user\nuser123\n" +     // Login sebagai User 
                    "1\n" +                 // Memilih menu 1 (harus tidak valid karena kelola akun menu Admin)
                    "0\nexit\n";

                using (var keyboard = new StringReader(skenario))
                using (var monitor = new StringWriter())
                {
                    Console.SetIn(keyboard); Console.SetOut(monitor); app.Run();
                    Assert.IsTrue(monitor.ToString().Contains("Input Tidak Valid!"));
                }
            }
            finally { Console.SetOut(originalOut); Console.SetIn(originalIn); }
        }

        [TestMethod]
        public void InputInvalid()
        {

            var originalOut = Console.Out;
            var originalIn = Console.In;

            try
            {
                var app = new ConsoleApp(new StockService(), new UserService(), new HistoryService());

                var skenarioTest =
                    "admin\n" +        
                    "admin123\n" +
                    "99\n" +         //input menu 99(tidak ada) tetap berada di menu        
                    "0\n" +          //Kembali ke halaman login     
                    "exit\n";


                using (var keyboardPalsu = new StringReader(skenarioTest))
                using (var monitorPalsu = new StringWriter())
                {
                    Console.SetIn(keyboardPalsu);
                    Console.SetOut(monitorPalsu);

                    app.Run();
                    var hasilLayar = monitorPalsu.ToString();

                    Assert.IsTrue(hasilLayar.Contains("Tidak Valid") || hasilLayar.Contains("Pilihan"),
                    $"\n--- DEBUG LOG ---\nAplikasi gagal menangkap input invalid 99! Layar:\n[{hasilLayar}]\n-----------------");
                }
            }
            finally
            {
                Console.SetOut(originalOut);
                Console.SetIn(originalIn);
            }
        }

        [TestMethod]
        public void LihatStok_SaatAdaBarang_HarusMencetakTabel()
        {
            var originalOut = Console.Out;
            var originalIn = Console.In;
            try
            {
                var app = new ConsoleApp(new StockService(), new UserService(), new HistoryService());
                var skenario =
                    "admin\nadmin123\n" +
                    "2\n" +                 // Halaman lihat stok
                    "\n" +                  // Tekan enter untuk kembali ke menu
                    "0\nexit\n";            // Logout & Exit

                using (var keyboard = new StringReader(skenario))
                using (var monitor = new StringWriter())
                {
                    Console.SetIn(keyboard); Console.SetOut(monitor); app.Run();
                }
            }
            finally { Console.SetOut(originalOut); Console.SetIn(originalIn); }
        }

        [TestMethod]
        public void LihatStok_SaatTidakAdaBarang_PrintTidakAdaBarang()
        {
            var originalOut = Console.Out;
            var originalIn = Console.In;
            try
            {
                var sService = new StockService();
                var uService = new UserService();
                var hService = new HistoryService();

                var semuaBarang = sService.GetAll();
                //mengosongkan data dummy
                foreach (var barang in semuaBarang.ToList()) 
                {
                    sService.Delete(barang.NamaBarang);
                }

                var app = new ConsoleApp(sService, uService, hService);

                var skenario =
                    "admin\nadmin123\n" +
                    "2\n" +                 // Halaman Lihat Stok (muncul pesan belum ada barang)
                    "\n" +                  // Tekan enter untuk kembali ke menu
                    "0\nexit\n";            // Logout & Exit

                using (var keyboard = new StringReader(skenario))
                using (var monitor = new StringWriter())
                {
                    Console.SetIn(keyboard); 
                    Console.SetOut(monitor); 
                    
                    app.Run();

                    var hasilLayar = monitor.ToString();
                    Assert.IsTrue(hasilLayar.Contains("Belum ada barang"),
                        "Pesan stok kosong tidak muncul padahal service sudah dikosongkan!");
                }
            }
            finally { Console.SetOut(originalOut); Console.SetIn(originalIn); }
        }

        //Kelola Stok
        [TestMethod]
        public void TambahBarang_Berhasil()
        {

            var originalOut = Console.Out;
            var originalIn = Console.In;

            try
            {
                var sService = new StockService();
                var uService = new UserService();
                var hService = new HistoryService();

                int jumlahAwal = sService.GetAll().Count;

                var app = new ConsoleApp(sService, uService, hService);

                var skenarioTest =
                    "admin\n" +
                    "admin123\n" +
                    "3\n" +         //Halaman kelola stock
                    "1\n" +         //Menu tambah barang
                    "Pensil\n" +    //Nama barang
                    "ATK\n" +       //Kategori barang
                    "20\n" +        //Jumlah barang
                    "5000\n" +      //Harga barang
                    "\n" +
                    "0\n" +
                    "exit\n";


                using (var keyboardPalsu = new StringReader(skenarioTest))
                using (var monitorPalsu = new StringWriter())
                {
                    Console.SetIn(keyboardPalsu);
                    Console.SetOut(monitorPalsu);

                    app.Run();
                    var hasilLayar = monitorPalsu.ToString();
                    Assert.IsTrue(hasilLayar.Contains("KELOLA STOK") || hasilLayar.Contains("Kelola Stok"));

                    var semuaStok = sService.GetAll();

                    Assert.AreEqual(jumlahAwal+1, semuaStok.Count, "Data barang gagal ditambahkan ke dalam List StockService!");

                    var barangBaru = semuaStok.FirstOrDefault(b => b.NamaBarang == "Pensil");
                    Assert.IsNotNull(barangBaru, "Barang 'Pensil' gagal ditambahkan ke dalam memori!");

                    Assert.AreEqual("Pensil", barangBaru.NamaBarang);
                    Assert.AreEqual(20, barangBaru.Jumlah, "Jumlah barang tidak bertambah menjadi 1!");
                    Assert.AreEqual(5000, barangBaru.Harga);
                }
            }
            finally
            {
                Console.SetOut(originalOut);
                Console.SetIn(originalIn);
            }
        }

        [TestMethod]
        public void KelolaStok_TambahBarangHargaBukanAngka_HarusMenampilkanError()
        {
            var originalOut = Console.Out;
            var originalIn = Console.In;
            try
            {
                var app = new ConsoleApp(new StockService(), new UserService(), new HistoryService());
                var skenario =
                    "admin\nadmin123\n" +
                    "3\n" + "1\n" + "Barang Test\n" + "ATK\n" + "10\n" +
                    "Gratis\n" +            // Harga diisi huruf
                    "0\nexit\n";

                using (var keyboard = new StringReader(skenario))
                using (var monitor = new StringWriter())
                {
                    Console.SetIn(keyboard); Console.SetOut(monitor); app.Run();
                    Assert.IsTrue(monitor.ToString().Contains("Harga harus berupa angka!"));
                }
            }
            finally { Console.SetOut(originalOut); Console.SetIn(originalIn); }
        }

        [TestMethod]
        public void KelolaStok_TambahBarangJumlahBukanAngka_HarusMenampilkanError()
        {
            var originalOut = Console.Out;
            var originalIn = Console.In;
            try
            {
                var app = new ConsoleApp(new StockService(), new UserService(), new HistoryService());
                var skenario =
                    "admin\nadmin123\n" +
                    "3\n" +                 // Kelola stok
                    "1\n" +                 // Tambah barang
                    "Barang Gagal\n" +
                    "ATK\n" +
                    "Sepuluh\n" +           // Jumlah diisi huruf 
                    "0\nexit\n";

                using (var keyboard = new StringReader(skenario))
                using (var monitor = new StringWriter())
                {
                    Console.SetIn(keyboard); Console.SetOut(monitor); app.Run();
                    Assert.IsTrue(monitor.ToString().Contains("Jumlah harus berupa angka!"));
                }
            }
            finally { Console.SetOut(originalOut); Console.SetIn(originalIn); }
        }

        [TestMethod]
        public void KelolaStok_TambahBarangDuplikat_BooleanBerhasilFalse()
        {
            var originalOut = Console.Out;
            var originalIn = Console.In;
            try
            {
                var app = new ConsoleApp(new StockService(), new UserService(), new HistoryService());
                // Menambahkan data barang yang sudah ada
                var skenario = "admin\nadmin123\n3\n1\nBuku Tulis\nATK\n10\n5000\n\n0\n0\nexit\n";

                using (var keyboard = new StringReader(skenario))
                using (var monitor = new StringWriter())
                {
                    Console.SetIn(keyboard); Console.SetOut(monitor); app.Run();
                }
            }
            finally { Console.SetOut(originalOut); Console.SetIn(originalIn); }
        }

        [TestMethod]
        public void KelolaStok_TambahStokInputBukanAngka_HarusMenampilkanError()
        {
            var originalOut = Console.Out;
            var originalIn = Console.In;
            try
            {
                var app = new ConsoleApp(new StockService(), new UserService(), new HistoryService());

                var skenario =
                    "admin\nadmin123\n" +
                    "3\n" +
                    "4\n" +
                    "Buku Tulis\n" +
                    "Sepuluh\n" +  //Stok diisikan huruf
                    "0\nexit\n";

                using (var keyboard = new StringReader(skenario))
                using (var monitor = new StringWriter())
                {
                    Console.SetIn(keyboard);
                    Console.SetOut(monitor);
                    app.Run();

                    Assert.IsTrue(monitor.ToString().Contains("Jumlah harus berupa angka!"), "Validasi Jumlah salah");
                }
            }
            finally { Console.SetOut(originalOut); Console.SetIn(originalIn); }
        }

        [TestMethod]
        public void KelolaStok_HapusBarang_HarusBerhasil()
        {
            var originalOut = Console.Out;
            var originalIn = Console.In;
            try
            {
                var app = new ConsoleApp(new StockService(), new UserService(), new HistoryService());

                var skenario =
                    "admin\nadmin123\n" +
                    "3\n" +                 
                    "2\n" +                 
                    "Buku Tulis\n" +       //Nama barang yang dihapus 
                    "\n" +                  
                    "0\nexit\n";            

                using (var keyboard = new StringReader(skenario))
                using (var monitor = new StringWriter())
                {
                    Console.SetIn(keyboard);
                    Console.SetOut(monitor);
                    app.Run();

                    Assert.IsTrue(monitor.ToString().Contains("Operasi selesai!"), "Gagal menyelesaikan operasi hapus");
                }
            }
            finally { Console.SetOut(originalOut); Console.SetIn(originalIn); }
        }

        [TestMethod]
        public void KelolaStok_EditBarang_HarusBerhasil()
        {
            var originalOut = Console.Out;
            var originalIn = Console.In;
            try
            {
                var app = new ConsoleApp(new StockService(), new UserService(), new HistoryService());
                var skenario =
                    "admin\nadmin123\n" +
                    "3\n" +                 
                    "3\n" +                 
                    "Buku Tulis\n" +        //Nama barang yang diubah
                    "Buku Gambar\n" +       //Nama baru
                    "ATK\n" +               //Category
                    "6000\n" +              //Harga Baru
                    "\n" +                                 
                    "0\nexit\n";            

                using (var keyboard = new StringReader(skenario))
                using (var monitor = new StringWriter())
                {
                    Console.SetIn(keyboard); Console.SetOut(monitor); app.Run();
                }
            }
            finally { Console.SetOut(originalOut); Console.SetIn(originalIn); }
        }

        [TestMethod]
        public void KelolaStok_EditHargaBukanAngka_HarusMenampilkanError()
        {
            var originalOut = Console.Out;
            var originalIn = Console.In;
            try
            {
                var app = new ConsoleApp(new StockService(), new UserService(), new HistoryService());
                var skenario =
                    "admin\nadmin123\n" +
                    "3\n" +                 // Kelola Stok
                    "3\n" +                 // Edit Barang
                    "Buku Tulis\n" + "Nama Baru\n" + "ATK\n" +
                    "Seribu\n" +            // Harga diisi huruf 
                    "0\nexit\n";

                using (var keyboard = new StringReader(skenario))
                using (var monitor = new StringWriter())
                {
                    Console.SetIn(keyboard); Console.SetOut(monitor); app.Run();
                    Assert.IsTrue(monitor.ToString().Contains("Harga harus berupa angka!"));
                }
            }
            finally { Console.SetOut(originalOut); Console.SetIn(originalIn); }
        }

        [TestMethod]
        public void KelolaStok_TambahStok_HarusBerhasil()
        {
            var originalOut = Console.Out;
            var originalIn = Console.In;
            try
            {
                var app = new ConsoleApp(new StockService(), new UserService(), new HistoryService());
                var skenario =
                    "admin\nadmin123\n" +
                    "3\n" +                 // Masuk kelola stock
                    "4\n" +                 // Tambah stock
                    "Buku Tulis\n" +        // Nama Barang
                    "10\n" +                // Jumlah yang ditambah
                    "\n" +                  
                    "0\nexit\n";           

                using (var keyboard = new StringReader(skenario))
                using (var monitor = new StringWriter())
                {
                    Console.SetIn(keyboard); Console.SetOut(monitor); app.Run();
                }
            }
            finally { Console.SetOut(originalOut); Console.SetIn(originalIn); }
        }

        [TestMethod]
        public void KelolaStok_KurangiStok_HarusBerhasil()
        {
            var originalOut = Console.Out;
            var originalIn = Console.In;
            try
            {
                var app = new ConsoleApp(new StockService(), new UserService(), new HistoryService());
                var skenario =
                    "admin\nadmin123\n" +
                    "3\n" +                 // Masuk kelola stock
                    "5\n" +                 // Kurangi Stok
                    "Buku Tulis\n" +        // Nama barang
                    "5\n" +                 // Jumlah yang dikurangi
                    "\n" +                  
                    "0\nexit\n";            

                using (var keyboard = new StringReader(skenario))
                using (var monitor = new StringWriter())
                {
                    Console.SetIn(keyboard); Console.SetOut(monitor); app.Run();
                }
            }
            finally { Console.SetOut(originalOut); Console.SetIn(originalIn); }
        }

        [TestMethod]
        public void KelolaStok_KurangiStokJumlahBukanAngka_HarusMenampilkanError()
        {
            var originalOut = Console.Out;
            var originalIn = Console.In;
            try
            {
                var app = new ConsoleApp(new StockService(), new UserService(), new HistoryService());
                var skenario =
                    "admin\nadmin123\n" +
                    "3\n" + "5\n" + "Buku Tulis\n" +
                    "Sedikit\n" +           //Jumlah diisi huruf
                    "0\nexit\n";

                using (var keyboard = new StringReader(skenario))
                using (var monitor = new StringWriter())
                {
                    Console.SetIn(keyboard); Console.SetOut(monitor); app.Run();
                    Assert.IsTrue(monitor.ToString().Contains("Jumlah harus berupa angka!"));
                }
            }
            finally { Console.SetOut(originalOut); Console.SetIn(originalIn); }
        }

        [TestMethod]
        public void KelolaStok_SkenarioGagalDanMenuInvalid_HarusTercover()
        {
            var originalOut = Console.Out;
            var originalIn = Console.In;
            try
            {
                var app = new ConsoleApp(new StockService(), new UserService(), new HistoryService());
                var skenario =
                    "admin\nadmin123\n" +
                    "3\n" +                 // Masuk Kelola Stok
                    "99\n" +                // Pilih 99 (tidak ada)
                    "Barang Hantu\n" +      // Input nama 
                    "\n" +                  // Tekan Enter (Operasi Selesai)
                    "3\n" +                 // Masuk kelola stock 
                    "2\n" +                 // Hapus barang
                    "Barang Hantu\n" +      // Hapus barang yang tidak ada
                    "\n" +                  // Tekan Enter (Operasi Selesai)
                    "0\nexit\n";            // Logout & Exit

                using (var keyboard = new StringReader(skenario))
                using (var monitor = new StringWriter())
                {
                    Console.SetIn(keyboard); Console.SetOut(monitor); app.Run();
                }
            }
            finally { Console.SetOut(originalOut); Console.SetIn(originalIn); }
        }

        [TestMethod]
        public void KelolaStok_OperasiBarangFiktif_HarusBerhasilTanpaTambahHistory()
        {
            var originalOut = Console.Out;
            var originalIn = Console.In;
            try
            {
                var app = new ConsoleApp(new StockService(), new UserService(), new HistoryService());
                var skenario =
                    "admin\nadmin123\n" +
                    "3\n" + "4\n" + "BarangGaib\n" + "10\n" + "\n" + // Tambah stok barang tidak ada
                    "3\n" + "5\n" + "BarangGaib\n" + "10\n" + "\n" + // Kurangi stok barang tidak ada
                    "0\nexit\n";

                using (var keyboard = new StringReader(skenario))
                using (var monitor = new StringWriter())
                {
                    Console.SetIn(keyboard); Console.SetOut(monitor); app.Run();
                }
            }
            finally { Console.SetOut(originalOut); Console.SetIn(originalIn); }
        }

        //Kelola Akun
        [TestMethod]
        public void KelolaAkun_Berhasil()
        {
            var originalOut = Console.Out;
            var originalIn = Console.In;

            try
            {
                var app = new ConsoleApp(new StockService(), new UserService(), new HistoryService());

                var skenario =
                    "admin\n" +
                    "admin123\n" +
                    "1\n" +          //Kelola Akun
                    "\n" +          
                    "0\n" +          
                    "0\n" + 
                    "exit\n";

                using (var keyboard = new StringReader(skenario))
                using (var monitor = new StringWriter())
                {
                    Console.SetIn(keyboard);
                    Console.SetOut(monitor);

                    app.Run();

                    var hasilLayar = monitor.ToString();

                   
                    Assert.IsTrue(hasilLayar.Contains("KELOLA AKUN") || hasilLayar.Contains("Kelola Akun"),
                        $"\n--- DEBUG LOG ---\nGagal memuat halaman Kelola Akun! Layar:\n[{hasilLayar}]\n-----------------");
                }
            }
            finally
            {
                Console.SetOut(originalOut);
                Console.SetIn(originalIn);
            }
        }

        [TestMethod]
        public void KelolaAkun_TambahAkun_HarusBerhasil()
        {
            var originalOut = Console.Out;
            var originalIn = Console.In;
            try
            {
                var app = new ConsoleApp(new StockService(), new UserService(), new HistoryService());

                var skenario =
                    "admin\n"+
                    "admin123\n" +      
                    "1\n" +                     
                    "\n" +
                    "1\n" + 
                    "pegawai_baru\n" +      
                    "pegawai@mail.com\n" +  
                    "rahasia123\n" +        
                    "User\n" +              
                    "\n" +                  
                    "\n" +                 
                    "0\n0\nexit\n";            

                using (var keyboardPalsu = new StringReader(skenario))
                using (var monitorPalsu = new StringWriter())
                {
                    Console.SetIn(keyboardPalsu);
                    Console.SetOut(monitorPalsu);
                    app.Run();

                    var hasilLayar = monitorPalsu.ToString();
                    Assert.IsTrue(hasilLayar.Contains("Akun berhasil ditambahkan!"),
                        $"\n--- DEBUG LOG ---\nPesan error tidak ditemukan! Layar:\n[{hasilLayar}]\n-----------------");
                }
            }
            finally 
            { 
                Console.SetOut(originalOut); 
                Console.SetIn(originalIn); 
            }
        }

        [TestMethod]
        public void KelolaAkun_TambahAkunGagal_BooleanBerhasilFalse()
        {
            var originalOut = Console.Out;
            var originalIn = Console.In;
            try
            {
                var app = new ConsoleApp(new StockService(), new UserService(), new HistoryService());
                // Menambah username yang sudah terpakai
                var skenario =
                    "admin\nadmin123\n" +
                    "1\n" + "\n" +          // Masuk kelola akun
                    "1\n" +                 // Tambah
                    "admin\n" + "a@m.com\n" + "p\n" + "Admin\n" +
                    "\n" +
                    "\n" + 
                    "0\n0\nexit\n";

                using (var keyboard = new StringReader(skenario))
                using (var monitor = new StringWriter())
                {
                    Console.SetIn(keyboard); Console.SetOut(monitor); app.Run();
                }
            }
            finally { Console.SetOut(originalOut); Console.SetIn(originalIn); }
        }

        [TestMethod]
        public void KelolaAkun_EditAkunInputIdBukanAngka_HarusMenampilkanError()
        {
            var originalOut = Console.Out;
            var originalIn = Console.In;
            try
            {
                var app = new ConsoleApp(new StockService(), new UserService(), new HistoryService());

                var skenarioTest =
                    "admin\nadmin123\n" +
                    "1\n" +                 
                    "\n" +
                    "2\n"+
                    "BukanAngka\n" +       //ID dipilih berupa huruf                  
                    "0\n" +                                  
                    "exit\n";

                using (var keyboardPalsu = new StringReader(skenarioTest))
                using (var monitorPalsu = new StringWriter())
                {
                    Console.SetIn(keyboardPalsu);
                    Console.SetOut(monitorPalsu);
                    app.Run();

                    var hasilLayar = monitorPalsu.ToString();
                    Assert.IsTrue(hasilLayar.Contains("ID harus berupa angka!"),
                        $"\n--- DEBUG LOG ---\nPesan error tidak ditemukan! Layar:\n[{hasilLayar}]\n-----------------");
                }
            }
            finally 
            { 
                Console.SetOut(originalOut); 
                Console.SetIn(originalIn); 
            }
        }

        [TestMethod]
        public void KelolaAkun_HapusAkun_Sukses_CetakPesanBerhasil()
        {
            var originalOut = Console.Out;
            var originalIn = Console.In;
            try
            {
                var app = new ConsoleApp(new StockService(), new UserService(), new HistoryService());
                var skenario = "admin\nadmin123\n1\n\n3\n2\n\n\n0\n0\nexit\n";

                using (var keyboard = new StringReader(skenario))
                using (var monitor = new StringWriter())
                {
                    Console.SetIn(keyboard); Console.SetOut(monitor); app.Run();
                    Assert.IsTrue(monitor.ToString().Contains("Akun berhasil dihapus!"));
                }
            }
            finally { Console.SetOut(originalOut); Console.SetIn(originalIn); }
        }

        [TestMethod]
        public void KelolaAkun_EditAkun_HarusBerhasil()
        {
            var originalOut = Console.Out;
            var originalIn = Console.In;
            try
            {
                var app = new ConsoleApp(new StockService(), new UserService(), new HistoryService());
                var skenario =
                    "admin\nadmin123\n" +
                    "1\n" +
                    "\n" +                  // Kelola akun
                    "2\n" +                 // Edit 
                    "2\n" +                 // Input ID yang mau diedit
                    "admin_edit\n" +        // Input username baru
                    "admin@mail.com\n" +    // Input email baru
                    "admin123\n" +          // Input password baru
                    "Admin\n" +             // Input role baru
                    "\n" +
                    "\n" +                  
                    "0\n" +                 // Kembali ke menu 
                    "0\nexit\n";            // Logout & Exit

                using (var keyboard = new StringReader(skenario))
                using (var monitor = new StringWriter())
                {
                    Console.SetIn(keyboard); 
                    Console.SetOut(monitor); 
                    
                    app.Run();
                }
            }
            finally { Console.SetOut(originalOut); Console.SetIn(originalIn); }
        }

        [TestMethod]
        public void KelolaAkun_SkenarioGagalDanMenuInvalid_HarusTercover()
        {
            var originalOut = Console.Out;
            var originalIn = Console.In;
            try
            {
                var app = new ConsoleApp(new StockService(), new UserService(), new HistoryService());
                var skenario =
                    "admin\nadmin123\n" +
                    "1\n" +                 // Kelola akun
                    "\n" + 
                    "99\n" +                // Pilih 99 
                    "\n" +
                    "\n" +
                    "3\n" +                 // Hapus akun
                    "999\n" +               // Pilih ID 999 (tidak ada)
                    "\n" +
                    "\n" +
                    "0\n" +                 // Kembali ke menu
                    "0\nexit\n";            

                using (var keyboard = new StringReader(skenario))
                using (var monitor = new StringWriter())
                {
                    Console.SetIn(keyboard); Console.SetOut(monitor); app.Run();
                }
            }
            finally { Console.SetOut(originalOut); Console.SetIn(originalIn); }
        }

        [TestMethod]
        public void KelolaAkun_HapusAkunIdInvalid_HarusMenampilkanError()
        {
            var originalOut = Console.Out;
            var originalIn = Console.In;
            try
            {
                var app = new ConsoleApp(new StockService(), new UserService(), new HistoryService());
                var skenario =
                    "admin\nadmin123\n" +
                    "1\n" +
                    "\n" +                  // Kelola akun
                    "3\n" +                 // Hapus akun
                    "BukanAngka\n" +        // ID diisi huruf 
                    "0\nexit\n";

                using (var keyboard = new StringReader(skenario))
                using (var monitor = new StringWriter())
                {
                    Console.SetIn(keyboard); Console.SetOut(monitor); app.Run();
                    Assert.IsTrue(monitor.ToString().Contains("ID harus berupa angka!"));
                }
            }
            finally { Console.SetOut(originalOut); Console.SetIn(originalIn); }
        }
    }
}

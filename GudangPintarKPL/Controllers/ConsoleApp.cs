using GudangPintar.Model;
using GudangPintarKPL.Controllers;
using GudangPintarKPL.Models;
using GudangPintarKPL.Printer;
using Microsoft.AspNetCore.Components.Sections;
using System;
using System.Globalization;

namespace GudangPintar.Controllers
{
    public class ConsoleApp
    {
        private readonly StockService stock;
        private readonly UserService user;
        private readonly HistoryService history;

        public ConsoleApp(StockService s, UserService u, HistoryService h)
        {
            stock = s;
            user = u;
            history = h;
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("\n=== LOGIN ===\n");

                Console.Write("Username: ");
                var uname = Console.ReadLine();

                if (uname == "exit" || uname == null) break;

                Console.Write("Password: ");
                var pass = Console.ReadLine();

                Console.WriteLine();

                if (string.IsNullOrWhiteSpace(uname) || string.IsNullOrWhiteSpace(pass))
                    {
                        Console.WriteLine("Username dan password tidak boleh kosong!");
                        Console.WriteLine("\nTekan ENTER...");
                        Console.ReadLine();
                        continue;
                    }

                var login = user.Login(uname, pass);

                if (login == null)
                {
                    Console.WriteLine("Login gagal!");
                    Console.WriteLine("\nTekan ENTER...");
                    Console.ReadLine();
                    continue;
                }

                var (u, role) = login.Value;
                Menu(u, role);
            }
        }

        private void Menu(User u, Role role)
        {
            while (true)
            {
                Console.WriteLine("\n=== MENU ===\n");

                if (role == Role.Admin)
                    Console.WriteLine("1. Kelola Akun");

                Console.WriteLine("2. Lihat Stok");
                Console.WriteLine("3. Kelola Stok");
                Console.WriteLine("4. Histori");
                Console.WriteLine("0. Logout");

                Console.Write("\nPilih: ");
                var input = Console.ReadLine();
                Console.WriteLine();

                if (input == null || input == "0") break;

                if (input == "1" && role == Role.Admin)
                    KelolaAkun();

                else if (input == "2")
                    LihatStok();

                else if (input == "3")
                    KelolaStok(u.Username);

                else if (input == "4")
                    LihatHistory();
                else
                    Console.WriteLine("Input Tidak Valid!");
            }
        }

        private void LihatStok()
        {
            var dataStock = stock.GetAll();

            if (dataStock.Count == 0)
            {
                Console.WriteLine("\n[ INFO: Belum ada barang yang ditambahkan ]");
            }

            TablePrinter.Print(dataStock, "Data Stok Barang");
        }

        private void KelolaStok(string userLogin)
        {
            Console.WriteLine("\n=== KELOLA STOK ===\n");

            Console.WriteLine("1. Tambah Barang");
            Console.WriteLine("2. Hapus Barang");
            Console.WriteLine("3. Edit Barang");
            Console.WriteLine("4. Tambah Stok");
            Console.WriteLine("5. Kurangi Stok");

            Console.Write("\nPilih: ");
            var i = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Nama barang: ");
            var nama = Console.ReadLine();
            Console.WriteLine();

            if (i == "1")
            {
                Console.WriteLine("Kategori:");
                foreach (var c in Enum.GetValues(typeof(Category)))
                    Console.WriteLine($"- {c}");

                Console.Write("\nPilih kategori: ");
                var kat = (Category)Enum.Parse(typeof(Category), Console.ReadLine());

                Console.Write("Jumlah: ");
                if (!int.TryParse(Console.ReadLine(), out int j))
                {
                    Console.WriteLine("Jumlah harus berupa angka!");
                    return;
                }

                Console.Write("Harga: ");
                if (!double.TryParse(Console.ReadLine(), out double h))
                {
                    Console.WriteLine("Harga harus berupa angka!");
                    return;
                }

                Console.Write("Tanggal kadaluarsa (yyyy-MM-dd) [kosong jika tidak ada]: ");
                var kadInput = Console.ReadLine();
                DateTime? kadaluarsa = null;
                if (!string.IsNullOrWhiteSpace(kadInput))
                {
                    if (DateTime.TryParseExact(kadInput, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsed))
                        kadaluarsa = parsed;
                    else
                    {
                        Console.WriteLine("Format tanggal salah. Gunakan yyyy-MM-dd.");
                        return;
                    }
                }

                bool berhasil = stock.Add(new Stock(nama, kat, j, h));

                if (berhasil)
                {
                    history.Add(new StockHistory(nama, "Tambah Barang", j, userLogin));
                }
            }

            else if (i == "2")
            {
                bool berhasil = stock.Delete(nama);

                if (berhasil)
                {
                    history.Add(new StockHistory(nama, "Hapus Barang", 0, userLogin));
                }
            }

            else if (i == "3")
            {
                Console.Write("Nama baru: ");
                var newNama = Console.ReadLine();

                Console.WriteLine("\nKategori:");
                foreach (var c in Enum.GetValues(typeof(Category)))
                    Console.WriteLine($"- {c}");

                Console.Write("\nPilih kategori: ");
                var kat = (Category)Enum.Parse(typeof(Category), Console.ReadLine());

                Console.Write("Harga baru: ");
                if (!double.TryParse(Console.ReadLine(), out double h))
                {
                    Console.WriteLine("Harga harus berupa angka!");
                    return;
                }

                Console.Write("Tanggal kadaluarsa (yyyy-MM-dd) [kosong jika tidak ada]: ");
                var kadInput = Console.ReadLine();
                DateTime? kadaluarsa = null;
                if (!string.IsNullOrWhiteSpace(kadInput))
                {
                    if (DateTime.TryParseExact(kadInput, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsed))
                        kadaluarsa = parsed;
                    else
                    {
                        Console.WriteLine("Format tanggal salah. Gunakan yyyy-MM-dd.");
                        return;
                    }
                }

<<<<<<< HEAD:GudangPintarKPL/GudangPintarKPL/Controllers/ConsoleApp.cs
                stock.Update(nama, newNama, kat, h, kadaluarsa);
=======
                stock.Update(nama, newNama, kat, h);
>>>>>>> a8b62e2d6144355e4b71cb7d24b87ec53897866e:GudangPintarKPL/Controllers/ConsoleApp.cs
                history.Add(new StockHistory(nama, "Edit Barang", 0, userLogin));
            }

            else if (i == "4")
            {
                Console.Write("Jumlah: ");
                if (!int.TryParse(Console.ReadLine(), out int j))
                {
                    Console.WriteLine("Jumlah harus berupa angka!");
                    return;
                }

                bool berhasil = stock.TambahStok(nama, j);

                if (berhasil)
                {
                    history.Add(new StockHistory(nama, "Tambah Stok", j, userLogin));
                }
            }

            else if (i == "5")
            {
                Console.Write("Jumlah: ");
                if (!int.TryParse(Console.ReadLine(), out int j))
                {
                    Console.WriteLine("Jumlah harus berupa angka!");
                    return;
                }

                bool berhasil = stock.KurangiStok(nama, j);

                if (berhasil)
                {
                    history.Add(new StockHistory(nama, "Kurangi Stok", j, userLogin));
                }
            }

            Console.WriteLine("\nOperasi selesai!");
            Console.WriteLine("Tekan ENTER untuk kembali...");
            Console.ReadLine();
            Console.WriteLine();
        }

        private void KelolaAkun()
        {
            while (true)
            {
                TablePrinter.Print(user.GetAll(),"Daftar Akun");

                Console.WriteLine("\n1. Tambah");
                Console.WriteLine("2. Edit");
                Console.WriteLine("3. Hapus");
                Console.WriteLine("0. Kembali");

                Console.Write("\nPilih: ");
                var i = Console.ReadLine();
                Console.WriteLine();

                if (i == null || i == "0") break;

                if (i == "1")
                {
                    Console.Write("Username: ");
                    var uname = Console.ReadLine();

                    Console.Write("Email: ");
                    var email = Console.ReadLine();

                    Console.Write("Password: ");
                    var pass = Console.ReadLine();

                    Console.WriteLine("\nRole:");
                    foreach (var r in Enum.GetValues(typeof(Role)))
                        Console.WriteLine($"- {r}");

                    Console.Write("\nPilih role: ");
                    var role = (Role)Enum.Parse(typeof(Role), Console.ReadLine());

                    bool berhasil = user.Add(uname, email, pass, role);

                    if (berhasil)
                    {
                        Console.WriteLine("Akun berhasil ditambahkan!");
                    }
                }

                else if (i == "2")
                {
                    Console.Write("ID: ");
                    if (!int.TryParse(Console.ReadLine(), out int id))
                    {
                        Console.WriteLine("ID harus berupa angka!");
                        return;
                    }

                    Console.Write("Username: ");
                    var uname = Console.ReadLine();

                    Console.Write("Email: ");
                    var email = Console.ReadLine();

                    Console.Write("Password: ");
                    var pass = Console.ReadLine();

                    Console.WriteLine("\nRole:");
                    foreach (var r in Enum.GetValues(typeof(Role)))
                        Console.WriteLine($"- {r}");

                    Console.Write("\nPilih role: ");
                    var role = (Role)Enum.Parse(typeof(Role), Console.ReadLine());

                    user.Update(id, uname, email, pass, role);
                }

                else if (i == "3")
                {
                    Console.Write("ID: ");
                    if (!int.TryParse(Console.ReadLine(), out int id))
                    {
                        Console.WriteLine("ID harus berupa angka!");
                        return;
                    }
                    bool berhasil = user.Delete(id);

                    if (berhasil)
                    {
                        Console.WriteLine("Akun berhasil dihapus!");
                    }
                }

                Console.WriteLine("\nOperasi selesai!");
                Console.WriteLine("Tekan ENTER untuk lanjut...");
                Console.ReadLine();
                Console.WriteLine();
            }
        }

        private void LihatHistory()
        { 
            var dataHistory = history.GetAll();

            if (dataHistory.Count == 0)
            {
                Console.WriteLine("\n[ INFO: Belum ada transaksi / History kosong ]");
            }

            TablePrinter.Print(dataHistory, "Histori Transaksi");
        }
    }
}
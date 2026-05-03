using GudangPintar.Model;
using GudangPintarKPL.Models;
using System;

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

                Console.Write("Password: ");
                var pass = Console.ReadLine();

                Console.WriteLine();

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

                if (input == "0") break;

                if (input == "1" && role == Role.Admin)
                    KelolaAkun();

                else if (input == "2")
                    LihatStok();

                else if (input == "3")
                    KelolaStok(u.Username);

                else if (input == "4")
                    LihatHistory();
            }
        }

        private void LihatStok()
        {
            Console.WriteLine("\n=== DATA STOK ===\n");

            Console.WriteLine("{0,-15} {1,-10} {2,-8} {3,-10} {4}",
                "Nama", "Kategori", "Jumlah", "Harga", "Status");

            Console.WriteLine("-------------------------------------------------------------");

            foreach (var s in stock.GetAll())
            {
                var notif = Notification.GetNotifikasi(s);

                Console.WriteLine("{0,-15} {1,-10} {2,-8} {3,-10} {4}",
                    s.NamaBarang, s.Kategori, s.Jumlah, s.Harga, notif);
            }

            Console.WriteLine("\nTekan ENTER untuk kembali...");
            Console.ReadLine();
            Console.WriteLine();
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
                int j = int.Parse(Console.ReadLine());

                Console.Write("Harga: ");
                double h = double.Parse(Console.ReadLine());

                stock.Add(new Stock(nama, kat, j, h));
                history.Add(new StockHistory(nama, "Tambah Barang", j, userLogin));
            }

            else if (i == "2")
            {
                stock.Delete(nama);
                history.Add(new StockHistory(nama, "Hapus Barang", 0, userLogin));
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
                double h = double.Parse(Console.ReadLine());

                stock.Update(nama, newNama, kat, h);
                history.Add(new StockHistory(nama, "Edit Barang", 0, userLogin));
            }

            else if (i == "4")
            {
                Console.Write("Jumlah: ");
                int j = int.Parse(Console.ReadLine());

                stock.TambahStok(nama, j);
                history.Add(new StockHistory(nama, "Tambah Stok", j, userLogin));
            }

            else if (i == "5")
            {
                Console.Write("Jumlah: ");
                int j = int.Parse(Console.ReadLine());

                stock.KurangiStok(nama, j);
                history.Add(new StockHistory(nama, "Kurangi Stok", j, userLogin));
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
                Console.WriteLine("\n=== KELOLA AKUN ===\n");

                foreach (var u in user.GetAll())
                {
                    Console.WriteLine($"{u.Id} | {u.Username} | {u.Email} | {user.GetRole(u.Username)}");
                }

                Console.WriteLine("\n1. Tambah");
                Console.WriteLine("2. Edit");
                Console.WriteLine("3. Hapus");
                Console.WriteLine("0. Kembali");

                Console.Write("\nPilih: ");
                var i = Console.ReadLine();
                Console.WriteLine();

                if (i == "0") break;

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

                    user.Add(uname, email, pass, role);
                }

                else if (i == "2")
                {
                    Console.Write("ID: ");
                    int id = int.Parse(Console.ReadLine());

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
                    int id = int.Parse(Console.ReadLine());
                    user.Delete(id);
                }

                Console.WriteLine("\nOperasi selesai!");
                Console.WriteLine("Tekan ENTER untuk lanjut...");
                Console.ReadLine();
                Console.WriteLine();
            }
        }

        private void LihatHistory()
        {
            Console.WriteLine("\n=== HISTORI ===\n");

            foreach (var h in history.GetAll())
                h.Tampilkan();

            Console.WriteLine("\nTekan ENTER untuk kembali...");
            Console.ReadLine();
            Console.WriteLine();
        }
    }
}
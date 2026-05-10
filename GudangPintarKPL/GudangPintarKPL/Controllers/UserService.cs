using GudangPintarKPL.Models;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

namespace GudangPintar.Controllers
{
    public class UserService
    {
        private List<User> users = new();
        private Dictionary<string, (string password, Role role)> auth = new();

        private int nextId = 1;

        public UserService()
        {
            Add("admin", "admin@mail.com", "admin123", Role.Admin);
            Add("user", "user@mail.com", "user123", Role.User);
        }

        public List<User> GetAll() => users;

        public (User, Role)? Login(string username, string password)
        {
            Debug.Assert(username != null, "Username tidak boleh null");
            Debug.Assert(password != null, "Password tidak boleh null");

            if (auth.ContainsKey(username) &&
                auth[username].password == password)
            {
                var user = users.First(u => u.Username == username);
                return (user, auth[username].role);
            }

            return null;
        }

        public bool Add(string username, string email, string password, Role role)
        {
            if (users.Any(u => u.Username == username))
            {
                Console.WriteLine("Username sudah digunakan!");
                return false;
            }

            if (password.Length < 6)
            {
                Console.WriteLine("Password minimal 6 karakter!");
                return false;
            }

            Debug.Assert(!string.IsNullOrWhiteSpace(username));
            Debug.Assert(password.Length >= 6);

            users.Add(new User
            {
                Id = nextId++,
                Username = username,
                Email = email,
                RoleUser = role
            });

            auth[username] = (password, role);

            return true;
        }

        public bool Delete(int id)
        {
            var u = users.FirstOrDefault(x => x.Id == id);

            if (u == null)
            {
                Console.WriteLine("User tidak ditemukan!");
                return false;
            }

            if (u.Username == "admin")
            {
                Console.WriteLine("Tidak dapat menghapus akun admin utama!");
                return false;
            }

            users.Remove(u);
            auth.Remove(u.Username);

            return true;
        }

        public void Update(int id, string username, string email, string password, Role role)
        {
            var u = users.FirstOrDefault(x => x.Id == id);

            if (users.Any(x => x.Username == username && x.Id != id))
            {
                Console.WriteLine("Username sudah digunakan!");
                return;
            }

            if (u != null)
            {
                auth.Remove(u.Username);

                u.Username = username;
                u.Email = email;
                u.RoleUser = role;

                auth[username] = (password, role);
            }
        }

        public Role GetRole(string username) => auth[username].role;
    }
}
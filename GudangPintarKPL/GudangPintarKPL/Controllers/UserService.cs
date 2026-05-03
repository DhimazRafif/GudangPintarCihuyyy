using GudangPintarKPL.Models;
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
            Add("admin", "admin@mail.com", "admin", Role.Admin);
            Add("user", "user@mail.com", "user", Role.User);
        }

        public List<User> GetAll() => users;

        public (User, Role)? Login(string username, string password)
        {
            if (auth.ContainsKey(username) && auth[username].password == password)
            {
                var user = users.First(u => u.Username == username);
                return (user, auth[username].role);
            }
            return null;
        }

        public void Add(string username, string email, string password, Role role)
        {
            users.Add(new User
            {
                Id = nextId++,
                Username = username,
                Email = email
            });

            auth[username] = (password, role);
        }

        public void Delete(int id)
        {
            var u = users.FirstOrDefault(x => x.Id == id);
            if (u != null)
            {
                users.Remove(u);
                auth.Remove(u.Username);
            }
        }

        public void Update(int id, string username, string email, string password, Role role)
        {
            var u = users.FirstOrDefault(x => x.Id == id);
            if (u != null)
            {
                auth.Remove(u.Username);

                u.Username = username;
                u.Email = email;

                auth[username] = (password, role);
            }
        }

        public Role GetRole(string username) => auth[username].role;
    }
}
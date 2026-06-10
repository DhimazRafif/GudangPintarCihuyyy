using GudangPintar.Controllers;
using GudangPintarKPL.Controllers;
using GudangPintarKPL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySQL

namespace GudangPintarGui.ControllerGui
{
    public class AkunController
    {
        private readonly UserService _userService;

        public AkunController()
        {
            _userService = new UserService();
        }

        // Mendapatkan semua user (kecuali yang soft delete)
        public List<User> GetAllActiveUsers()
        {
            return _userService.GetAll()
                .Where(u => u.IsActive)  // Hanya yang aktif
                .ToList();
        }

        // Soft Delete - hanya ubah status isActive ke false
        public bool SoftDeleteUser(int id)
        {
            var user = _userService.GetAll().FirstOrDefault(u => u.Id == id);
            if (user != null && user.Username != "admin") // Admin utama tidak bisa dihapus
            {
                user.IsActive = false;
                return true;
            }
            return false;
        }

        // Tambah user baru
        public bool AddUser(string username, string email, string password, Role role)
        {
            return _userService.Add(username, email, password, role);
        }

        // Update user
        public bool UpdateUser(int id, string username, string email, string password, Role role)
        {
            var user = _userService.GetAll().FirstOrDefault(u => u.Id == id);
            if (user != null && user.IsActive)
            {
                _userService.Update(id, username, email, password, role);
                return true;
            }
            return false;
        }

        // Hard Delete (opsional - benar-benar hapus)
        public bool HardDeleteUser(int id)
        {
            return _userService.Delete(id);
        }
    }
}
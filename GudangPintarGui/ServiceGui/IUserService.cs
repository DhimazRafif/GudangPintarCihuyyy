using GudangPintarGui.Models;
using System.Collections.Generic;

namespace GudangPintarGui.ServiceGUI
{
    public interface IUserService
    {
        List<User> GetAllActive();              // Hanya IsActive = true
        List<User> GetAll();                    // Semua user (untuk admin)
        User GetById(int userId);
        User GetByUsername(string username);
        bool Add(string name, string username, string password, int roleId);
        bool Update(int userId, string name, string username, string password, int roleId);
        bool Delete(int userId);                // Soft delete
        (User user, int roleId)? Login(string username, string password);
        bool IsUsernameExists(string username, int excludeUserId = -1);
    }
}
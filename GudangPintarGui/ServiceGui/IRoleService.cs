using GudangPintarGui.Models;
using System.Collections.Generic;

namespace GudangPintarGui.ServiceGUI
{
    public interface IRoleService
    {
        // Get semua role dari database
        List<Role> GetAllRoles();

        // Get role by ID
        Role GetRoleById(int roleId);

        // Get role name by ID
        string GetRoleName(int roleId);

        // Check if role exists
        bool RoleExists(int roleId);

        // Get default role (Pegawai)
        int GetDefaultRoleId();
    }
}
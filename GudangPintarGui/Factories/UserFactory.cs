using System;
using GudangPintarGui.ServiceGUI;

namespace GudangPintarGui.Factories
{
    // Interface untuk hak akses
    public interface IUserPrivileges
    {
        bool CanManageAccounts { get; }
        bool CanManageItems { get; }
        bool CanViewHistory { get; }
        bool CanViewItems { get; }
        string GetRoleDisplayName();
    }

    public class AdminPrivileges : IUserPrivileges
    {
        public bool CanManageAccounts => true;
        public bool CanManageItems => true;
        public bool CanViewHistory => true;
        public bool CanViewItems => true;
        public string GetRoleDisplayName() => "Admin";
    }

    public class EmployeePrivileges : IUserPrivileges
    {
        public bool CanManageAccounts => false;
        public bool CanManageItems => false;
        public bool CanViewHistory => true;
        public bool CanViewItems => true;
        public string GetRoleDisplayName() => "Pegawai";
    }

    // Factory untuk membuat User object
    public interface IUserFactory
    {
        User CreateUser(string name, string username, string password, int roleId);
    }

    public class AdminUserFactory : IUserFactory
    {
        public User CreateUser(string name, string username, string password, int roleId)
        {
            return new User(0, name, username, password, roleId, true);
        }
    }

    public class PegawaiUserFactory : IUserFactory
    {
        public User CreateUser(string name, string username, string password, int roleId)
        {
            return new User(0, name, username, password, roleId, true);
        }
    }

    public static class UserFactoryProducer
    {
        public static IUserFactory GetFactory(int roleId)
        {
            return roleId switch
            {
                RoleService.ROLE_ADMIN => new AdminUserFactory(),
                RoleService.ROLE_PEGAWAI => new PegawaiUserFactory(),
                _ => throw new ArgumentException($"Role ID {roleId} tidak dikenal")
            };
        }
    }

    // Helper untuk konversi (jika masih diperlukan)
    public static class UserAccountFactory
    {
        public static IUserPrivileges CreatePrivileges(int roleId)
        {
            return roleId == RoleService.ROLE_ADMIN ? new AdminPrivileges() : new EmployeePrivileges();
        }

        public static string GetRoleNameFromDatabase(int roleId)
        {
            return roleId == RoleService.ROLE_ADMIN ? "Admin" : "Pegawai";
        }
    }
}
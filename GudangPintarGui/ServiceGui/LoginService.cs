using GudangPintarGui.ConfigDatabase;
using GudangPintarGui.Models;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using GudangPintarGui.Utils;

namespace GudangPintarGui.ServiceGui
{
    public class LoginService
    {
        public User ValidateLogin(string username, string password)
        {
            using (var connection = DBConnection.GetInstance().GetConnection())
            {
                connection.Open();

                string query = "SELECT u.userid, u.username, u.password, r.name AS nama_role " +
                               "FROM user u " +
                               "JOIN role r ON u.role = r.roleid " +
                               "WHERE u.isActive = 1 AND u.username = @username";

                using(var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string dbPasswordHash = reader.GetString("password");

                            // Verifikasi menggunakan SHA-256 helper
                            if (PasswordHelper.VerifyPassword(password, dbPasswordHash))
                            {
                                return new User
                                {
                                    UserId = reader.GetInt32("userid"),
                                    Username = reader.GetString("username"),
                                    Password = dbPasswordHash,
                                    RoleUser = reader.GetString("nama_role")
                                };
                            }
                        }
                    }
                }
            }
            return null;
        }
    }
}

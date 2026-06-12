using System;
using System.Windows.Forms;
using GudangPintar.Controllers;
using GudangPintarGui.View;
using GudangPintarGui.ConfigDatabase;
using GudangPintarGui.ServiceGui;
using GudangPintarGui.Models;
using Microsoft.AspNetCore.Identity.Data;

namespace GudangPintarGui.ControllerGui
{
    public class LoginController
    {
        private readonly LoginService _loginService;
        
        public LoginController()
        {
            _loginService = new LoginService();
        }

        public void Login(string username, string password, Login loginForm)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username atau Password tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var user = _loginService.ValidateLogin(username, password);

                if (user == null)
                {
                    MessageBox.Show("Login gagal! Periksa kembali kredensial Anda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                loginForm.Hide();

                if (user.RoleUser == "Admin")
                {
                    Dashboard adminDashboard = new Dashboard(user);
                    adminDashboard.ShowDialog();
                }
                else if (user.RoleUser == "Pegawai")
                {
                    DashboardPegawai pegawaiDashboard = new DashboardPegawai(user);
                    pegawaiDashboard.ShowDialog();
                }

                loginForm.ClearInputs();
                loginForm.Show();
            }
            catch (Exception ex)
            {
                loginForm.Show();
                MessageBox.Show($"Aplikasi Crash saat proses Login!\n\nPesan Eror: {ex.Message}",
                                "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            loginForm.ClearInputs();
            loginForm.Show();
        }
    
    }
}

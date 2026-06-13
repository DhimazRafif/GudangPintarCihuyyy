using System;
using System.Windows.Forms;
using GudangPintar.Controllers;
using GudangPintarGui.View;
using GudangPintarKPL.Controllers;
using GudangPintarKPL.Models;
using Microsoft.AspNetCore.Identity.Data;

namespace GudangPintarGui.ControllerGui
{
    public class LoginController
    {
        private readonly UserService _userService;
        private readonly StockService _stockService;
        private readonly HistoryService _historyService;

        public LoginController(UserService userService, StockService stockService, HistoryService historyService)
        {
            _userService = userService;
            _stockService = stockService;
            _historyService = historyService;
        }

        public void Login(string username, string password, Login loginForm)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username atau Password tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var loginResult = _userService.Login(username, password);

            if (loginResult == null)
            {
                MessageBox.Show("Login gagal! Periksa kembali kredensial Anda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var (user, role) = loginResult.Value;

            loginForm.Hide();

            if (role == Role.Admin)
            {
                Dashboard adminDashboard = new Dashboard(user, _stockService, _userService, _historyService);
                adminDashboard.ShowDialog();
            }
            else if (role == Role.User)
            {
                DashboardPegawai pegawaiDashboard = new DashboardPegawai(user, _stockService, _historyService);
                pegawaiDashboard.ShowDialog();
            }


            loginForm.ClearInputs();
            loginForm.Show();
        }
    }
}

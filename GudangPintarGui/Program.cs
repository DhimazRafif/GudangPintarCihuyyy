using GudangPintar.Controllers;
using GudangPintarGui.ControllerGui;
using GudangPintarGui.View; // Menuju folder View tempat Login Form berada
using GudangPintarKPL.Controllers; // Menuju namespace tempat service kamu berada
using GudangPintarKPL.Models;
using System;
using System.Windows.Forms;

namespace GudangPintarGui
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 1. Inisialisasi service dari project GudangPintarKPL
            var stockService = new StockService();
            var userService = new UserService();
            var historyService = new HistoryService();

            var loginController = new LoginController(userService, stockService, historyService);

            userService.Add("admin", "admin@mail.com", "admin123", Role.Admin);
            userService.Add("pegawai", "pegawai@mail.com", "pegawai123", Role.User);

            // 2. Jalankan Login Form dengan menyuntikkan services
            Application.Run(new Login(loginController));
        }
    }
}
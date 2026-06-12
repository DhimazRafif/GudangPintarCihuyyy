using GudangPintar.Controllers;
using GudangPintarGui.ControllerGui;
using GudangPintarGui.View;
using GudangPintarGui.Models;
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

            try
            {
                // Jaring pengaman untuk mendeteksi eror di gerbang awal
                var loginController = new LoginController();
                Application.Run(new Login(loginController));
            }
            catch (Exception ex)
            {
                // Jika gerbang awal crash, kotak pesan ini akan langsung muncul!
                MessageBox.Show($"Aplikasi Gagal Start!\n\nPesan Eror: {ex.Message}\n\nDetail: {ex.StackTrace}",
                                "Fatal Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
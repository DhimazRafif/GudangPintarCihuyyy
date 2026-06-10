using GudangPintarGui.ControllerGui;
using Microsoft.AspNetCore.Mvc;

namespace GudangPintarGui
{
    public partial class Login : Form
    {
        private readonly LoginController _logincontroller;
        public Login(LoginController loginController)
        {
            InitializeComponent();
            _logincontroller = loginController;
        }

        public void ClearInputs()
        {
            tbUsername.Text = "";
            tbPassword.Text = "";
            tbUsername.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;

            _logincontroller.Login(username, password, this);
        }
    }
}

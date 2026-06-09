using GudangPintar.Controllers;
using GudangPintarGui.ControllerGui;
using GudangPintarKPL.Controllers;
using GudangPintarKPL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;

namespace GudangPintarGui
{
    public partial class Dashboard : Form
    {
        private readonly User _currentUser;
        private readonly StockService _stockService;
        private readonly UserService _userService;
        private readonly HistoryService _historyService;
        private readonly DashboardController _dashboardController;
        public Dashboard(User user, StockService s, UserService u, HistoryService h)
        {
            InitializeComponent();

            _currentUser = user;
            _stockService = s;
            _userService = u;
            _historyService = h;

            _dashboardController = new DashboardController(s, h);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            _dashboardController.LoadDataBarang(dgvBarang);
            _dashboardController.UpdateSummaryCards(lblTotalBarang, lblTotalStok);
        }
    }
}

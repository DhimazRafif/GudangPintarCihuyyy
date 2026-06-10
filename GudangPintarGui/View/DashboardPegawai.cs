using GudangPintar.Controllers;
using GudangPintarGui.ControllerGui;
using GudangPintarKPL.Controllers;
using GudangPintarKPL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GudangPintarGui.View
{
    public partial class DashboardPegawai : Form
    {
        private readonly User _currentUser;
        private readonly StockService _stockService;
        private readonly UserService _userService;
        private readonly HistoryService _historyService;
        private readonly DashboardController _dashboardController;
        public DashboardPegawai(User user, StockService s, HistoryService h)
        {
            InitializeComponent();

            _currentUser = user;

            _dashboardController = new DashboardController(s, h);
        }

        private void DashboardPegawai_Load(object sender, EventArgs e)
        {
            _dashboardController.LoadDataBarang(dgvBarangPegawai);

            _dashboardController.UpdateSummaryCards(lblTotalBarangPegawai, lblTotalStokPegawai);
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

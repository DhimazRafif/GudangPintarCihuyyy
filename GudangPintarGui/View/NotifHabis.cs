using System;
using System.Windows.Forms;

namespace GudangPintarGui.View
{
    public partial class NotifHabis : Form
    {
        public NotifHabis()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            button5.Click += button5_Click;
        }

        public NotifHabis(string namaBarang) : this()
        {
            SetBarang(namaBarang);
        }

        public void SetBarang(string namaBarang)
        {
            labelbarang.Text = namaBarang;
        }

        private void button5_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
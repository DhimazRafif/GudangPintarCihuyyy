namespace GudangPintarGui.View
{
    partial class DashboardPegawai
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel4 = new Panel();
            dgvBarangPegawai = new DataGridView();
            panel3 = new Panel();
            lblTotalStokPegawai = new Label();
            label1 = new Label();
            panel2 = new Panel();
            lblTotalBarangPegawai = new Label();
            label2 = new Label();
            panel1 = new Panel();
            btnLogout = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBarangPegawai).BeginInit();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel4
            // 
            panel4.Controls.Add(dgvBarangPegawai);
            panel4.Location = new Point(358, 196);
            panel4.Margin = new Padding(4);
            panel4.Name = "panel4";
            panel4.Size = new Size(1448, 1066);
            panel4.TabIndex = 4;
            // 
            // dgvBarangPegawai
            // 
            dgvBarangPegawai.BackgroundColor = SystemColors.ControlLightLight;
            dgvBarangPegawai.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBarangPegawai.Location = new Point(0, 0);
            dgvBarangPegawai.Margin = new Padding(4, 5, 4, 5);
            dgvBarangPegawai.Name = "dgvBarangPegawai";
            dgvBarangPegawai.RowHeadersWidth = 51;
            dgvBarangPegawai.Size = new Size(1448, 1066);
            dgvBarangPegawai.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = Color.LawnGreen;
            panel3.Controls.Add(lblTotalStokPegawai);
            panel3.Controls.Add(label1);
            panel3.Location = new Point(1060, 5);
            panel3.Margin = new Padding(4, 5, 4, 5);
            panel3.Name = "panel3";
            panel3.Size = new Size(744, 186);
            panel3.TabIndex = 20;
            // 
            // lblTotalStokPegawai
            // 
            lblTotalStokPegawai.AutoSize = true;
            lblTotalStokPegawai.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            lblTotalStokPegawai.ForeColor = Color.White;
            lblTotalStokPegawai.Location = new Point(276, 64);
            lblTotalStokPegawai.Margin = new Padding(4, 0, 4, 0);
            lblTotalStokPegawai.Name = "lblTotalStokPegawai";
            lblTotalStokPegawai.Size = new Size(107, 45);
            lblTotalStokPegawai.TabIndex = 2;
            lblTotalStokPegawai.Text = "label4";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(259, 21);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(145, 40);
            label1.TabIndex = 0;
            label1.Text = "Total Stok";
            // 
            // panel2
            // 
            panel2.BackColor = Color.LawnGreen;
            panel2.Controls.Add(lblTotalBarangPegawai);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(351, 5);
            panel2.Margin = new Padding(4, 5, 4, 5);
            panel2.Name = "panel2";
            panel2.Size = new Size(700, 186);
            panel2.TabIndex = 19;
            // 
            // lblTotalBarangPegawai
            // 
            lblTotalBarangPegawai.AutoSize = true;
            lblTotalBarangPegawai.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            lblTotalBarangPegawai.ForeColor = Color.White;
            lblTotalBarangPegawai.Location = new Point(292, 69);
            lblTotalBarangPegawai.Margin = new Padding(4, 0, 4, 0);
            lblTotalBarangPegawai.Name = "lblTotalBarangPegawai";
            lblTotalBarangPegawai.Size = new Size(102, 45);
            lblTotalBarangPegawai.TabIndex = 2;
            lblTotalBarangPegawai.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(260, 21);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(181, 40);
            label2.TabIndex = 1;
            label2.Text = "Total Barang";
            // 
            // panel1
            // 
            panel1.BackColor = Color.LawnGreen;
            panel1.Controls.Add(btnLogout);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(2, 5);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(340, 1259);
            panel1.TabIndex = 18;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.DarkGray;
            btnLogout.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = SystemColors.ControlText;
            btnLogout.Location = new Point(72, 1074);
            btnLogout.Margin = new Padding(4, 5, 4, 5);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(174, 51);
            btnLogout.TabIndex = 8;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(72, 481);
            button3.Margin = new Padding(4, 5, 4, 5);
            button3.Name = "button3";
            button3.Size = new Size(174, 61);
            button3.TabIndex = 7;
            button3.Text = "Riwayat";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(72, 371);
            button2.Margin = new Padding(4, 5, 4, 5);
            button2.Name = "button2";
            button2.Size = new Size(174, 65);
            button2.TabIndex = 6;
            button2.Text = "Barang";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(72, 265);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(174, 64);
            button1.TabIndex = 5;
            button1.Text = "Dashboard";
            button1.UseVisualStyleBackColor = true;
            // 
            // DashboardPegawai
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.White;
            ClientSize = new Size(1806, 1269);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(panel4);
            Margin = new Padding(4);
            Name = "DashboardPegawai";
            Text = "Form1";
            Load += DashboardPegawai_Load;
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBarangPegawai).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel4;
        private Panel panel3;
        private Label label1;
        private Panel panel2;
        private Label label2;
        private Panel panel1;
        private Button btnLogout;
        private Button button3;
        private Button button2;
        private Button button1;
        private DataGridView dgvBarangPegawai;
        private Label lblTotalBarangPegawai;
        private Label lblTotalStokPegawai;
    }
}
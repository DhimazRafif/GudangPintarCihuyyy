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
            panel1 = new Panel();
            btnLogout = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            panel2 = new Panel();
            lblTotalBarangPegawai = new Label();
            label1 = new Label();
            panel3 = new Panel();
            lblTotalStokPegawai = new Label();
            label2 = new Label();
            panel4 = new Panel();
            dgvBarangPegawai = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBarangPegawai).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.LimeGreen;
            panel1.Controls.Add(btnLogout);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(4, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(272, 743);
            panel1.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.DarkSeaGreen;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Location = new Point(78, 623);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(94, 29);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "btnLogout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.LightGreen;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(78, 266);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 2;
            button3.Text = "Riwayat";
            button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.LightGreen;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(78, 196);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 1;
            button2.Text = "Barang";
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.LightGreen;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(78, 132);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "Dashboard";
            button1.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.LimeGreen;
            panel2.Controls.Add(lblTotalBarangPegawai);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(286, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(482, 150);
            panel2.TabIndex = 2;
            // 
            // lblTotalBarangPegawai
            // 
            lblTotalBarangPegawai.AutoSize = true;
            lblTotalBarangPegawai.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalBarangPegawai.Location = new Point(185, 67);
            lblTotalBarangPegawai.Name = "lblTotalBarangPegawai";
            lblTotalBarangPegawai.Size = new Size(104, 41);
            lblTotalBarangPegawai.TabIndex = 1;
            lblTotalBarangPegawai.Text = "label3";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(149, 22);
            label1.Name = "label1";
            label1.Size = new Size(105, 23);
            label1.TabIndex = 0;
            label1.Text = "Total Barang";
            // 
            // panel3
            // 
            panel3.BackColor = Color.LimeGreen;
            panel3.Controls.Add(lblTotalStokPegawai);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(774, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(487, 150);
            panel3.TabIndex = 3;
            // 
            // lblTotalStokPegawai
            // 
            lblTotalStokPegawai.AutoSize = true;
            lblTotalStokPegawai.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalStokPegawai.Location = new Point(176, 67);
            lblTotalStokPegawai.Name = "lblTotalStokPegawai";
            lblTotalStokPegawai.Size = new Size(104, 41);
            lblTotalStokPegawai.TabIndex = 1;
            lblTotalStokPegawai.Text = "label4";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(153, 22);
            label2.Name = "label2";
            label2.Size = new Size(83, 23);
            label2.TabIndex = 0;
            label2.Text = "Total Stok";
            // 
            // panel4
            // 
            panel4.Controls.Add(dgvBarangPegawai);
            panel4.Location = new Point(286, 158);
            panel4.Name = "panel4";
            panel4.Size = new Size(975, 587);
            panel4.TabIndex = 4;
            // 
            // dgvBarangPegawai
            // 
            dgvBarangPegawai.BackgroundColor = SystemColors.ControlLightLight;
            dgvBarangPegawai.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBarangPegawai.Dock = DockStyle.Fill;
            dgvBarangPegawai.Location = new Point(0, 0);
            dgvBarangPegawai.Name = "dgvBarangPegawai";
            dgvBarangPegawai.RowHeadersVisible = false;
            dgvBarangPegawai.RowHeadersWidth = 51;
            dgvBarangPegawai.Size = new Size(975, 587);
            dgvBarangPegawai.TabIndex = 0;
            // 
            // DashboardPegawai
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1262, 753);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            MinimumSize = new Size(1100, 656);
            Name = "DashboardPegawai";
            Text = "Form1";
            Load += DashboardPegawai_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBarangPegawai).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Button button3;
        private Button button2;
        private Button button1;
        private Button btnLogout;
        private Label label1;
        private Label lblTotalBarangPegawai;
        private Label lblTotalStokPegawai;
        private Label label2;
        private Panel panel4;
        private DataGridView dgvBarangPegawai;
    }
}
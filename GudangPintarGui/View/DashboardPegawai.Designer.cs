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
            panel4.Location = new Point(251, 118);
            panel4.Margin = new Padding(3, 2, 3, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(1014, 640);
            panel4.TabIndex = 4;
            // 
            // dgvBarangPegawai
            // 
            dgvBarangPegawai.BackgroundColor = SystemColors.ControlLightLight;
            dgvBarangPegawai.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBarangPegawai.Location = new Point(0, 0);
            dgvBarangPegawai.Name = "dgvBarangPegawai";
            dgvBarangPegawai.RowHeadersWidth = 51;
            dgvBarangPegawai.Size = new Size(1014, 640);
            dgvBarangPegawai.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = Color.LimeGreen;
            panel3.Controls.Add(lblTotalStokPegawai);
            panel3.Controls.Add(label1);
            panel3.Location = new Point(742, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(521, 112);
            panel3.TabIndex = 20;
            // 
            // lblTotalStokPegawai
            // 
            lblTotalStokPegawai.AutoSize = true;
            lblTotalStokPegawai.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            lblTotalStokPegawai.ForeColor = Color.White;
            lblTotalStokPegawai.Location = new Point(193, 38);
            lblTotalStokPegawai.Name = "lblTotalStokPegawai";
            lblTotalStokPegawai.Size = new Size(74, 30);
            lblTotalStokPegawai.TabIndex = 2;
            lblTotalStokPegawai.Text = "label4";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(181, 13);
            label1.Name = "label1";
            label1.Size = new Size(95, 25);
            label1.TabIndex = 0;
            label1.Text = "Total Stok";
            // 
            // panel2
            // 
            panel2.BackColor = Color.LimeGreen;
            panel2.Controls.Add(lblTotalBarangPegawai);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(246, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(490, 112);
            panel2.TabIndex = 19;
            // 
            // lblTotalBarangPegawai
            // 
            lblTotalBarangPegawai.AutoSize = true;
            lblTotalBarangPegawai.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            lblTotalBarangPegawai.ForeColor = Color.White;
            lblTotalBarangPegawai.Location = new Point(204, 41);
            lblTotalBarangPegawai.Name = "lblTotalBarangPegawai";
            lblTotalBarangPegawai.Size = new Size(70, 30);
            lblTotalBarangPegawai.TabIndex = 2;
            lblTotalBarangPegawai.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(182, 13);
            label2.Name = "label2";
            label2.Size = new Size(118, 25);
            label2.TabIndex = 1;
            label2.Text = "Total Barang";
            // 
            // panel1
            // 
            panel1.BackColor = Color.LimeGreen;
            panel1.Controls.Add(btnLogout);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(1, 3);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(238, 755);
            panel1.TabIndex = 18;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.DarkGray;
            btnLogout.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = SystemColors.ControlText;
            btnLogout.Location = new Point(50, 644);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(122, 31);
            btnLogout.TabIndex = 8;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(50, 289);
            button3.Name = "button3";
            button3.Size = new Size(122, 37);
            button3.TabIndex = 7;
            button3.Text = "Riwayat";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(50, 223);
            button2.Name = "button2";
            button2.Size = new Size(122, 39);
            button2.TabIndex = 6;
            button2.Text = "Barang";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(50, 159);
            button1.Name = "button1";
            button1.Size = new Size(122, 38);
            button1.TabIndex = 5;
            button1.Text = "Dashboard";
            button1.UseVisualStyleBackColor = true;
            // 
            // DashboardPegawai
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.White;
            ClientSize = new Size(1264, 637);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(panel4);
            Margin = new Padding(3, 2, 3, 2);
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
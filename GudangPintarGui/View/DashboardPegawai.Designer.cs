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
            panel1.Controls.Add(btnLogout);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(4, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(272, 607);
            panel1.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.Red;
            btnLogout.Location = new Point(81, 544);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(94, 29);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "btnLogout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // button3
            // 
            button3.Location = new Point(78, 266);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 2;
            button3.Text = "Riwayat";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(78, 196);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 1;
            button2.Text = "Barang";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(78, 132);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "Dashboard";
            button1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(lblTotalBarangPegawai);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(286, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(400, 125);
            panel2.TabIndex = 2;
            // 
            // lblTotalBarangPegawai
            // 
            lblTotalBarangPegawai.AutoSize = true;
            lblTotalBarangPegawai.Location = new Point(172, 67);
            lblTotalBarangPegawai.Name = "lblTotalBarangPegawai";
            lblTotalBarangPegawai.Size = new Size(50, 20);
            lblTotalBarangPegawai.TabIndex = 1;
            lblTotalBarangPegawai.Text = "label3";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(149, 22);
            label1.Name = "label1";
            label1.Size = new Size(93, 20);
            label1.TabIndex = 0;
            label1.Text = "Total Barang";
            // 
            // panel3
            // 
            panel3.Controls.Add(lblTotalStokPegawai);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(692, 12);
            panel3.Name = "panel3";
            panel3.Size = new Size(391, 125);
            panel3.TabIndex = 3;
            // 
            // lblTotalStokPegawai
            // 
            lblTotalStokPegawai.AutoSize = true;
            lblTotalStokPegawai.Location = new Point(166, 67);
            lblTotalStokPegawai.Name = "lblTotalStokPegawai";
            lblTotalStokPegawai.Size = new Size(50, 20);
            lblTotalStokPegawai.TabIndex = 1;
            lblTotalStokPegawai.Text = "label4";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(153, 22);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 0;
            label2.Text = "Total Stok";
            // 
            // panel4
            // 
            panel4.Controls.Add(dgvBarangPegawai);
            panel4.Location = new Point(286, 158);
            panel4.Name = "panel4";
            panel4.Size = new Size(797, 451);
            panel4.TabIndex = 4;
            // 
            // dgvBarangPegawai
            // 
            dgvBarangPegawai.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBarangPegawai.Dock = DockStyle.Fill;
            dgvBarangPegawai.Location = new Point(0, 0);
            dgvBarangPegawai.Name = "dgvBarangPegawai";
            dgvBarangPegawai.RowHeadersWidth = 51;
            dgvBarangPegawai.Size = new Size(797, 451);
            dgvBarangPegawai.TabIndex = 0;
            // 
            // DashboardPegawai
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1082, 609);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
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
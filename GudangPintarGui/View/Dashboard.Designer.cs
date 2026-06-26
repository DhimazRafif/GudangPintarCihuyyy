namespace GudangPintarGui
{
    partial class Dashboard
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
            button5 = new Button();
            btnLogout = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            panel3 = new Panel();
            lblTotalStok = new Label();
            label1 = new Label();
            panel2 = new Panel();
            lblTotalBarang = new Label();
            label2 = new Label();
            panel4 = new Panel();
            dgvBarang = new DataGridView();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBarang).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.LimeGreen;
            panel1.Controls.Add(button5);
            panel1.Controls.Add(btnLogout);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(2, 2);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(273, 755);
            panel1.TabIndex = 0;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.Location = new Point(58, 472);
            button5.Margin = new Padding(3, 2, 3, 2);
            button5.Name = "button5";
            button5.Size = new Size(139, 46);
            button5.TabIndex = 9;
            button5.Text = "Akun";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.DarkGray;
            btnLogout.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = SystemColors.ControlText;
            btnLogout.Location = new Point(58, 858);
            btnLogout.Margin = new Padding(3, 4, 3, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(139, 42);
            btnLogout.TabIndex = 8;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(58, 386);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(139, 50);
            button3.TabIndex = 7;
            button3.Text = "Riwayat";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(58, 298);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(139, 52);
            button2.TabIndex = 6;
            button2.Text = "Barang";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(58, 212);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(139, 50);
            button1.TabIndex = 5;
            button1.Text = "Dashboard";
            button1.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            panel3.BackColor = Color.LimeGreen;
            panel3.Controls.Add(lblTotalStok);
            panel3.Controls.Add(label1);
            panel3.Location = new Point(848, 2);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(595, 150);
            panel3.TabIndex = 17;
            // 
            // lblTotalStok
            // 
            lblTotalStok.AutoSize = true;
            lblTotalStok.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            lblTotalStok.ForeColor = Color.Black;
            lblTotalStok.Location = new Point(221, 50);
            lblTotalStok.Name = "lblTotalStok";
            lblTotalStok.Size = new Size(91, 37);
            lblTotalStok.TabIndex = 2;
            lblTotalStok.Text = "label4";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(207, 18);
            label1.Name = "label1";
            label1.Size = new Size(122, 32);
            label1.TabIndex = 0;
            label1.Text = "Total Stok";
            // 
            // panel2
            // 
            panel2.BackColor = Color.LimeGreen;
            panel2.Controls.Add(lblTotalBarang);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(281, 2);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(560, 150);
            panel2.TabIndex = 16;
            // 
            // lblTotalBarang
            // 
            lblTotalBarang.AutoSize = true;
            lblTotalBarang.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            lblTotalBarang.ForeColor = Color.Black;
            lblTotalBarang.Location = new Point(233, 50);
            lblTotalBarang.Name = "lblTotalBarang";
            lblTotalBarang.Size = new Size(86, 37);
            lblTotalBarang.TabIndex = 3;
            lblTotalBarang.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(208, 18);
            label2.Name = "label2";
            label2.Size = new Size(152, 32);
            label2.TabIndex = 1;
            label2.Text = "Total Barang";
            // 
            // panel4
            // 
            panel4.Controls.Add(dgvBarang);
            panel4.Location = new Point(281, 160);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(1162, 850);
            panel4.TabIndex = 18;
            // 
            // dgvBarang
            // 
            dgvBarang.BackgroundColor = SystemColors.ControlLightLight;
            dgvBarang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBarang.Location = new Point(0, 0);
            dgvBarang.Margin = new Padding(3, 4, 3, 4);
            dgvBarang.Name = "dgvBarang";
            dgvBarang.RowHeadersVisible = false;
            dgvBarang.RowHeadersWidth = 62;
            dgvBarang.Size = new Size(1162, 850);
            dgvBarang.TabIndex = 0;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.White;
            ClientSize = new Size(1445, 844);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Dashboard";
            Text = "Form1";
            Load += Dashboard_Load;
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBarang).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button5;
        private Button btnLogout;
        private Button button3;
        private Button button2;
        private Button button1;
        private Panel panel3;
        private Label label1;
        private Panel panel2;
        private Label label2;
        private Panel panel4;
        private DataGridView dgvBarang;
        private Label lblTotalStok;
        private Label lblTotalBarang;
    }
}
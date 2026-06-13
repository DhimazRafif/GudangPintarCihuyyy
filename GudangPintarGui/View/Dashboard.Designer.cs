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
            btnLogout = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            panel2 = new Panel();
            lblTotalBarang = new Label();
            label1 = new Label();
            panel3 = new Panel();
            lblTotalStok = new Label();
            label2 = new Label();
            panel5 = new Panel();
            dgvBarang = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBarang).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnLogout);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(2, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(234, 615);
            panel1.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.Red;
            btnLogout.Location = new Point(60, 558);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(94, 29);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "Log Out";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // button4
            // 
            button4.Location = new Point(47, 323);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 3;
            button4.Text = "Akun";
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(47, 261);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 2;
            button3.Text = "Riwayat";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(47, 204);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 1;
            button2.Text = "Barang";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(47, 140);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "Dashboard";
            button1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(lblTotalBarang);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(245, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(427, 125);
            panel2.TabIndex = 2;
            // 
            // lblTotalBarang
            // 
            lblTotalBarang.AutoSize = true;
            lblTotalBarang.Location = new Point(179, 71);
            lblTotalBarang.Name = "lblTotalBarang";
            lblTotalBarang.Size = new Size(50, 20);
            lblTotalBarang.TabIndex = 1;
            lblTotalBarang.Text = "label3";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(161, 18);
            label1.Name = "label1";
            label1.Size = new Size(93, 20);
            label1.TabIndex = 0;
            label1.Text = "Total Barang";
            // 
            // panel3
            // 
            panel3.Controls.Add(lblTotalStok);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(678, 12);
            panel3.Name = "panel3";
            panel3.Size = new Size(398, 125);
            panel3.TabIndex = 3;
            // 
            // lblTotalStok
            // 
            lblTotalStok.AutoSize = true;
            lblTotalStok.Location = new Point(173, 71);
            lblTotalStok.Name = "lblTotalStok";
            lblTotalStok.Size = new Size(50, 20);
            lblTotalStok.TabIndex = 1;
            lblTotalStok.Text = "label4";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(163, 18);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 0;
            label2.Text = "Total Stok";
            // 
            // panel5
            // 
            panel5.Controls.Add(dgvBarang);
            panel5.Location = new Point(245, 154);
            panel5.Name = "panel5";
            panel5.Size = new Size(831, 452);
            panel5.TabIndex = 5;
            // 
            // dgvBarang
            // 
            dgvBarang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBarang.Dock = DockStyle.Fill;
            dgvBarang.Location = new Point(0, 0);
            dgvBarang.Name = "dgvBarang";
            dgvBarang.RowHeadersWidth = 51;
            dgvBarang.Size = new Size(831, 452);
            dgvBarang.TabIndex = 0;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1082, 609);
            Controls.Add(panel5);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Dashboard";
            Text = "Form1";
            Load += Dashboard_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBarang).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private Panel panel2;
        private Panel panel3;
        private Button btnLogout;
        private Panel panel5;
        private DataGridView dgvBarang;
        private Label lblTotalBarang;
        private Label label1;
        private Label lblTotalStok;
        private Label label2;
    }
}
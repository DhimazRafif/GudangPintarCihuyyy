namespace GudangPintarGui.View
{
    partial class PengelolahanAkun
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
            label1 = new Label();
            btnHapus = new Button();
            btnEdit = new Button();
            btnTambah = new Button();
            dgvPengelolahanAkun = new DataGridView();
            ClmID = new DataGridViewTextBoxColumn();
            ClmNama = new DataGridViewTextBoxColumn();
            ClmUsername = new DataGridViewTextBoxColumn();
            ClmRole = new DataGridViewTextBoxColumn();
            ClmStatus = new DataGridViewTextBoxColumn();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            panel3 = new Panel();
            lblTotalStok = new Label();
            label2 = new Label();
            panel2 = new Panel();
            lblTotalBarang = new Label();
            label3 = new Label();
            panel1 = new Panel();
            button5 = new Button();
            btnLogout = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPengelolahanAkun).BeginInit();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(246, 118);
            label1.Name = "label1";
            label1.Size = new Size(182, 40);
            label1.TabIndex = 4;
            label1.Text = "Kelola Akun";
            // 
            // btnHapus
            // 
            btnHapus.BackColor = Color.Red;
            btnHapus.FlatStyle = FlatStyle.Popup;
            btnHapus.ForeColor = Color.White;
            btnHapus.Location = new Point(1167, 121);
            btnHapus.Name = "btnHapus";
            btnHapus.Size = new Size(75, 23);
            btnHapus.TabIndex = 3;
            btnHapus.Text = "Hapus";
            btnHapus.UseVisualStyleBackColor = false;
            btnHapus.Click += btnHapus_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(255, 128, 0);
            btnEdit.FlatStyle = FlatStyle.Popup;
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(1086, 121);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 23);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnTambah
            // 
            btnTambah.BackColor = Color.SeaGreen;
            btnTambah.FlatStyle = FlatStyle.Popup;
            btnTambah.ForeColor = Color.White;
            btnTambah.Location = new Point(1005, 121);
            btnTambah.Name = "btnTambah";
            btnTambah.Size = new Size(75, 23);
            btnTambah.TabIndex = 1;
            btnTambah.Text = "Tambah";
            btnTambah.UseVisualStyleBackColor = false;
            btnTambah.Click += btnTambah_Click;
            // 
            // dgvPengelolahanAkun
            // 
            dgvPengelolahanAkun.AllowUserToAddRows = false;
            dgvPengelolahanAkun.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPengelolahanAkun.BackgroundColor = Color.DarkGray;
            dgvPengelolahanAkun.BorderStyle = BorderStyle.None;
            dgvPengelolahanAkun.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPengelolahanAkun.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvPengelolahanAkun.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPengelolahanAkun.Columns.AddRange(new DataGridViewColumn[] { ClmID, ClmNama, ClmUsername, ClmRole, ClmStatus });
            dgvPengelolahanAkun.Location = new Point(246, 162);
            dgvPengelolahanAkun.MultiSelect = false;
            dgvPengelolahanAkun.Name = "dgvPengelolahanAkun";
            dgvPengelolahanAkun.RowHeadersVisible = false;
            dgvPengelolahanAkun.RowHeadersWidth = 62;
            dgvPengelolahanAkun.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPengelolahanAkun.Size = new Size(1017, 597);
            dgvPengelolahanAkun.TabIndex = 0;
            dgvPengelolahanAkun.CellContentClick += dgvPengelolahanAkun_CellContentClick;
            // 
            // ClmID
            // 
            ClmID.HeaderText = "ID";
            ClmID.MinimumWidth = 8;
            ClmID.Name = "ClmID";
            // 
            // ClmNama
            // 
            ClmNama.HeaderText = "Nama";
            ClmNama.MinimumWidth = 8;
            ClmNama.Name = "ClmNama";
            // 
            // ClmUsername
            // 
            ClmUsername.HeaderText = "Username";
            ClmUsername.MinimumWidth = 8;
            ClmUsername.Name = "ClmUsername";
            // 
            // ClmRole
            // 
            ClmRole.HeaderText = "Role";
            ClmRole.MinimumWidth = 8;
            ClmRole.Name = "ClmRole";
            // 
            // ClmStatus
            // 
            ClmStatus.HeaderText = "Status";
            ClmStatus.MinimumWidth = 8;
            ClmStatus.Name = "ClmStatus";
            // 
            // panel3
            // 
            panel3.BackColor = Color.LimeGreen;
            panel3.Controls.Add(lblTotalStok);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(742, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(521, 112);
            panel3.TabIndex = 20;
            // 
            // lblTotalStok
            // 
            lblTotalStok.AutoSize = true;
            lblTotalStok.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            lblTotalStok.ForeColor = Color.White;
            lblTotalStok.Location = new Point(193, 38);
            lblTotalStok.Name = "lblTotalStok";
            lblTotalStok.Size = new Size(74, 30);
            lblTotalStok.TabIndex = 2;
            lblTotalStok.Text = "label4";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(181, 13);
            label2.Name = "label2";
            label2.Size = new Size(95, 25);
            label2.TabIndex = 0;
            label2.Text = "Total Stok";
            // 
            // panel2
            // 
            panel2.BackColor = Color.LimeGreen;
            panel2.Controls.Add(lblTotalBarang);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(246, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(490, 112);
            panel2.TabIndex = 19;
            // 
            // lblTotalBarang
            // 
            lblTotalBarang.AutoSize = true;
            lblTotalBarang.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            lblTotalBarang.ForeColor = Color.White;
            lblTotalBarang.Location = new Point(204, 38);
            lblTotalBarang.Name = "lblTotalBarang";
            lblTotalBarang.Size = new Size(70, 30);
            lblTotalBarang.TabIndex = 3;
            lblTotalBarang.Text = "label1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(182, 13);
            label3.Name = "label3";
            label3.Size = new Size(118, 25);
            label3.TabIndex = 1;
            label3.Text = "Total Barang";
            // 
            // panel1
            // 
            panel1.BackColor = Color.LimeGreen;
            panel1.Controls.Add(button5);
            panel1.Controls.Add(btnLogout);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(2, 3);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(238, 755);
            panel1.TabIndex = 18;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.Location = new Point(51, 354);
            button5.Margin = new Padding(3, 2, 3, 2);
            button5.Name = "button5";
            button5.Size = new Size(122, 35);
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
            btnLogout.Location = new Point(51, 644);
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
            button3.Location = new Point(51, 289);
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
            button2.Location = new Point(51, 223);
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
            button1.Location = new Point(51, 159);
            button1.Name = "button1";
            button1.Size = new Size(122, 38);
            button1.TabIndex = 5;
            button1.Text = "Dashboard";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // PengelolahanAkun
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1264, 637);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(btnHapus);
            Controls.Add(btnEdit);
            Controls.Add(dgvPengelolahanAkun);
            Controls.Add(btnTambah);
            Name = "PengelolahanAkun";
            Text = "PengelolahanAkun";
            ((System.ComponentModel.ISupportInitialize)dgvPengelolahanAkun).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dgvPengelolahanAkun;
        private DataGridViewTextBoxColumn ClmID;
        private DataGridViewTextBoxColumn ClmNama;
        private DataGridViewTextBoxColumn ClmUsername;
        private DataGridViewTextBoxColumn ClmRole;
        private DataGridViewTextBoxColumn ClmStatus;
        private Button btnHapus;
        private Button btnEdit;
        private Button btnTambah;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label label1;
        private Panel panel3;
        private Label lblTotalStok;
        private Label label2;
        private Panel panel2;
        private Label lblTotalBarang;
        private Label label3;
        private Panel panel1;
        private Button button5;
        private Button btnLogout;
        private Button button3;
        private Button button2;
        private Button button1;
    }
}
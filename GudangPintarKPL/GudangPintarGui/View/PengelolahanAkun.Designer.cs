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
            splitContainer1 = new SplitContainer();
            btnLogout = new Button();
            btnAkun = new Button();
            btnRiwayat = new Button();
            btnBarang = new Button();
            btnDasboard = new Button();
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
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPengelolahanAkun).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(btnLogout);
            splitContainer1.Panel1.Controls.Add(btnAkun);
            splitContainer1.Panel1.Controls.Add(btnRiwayat);
            splitContainer1.Panel1.Controls.Add(btnBarang);
            splitContainer1.Panel1.Controls.Add(btnDasboard);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.LimeGreen;
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Controls.Add(btnHapus);
            splitContainer1.Panel2.Controls.Add(btnEdit);
            splitContainer1.Panel2.Controls.Add(btnTambah);
            splitContainer1.Panel2.Controls.Add(dgvPengelolahanAkun);
            splitContainer1.Size = new Size(1264, 749);
            splitContainer1.SplitterDistance = 285;
            splitContainer1.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.White;
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.FlatStyle = FlatStyle.Popup;
            btnLogout.Location = new Point(0, 726);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(285, 23);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnAkun
            // 
            btnAkun.BackColor = Color.White;
            btnAkun.FlatStyle = FlatStyle.Popup;
            btnAkun.Location = new Point(54, 431);
            btnAkun.Name = "btnAkun";
            btnAkun.Size = new Size(169, 23);
            btnAkun.TabIndex = 3;
            btnAkun.Text = "Akun";
            btnAkun.UseVisualStyleBackColor = false;
            btnAkun.Click += btnAkun_Click;
            // 
            // btnRiwayat
            // 
            btnRiwayat.BackColor = Color.White;
            btnRiwayat.FlatStyle = FlatStyle.Popup;
            btnRiwayat.Location = new Point(54, 324);
            btnRiwayat.Name = "btnRiwayat";
            btnRiwayat.Size = new Size(169, 23);
            btnRiwayat.TabIndex = 2;
            btnRiwayat.Text = "Riwayat";
            btnRiwayat.UseVisualStyleBackColor = false;
            btnRiwayat.Click += btnRiwayat_Click;
            // 
            // btnBarang
            // 
            btnBarang.BackColor = Color.White;
            btnBarang.FlatStyle = FlatStyle.Popup;
            btnBarang.Location = new Point(54, 238);
            btnBarang.Name = "btnBarang";
            btnBarang.Size = new Size(169, 23);
            btnBarang.TabIndex = 1;
            btnBarang.Text = "Barang";
            btnBarang.UseVisualStyleBackColor = false;
            btnBarang.Click += btnBarang_Click;
            // 
            // btnDasboard
            // 
            btnDasboard.BackColor = Color.White;
            btnDasboard.FlatStyle = FlatStyle.Popup;
            btnDasboard.Location = new Point(54, 164);
            btnDasboard.Name = "btnDasboard";
            btnDasboard.Size = new Size(169, 23);
            btnDasboard.TabIndex = 0;
            btnDasboard.Text = "Dasboard";
            btnDasboard.UseVisualStyleBackColor = false;
            btnDasboard.Click += btnDasboard_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Transparent;
            label1.Location = new Point(143, 0);
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
            btnHapus.Location = new Point(586, 68);
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
            btnEdit.Location = new Point(505, 68);
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
            btnTambah.Location = new Point(424, 68);
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
            dgvPengelolahanAkun.BorderStyle = BorderStyle.None;
            dgvPengelolahanAkun.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPengelolahanAkun.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPengelolahanAkun.Columns.AddRange(new DataGridViewColumn[] { ClmID, ClmNama, ClmUsername, ClmRole, ClmStatus });
            dgvPengelolahanAkun.Location = new Point(143, 97);
            dgvPengelolahanAkun.Name = "dgvPengelolahanAkun";
            dgvPengelolahanAkun.Size = new Size(535, 638);
            dgvPengelolahanAkun.TabIndex = 0;
            dgvPengelolahanAkun.CellContentClick += dgvPengelolahanAkun_CellContentClick;
            // 
            // ClmID
            // 
            ClmID.HeaderText = "ID";
            ClmID.Name = "ClmID";
            // 
            // ClmNama
            // 
            ClmNama.HeaderText = "Nama";
            ClmNama.Name = "ClmNama";
            // 
            // ClmUsername
            // 
            ClmUsername.HeaderText = "Username";
            ClmUsername.Name = "ClmUsername";
            // 
            // ClmRole
            // 
            ClmRole.HeaderText = "Role";
            ClmRole.Name = "ClmRole";
            // 
            // ClmStatus
            // 
            ClmStatus.HeaderText = "Status";
            ClmStatus.Name = "ClmStatus";
            // 
            // PengelolahanAkun
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 749);
            Controls.Add(splitContainer1);
            Name = "PengelolahanAkun";
            Text = "PengelolahanAkun";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPengelolahanAkun).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Button btnLogout;
        private Button btnAkun;
        private Button btnRiwayat;
        private Button btnBarang;
        private Button btnDasboard;
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
    }
}
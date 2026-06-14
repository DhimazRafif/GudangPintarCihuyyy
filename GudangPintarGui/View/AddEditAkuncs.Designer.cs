namespace GudangPintarGui.View
{
    partial class AddEditAkuncs
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
            lblTambahdanEditAkun = new Label();
            btnTambah = new Button();
            btnBatal = new Button();
            lblNamaLengkap = new Label();
            lblUsername = new Label();
            lblPassword = new Label();
            lblRole = new Label();
            lblHakAkses = new Label();
            txtNamaLengkap = new TextBox();
            textUsername = new TextBox();
            txtPassword = new TextBox();
            cmbRole = new ComboBox();
            checkedListBox1 = new CheckedListBox();
            btnHakAkses = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.LimeGreen;
            panel1.Controls.Add(lblTambahdanEditAkun);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(444, 51);
            panel1.TabIndex = 0;
            // 
            // lblTambahdanEditAkun
            // 
            lblTambahdanEditAkun.AutoSize = true;
            lblTambahdanEditAkun.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTambahdanEditAkun.ForeColor = Color.White;
            lblTambahdanEditAkun.Location = new Point(114, 9);
            lblTambahdanEditAkun.Name = "lblTambahdanEditAkun";
            lblTambahdanEditAkun.Size = new Size(212, 25);
            lblTambahdanEditAkun.TabIndex = 0;
            lblTambahdanEditAkun.Text = "Tambah dan Edit Akun";
            // 
            // btnTambah
            // 
            btnTambah.BackColor = Color.Lime;
            btnTambah.FlatStyle = FlatStyle.Popup;
            btnTambah.ForeColor = Color.White;
            btnTambah.Location = new Point(15, 328);
            btnTambah.Name = "btnTambah";
            btnTambah.Size = new Size(75, 23);
            btnTambah.TabIndex = 1;
            btnTambah.Text = "Tambah";
            btnTambah.UseVisualStyleBackColor = false;
            btnTambah.Click += btnTambah_Click;
            // 
            // btnBatal
            // 
            btnBatal.BackColor = Color.Red;
            btnBatal.FlatStyle = FlatStyle.Popup;
            btnBatal.ForeColor = Color.White;
            btnBatal.Location = new Point(122, 328);
            btnBatal.Name = "btnBatal";
            btnBatal.Size = new Size(75, 23);
            btnBatal.TabIndex = 2;
            btnBatal.Text = "Batal";
            btnBatal.UseVisualStyleBackColor = false;
            btnBatal.Click += btnBatal_Click;
            // 
            // lblNamaLengkap
            // 
            lblNamaLengkap.AutoSize = true;
            lblNamaLengkap.Location = new Point(15, 76);
            lblNamaLengkap.Name = "lblNamaLengkap";
            lblNamaLengkap.Size = new Size(93, 15);
            lblNamaLengkap.TabIndex = 3;
            lblNamaLengkap.Text = "Nama Lengkap :";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(41, 105);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(66, 15);
            lblUsername.TabIndex = 4;
            lblUsername.Text = "Username :";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(45, 134);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(63, 15);
            lblPassword.TabIndex = 5;
            lblPassword.Text = "Password :";
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new Point(72, 163);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(36, 15);
            lblRole.TabIndex = 6;
            lblRole.Text = "Role :";
            // 
            // lblHakAkses
            // 
            lblHakAkses.AutoSize = true;
            lblHakAkses.Location = new Point(41, 197);
            lblHakAkses.Name = "lblHakAkses";
            lblHakAkses.Size = new Size(67, 15);
            lblHakAkses.TabIndex = 7;
            lblHakAkses.Text = "Hak Akses :";
            // 
            // txtNamaLengkap
            // 
            txtNamaLengkap.Location = new Point(113, 73);
            txtNamaLengkap.Name = "txtNamaLengkap";
            txtNamaLengkap.Size = new Size(286, 23);
            txtNamaLengkap.TabIndex = 8;
            // 
            // textUsername
            // 
            textUsername.Location = new Point(113, 102);
            textUsername.Name = "textUsername";
            textUsername.Size = new Size(286, 23);
            textUsername.TabIndex = 9;
            // 
            // txtPassword
            // 
            txtPassword.ForeColor = SystemColors.ControlText;
            txtPassword.Location = new Point(114, 131);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(286, 23);
            txtPassword.TabIndex = 10;
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.FormattingEnabled = true;
            cmbRole.Items.AddRange(new object[] { "Admin", "Pegawai" });
            cmbRole.Location = new Point(114, 160);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(286, 23);
            cmbRole.TabIndex = 11;
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Items.AddRange(new object[] { "Melihat Data Barang", "Melihat Riwayat", "Mengelola Data Barang", "Mengelola Akun" });
            checkedListBox1.Location = new Point(113, 197);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(278, 76);
            checkedListBox1.TabIndex = 12;
            checkedListBox1.Visible = false;
            // 
            // btnHakAkses
            // 
            btnHakAkses.Location = new Point(32, 215);
            btnHakAkses.Name = "btnHakAkses";
            btnHakAkses.Size = new Size(75, 23);
            btnHakAkses.TabIndex = 13;
            btnHakAkses.Text = "Tekan";
            btnHakAkses.UseVisualStyleBackColor = true;
            btnHakAkses.Click += btnHakAkses_Click;
            // 
            // AddEditAkuncs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(444, 461);
            Controls.Add(btnHakAkses);
            Controls.Add(checkedListBox1);
            Controls.Add(cmbRole);
            Controls.Add(txtPassword);
            Controls.Add(textUsername);
            Controls.Add(txtNamaLengkap);
            Controls.Add(lblHakAkses);
            Controls.Add(lblRole);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            Controls.Add(lblNamaLengkap);
            Controls.Add(btnBatal);
            Controls.Add(btnTambah);
            Controls.Add(panel1);
            Name = "AddEditAkuncs";
            Text = "AddEditAkuncs";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lblTambahdanEditAkun;
        private Button btnTambah;
        private Button btnBatal;
        private Label lblNamaLengkap;
        private Label lblUsername;
        private Label lblPassword;
        private Label lblRole;
        private Label lblHakAkses;
        private TextBox txtNamaLengkap;
        private TextBox textUsername;
        private TextBox txtPassword;
        private ComboBox cmbRole;
        private CheckedListBox checkedListBox1;
        private Button btnHakAkses;
    }
}
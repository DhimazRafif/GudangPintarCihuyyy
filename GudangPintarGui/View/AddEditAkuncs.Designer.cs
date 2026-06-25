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
            txtNamaLengkap = new TextBox();
            textUsername = new TextBox();
            txtPassword = new TextBox();
            cmbRole = new ComboBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.LimeGreen;
            panel1.Controls.Add(lblTambahdanEditAkun);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(507, 68);
            panel1.TabIndex = 0;
            // 
            // lblTambahdanEditAkun
            // 
            lblTambahdanEditAkun.AutoSize = true;
            lblTambahdanEditAkun.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTambahdanEditAkun.ForeColor = Color.White;
            lblTambahdanEditAkun.Location = new Point(130, 12);
            lblTambahdanEditAkun.Name = "lblTambahdanEditAkun";
            lblTambahdanEditAkun.Size = new Size(271, 32);
            lblTambahdanEditAkun.TabIndex = 0;
            lblTambahdanEditAkun.Text = "Tambah dan Edit Akun";
            // 
            // btnTambah
            // 
            btnTambah.BackColor = Color.Lime;
            btnTambah.FlatStyle = FlatStyle.Popup;
            btnTambah.ForeColor = Color.White;
            btnTambah.Location = new Point(17, 437);
            btnTambah.Margin = new Padding(3, 4, 3, 4);
            btnTambah.Name = "btnTambah";
            btnTambah.Size = new Size(86, 31);
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
            btnBatal.Location = new Point(139, 437);
            btnBatal.Margin = new Padding(3, 4, 3, 4);
            btnBatal.Name = "btnBatal";
            btnBatal.Size = new Size(86, 31);
            btnBatal.TabIndex = 2;
            btnBatal.Text = "Batal";
            btnBatal.UseVisualStyleBackColor = false;
            btnBatal.Click += btnBatal_Click;
            // 
            // lblNamaLengkap
            // 
            lblNamaLengkap.AutoSize = true;
            lblNamaLengkap.Location = new Point(17, 101);
            lblNamaLengkap.Name = "lblNamaLengkap";
            lblNamaLengkap.Size = new Size(116, 20);
            lblNamaLengkap.TabIndex = 3;
            lblNamaLengkap.Text = "Nama Lengkap :";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(47, 140);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(82, 20);
            lblUsername.TabIndex = 4;
            lblUsername.Text = "Username :";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(51, 179);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(77, 20);
            lblPassword.TabIndex = 5;
            lblPassword.Text = "Password :";
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new Point(82, 217);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(46, 20);
            lblRole.TabIndex = 6;
            lblRole.Text = "Role :";
            // 
            // txtNamaLengkap
            // 
            txtNamaLengkap.Location = new Point(129, 97);
            txtNamaLengkap.Margin = new Padding(3, 4, 3, 4);
            txtNamaLengkap.Name = "txtNamaLengkap";
            txtNamaLengkap.Size = new Size(326, 27);
            txtNamaLengkap.TabIndex = 8;
            // 
            // textUsername
            // 
            textUsername.Location = new Point(129, 136);
            textUsername.Margin = new Padding(3, 4, 3, 4);
            textUsername.Name = "textUsername";
            textUsername.Size = new Size(326, 27);
            textUsername.TabIndex = 9;
            // 
            // txtPassword
            // 
            txtPassword.ForeColor = SystemColors.ControlText;
            txtPassword.Location = new Point(130, 175);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(326, 27);
            txtPassword.TabIndex = 10;
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.FormattingEnabled = true;
            cmbRole.Items.AddRange(new object[] { "Admin", "Pegawai" });
            cmbRole.Location = new Point(130, 213);
            cmbRole.Margin = new Padding(3, 4, 3, 4);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(326, 28);
            cmbRole.TabIndex = 11;
            // 
            // AddEditAkuncs
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(507, 615);
            Controls.Add(cmbRole);
            Controls.Add(txtPassword);
            Controls.Add(textUsername);
            Controls.Add(txtNamaLengkap);
            Controls.Add(lblRole);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            Controls.Add(lblNamaLengkap);
            Controls.Add(btnBatal);
            Controls.Add(btnTambah);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
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
        private TextBox txtNamaLengkap;
        private TextBox textUsername;
        private TextBox txtPassword;
        private ComboBox cmbRole;
    }
}
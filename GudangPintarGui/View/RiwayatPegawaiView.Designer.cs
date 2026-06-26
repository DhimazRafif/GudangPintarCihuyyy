namespace GudangPintarGui.View
{
    partial class RiwayatPegawaiView
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
            lblTotalBarang = new Label();
            label3 = new Label();
            panel3 = new Panel();
            lblTotalStok = new Label();
            label2 = new Label();
            dgvRiwayat = new DataGridView();
            ClmID = new DataGridViewTextBoxColumn();
            ClmBarang = new DataGridViewTextBoxColumn();
            ClmQuantity = new DataGridViewTextBoxColumn();
            ClmUser = new DataGridViewTextBoxColumn();
            ClmSupplier = new DataGridViewTextBoxColumn();
            label1 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRiwayat).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.LimeGreen;
            panel1.Controls.Add(btnLogout);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(2, 3);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(238, 755);
            panel1.TabIndex = 1;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.DarkGray;
            btnLogout.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = SystemColors.ControlText;
            btnLogout.Location = new Point(51, 644);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(122, 31);
            btnLogout.TabIndex = 11;
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
            button3.TabIndex = 8;
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
            button2.TabIndex = 7;
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
            button1.TabIndex = 6;
            button1.Text = "Dashboard";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.LimeGreen;
            panel2.Controls.Add(lblTotalBarang);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(246, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(490, 112);
            panel2.TabIndex = 21;
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
            // panel3
            // 
            panel3.BackColor = Color.LimeGreen;
            panel3.Controls.Add(lblTotalStok);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(742, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(521, 112);
            panel3.TabIndex = 22;
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
            // dgvRiwayat
            // 
            dgvRiwayat.AllowUserToAddRows = false;
            dgvRiwayat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRiwayat.BackgroundColor = Color.DarkGray;
            dgvRiwayat.BorderStyle = BorderStyle.None;
            dgvRiwayat.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvRiwayat.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvRiwayat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRiwayat.Columns.AddRange(new DataGridViewColumn[] { ClmID, ClmBarang, ClmQuantity, ClmUser, ClmSupplier });
            dgvRiwayat.Location = new Point(246, 162);
            dgvRiwayat.MultiSelect = false;
            dgvRiwayat.Name = "dgvRiwayat";
            dgvRiwayat.RowHeadersVisible = false;
            dgvRiwayat.RowHeadersWidth = 62;
            dgvRiwayat.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRiwayat.Size = new Size(1017, 478);
            dgvRiwayat.TabIndex = 23;
            // 
            // ClmID
            // 
            ClmID.HeaderText = "ID";
            ClmID.MinimumWidth = 8;
            ClmID.Name = "ClmID";
            // 
            // ClmBarang
            // 
            ClmBarang.HeaderText = "Nama Barang";
            ClmBarang.MinimumWidth = 8;
            ClmBarang.Name = "ClmBarang";
            // 
            // ClmQuantity
            // 
            ClmQuantity.HeaderText = "Banyak Stok";
            ClmQuantity.MinimumWidth = 8;
            ClmQuantity.Name = "ClmQuantity";
            // 
            // ClmUser
            // 
            ClmUser.HeaderText = "Diganti Oleh";
            ClmUser.MinimumWidth = 8;
            ClmUser.Name = "ClmUser";
            // 
            // ClmSupplier
            // 
            ClmSupplier.HeaderText = "Dari Supplier";
            ClmSupplier.MinimumWidth = 8;
            ClmSupplier.Name = "ClmSupplier";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(246, 118);
            label1.Name = "label1";
            label1.Size = new Size(126, 40);
            label1.TabIndex = 24;
            label1.Text = "Riwayat";
            // 
            // RiwayatPegawaiView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1264, 637);
            Controls.Add(label1);
            Controls.Add(dgvRiwayat);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(2);
            Name = "RiwayatPegawaiView";
            Text = "RiwayatPegawaiView";
            Load += RiwayatPegawaiView_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRiwayat).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button btnLogout;
        private Button button3;
        private Button button2;
        private Button button1;
        private Panel panel2;
        private Label lblTotalBarang;
        private Label label3;
        private Panel panel3;
        private Label lblTotalStok;
        private Label label2;
        private DataGridView dgvRiwayat;
        private DataGridViewTextBoxColumn ClmID;
        private DataGridViewTextBoxColumn ClmBarang;
        private DataGridViewTextBoxColumn ClmQuantity;
        private DataGridViewTextBoxColumn ClmUser;
        private DataGridViewTextBoxColumn ClmSupplier;
        private Label label1;
    }
}
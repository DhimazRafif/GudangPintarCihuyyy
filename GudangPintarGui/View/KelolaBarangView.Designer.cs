namespace GudangPintarGui.View
{
    partial class KelolaBarangView
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
            btnBukaTambah = new Button();
            dgvBarang = new DataGridView();
            colNamaBarang = new DataGridViewTextBoxColumn();
            colKategori = new DataGridViewTextBoxColumn();
            colStock = new DataGridViewTextBoxColumn();
            colHarga = new DataGridViewTextBoxColumn();
            colThreshold = new DataGridViewTextBoxColumn();
            btnTambahStok = new Button();
            btnHapus = new Button();
            panel1 = new Panel();
            label1 = new Label();
            lblTotalBarang = new Label();
            txtCariNama = new TextBox();
            label2 = new Label();
            btnRefresh = new Button();
            panel2 = new Panel();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            panel3 = new Panel();
            lblTotalStok = new Label();
            label3 = new Label();
            btnKurangStock = new Button();
            btnEditBarang = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvBarang).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // btnBukaTambah
            // 
            btnBukaTambah.BackColor = Color.Lime;
            btnBukaTambah.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBukaTambah.ForeColor = Color.White;
            btnBukaTambah.Location = new Point(987, 227);
            btnBukaTambah.Margin = new Padding(4, 5, 4, 5);
            btnBukaTambah.Name = "btnBukaTambah";
            btnBukaTambah.Size = new Size(107, 38);
            btnBukaTambah.TabIndex = 1;
            btnBukaTambah.Text = "Tambah Barang";
            btnBukaTambah.UseVisualStyleBackColor = false;
            btnBukaTambah.Click += btnBukaTambah_Click;
            // 
            // dgvBarang
            // 
            dgvBarang.AllowUserToAddRows = false;
            dgvBarang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBarang.BackgroundColor = Color.LightGray;
            dgvBarang.BorderStyle = BorderStyle.None;
            dgvBarang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBarang.Columns.AddRange(new DataGridViewColumn[] { colNamaBarang, colKategori, colStock, colHarga, colThreshold });
            dgvBarang.Location = new Point(340, 268);
            dgvBarang.Margin = new Padding(4, 5, 4, 5);
            dgvBarang.Name = "dgvBarang";
            dgvBarang.ReadOnly = true;
            dgvBarang.RowHeadersWidth = 62;
            dgvBarang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBarang.Size = new Size(1453, 995);
            dgvBarang.TabIndex = 2;
            dgvBarang.CellClick += dgvBarang_CellClick;
            dgvBarang.CellContentClick += dgvBarang_CellClick;
            dgvBarang.CellContentDoubleClick += dgvBarang_CellClick;
            // 
            // colNamaBarang
            // 
            colNamaBarang.HeaderText = "Nama Barang";
            colNamaBarang.MinimumWidth = 8;
            colNamaBarang.Name = "colNamaBarang";
            colNamaBarang.ReadOnly = true;
            // 
            // colKategori
            // 
            colKategori.HeaderText = "Kategori";
            colKategori.MinimumWidth = 8;
            colKategori.Name = "colKategori";
            colKategori.ReadOnly = true;
            // 
            // colStock
            // 
            colStock.HeaderText = "Jumlah Stock";
            colStock.MinimumWidth = 8;
            colStock.Name = "colStock";
            colStock.ReadOnly = true;
            // 
            // colHarga
            // 
            colHarga.HeaderText = "Harga Satuan";
            colHarga.MinimumWidth = 8;
            colHarga.Name = "colHarga";
            colHarga.ReadOnly = true;
            // 
            // colThreshold
            // 
            colThreshold.HeaderText = "Batas Minimum";
            colThreshold.MinimumWidth = 8;
            colThreshold.Name = "colThreshold";
            colThreshold.ReadOnly = true;
            // 
            // btnTambahStok
            // 
            btnTambahStok.BackColor = Color.DarkOrange;
            btnTambahStok.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTambahStok.ForeColor = Color.White;
            btnTambahStok.Location = new Point(1103, 227);
            btnTambahStok.Margin = new Padding(4, 5, 4, 5);
            btnTambahStok.Name = "btnTambahStok";
            btnTambahStok.Size = new Size(146, 38);
            btnTambahStok.TabIndex = 3;
            btnTambahStok.Text = "Tambah Stock";
            btnTambahStok.UseVisualStyleBackColor = false;
            btnTambahStok.Click += btnTambahStok_Click;
            // 
            // btnHapus
            // 
            btnHapus.BackColor = Color.IndianRed;
            btnHapus.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHapus.ForeColor = Color.White;
            btnHapus.Location = new Point(1566, 227);
            btnHapus.Margin = new Padding(4, 5, 4, 5);
            btnHapus.Name = "btnHapus";
            btnHapus.Size = new Size(107, 38);
            btnHapus.TabIndex = 4;
            btnHapus.Text = "Hapus Barang";
            btnHapus.UseVisualStyleBackColor = false;
            btnHapus.Click += btnHapus_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.LawnGreen;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblTotalBarang);
            panel1.Location = new Point(351, 5);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(700, 187);
            panel1.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(260, 22);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(181, 40);
            label1.TabIndex = 1;
            label1.Text = "Total Barang";
            // 
            // lblTotalBarang
            // 
            lblTotalBarang.AutoSize = true;
            lblTotalBarang.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            lblTotalBarang.ForeColor = Color.White;
            lblTotalBarang.Location = new Point(290, 63);
            lblTotalBarang.Margin = new Padding(4, 0, 4, 0);
            lblTotalBarang.Name = "lblTotalBarang";
            lblTotalBarang.Size = new Size(102, 45);
            lblTotalBarang.TabIndex = 0;
            lblTotalBarang.Text = "label1";
            // 
            // txtCariNama
            // 
            txtCariNama.Location = new Point(526, 220);
            txtCariNama.Margin = new Padding(4, 5, 4, 5);
            txtCariNama.Name = "txtCariNama";
            txtCariNama.PlaceholderText = "Cari Barang . . .";
            txtCariNama.Size = new Size(395, 31);
            txtCariNama.TabIndex = 6;
            txtCariNama.TextChanged += txtCariNama_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(370, 227);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(154, 25);
            label2.TabIndex = 7;
            label2.Text = "Cari Nama Barang";
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(1697, 227);
            btnRefresh.Margin = new Padding(4, 5, 4, 5);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(107, 38);
            btnRefresh.TabIndex = 8;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.LawnGreen;
            panel2.Controls.Add(button5);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button1);
            panel2.Location = new Point(3, 5);
            panel2.Margin = new Padding(4, 5, 4, 5);
            panel2.Name = "panel2";
            panel2.Size = new Size(340, 1258);
            panel2.TabIndex = 6;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.Location = new Point(70, 588);
            button5.Margin = new Padding(4, 3, 4, 3);
            button5.Name = "button5";
            button5.Size = new Size(174, 58);
            button5.TabIndex = 4;
            button5.Text = "Akun";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.DarkGray;
            button4.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = SystemColors.ControlText;
            button4.Location = new Point(70, 1072);
            button4.Margin = new Padding(4, 5, 4, 5);
            button4.Name = "button4";
            button4.Size = new Size(174, 52);
            button4.TabIndex = 3;
            button4.Text = "Logout";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(70, 480);
            button3.Margin = new Padding(4, 5, 4, 5);
            button3.Name = "button3";
            button3.Size = new Size(174, 62);
            button3.TabIndex = 2;
            button3.Text = "Riwayat";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(70, 370);
            button2.Margin = new Padding(4, 5, 4, 5);
            button2.Name = "button2";
            button2.Size = new Size(174, 65);
            button2.TabIndex = 1;
            button2.Text = "Barang";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(70, 263);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(174, 63);
            button1.TabIndex = 0;
            button1.Text = "Dashboard";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.LawnGreen;
            panel3.Controls.Add(lblTotalStok);
            panel3.Controls.Add(label3);
            panel3.Location = new Point(1060, 5);
            panel3.Margin = new Padding(4, 5, 4, 5);
            panel3.Name = "panel3";
            panel3.Size = new Size(744, 187);
            panel3.TabIndex = 6;
            // 
            // lblTotalStok
            // 
            lblTotalStok.AutoSize = true;
            lblTotalStok.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            lblTotalStok.ForeColor = Color.White;
            lblTotalStok.Location = new Point(277, 63);
            lblTotalStok.Margin = new Padding(4, 0, 4, 0);
            lblTotalStok.Name = "lblTotalStok";
            lblTotalStok.Size = new Size(107, 45);
            lblTotalStok.TabIndex = 1;
            lblTotalStok.Text = "label4";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(261, 22);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(145, 40);
            label3.TabIndex = 0;
            label3.Text = "Total Stok";
            // 
            // btnKurangStock
            // 
            btnKurangStock.BackColor = Color.DarkOrange;
            btnKurangStock.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnKurangStock.ForeColor = Color.White;
            btnKurangStock.Location = new Point(1257, 227);
            btnKurangStock.Margin = new Padding(4, 5, 4, 5);
            btnKurangStock.Name = "btnKurangStock";
            btnKurangStock.Size = new Size(146, 38);
            btnKurangStock.TabIndex = 9;
            btnKurangStock.Text = "Kurang Stock";
            btnKurangStock.UseVisualStyleBackColor = false;
            btnKurangStock.Click += btnKurangStock_Click;
            // 
            // btnEditBarang
            // 
            btnEditBarang.BackColor = Color.RoyalBlue;
            btnEditBarang.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditBarang.ForeColor = Color.White;
            btnEditBarang.Location = new Point(1411, 227);
            btnEditBarang.Margin = new Padding(4, 5, 4, 5);
            btnEditBarang.Name = "btnEditBarang";
            btnEditBarang.Size = new Size(146, 38);
            btnEditBarang.TabIndex = 10;
            btnEditBarang.Text = "Edit Barang";
            btnEditBarang.UseVisualStyleBackColor = false;
            btnEditBarang.Click += btnEditBarang_Click;
            // 
            // KelolaBarangView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.White;
            ClientSize = new Size(1806, 1268);
            Controls.Add(btnEditBarang);
            Controls.Add(btnKurangStock);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(btnRefresh);
            Controls.Add(label2);
            Controls.Add(txtCariNama);
            Controls.Add(panel1);
            Controls.Add(btnHapus);
            Controls.Add(btnTambahStok);
            Controls.Add(dgvBarang);
            Controls.Add(btnBukaTambah);
            Margin = new Padding(4, 5, 4, 5);
            Name = "KelolaBarangView";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvBarang).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnBukaTambah;
        private DataGridView dgvBarang;
        private Button btnTambahStok;
        private Button btnHapus;
        private Panel panel1;
        private TextBox txtCariNama;
        private Label label2;
        private DataGridViewTextBoxColumn colNamaBarang;
        private DataGridViewTextBoxColumn colKategori;
        private DataGridViewTextBoxColumn colStock;
        private DataGridViewTextBoxColumn colHarga;
        private DataGridViewTextBoxColumn colThreshold;
        private Button btnRefresh;
        private Panel panel2;
        private Panel panel3;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Label lblTotalBarang;
        private Label label1;
        private Label lblTotalStok;
        private Label label3;
        private Button btnKurangStock;
        private Button btnEditBarang;
    }
}
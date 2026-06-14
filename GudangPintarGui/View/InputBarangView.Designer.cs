namespace GudangPintarGui.View
{
    partial class InputBarangView
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
            txtNamaBarang = new TextBox();
            label1 = new Label();
            cmbKategori = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            numJumlah = new NumericUpDown();
            numHarga = new NumericUpDown();
            numThreshold = new NumericUpDown();
            label5 = new Label();
            btnSimpan = new Button();
            btnBatal = new Button();
            label6 = new Label();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)numJumlah).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numHarga).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numThreshold).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtNamaBarang
            // 
            txtNamaBarang.Anchor = AnchorStyles.Top;
            txtNamaBarang.Font = new Font("Segoe UI", 10F);
            txtNamaBarang.Location = new Point(160, 76);
            txtNamaBarang.Name = "txtNamaBarang";
            txtNamaBarang.PlaceholderText = "Masukkan Nama Barang . . .";
            txtNamaBarang.Size = new Size(161, 25);
            txtNamaBarang.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(75, 86);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 1;
            label1.Text = "Nama Barang";
            // 
            // cmbKategori
            // 
            cmbKategori.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKategori.FormattingEnabled = true;
            cmbKategori.Location = new Point(160, 115);
            cmbKategori.Name = "cmbKategori";
            cmbKategori.Size = new Size(161, 23);
            cmbKategori.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(103, 118);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 3;
            label2.Text = "Kategori";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(77, 235);
            label3.Name = "label3";
            label3.Size = new Size(77, 15);
            label3.TabIndex = 4;
            label3.Text = "Jumlah Stock";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(76, 155);
            label4.Name = "label4";
            label4.Size = new Size(78, 15);
            label4.TabIndex = 5;
            label4.Text = "Harga Satuan";
            // 
            // numJumlah
            // 
            numJumlah.Location = new Point(160, 233);
            numJumlah.Name = "numJumlah";
            numJumlah.Size = new Size(161, 23);
            numJumlah.TabIndex = 6;
            // 
            // numHarga
            // 
            numHarga.Location = new Point(159, 153);
            numHarga.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            numHarga.Name = "numHarga";
            numHarga.Size = new Size(161, 23);
            numHarga.TabIndex = 7;
            // 
            // numThreshold
            // 
            numThreshold.Location = new Point(160, 192);
            numThreshold.Name = "numThreshold";
            numThreshold.Size = new Size(161, 23);
            numThreshold.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(63, 194);
            label5.Name = "label5";
            label5.Size = new Size(91, 15);
            label5.TabIndex = 9;
            label5.Text = "Batas Minimum";
            // 
            // btnSimpan
            // 
            btnSimpan.BackColor = Color.LimeGreen;
            btnSimpan.Cursor = Cursors.Hand;
            btnSimpan.FlatAppearance.BorderSize = 0;
            btnSimpan.FlatStyle = FlatStyle.Flat;
            btnSimpan.ForeColor = Color.White;
            btnSimpan.Location = new Point(45, 346);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(75, 23);
            btnSimpan.TabIndex = 10;
            btnSimpan.Text = "Simpan";
            btnSimpan.UseVisualStyleBackColor = false;
            btnSimpan.Click += btnSimpan_Click;
            // 
            // btnBatal
            // 
            btnBatal.BackColor = Color.IndianRed;
            btnBatal.Cursor = Cursors.Hand;
            btnBatal.FlatAppearance.BorderSize = 0;
            btnBatal.FlatStyle = FlatStyle.Flat;
            btnBatal.ForeColor = Color.White;
            btnBatal.Location = new Point(139, 346);
            btnBatal.Name = "btnBatal";
            btnBatal.Size = new Size(75, 23);
            btnBatal.TabIndex = 11;
            btnBatal.Text = "Batal";
            btnBatal.UseVisualStyleBackColor = false;
            btnBatal.Click += btnBatal_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(8, 9);
            label6.Name = "label6";
            label6.Size = new Size(168, 21);
            label6.TabIndex = 14;
            label6.Text = "Tambah Barang Baru";
            // 
            // panel1
            // 
            panel1.BackColor = Color.LimeGreen;
            panel1.Controls.Add(label6);
            panel1.Location = new Point(12, 9);
            panel1.Name = "panel1";
            panel1.Size = new Size(394, 43);
            panel1.TabIndex = 15;
            // 
            // InputBarangView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(418, 450);
            Controls.Add(btnBatal);
            Controls.Add(btnSimpan);
            Controls.Add(label5);
            Controls.Add(numThreshold);
            Controls.Add(numHarga);
            Controls.Add(numJumlah);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cmbKategori);
            Controls.Add(label1);
            Controls.Add(txtNamaBarang);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "InputBarangView";
            StartPosition = FormStartPosition.CenterParent;
            Text = "InputBarangView";
            ((System.ComponentModel.ISupportInitialize)numJumlah).EndInit();
            ((System.ComponentModel.ISupportInitialize)numHarga).EndInit();
            ((System.ComponentModel.ISupportInitialize)numThreshold).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNamaBarang;
        private Label label1;
        private ComboBox cmbKategori;
        private Label label2;
        private Label label3;
        private Label label4;
        private NumericUpDown numJumlah;
        private NumericUpDown numHarga;
        private NumericUpDown numThreshold;
        private Label label5;
        private Button btnSimpan;
        private Button btnBatal;
        private Label label6;
        private Panel panel1;
    }
}
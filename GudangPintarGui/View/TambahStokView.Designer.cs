namespace GudangPintarGui.View
{
    partial class TambahStokView
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
            btnBatal = new Button();
            btnSimpan = new Button();
            lblJumlah = new Label();
            lblSupplier = new Label();
            lblNamaBarang = new Label();
            panel1 = new Panel();
            label6 = new Label();
            cmbSupplier = new ComboBox();
            numJumlah = new NumericUpDown();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numJumlah).BeginInit();
            SuspendLayout();
            // 
            // btnBatal
            // 
            btnBatal.BackColor = Color.IndianRed;
            btnBatal.Cursor = Cursors.Hand;
            btnBatal.FlatAppearance.BorderSize = 0;
            btnBatal.FlatStyle = FlatStyle.Flat;
            btnBatal.ForeColor = Color.White;
            btnBatal.Location = new Point(120, 210);
            btnBatal.Name = "btnBatal";
            btnBatal.Size = new Size(75, 23);
            btnBatal.TabIndex = 27;
            btnBatal.Text = "Batal";
            btnBatal.UseVisualStyleBackColor = false;
            btnBatal.Click += btnBatal_Click;
            // 
            // btnSimpan
            // 
            btnSimpan.BackColor = Color.LimeGreen;
            btnSimpan.Cursor = Cursors.Hand;
            btnSimpan.FlatAppearance.BorderSize = 0;
            btnSimpan.FlatStyle = FlatStyle.Flat;
            btnSimpan.ForeColor = Color.White;
            btnSimpan.Location = new Point(24, 210);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(75, 23);
            btnSimpan.TabIndex = 26;
            btnSimpan.Text = "Simpan";
            btnSimpan.UseVisualStyleBackColor = false;
            btnSimpan.Click += btnSimpan_Click;
            // 
            // lblJumlah
            // 
            lblJumlah.AutoSize = true;
            lblJumlah.Location = new Point(20, 156);
            lblJumlah.Name = "lblJumlah";
            lblJumlah.Size = new Size(104, 15);
            lblJumlah.TabIndex = 21;
            lblJumlah.Text = "Jumlah Tambahan";
            // 
            // lblSupplier
            // 
            lblSupplier.AutoSize = true;
            lblSupplier.Location = new Point(20, 123);
            lblSupplier.Name = "lblSupplier";
            lblSupplier.Size = new Size(76, 15);
            lblSupplier.TabIndex = 19;
            lblSupplier.Text = "Pilih Supplier";
            // 
            // lblNamaBarang
            // 
            lblNamaBarang.AutoSize = true;
            lblNamaBarang.Location = new Point(20, 90);
            lblNamaBarang.Name = "lblNamaBarang";
            lblNamaBarang.Size = new Size(79, 15);
            lblNamaBarang.TabIndex = 17;
            lblNamaBarang.Text = "Nama Barang";
            // 
            // panel1
            // 
            panel1.BackColor = Color.LimeGreen;
            panel1.Controls.Add(label6);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(394, 43);
            panel1.TabIndex = 28;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(8, 9);
            label6.Name = "label6";
            label6.Size = new Size(175, 21);
            label6.TabIndex = 14;
            label6.Text = "Tambah Stock Barang";
            // 
            // cmbSupplier
            // 
            cmbSupplier.FormattingEnabled = true;
            cmbSupplier.Location = new Point(130, 120);
            cmbSupplier.Name = "cmbSupplier";
            cmbSupplier.Size = new Size(152, 23);
            cmbSupplier.TabIndex = 29;
            // 
            // numJumlah
            // 
            numJumlah.Location = new Point(130, 156);
            numJumlah.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            numJumlah.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numJumlah.Name = "numJumlah";
            numJumlah.Size = new Size(152, 23);
            numJumlah.TabIndex = 30;
            numJumlah.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // TambahStokView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 286);
            Controls.Add(numJumlah);
            Controls.Add(cmbSupplier);
            Controls.Add(btnBatal);
            Controls.Add(btnSimpan);
            Controls.Add(lblJumlah);
            Controls.Add(lblSupplier);
            Controls.Add(lblNamaBarang);
            Controls.Add(panel1);
            Name = "TambahStokView";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numJumlah).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBatal;
        private Button btnSimpan;
        private NumericUpDown numThreshold;
        private NumericUpDown numHarga;
        private NumericUpDown numJumlah;
        private Label lblJumlah;
        private Label lblSupplier;
        private ComboBox cmbKategori;
        private Label lblNamaBarang;
        private TextBox txtNamaBarang;
        private Panel panel1;
        private Label label6;
        private ComboBox cmbSupplier;
        private NumericUpDown numJumlahTambah;
    }
}
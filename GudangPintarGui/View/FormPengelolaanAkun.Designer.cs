namespace GudangPintarGui.View
{
    partial class FormPengelolaanAkun
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
            this.PnlHeaderAtas = new System.Windows.Forms.Panel();
            this.lblGudangPintar = new System.Windows.Forms.Label();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnBarang = new System.Windows.Forms.Button();
            this.btnRiwayat = new System.Windows.Forms.Button();
            this.btnAkun = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.PnlHeaderAtas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlHeaderAtas
            // 
            this.PnlHeaderAtas.BackColor = System.Drawing.Color.Lime;
            this.PnlHeaderAtas.Controls.Add(this.lblGudangPintar);
            this.PnlHeaderAtas.Location = new System.Drawing.Point(2, 2);
            this.PnlHeaderAtas.Name = "PnlHeaderAtas";
            this.PnlHeaderAtas.Size = new System.Drawing.Size(798, 61);
            this.PnlHeaderAtas.TabIndex = 4;
            // 
            // lblGudangPintar
            // 
            this.lblGudangPintar.AutoSize = true;
            this.lblGudangPintar.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGudangPintar.Location = new System.Drawing.Point(31, 19);
            this.lblGudangPintar.Name = "lblGudangPintar";
            this.lblGudangPintar.Size = new System.Drawing.Size(124, 21);
            this.lblGudangPintar.TabIndex = 0;
            this.lblGudangPintar.Text = "Gudang Pintar";
            // 
            // btnDashboard
            // 
            this.btnDashboard.ForeColor = System.Drawing.Color.Black;
            this.btnDashboard.Location = new System.Drawing.Point(65, 70);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(124, 23);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "Dasboard";
            this.btnDashboard.UseVisualStyleBackColor = true;
            // 
            // btnBarang
            // 
            this.btnBarang.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBarang.Location = new System.Drawing.Point(65, 119);
            this.btnBarang.Name = "btnBarang";
            this.btnBarang.Size = new System.Drawing.Size(124, 23);
            this.btnBarang.TabIndex = 1;
            this.btnBarang.Text = "Barang";
            this.btnBarang.UseVisualStyleBackColor = true;
            // 
            // btnRiwayat
            // 
            this.btnRiwayat.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnRiwayat.Location = new System.Drawing.Point(65, 173);
            this.btnRiwayat.Name = "btnRiwayat";
            this.btnRiwayat.Size = new System.Drawing.Size(124, 23);
            this.btnRiwayat.TabIndex = 2;
            this.btnRiwayat.Text = "Riwayat";
            this.btnRiwayat.UseVisualStyleBackColor = true;
            // 
            // btnAkun
            // 
            this.btnAkun.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAkun.Location = new System.Drawing.Point(65, 225);
            this.btnAkun.Name = "btnAkun";
            this.btnAkun.Size = new System.Drawing.Size(124, 23);
            this.btnAkun.TabIndex = 3;
            this.btnAkun.Text = "Akun";
            this.btnAkun.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(2, 70);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.splitContainer1.Panel1.Controls.Add(this.btnDashboard);
            this.splitContainer1.Panel1.Controls.Add(this.btnAkun);
            this.splitContainer1.Panel1.Controls.Add(this.btnBarang);
            this.splitContainer1.Panel1.Controls.Add(this.btnRiwayat);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(798, 373);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 5;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(521, 355);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // FormPengelolaanAkun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(800, 441);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.PnlHeaderAtas);
            this.Name = "FormPengelolaanAkun";
            this.Text = "Form1";
            this.PnlHeaderAtas.ResumeLayout(false);
            this.PnlHeaderAtas.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel PnlHeaderAtas;
        private System.Windows.Forms.Label lblGudangPintar;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnBarang;
        private System.Windows.Forms.Button btnRiwayat;
        private System.Windows.Forms.Button btnAkun;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
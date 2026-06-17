namespace GudangPintarGui.View
{
    partial class NotifMenipis
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
            label1 = new Label();
            label2 = new Label();
            labelbarang = new Label();
            button5 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.LawnGreen;
            panel1.Controls.Add(labelbarang);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(355, 141);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(109, 0);
            label1.Name = "label1";
            label1.Size = new Size(139, 32);
            label1.TabIndex = 0;
            label1.Text = "Peringatan!";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.Location = new Point(9, 32);
            label2.Name = "label2";
            label2.Size = new Size(336, 32);
            label2.TabIndex = 1;
            label2.Text = "Stok barang dibawah menipis";
            label2.Click += label2_Click;
            // 
            // labelbarang
            // 
            labelbarang.Anchor = AnchorStyles.Top;
            labelbarang.AutoSize = true;
            labelbarang.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            labelbarang.Location = new Point(105, 74);
            labelbarang.Name = "labelbarang";
            labelbarang.Size = new Size(143, 32);
            labelbarang.TabIndex = 2;
            labelbarang.Text = "labelbarang";
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.Location = new Point(135, 127);
            button5.Margin = new Padding(4, 3, 4, 3);
            button5.Name = "button5";
            button5.Size = new Size(101, 45);
            button5.TabIndex = 10;
            button5.Text = "Tutup";
            button5.UseVisualStyleBackColor = true;
            // 
            // NotifMenipis
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(379, 180);
            Controls.Add(button5);
            Controls.Add(panel1);
            Name = "NotifMenipis";
            Text = "NotifMenipis";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        private Label labelbarang;
        private Button button5;
    }
}
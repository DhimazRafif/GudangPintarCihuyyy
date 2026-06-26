namespace GudangPintarGui
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tbUsername = new TextBox();
            tbPassword = new TextBox();
            btnLogin = new Button();
            label4 = new Label();
            label1 = new Label();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tbUsername
            // 
            tbUsername.Location = new Point(173, 253);
            tbUsername.Name = "tbUsername";
            tbUsername.PlaceholderText = "User Name . . .";
            tbUsername.Size = new Size(225, 27);
            tbUsername.TabIndex = 4;
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(173, 310);
            tbPassword.Name = "tbPassword";
            tbPassword.PlaceholderText = "Password . . .";
            tbPassword.Size = new Size(225, 27);
            tbPassword.TabIndex = 5;
            tbPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.LawnGreen;
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.Black;
            btnLogin.Location = new Point(208, 438);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(143, 68);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ActiveCaptionText;
            label4.Location = new Point(173, 213);
            label4.Name = "label4";
            label4.Size = new Size(238, 20);
            label4.TabIndex = 7;
            label4.Text = "Masukkan username dan password";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(170, 90);
            label1.Name = "label1";
            label1.Size = new Size(243, 46);
            label1.TabIndex = 1;
            label1.Text = "Gudang Pintar";
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightGray;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(tbPassword);
            panel1.Controls.Add(tbUsername);
            panel1.Location = new Point(459, 117);
            panel1.Name = "panel1";
            panel1.Size = new Size(566, 629);
            panel1.TabIndex = 8;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1445, 1015);
            Controls.Add(panel1);
            Name = "Login";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox tbUsername;
        private TextBox tbPassword;
        private Button btnLogin;
        private Label label4;
        private Label label1;
        private Panel panel1;
    }
}

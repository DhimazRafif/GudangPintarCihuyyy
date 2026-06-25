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
            btnLogin = new Button();
            label1 = new Label();
            tbUsername = new TextBox();
            tbPassword = new TextBox();
            panel1 = new Panel();
            label4 = new Label();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.LawnGreen;
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.Black;
            btnLogin.Location = new Point(1127, 517);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(143, 68);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(1083, 169);
            label1.Name = "label1";
            label1.Size = new Size(243, 46);
            label1.TabIndex = 1;
            label1.Text = "Gudang Pintar";
            // 
            // tbUsername
            // 
            tbUsername.Location = new Point(1086, 332);
            tbUsername.Name = "tbUsername";
            tbUsername.PlaceholderText = "User Name . . .";
            tbUsername.Size = new Size(225, 27);
            tbUsername.TabIndex = 4;
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(1086, 389);
            tbPassword.Name = "tbPassword";
            tbPassword.PlaceholderText = "Password . . .";
            tbPassword.Size = new Size(225, 27);
            tbPassword.TabIndex = 5;
            tbPassword.UseSystemPasswordChar = true;
            // 
            // panel1
            // 
            panel1.BackColor = Color.LawnGreen;
            panel1.Location = new Point(1, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(930, 1012);
            panel1.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.AppWorkspace;
            label4.Location = new Point(1086, 292);
            label4.Name = "label4";
            label4.Size = new Size(238, 20);
            label4.TabIndex = 7;
            label4.Text = "Masukkan username dan password";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1445, 1015);
            Controls.Add(label4);
            Controls.Add(panel1);
            Controls.Add(tbPassword);
            Controls.Add(tbUsername);
            Controls.Add(label1);
            Controls.Add(btnLogin);
            Name = "Login";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private Label label1;
        private TextBox tbUsername;
        private TextBox tbPassword;
        private Panel panel1;
        private Label label4;
    }
}

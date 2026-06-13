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
            label2 = new Label();
            label3 = new Label();
            tbUsername = new TextBox();
            tbPassword = new TextBox();
            panel1 = new Panel();
            label4 = new Label();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(731, 363);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(328, 29);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(803, 23);
            label1.Name = "label1";
            label1.Size = new Size(208, 41);
            label1.TabIndex = 1;
            label1.Text = "Gudang Pintar";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(723, 146);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 2;
            label2.Text = "Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(723, 190);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 3;
            label3.Text = "Password";
            // 
            // tbUsername
            // 
            tbUsername.Location = new Point(834, 143);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(225, 27);
            tbUsername.TabIndex = 4;
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(834, 190);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(225, 27);
            tbPassword.TabIndex = 5;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Lime;
            panel1.Location = new Point(12, 6);
            panel1.Name = "panel1";
            panel1.Size = new Size(705, 602);
            panel1.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(787, 84);
            label4.Name = "label4";
            label4.Size = new Size(238, 20);
            label4.TabIndex = 7;
            label4.Text = "Masukkan username dan password";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1082, 609);
            Controls.Add(label4);
            Controls.Add(panel1);
            Controls.Add(tbPassword);
            Controls.Add(tbUsername);
            Controls.Add(label3);
            Controls.Add(label2);
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
        private Label label2;
        private Label label3;
        private TextBox tbUsername;
        private TextBox tbPassword;
        private Panel panel1;
        private Label label4;
    }
}

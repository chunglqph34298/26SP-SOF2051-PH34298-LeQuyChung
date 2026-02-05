namespace Quan_Ly_Nhan_Su
{
    partial class FormLogin
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
            btnLogin = new Button();
            btnThoat = new Button();
            label1 = new Label();
            label2 = new Label();
            tbUsername = new TextBox();
            tbPassword = new TextBox();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(157, 268);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(112, 34);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Đăng Nhập";
            btnLogin.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(288, 268);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(112, 34);
            btnThoat.TabIndex = 1;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(146, 131);
            label1.Name = "label1";
            label1.Size = new Size(134, 25);
            label1.TabIndex = 2;
            label1.Text = "Tên Đăng Nhập";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(146, 193);
            label2.Name = "label2";
            label2.Size = new Size(87, 25);
            label2.TabIndex = 3;
            label2.Text = "Mật Khẩu";
            // 
            // tbUsername
            // 
            tbUsername.Location = new Point(189, 159);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(150, 31);
            tbUsername.TabIndex = 4;
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(189, 221);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(150, 31);
            tbPassword.TabIndex = 5;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(648, 378);
            Controls.Add(tbPassword);
            Controls.Add(tbUsername);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnThoat);
            Controls.Add(btnLogin);
            Name = "FormLogin";
            Text = "FormLogin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private Button btnThoat;
        private Label label1;
        private Label label2;
        private TextBox tbUsername;
        private TextBox tbPassword;
    }
}
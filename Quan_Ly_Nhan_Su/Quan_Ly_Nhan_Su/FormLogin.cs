namespace Quan_Ly_Nhan_Su
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();

            tbPassword.UseSystemPasswordChar = true;
            this.AcceptButton = btnLogin; // bấm Enter để login
            btnLogin.Click += btnLogin_Click;
            btnThoat.Click += btnThoat_Click;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = tbUsername.Text.Trim();
            string pass = tbPassword.Text; // đừng Trim mật khẩu

            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu!");
                return;
            }

            // ✅ LOGIN CỨNG
            if (user == "admin" && pass == "admin")
            {
                this.Hide();

                var frm = new Form1(); // Form quản trị của m
                frm.FormClosed += (s, _) => this.Close(); // đóng Form1 là thoát app luôn
                frm.Show();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

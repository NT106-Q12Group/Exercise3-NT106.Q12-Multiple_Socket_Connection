using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Exercise3_NT106.Q12_TCPClient
{
    public partial class SignIn : Form
    {
        private const string PH_USERNAME = "Tên đăng nhập";
        private const string PH_PASSWORD = "Nhập mật khẩu";
        private bool _busy;

        public SignIn()
        {
            InitializeComponent();

            btn_signin.Click -= btn_signin_Click;
            btn_signin.Click += btn_signin_Click;

            linkedlb_signup.Click -= linkedlb_signup_Click;
            linkedlb_signup.Click += linkedlb_signup_Click;

            SetupPlaceholders();
            AcceptButton = btn_signin;
        }

        private void linkedlb_signup_Click(object? sender, EventArgs e)
        {
            new SignUp().Show();
            Hide();
        }

        private void SetupPlaceholders()
        {
            SetPlaceholder(tb_username, PH_USERNAME);
            SetPasswordPlaceholder(tb_psw, PH_PASSWORD);
        }

        private static void SetPlaceholder(TextBox tb, string text)
        {
            tb.ForeColor = Color.Gray;
            tb.Text = text;

            tb.Enter += (s, e) =>
            {
                if (tb.ForeColor == Color.Gray && tb.Text == text)
                {
                    tb.Text = "";
                    tb.ForeColor = Color.Black;
                }
            };
            tb.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(tb.Text))
                {
                    tb.ForeColor = Color.Gray;
                    tb.Text = text;
                }
            };
        }

        private static void SetPasswordPlaceholder(TextBox tb, string text)
        {
            tb.UseSystemPasswordChar = false;
            tb.ForeColor = Color.Gray;
            tb.Text = text;

            tb.Enter += (s, e) =>
            {
                if (tb.ForeColor == Color.Gray && tb.Text == text)
                {
                    tb.Text = "";
                    tb.ForeColor = Color.Black;
                    tb.UseSystemPasswordChar = true;
                }
            };
            tb.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(tb.Text))
                {
                    tb.UseSystemPasswordChar = false;
                    tb.ForeColor = Color.Gray;
                    tb.Text = text;
                }
            };
        }

        private void btn_signin_Click(object? sender, EventArgs e)
        {
            if (_busy) return;
            _busy = true;
            btn_signin.Enabled = false;

            try
            {
                string u = (tb_username.ForeColor == Color.Gray) ? "" : tb_username.Text.Trim();
                string p = (tb_psw.ForeColor == Color.Gray) ? "" : tb_psw.Text;

                if (string.IsNullOrWhiteSpace(u))
                { MessageBox.Show("Vui lòng nhập tên đăng nhập."); tb_username.Focus(); return; }

                if (string.IsNullOrWhiteSpace(p))
                { MessageBox.Show("Vui lòng nhập mật khẩu."); tb_psw.Focus(); return; }

                if (!Session.Client.TestConnection())
                { MessageBox.Show("Không thể kết nối server (25565)."); return; }

                string resp = Session.Client.Login(u, p);
                var parts = resp.Split('|');
                if (parts.Length > 0 && parts[0].Equals("Success", StringComparison.OrdinalIgnoreCase))
                {
                    var user = new UserView
                    {
                        Username = parts.Length > 1 ? parts[1] : u,
                        Email = parts.Length > 2 ? parts[2] : "",
                        FullName = parts.Length > 3 ? parts[3] : "",
                        Age = parts.Length > 4 ? parts[4] : "",
                        Address = parts.Length > 5 ? parts[5] : "",
                        Phone = parts.Length > 6 ? parts[6] : ""
                    };

                    Session.CurrentUser = user.Username;

                    var dash = new Dashboard(user, Session.Client);
                    dash.FormClosed += (s, _) => Close();
                    Hide();
                    dash.Show();
                }
                else
                {
                    string msg = parts.Length > 1 ? parts[1] : "Đăng nhập thất bại.";
                    MessageBox.Show(msg, "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                btn_signin.Enabled = true;
                _busy = false;
            }
        }
    }
}

using System;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Exercise3_NT106.Q12_TCPClient
{
    public partial class SignUp : Form
    {
        private const string PH_USERNAME = "Tên đăng nhập (4–20 ký tự, chữ/số/_ )";
        private const string PH_PASSWORD = "Nhập mật khẩu";
        private const string PH_CFPASS = "Xác nhận mật khẩu";
        private const string PH_EMAIL = "Email";
        private const string PH_FULLNAME = "Họ và tên";
        private const string PH_BIRTHDATE = "Ngày sinh (dd/MM/yyyy)";
        private const string PH_ADDRESS = "Địa chỉ";
        private const string PH_PHONE = "Số điện thoại (10 số, bắt đầu 0)";

        private bool _busy;

        public SignUp()
        {
            InitializeComponent();

            btn_signup.Click -= btn_signup_Click;
            btn_signup.Click += btn_signup_Click;

            linkedlb_signin.Click -= linkedlb_signin_Click;
            linkedlb_signin.Click += linkedlb_signin_Click;

            SetupPlaceholders();

            tb_phone.KeyPress -= Tb_phone_KeyPressOnlyDigits;
            tb_phone.KeyPress += Tb_phone_KeyPressOnlyDigits;

            tb_phone.MaxLength = 10;
        }

        private void linkedlb_signin_Click(object? sender, EventArgs e)
        {
            new SignIn().Show();
            Hide();
        }

        private void SetupPlaceholders()
        {
            SetPlaceholder(tb_username, PH_USERNAME);
            SetPasswordPlaceholder(tb_psw, PH_PASSWORD);
            SetPasswordPlaceholder(tb_cfpsw, PH_CFPASS);
            SetPlaceholder(tb_email, PH_EMAIL);
            SetPlaceholder(tb_fullname, PH_FULLNAME);
            SetPlaceholder(tb_age, PH_BIRTHDATE);
            SetPlaceholder(tb_address, PH_ADDRESS);
            SetPlaceholder(tb_phone, PH_PHONE);
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

        private static bool IsValidEmail(string email)
            => Regex.IsMatch(email ?? "", @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

        private static bool TryValidateBirthdate(string input, out string normalized, out string error)
        {
            normalized = "";
            error = "";

            if (!DateTime.TryParseExact(input, "dd/MM/yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out var dob))
            {
                error = "Ngày sinh phải theo định dạng dd/MM/yyyy (ví dụ 31/12/2001).";
                return false;
            }

            if (dob > DateTime.Today)
            {
                error = "Ngày sinh không được ở tương lai.";
                return false;
            }

            if (dob.Year < 1900)
            {
                error = "Ngày sinh không hợp lệ (trước năm 1900).";
                return false;
            }

            normalized = dob.ToString("dd/MM/yyyy");
            return true;
        }

        private static bool IsValidPhoneVN10(string phone)
            => Regex.IsMatch(phone ?? "", @"^0\d{9}$");

        private void Tb_phone_KeyPressOnlyDigits(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void btn_signup_Click(object? sender, EventArgs e)
        {
            if (_busy) return;
            _busy = true;
            btn_signup.Enabled = false;

            try
            {
                string username = (tb_username.ForeColor == Color.Gray) ? "" : tb_username.Text.Trim();
                string psw = (tb_psw.ForeColor == Color.Gray) ? "" : tb_psw.Text;
                string cfpsw = (tb_cfpsw.ForeColor == Color.Gray) ? "" : tb_cfpsw.Text;
                string email = (tb_email.ForeColor == Color.Gray) ? "" : tb_email.Text.Trim();
                string fullname = (tb_fullname.ForeColor == Color.Gray) ? "" : tb_fullname.Text.Trim();
                string birthRaw = (tb_age.ForeColor == Color.Gray) ? "" : tb_age.Text.Trim();     // ngày sinh
                string address = (tb_address.ForeColor == Color.Gray) ? "" : tb_address.Text.Trim();
                string phone = (tb_phone.ForeColor == Color.Gray) ? "" : tb_phone.Text.Trim();

                if (username.Length < 4 || username.Length > 20 || !Regex.IsMatch(username, "^[a-zA-Z0-9_]+$"))
                { MessageBox.Show("Tên đăng nhập 4–20 ký tự, chỉ gồm chữ/số/_"); tb_username.Focus(); return; }

                if (psw.Length < 8) { MessageBox.Show("Mật khẩu phải ≥ 8 ký tự."); tb_psw.Focus(); return; }
                if (psw != cfpsw) { MessageBox.Show("Xác nhận mật khẩu không khớp."); tb_cfpsw.Focus(); return; }

                if (!IsValidEmail(email)) { MessageBox.Show("Email không hợp lệ."); tb_email.Focus(); return; }

                if (!TryValidateBirthdate(birthRaw, out var birthNormalized, out var birthErr))
                { MessageBox.Show(birthErr); tb_age.Focus(); return; }

                if (!IsValidPhoneVN10(phone))
                { MessageBox.Show("Số điện thoại phải gồm 10 số và bắt đầu bằng 0."); tb_phone.Focus(); return; }

                if (!Session.Client.TestConnection())
                { MessageBox.Show("Không thể kết nối server (25565)."); return; }

                string resp = Session.Client.Register(username, psw, email, fullname, birthNormalized, address, phone);
                var parts = resp.Split('|');

                if (parts.Length > 0 && parts[0].Equals("Success", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Đăng ký thành công!");
                    new SignIn().Show(); Hide();
                }
                else
                {
                    string msg = parts.Length > 1 ? parts[1] : "Đăng ký thất bại.";
                    MessageBox.Show(msg, "Đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                btn_signup.Enabled = true;
                _busy = false;
            }
        }
    }
}

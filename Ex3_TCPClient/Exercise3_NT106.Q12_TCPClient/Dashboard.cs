using System;
using System.Windows.Forms;

namespace Exercise3_NT106.Q12_TCPClient
{
    public partial class Dashboard : Form
    {
        private readonly TCPClient _client;
        private readonly UserView _user;
        private bool _busy;

        public Dashboard(UserView user, TCPClient client)
        {
            InitializeComponent();
            _user = user; _client = client;

            btn_signout.Click -= btn_signout_Click;
            btn_signout.Click += btn_signout_Click;

            Load += (s, e) =>
            {
                tb_fullname.Text = _user.FullName;
                tb_username.Text = _user.Username;
                tb_address.Text = _user.Address;
                tb_email.Text = _user.Email;
                tb_phone.Text = _user.Phone;
                tb_age.Text = _user.Age;

                tb_fullname.ReadOnly = tb_username.ReadOnly =
                tb_address.ReadOnly = tb_email.ReadOnly =
                tb_phone.ReadOnly = tb_age.ReadOnly = true;
            };
        }

        private void btn_signout_Click(object? sender, EventArgs e)
        {
            if (_busy) return;
            _busy = true;
            btn_signout.Enabled = false;

            try
            {
                string message = "Đăng xuất thành công!";
                if (!string.IsNullOrEmpty(_user.Username) && _client.IsConnected())
                {
                    var resp = _client.Logout(_user.Username);
                    var parts = resp.Split('|');
                    if (!(parts.Length > 0 && parts[0].Equals("Success", StringComparison.OrdinalIgnoreCase)))
                        message = "Server không xác nhận đăng xuất.";
                }

                try { _client.Disconnect(); } catch { }

                Hide();
                var si = new SignIn();
                si.Show();
                BeginInvoke((Action)(() => MessageBox.Show(message, "Đăng xuất")));
            }
            finally
            {
                btn_signout.Enabled = true;
                _busy = false;
            }
        }
    }
}

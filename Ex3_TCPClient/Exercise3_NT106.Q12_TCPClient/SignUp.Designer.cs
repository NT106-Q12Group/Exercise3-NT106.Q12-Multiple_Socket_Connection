namespace Exercise3_NT106.Q12_TCPClient
{
    partial class SignUp
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
            tb_username = new TextBox();
            btn_signup = new Button();
            lb_signin = new Label();
            linkedlb_signin = new LinkLabel();
            tb_fullname = new TextBox();
            tb_age = new TextBox();
            tb_email = new TextBox();
            tb_cfpsw = new TextBox();
            tb_psw = new TextBox();
            tb_address = new TextBox();
            tb_phone = new TextBox();
            SuspendLayout();
            // 
            // tb_username
            // 
            tb_username.Location = new Point(139, 63);
            tb_username.Name = "tb_username";
            tb_username.Size = new Size(213, 27);
            tb_username.TabIndex = 0;
            // 
            // btn_signup
            // 
            btn_signup.Location = new Point(351, 305);
            btn_signup.Name = "btn_signup";
            btn_signup.Size = new Size(94, 29);
            btn_signup.TabIndex = 1;
            btn_signup.Text = "Sign Up";
            btn_signup.UseVisualStyleBackColor = true;
            btn_signup.Click += btn_signup_Click;
            // 
            // lb_signin
            // 
            lb_signin.AutoSize = true;
            lb_signin.Location = new Point(276, 337);
            lb_signin.Name = "lb_signin";
            lb_signin.Size = new Size(178, 20);
            lb_signin.TabIndex = 2;
            lb_signin.Text = "Already have an account?";
            // 
            // linkedlb_signin
            // 
            linkedlb_signin.AutoSize = true;
            linkedlb_signin.Location = new Point(453, 337);
            linkedlb_signin.Name = "linkedlb_signin";
            linkedlb_signin.Size = new Size(54, 20);
            linkedlb_signin.TabIndex = 3;
            linkedlb_signin.TabStop = true;
            linkedlb_signin.Text = "Sign In";
            // 
            // tb_fullname
            // 
            tb_fullname.Location = new Point(453, 63);
            tb_fullname.Name = "tb_fullname";
            tb_fullname.Size = new Size(213, 27);
            tb_fullname.TabIndex = 4;
            // 
            // tb_age
            // 
            tb_age.Location = new Point(453, 123);
            tb_age.Name = "tb_age";
            tb_age.Size = new Size(213, 27);
            tb_age.TabIndex = 5;
            // 
            // tb_email
            // 
            tb_email.Location = new Point(139, 248);
            tb_email.Name = "tb_email";
            tb_email.Size = new Size(213, 27);
            tb_email.TabIndex = 6;
            // 
            // tb_cfpsw
            // 
            tb_cfpsw.Location = new Point(139, 187);
            tb_cfpsw.Name = "tb_cfpsw";
            tb_cfpsw.Size = new Size(213, 27);
            tb_cfpsw.TabIndex = 7;
            // 
            // tb_psw
            // 
            tb_psw.Location = new Point(139, 123);
            tb_psw.Name = "tb_psw";
            tb_psw.Size = new Size(213, 27);
            tb_psw.TabIndex = 8;
            // 
            // tb_address
            // 
            tb_address.Location = new Point(453, 187);
            tb_address.Name = "tb_address";
            tb_address.Size = new Size(213, 27);
            tb_address.TabIndex = 10;
            // 
            // tb_phone
            // 
            tb_phone.Location = new Point(453, 248);
            tb_phone.Name = "tb_phone";
            tb_phone.Size = new Size(213, 27);
            tb_phone.TabIndex = 11;
            // 
            // SignUp
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tb_phone);
            Controls.Add(tb_address);
            Controls.Add(tb_psw);
            Controls.Add(tb_cfpsw);
            Controls.Add(tb_email);
            Controls.Add(tb_age);
            Controls.Add(tb_fullname);
            Controls.Add(linkedlb_signin);
            Controls.Add(lb_signin);
            Controls.Add(btn_signup);
            Controls.Add(tb_username);
            Name = "SignUp";
            Text = "SignUp";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tb_username;
        private Button btn_signup;
        private Label lb_signin;
        private LinkLabel linkedlb_signin;
        private TextBox tb_fullname;
        private TextBox tb_age;
        private TextBox tb_email;
        private TextBox tb_cfpsw;
        private TextBox tb_psw;
        private TextBox tb_address;
        private TextBox tb_phone;
    }
}
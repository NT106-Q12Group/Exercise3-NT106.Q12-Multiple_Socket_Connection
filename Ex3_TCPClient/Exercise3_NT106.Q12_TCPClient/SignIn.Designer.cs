namespace Exercise3_NT106.Q12_TCPClient
{
    partial class SignIn
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
            tb_psw = new TextBox();
            lb_signup = new Label();
            linkedlb_signup = new LinkLabel();
            btn_signin = new Button();
            SuspendLayout();
            // 
            // tb_username
            // 
            tb_username.Location = new Point(128, 148);
            tb_username.Name = "tb_username";
            tb_username.Size = new Size(248, 27);
            tb_username.TabIndex = 0;
            // 
            // tb_psw
            // 
            tb_psw.Location = new Point(128, 210);
            tb_psw.Name = "tb_psw";
            tb_psw.Size = new Size(248, 27);
            tb_psw.TabIndex = 1;
            // 
            // lb_signup
            // 
            lb_signup.AutoSize = true;
            lb_signup.Location = new Point(128, 307);
            lb_signup.Name = "lb_signup";
            lb_signup.Size = new Size(163, 20);
            lb_signup.TabIndex = 2;
            lb_signup.Text = "Don't have an account?";
            // 
            // linkedlb_signup
            // 
            linkedlb_signup.AutoSize = true;
            linkedlb_signup.Location = new Point(297, 307);
            linkedlb_signup.Name = "linkedlb_signup";
            linkedlb_signup.Size = new Size(59, 20);
            linkedlb_signup.TabIndex = 3;
            linkedlb_signup.TabStop = true;
            linkedlb_signup.Text = "Sign up";
            // 
            // btn_signin
            // 
            btn_signin.Location = new Point(206, 256);
            btn_signin.Name = "btn_signin";
            btn_signin.Size = new Size(94, 29);
            btn_signin.TabIndex = 4;
            btn_signin.Text = "Sign In";
            btn_signin.UseVisualStyleBackColor = true;
            btn_signin.Click += btn_signin_Click;
            // 
            // SignIn
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_signin);
            Controls.Add(linkedlb_signup);
            Controls.Add(lb_signup);
            Controls.Add(tb_psw);
            Controls.Add(tb_username);
            Name = "SignIn";
            Text = "SignIn";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tb_username;
        private TextBox tb_psw;
        private Label lb_signup;
        private LinkLabel linkedlb_signup;
        private Button btn_signin;
    }
}
namespace Exercise3_NT106.Q12_TCPClient
{
    partial class Dashboard
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
            tb_fullname = new TextBox();
            btn_signout = new Button();
            tb_username = new TextBox();
            tb_age = new TextBox();
            tb_address = new TextBox();
            tb_email = new TextBox();
            tb_phone = new TextBox();
            SuspendLayout();
            // 
            // tb_fullname
            // 
            tb_fullname.Location = new Point(273, 62);
            tb_fullname.Name = "tb_fullname";
            tb_fullname.ReadOnly = true;
            tb_fullname.Size = new Size(254, 27);
            tb_fullname.TabIndex = 0;
            // 
            // btn_signout
            // 
            btn_signout.Location = new Point(653, 47);
            btn_signout.Name = "btn_signout";
            btn_signout.Size = new Size(94, 29);
            btn_signout.TabIndex = 1;
            btn_signout.Text = "Sign Out";
            btn_signout.UseVisualStyleBackColor = true;
            btn_signout.Click += btn_signout_Click;
            // 
            // tb_username
            // 
            tb_username.Location = new Point(273, 117);
            tb_username.Name = "tb_username";
            tb_username.ReadOnly = true;
            tb_username.Size = new Size(254, 27);
            tb_username.TabIndex = 2;
            // 
            // tb_age
            // 
            tb_age.Location = new Point(273, 181);
            tb_age.Name = "tb_age";
            tb_age.ReadOnly = true;
            tb_age.Size = new Size(254, 27);
            tb_age.TabIndex = 3;
            // 
            // tb_address
            // 
            tb_address.Location = new Point(273, 246);
            tb_address.Name = "tb_address";
            tb_address.ReadOnly = true;
            tb_address.Size = new Size(254, 27);
            tb_address.TabIndex = 4;
            // 
            // tb_email
            // 
            tb_email.Location = new Point(273, 313);
            tb_email.Name = "tb_email";
            tb_email.ReadOnly = true;
            tb_email.Size = new Size(254, 27);
            tb_email.TabIndex = 5;
            // 
            // tb_phone
            // 
            tb_phone.Location = new Point(273, 377);
            tb_phone.Name = "tb_phone";
            tb_phone.ReadOnly = true;
            tb_phone.Size = new Size(254, 27);
            tb_phone.TabIndex = 6;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tb_phone);
            Controls.Add(tb_email);
            Controls.Add(tb_address);
            Controls.Add(tb_age);
            Controls.Add(tb_username);
            Controls.Add(btn_signout);
            Controls.Add(tb_fullname);
            Name = "Dashboard";
            Text = "Dashboard";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tb_fullname;
        private Button btn_signout;
        private TextBox tb_username;
        private TextBox tb_age;
        private TextBox tb_address;
        private TextBox tb_email;
        private TextBox tb_phone;
    }
}
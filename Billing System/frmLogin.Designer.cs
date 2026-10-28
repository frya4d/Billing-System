namespace Billing_System
{
    partial class frmLogin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblHeader = new Label();
            pnlFooter = new Panel();
            label2 = new Label();
            usertxt = new TextBox();
            label1 = new Label();
            passtxt = new TextBox();
            chkShowPassword = new CheckBox();
            label3 = new Label();
            type = new ComboBox();
            button1 = new Button();
            btnCancel = new Button();
            lnkForgotPassword = new LinkLabel();
            btnsn = new Button();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(70, 205, 196);
            pnlHeader.Controls.Add(lblHeader);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(380, 45);
            pnlHeader.TabIndex = 0;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblHeader.ForeColor = Color.Black;
            lblHeader.Location = new Point(15, 6);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(144, 32);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Login Form";
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = Color.FromArgb(70, 205, 196);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 458);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(380, 12);
            pnlFooter.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.Location = new Point(60, 60);
            label2.Name = "label2";
            label2.Size = new Size(89, 23);
            label2.TabIndex = 2;
            label2.Text = "Username";
            // 
            // usertxt
            // 
            usertxt.Font = new Font("Segoe UI", 10F);
            usertxt.Location = new Point(60, 86);
            usertxt.Name = "usertxt";
            usertxt.Size = new Size(260, 30);
            usertxt.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.Location = new Point(60, 124);
            label1.Name = "label1";
            label1.Size = new Size(85, 23);
            label1.TabIndex = 4;
            label1.Text = "Password";
            // 
            // passtxt
            // 
            passtxt.Font = new Font("Segoe UI", 10F);
            passtxt.Location = new Point(60, 150);
            passtxt.Name = "passtxt";
            passtxt.PasswordChar = '*';
            passtxt.Size = new Size(260, 30);
            passtxt.TabIndex = 5;
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            chkShowPassword.Location = new Point(60, 186);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(140, 24);
            chkShowPassword.TabIndex = 6;
            chkShowPassword.Text = "Show Password";
            chkShowPassword.UseVisualStyleBackColor = true;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.Location = new Point(60, 218);
            label3.Name = "label3";
            label3.Size = new Size(88, 23);
            label3.TabIndex = 7;
            label3.Text = "User Type";
            // 
            // type
            // 
            type.DropDownStyle = ComboBoxStyle.DropDownList;
            type.Font = new Font("Segoe UI", 10F);
            type.FormattingEnabled = true;
            type.Items.AddRange(new object[] { "Admin", "User" });
            type.Location = new Point(60, 244);
            type.Name = "type";
            type.Size = new Size(260, 31);
            type.TabIndex = 8;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button1.Location = new Point(60, 295);
            button1.Name = "button1";
            button1.Size = new Size(260, 36);
            button1.TabIndex = 9;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.Location = new Point(60, 342);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(260, 36);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lnkForgotPassword
            // 
            lnkForgotPassword.AutoSize = true;
            lnkForgotPassword.Font = new Font("Segoe UI", 9.5F);
            lnkForgotPassword.LinkColor = Color.Blue;
            lnkForgotPassword.Location = new Point(194, 395);
            lnkForgotPassword.Name = "lnkForgotPassword";
            lnkForgotPassword.Size = new Size(126, 21);
            lnkForgotPassword.TabIndex = 11;
            lnkForgotPassword.TabStop = true;
            lnkForgotPassword.Text = "Forgot Password";
            lnkForgotPassword.LinkClicked += lnkForgotPassword_LinkClicked;
            // 
            // btnsn
            // 
            btnsn.Location = new Point(65, 392);
            btnsn.Name = "btnsn";
            btnsn.Size = new Size(94, 29);
            btnsn.TabIndex = 12;
            btnsn.Text = "Singup";
            btnsn.UseVisualStyleBackColor = true;
            btnsn.Click += btnsn_Click;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(380, 470);
            Controls.Add(btnsn);
            Controls.Add(lnkForgotPassword);
            Controls.Add(btnCancel);
            Controls.Add(button1);
            Controls.Add(type);
            Controls.Add(label3);
            Controls.Add(chkShowPassword);
            Controls.Add(passtxt);
            Controls.Add(label1);
            Controls.Add(usertxt);
            Controls.Add(label2);
            Controls.Add(pnlFooter);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login Form";
            Load += frmLogin_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlHeader;
        private Label lblHeader;
        private Panel pnlFooter;
        private Label label1;
        private Label label2;
        private TextBox passtxt;
        private CheckBox chkShowPassword;
        private Label label3;
        private ComboBox type;
        private TextBox usertxt;
        private Button button1;
        private Button btnCancel;
        private LinkLabel lnkForgotPassword;
        private Button btnsn;
    }
}

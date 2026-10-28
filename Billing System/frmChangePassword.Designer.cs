namespace Billing_System
{
    partial class frmChangePassword
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
            lblHeaderTitle = new Label();
            pnlFooter = new Panel();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblNewPassword = new Label();
            txtNewPassword = new TextBox();
            lblConfirmPassword = new Label();
            txtConfirmPassword = new TextBox();
            btnChangePassword = new Button();
            btnCancel = new Button();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            pnlHeader.BackColor = Color.FromArgb(70, 205, 196);
            pnlHeader.Controls.Add(lblHeaderTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(380, 45);
            pnlHeader.TabIndex = 0;
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.Black;
            lblHeaderTitle.Location = new Point(15, 8);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(181, 28);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "Change Password";
            pnlFooter.BackColor = Color.FromArgb(70, 205, 196);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 348);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(380, 12);
            pnlFooter.TabIndex = 1;
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblUsername.Location = new Point(60, 60);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(92, 21);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "Username:";
            txtUsername.Font = new Font("Segoe UI", 10F);
            txtUsername.Location = new Point(60, 85);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(260, 30);
            txtUsername.TabIndex = 3;
            lblNewPassword.AutoSize = true;
            lblNewPassword.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblNewPassword.Location = new Point(60, 125);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new Size(128, 21);
            lblNewPassword.TabIndex = 4;
            lblNewPassword.Text = "New Password:";
            txtNewPassword.Font = new Font("Segoe UI", 10F);
            txtNewPassword.Location = new Point(60, 150);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.PasswordChar = '*';
            txtNewPassword.Size = new Size(260, 30);
            txtNewPassword.TabIndex = 5;
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblConfirmPassword.Location = new Point(60, 190);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(153, 21);
            lblConfirmPassword.TabIndex = 6;
            lblConfirmPassword.Text = "Confirm Password:";
            txtConfirmPassword.Font = new Font("Segoe UI", 10F);
            txtConfirmPassword.Location = new Point(60, 215);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.Size = new Size(260, 30);
            txtConfirmPassword.TabIndex = 7;
            btnChangePassword.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnChangePassword.Location = new Point(60, 265);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(150, 35);
            btnChangePassword.TabIndex = 8;
            btnChangePassword.Text = "Change Password";
            btnChangePassword.UseVisualStyleBackColor = true;
            btnChangePassword.Click += btnChangePassword_Click;
            btnCancel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnCancel.Location = new Point(220, 265);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(380, 360);
            Controls.Add(btnCancel);
            Controls.Add(btnChangePassword);
            Controls.Add(txtConfirmPassword);
            Controls.Add(lblConfirmPassword);
            Controls.Add(txtNewPassword);
            Controls.Add(lblNewPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Controls.Add(pnlFooter);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmChangePassword";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Change Password";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlHeader;
        private Label lblHeaderTitle;
        private Panel pnlFooter;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblNewPassword;
        private TextBox txtNewPassword;
        private Label lblConfirmPassword;
        private TextBox txtConfirmPassword;
        private Button btnChangePassword;
        private Button btnCancel;
    }
}

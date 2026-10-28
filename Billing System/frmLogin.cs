using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Billing_System
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                passtxt.PasswordChar = '\0';
            }
            else
            {
                passtxt.PasswordChar = '*';
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lnkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmChangePassword cp = new frmChangePassword();
            cp.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usertxt.Text) || string.IsNullOrWhiteSpace(passtxt.Text))
            {
                MessageBox.Show("Please enter username and password!");
                return;
            }

            SqlConnection sqll = new SqlConnection(frmDashboard.connString);

            String query = "SELECT * FROM tbl_users WHERE username=@u AND password=@p AND user_type=@a ";
            SqlCommand sql = new SqlCommand(query, sqll);
            sql.Parameters.AddWithValue("@u", usertxt.Text.Trim());
            sql.Parameters.AddWithValue("@p", passtxt.Text);
            sql.Parameters.AddWithValue("@a", type.Text.Trim());

            sqll.Open();
            int check = 0;

            SqlDataReader dl = sql.ExecuteReader();
            while (dl.Read())
            {
                check++;
            }
            dl.Close();
            sqll.Close();

            if (check == 1)
            {
                MessageBox.Show("Login Successful!");

                frmDashboard.LoggedInUser = usertxt.Text.Trim();

                if (type.Text == "Admin")
                {
                    frmDashboard fd = new frmDashboard();
                    fd.Show();
                    this.Hide();
                }
                else if (type.Text == "User")
                {
                    frmUsers fu = new frmUsers();
                    fu.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Invalid Username, Password, or User Type!");
            }
        }

        private void btnsn_Click(object sender, EventArgs e)
        {
            frmUsers fu = new frmUsers();
            fu.Show();
            
            
            
        }
    }
}

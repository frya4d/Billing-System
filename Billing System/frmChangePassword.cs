using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Billing_System
{
    public partial class frmChangePassword : Form
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtNewPassword.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                MessageBox.Show("Please fill all fields!");
                return;
            }

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match!");
                return;
            }

            if (!Program.IsValidPassword(txtNewPassword.Text, out string passError))
            {
                MessageBox.Show(passError);
                return;
            }

            try
            {
                SqlConnection conn = new SqlConnection(frmDashboard.connString);
                string query = "UPDATE tbl_users SET password=@p WHERE username=@u";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@p", txtNewPassword.Text);
                cmd.Parameters.AddWithValue("@u", txtUsername.Text.Trim());

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                conn.Close();

                if (rows > 0)
                {
                    MessageBox.Show("Password changed successfully!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Username not found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

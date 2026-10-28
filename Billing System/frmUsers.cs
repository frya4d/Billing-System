using System.Data;
using Microsoft.Data.SqlClient;

namespace Billing_System
{
    public partial class frmUsers : Form
    {
        public frmUsers()
        {
            InitializeComponent();
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                SqlConnection conn = new SqlConnection(frmDashboard.connString);
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM tbl_users", conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvUsers.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message);
            }
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool CheckPassword(string password)
        {
            if (password.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters long!");
                return false;
            }

            bool hasLetter = false;
            bool hasNumber = false;
            bool hasSymbol = false;

            for (int i = 0; i < password.Length; i++)
            {
                char c = password[i];
                if (char.IsLetter(c))
                {
                    hasLetter = true;
                }
                else if (char.IsDigit(c))
                {
                    hasNumber = true;
                }
                else
                {
                    hasSymbol = true;
                }
            }

            if (!hasLetter || !hasNumber || !hasSymbol)
            {
                MessageBox.Show("Password must contain letters, numbers, and symbols!");
                return false;
            }

            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text == "" || txtLastName.Text == "" || txtEmail.Text == "" ||
                txtUserName.Text == "" || txtPassword.Text == "" || txtConfirmPassword.Text == "" ||
                txtContact.Text == "" || cmbGender.Text == "" || txtAddress.Text == "" || cmbUserType.Text == "")
            {
                MessageBox.Show("Please fill in all fields!");
                return;
            }

            if (!CheckPassword(txtPassword.Text))
            {
                return;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Password and Confirm Password do not match!");
                return;
            }

            try
            {
                SqlConnection conn = new SqlConnection(frmDashboard.connString);
                string query = "INSERT INTO tbl_users (first_name, last_name, email, username, password, contact, gender, address, user_type) " +
                               "VALUES (@first_name, @last_name, @email, @username, @password, @contact, @gender, @address, @user_type)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@first_name", txtFirstName.Text.Trim());
                cmd.Parameters.AddWithValue("@last_name", txtLastName.Text.Trim());
                cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@username", txtUserName.Text.Trim());
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@contact", txtContact.Text.Trim());
                cmd.Parameters.AddWithValue("@gender", cmbGender.Text);
                cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@user_type", cmbUserType.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("User added successfully!");
                LoadUsers();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding user: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtUserId.Text == "")
            {
                MessageBox.Show("Please select a user from the table to update!");
                return;
            }

            if (txtFirstName.Text == "" || txtLastName.Text == "" || txtEmail.Text == "" ||
                txtUserName.Text == "" || txtPassword.Text == "" || txtConfirmPassword.Text == "" ||
                txtContact.Text == "" || cmbGender.Text == "" || txtAddress.Text == "" || cmbUserType.Text == "")
            {
                MessageBox.Show("Please fill in all fields!");
                return;
            }

            if (!CheckPassword(txtPassword.Text))
            {
                return;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Password and Confirm Password do not match!");
                return;
            }

            try
            {
                SqlConnection conn = new SqlConnection(frmDashboard.connString);
                string query = "UPDATE tbl_users SET first_name=@first_name, last_name=@last_name, email=@email, " +
                               "username=@username, password=@password, contact=@contact, gender=@gender, " +
                               "address=@address, user_type=@user_type WHERE id=@id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", txtUserId.Text);
                cmd.Parameters.AddWithValue("@first_name", txtFirstName.Text.Trim());
                cmd.Parameters.AddWithValue("@last_name", txtLastName.Text.Trim());
                cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@username", txtUserName.Text.Trim());
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@contact", txtContact.Text.Trim());
                cmd.Parameters.AddWithValue("@gender", cmbGender.Text);
                cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@user_type", cmbUserType.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("User updated successfully!");
                LoadUsers();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating user: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtUserId.Text == "")
            {
                MessageBox.Show("Please select a user from the table to delete!");
                return;
            }

            try
            {
                SqlConnection conn = new SqlConnection(frmDashboard.connString);
                string query = "DELETE FROM tbl_users WHERE id=@id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", txtUserId.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("User deleted successfully!");
                LoadUsers();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting user: " + ex.Message);
            }
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.RowIndex >= dgvUsers.Rows.Count) return;
            DataGridViewRow row = dgvUsers.Rows[e.RowIndex];

            txtUserId.Text = row.Cells[0].Value.ToString();
            txtFirstName.Text = row.Cells[1].Value.ToString();
            txtLastName.Text = row.Cells[2].Value.ToString();
            txtEmail.Text = row.Cells[3].Value.ToString();
            txtUserName.Text = row.Cells[4].Value.ToString();
            txtPassword.Text = row.Cells[5].Value.ToString();
            txtConfirmPassword.Text = row.Cells[5].Value.ToString();
            txtContact.Text = row.Cells[6].Value.ToString();
            cmbGender.Text = row.Cells[7].Value.ToString();
            txtAddress.Text = row.Cells[8].Value.ToString();
            cmbUserType.Text = row.Cells[9].Value.ToString();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(frmDashboard.connString);
                string query = "SELECT * FROM tbl_users WHERE id LIKE '%" + txtSearch.Text + "%'";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvUsers.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching: " + ex.Message);
            }
        }

        private void ClearFields()
        {
            txtUserId.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtUserName.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
            txtContact.Clear();
            cmbGender.SelectedIndex = -1;
            txtAddress.Clear();
            cmbUserType.SelectedIndex = -1;
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblHeaderTitle_Click(object sender, EventArgs e)
        {

        }
    }
}





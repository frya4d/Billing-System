using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Billing_System
{
    public partial class frmCustomer : Form
    {
        public frmCustomer()
        {
            InitializeComponent();
        }
        private void LoadUsers()
        {
            try
            {
                SqlConnection conn = new SqlConnection(frmDashboard.connString);
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM tbl_customer", conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message);
            }
        }
        private void frmCustomer_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.RowIndex >= dataGridView1.Rows.Count) return;
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            idtxt.Text = row.Cells[0].Value.ToString();
            typetxt.Text = row.Cells[1].Value.ToString();
            nametxt.Text = row.Cells[2].Value.ToString();
            contacttxt.Text = row.Cells[3].Value.ToString();
            emailtxt.Text = row.Cells[4].Value.ToString();
            addresstxt.Text = row.Cells[5].Value.ToString();

        }

        private void addbtn_Click(object sender, EventArgs e)
        {


            if (typetxt.Text == "" || nametxt.Text == "" || contacttxt.Text == "" ||
                emailtxt.Text == "" || addresstxt.Text == "")
            {
                MessageBox.Show("Please fill in all fields!");
                return;
            }

            if (!Program.IsValidName(nametxt.Text, out string nameError))
            {
                MessageBox.Show(nameError);
                return;
            }

            if (!Program.IsValidPhone(contacttxt.Text, out string phoneError))
            {
                MessageBox.Show(phoneError);
                return;
            }

            if (!Program.IsValidEmail(emailtxt.Text, out string emailError))
            {
                MessageBox.Show(emailError);
                return;
            }



            try
            {
                SqlConnection conn = new SqlConnection(frmDashboard.connString);
                string query = "INSERT INTO tbl_customer (type, name, contact, email, address) " +
                               "VALUES (@type, @name, @contact, @email, @address)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@type", typetxt.Text.Trim());
                cmd.Parameters.AddWithValue("@name", nametxt.Text.Trim());
                cmd.Parameters.AddWithValue("@contact", contacttxt.Text.Trim());
                cmd.Parameters.AddWithValue("@email", emailtxt.Text.Trim());
                cmd.Parameters.AddWithValue("@address", addresstxt.Text.Trim());


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

        private void updatebtn_Click(object sender, EventArgs e)
        {
            if (idtxt.Text == "")
            {
                MessageBox.Show("Please select a user from the table to update!");
                return;
            }

            if (typetxt.Text == "" || nametxt.Text == "" || contacttxt.Text == "" ||
                emailtxt.Text == "" || addresstxt.Text == "")
            {
                MessageBox.Show("Please fill in all fields!");
                return;
            }
            if (!Program.IsValidName(nametxt.Text, out string nameError))
            {
                MessageBox.Show(nameError);
                return;
            }

            if (!Program.IsValidPhone(contacttxt.Text, out string phoneError))
            {
                MessageBox.Show(phoneError);
                return;
            }

            if (!Program.IsValidEmail(emailtxt.Text, out string emailError))
            {
                MessageBox.Show(emailError);
                return;
            }



            try
            {
                SqlConnection conn = new SqlConnection(frmDashboard.connString);
                string query = "UPDATE tbl_customer SET type=@type, name=@name, contact=@contact, " +
                               "email=@email, address=@address WHERE id=@id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idtxt.Text);
                cmd.Parameters.AddWithValue("@type", typetxt.Text.Trim());
                cmd.Parameters.AddWithValue("@name", nametxt.Text.Trim());
                cmd.Parameters.AddWithValue("@contact", contacttxt.Text.Trim());
                cmd.Parameters.AddWithValue("@email", emailtxt.Text.Trim());
                cmd.Parameters.AddWithValue("@address", addresstxt.Text.Trim());

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

        private void deletebtn_Click(object sender, EventArgs e)
        {

            if (idtxt.Text == "")
            {
                MessageBox.Show("Please select a user from the table to delete!");
                return;
            }

            try
            {
                SqlConnection conn = new SqlConnection(frmDashboard.connString);
                string query = "DELETE FROM tbl_customer WHERE id=@id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idtxt.Text);

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


        private void ClearFields()
        {
            idtxt.Clear();
            typetxt.SelectedIndex = -1;
            nametxt.Clear();
            emailtxt.Clear();
            contacttxt.Clear();
            addresstxt.Clear();

        }

        private void contacttxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchbtn_Click(object sender, EventArgs e)
        {

        }
    }

}

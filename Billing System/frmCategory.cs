using System.Data;
using Microsoft.Data.SqlClient;

namespace Billing_System
{
    public partial class frmCategory : Form
    {
        public frmCategory()
        {
            InitializeComponent();
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            LoadCategories();
        }

        private void LoadCategories()
        {
            try
            {
                SqlConnection conn = new SqlConnection(frmDashboard.connString);
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT category_id AS [Category ID], title AS [Title], description AS [Description] FROM tbl_categories", conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvCategories.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text == "")
            {
                MessageBox.Show("Please enter the Category Title!");
                return;
            }

            try
            {
                SqlConnection conn = new SqlConnection(frmDashboard.connString);
                string query = "INSERT INTO tbl_categories (title, description) VALUES (@title, @description)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@title", txtTitle.Text.Trim());
                cmd.Parameters.AddWithValue("@description", txtDescription.Text.Trim());

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Category added successfully!");
                LoadCategories();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding category: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtCategoryId.Text == "")
            {
                MessageBox.Show("Please select a category to update!");
                return;
            }

            try
            {
                SqlConnection conn = new SqlConnection(frmDashboard.connString);
                string query = "UPDATE tbl_categories SET title=@title, description=@description WHERE category_id=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", txtCategoryId.Text);
                cmd.Parameters.AddWithValue("@title", txtTitle.Text.Trim());
                cmd.Parameters.AddWithValue("@description", txtDescription.Text.Trim());

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Category updated successfully!");
                LoadCategories();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating category: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtCategoryId.Text == "")
            {
                MessageBox.Show("Please select a category to delete!");
                return;
            }

            try
            {
                SqlConnection conn = new SqlConnection(frmDashboard.connString);
                string query = "DELETE FROM tbl_categories WHERE category_id=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", txtCategoryId.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Category deleted successfully!");
                LoadCategories();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting category: " + ex.Message);
            }
        }

        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.RowIndex >= dgvCategories.Rows.Count) return;
            DataGridViewRow row = dgvCategories.Rows[e.RowIndex];

            txtCategoryId.Text = row.Cells[0].Value.ToString();
            txtTitle.Text = row.Cells[1].Value.ToString();
            txtDescription.Text = row.Cells[2].Value.ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchCategory();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchCategory();
        }

        private void SearchCategory()
        {
            try
            {
                SqlConnection conn = new SqlConnection(frmDashboard.connString);
                string query = "SELECT * FROM tbl_categories WHERE category_id LIKE '%" + txtSearch.Text + "%'";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvCategories.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching: " + ex.Message);
            }
        }

        private void ClearFields()
        {
            txtCategoryId.Clear();
            txtTitle.Clear();
            txtDescription.Clear();
        }

        private void lblHeader_Click(object sender, EventArgs e)
        {

        }

        private void dgvCategories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

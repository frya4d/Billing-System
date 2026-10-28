using System.Data;
using Microsoft.Data.SqlClient;

namespace Billing_System
{
    public partial class frmProducts : Form
    {
        public frmProducts()
        {
            InitializeComponent();
        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadCategories();

            txtAddedDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            txtAddedBy.Text = frmDashboard.LoggedInUser;
        }

        private void frmProducts_Activated(object sender, EventArgs e)
        {
            LoadCategories();
        }

        private void cmbCategory_DropDown(object sender, EventArgs e)
        {
            LoadCategories();
        }

        private void LoadCategories()
        {
            string currentSelection = cmbCategory.Text;
            cmbCategory.Items.Clear();

            try
            {
                SqlConnection conn = new SqlConnection(frmDashboard.connString);
                SqlCommand cmd = new SqlCommand("SELECT title FROM tbl_categories", conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string title = reader["title"]?.ToString() ?? "";
                    if (title != "")
                    {
                        cmbCategory.Items.Add(title);
                    }
                }
                conn.Close();

                if (cmbCategory.Items.Contains(currentSelection))
                {
                    cmbCategory.Text = currentSelection;
                }
                else if (cmbCategory.Items.Count > 0)
                {
                    cmbCategory.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message);
            }
        }

        private void LoadProducts()
        {
            try
            {
                SqlConnection conn = new SqlConnection(frmDashboard.connString);
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT product_id AS [ID], name AS [Name], category AS [Category], description AS [Description], quantity AS [Quantity], added_date AS [Added Date], added_by AS [Added By] FROM tbl_products", conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvProducts.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || cmbCategory.Text == "" || txtQuantity.Text == "")
            {
                MessageBox.Show("Please enter Name, Category, and Quantity!");
                return;
            }

            try
            {
                SqlConnection conn = new SqlConnection(frmDashboard.connString);
                string query = "INSERT INTO tbl_products (name, category, description, quantity, added_date, added_by) " +
                               "VALUES (@name, @category, @description, @quantity, @added_date, @added_by)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@category", cmbCategory.Text);
                cmd.Parameters.AddWithValue("@description", txtDescription.Text.Trim());
                cmd.Parameters.AddWithValue("@quantity", txtQuantity.Text.Trim());
                cmd.Parameters.AddWithValue("@added_date", txtAddedDate.Text);
                cmd.Parameters.AddWithValue("@added_by", txtAddedBy.Text.Trim());

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Product added successfully!");
                LoadProducts();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding product: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Please select a product from the table to update!");
                return;
            }

            try
            {
                SqlConnection conn = new SqlConnection(frmDashboard.connString);
                string query = "UPDATE tbl_products SET name=@name, category=@category, description=@description, " +
                               "quantity=@quantity, added_date=@added_date, added_by=@added_by WHERE product_id=@id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", txtId.Text);
                cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@category", cmbCategory.Text);
                cmd.Parameters.AddWithValue("@description", txtDescription.Text.Trim());
                cmd.Parameters.AddWithValue("@quantity", txtQuantity.Text.Trim());
                cmd.Parameters.AddWithValue("@added_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@added_by", txtAddedBy.Text.Trim());

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Product updated successfully!");
                LoadProducts();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating product: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Please select a product from the table to delete!");
                return;
            }

            try
            {
                SqlConnection conn = new SqlConnection(frmDashboard.connString);
                string query = "DELETE FROM tbl_products WHERE product_id=@id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", txtId.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Product deleted successfully!");
                LoadProducts();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting product: " + ex.Message);
            }
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.RowIndex >= dgvProducts.Rows.Count) return;
            DataGridViewRow row = dgvProducts.Rows[e.RowIndex];

            txtId.Text = row.Cells[0].Value.ToString();
            txtName.Text = row.Cells[1].Value.ToString();
            cmbCategory.Text = row.Cells[2].Value.ToString();
            txtDescription.Text = row.Cells[3].Value.ToString();
            txtQuantity.Text = row.Cells[4].Value.ToString();
            txtAddedDate.Text = row.Cells[5].Value.ToString();
            txtAddedBy.Text = row.Cells[6].Value.ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchProductById();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchProductById();
        }

        private void SearchProductById()
        {
            try
            {
                SqlConnection conn = new SqlConnection(frmDashboard.connString);
                string query = "SELECT * FROM tbl_products WHERE product_id LIKE '%" + txtSearch.Text + "%'";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvProducts.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching: " + ex.Message);
            }
        }

        private void ClearFields()
        {
            txtId.Clear();
            txtName.Clear();
            if (cmbCategory.Items.Count > 0) cmbCategory.SelectedIndex = 0;
            txtDescription.Clear();
            txtQuantity.Clear();
            txtAddedDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            txtAddedBy.Text = frmDashboard.LoggedInUser;
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

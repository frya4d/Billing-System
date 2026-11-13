using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Billing_System
{
    public partial class frmPurchases : Form
    {
        private int selectedCustomerId = 0;
        private bool isClearing = false;

        public frmPurchases()
        {
            InitializeComponent();
            SetupForm();
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(frmDashboard.connString);
        }

        private void SetupForm()
        {
            if (dgvProducts.Columns.Count == 0)
            {
                dgvProducts.Columns.Add("ProductID", "Product ID");
                dgvProducts.Columns.Add("ProductName", "Name");
                dgvProducts.Columns.Add("Category", "Category");
                dgvProducts.Columns.Add("Price", "Price");
                dgvProducts.Columns.Add("Quantity", "Quantity");
                dgvProducts.Columns.Add("Total", "Total");
            }

            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.ReadOnly = true;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvProducts.KeyDown += dgvProducts_KeyDown;

            txtSubTotal.ReadOnly = true;
            txtTotal.ReadOnly = true;
            txtReturn.ReadOnly = true;
        }

        private void frmPurchases_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string phone = searchtxt.Text.Trim();
            if (string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("Please enter customer phone.");
                return;
            }

            try
            {
                using SqlConnection con = GetConnection();
                string query = "SELECT id, name, email, address FROM tbl_customer WHERE contact = @contact";
                using SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@contact", phone);

                con.Open();
                using SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    selectedCustomerId = Convert.ToInt32(dr["id"]);
                    nametxt.Text = dr["name"]?.ToString() ?? "";
                    emailtxt.Text = dr["email"]?.ToString() ?? "";
                    addresstxt.Text = dr["address"]?.ToString() ?? "";
                }
                else
                {
                    selectedCustomerId = 0;
                    nametxt.Clear();
                    emailtxt.Clear();
                    addresstxt.Clear();
                    MessageBox.Show("Customer Not Found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void idtxt_TextChanged(object sender, EventArgs e)
        {
            if (isClearing) return;

            if (!int.TryParse(idtxt.Text.Trim(), out int productId) || productId <= 0)
            {
                pnametxt.Clear();
                catetxt.Clear();
                pricetxt.Clear();
                return;
            }

            try
            {
                using SqlConnection con = GetConnection();
                string query = "SELECT name, category, price FROM tbl_products WHERE product_id = @product_id";
                using SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@product_id", productId);

                con.Open();
                using SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    pnametxt.Text = dr["name"]?.ToString() ?? "";
                    catetxt.Text = dr["category"]?.ToString() ?? "";
                    pricetxt.Text = dr["price"] != DBNull.Value ? dr["price"].ToString() : "";
                }
                else
                {
                    pnametxt.Clear();
                    catetxt.Clear();
                    pricetxt.Clear();
                }
            }
            catch
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(idtxt.Text.Trim(), out int productId) ||
                !int.TryParse(quantxt.Text.Trim(), out int quantity) ||
                quantity <= 0)
            {
                MessageBox.Show("Enter valid Product ID and Quantity.");
                return;
            }

            try
            {
                string name = "";
                string category = "";
                decimal price = 0;
                int stock = 0;
                bool found = false;

                using (SqlConnection con = GetConnection())
                {
                    string query = "SELECT name, category, price, quantity FROM tbl_products WHERE product_id = @product_id";
                    using SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@product_id", productId);

                    con.Open();
                    using SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        found = true;
                        name = dr["name"]?.ToString() ?? "";
                        category = dr["category"]?.ToString() ?? "";
                        decimal.TryParse(dr["price"]?.ToString(), out price);
                        int.TryParse(dr["quantity"]?.ToString(), out stock);
                    }
                }

                if (!found)
                {
                    MessageBox.Show("Product Not Found!");
                    return;
                }

                if (quantity > stock)
                {
                    MessageBox.Show("Not Enough Stock!");
                    return;
                }

                foreach (DataGridViewRow row in dgvProducts.Rows)
                {
                    if (row.IsNewRow) continue;

                    if (Convert.ToInt32(row.Cells["ProductID"].Value) == productId)
                    {
                        int currentQty = Convert.ToInt32(row.Cells["Quantity"].Value);
                        if (currentQty + quantity > stock)
                        {
                            MessageBox.Show("Not Enough Stock!");
                            return;
                        }

                        int newQty = currentQty + quantity;
                        row.Cells["Quantity"].Value = newQty;
                        row.Cells["Total"].Value = price * newQty;

                        CalculateTotal();
                        ClearProductFields();
                        return;
                    }
                }

                decimal total = price * quantity;
                dgvProducts.Rows.Add(productId, name, category, price, quantity, total);

                CalculateTotal();
                ClearProductFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnRemove_Click(object? sender, EventArgs e)
        {
            RemoveSelectedProduct();
        }

        private void dgvProducts_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveSelectedProduct();
            }
        }

        private void RemoveSelectedProduct()
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvProducts.SelectedRows)
                {
                    if (!row.IsNewRow)
                    {
                        dgvProducts.Rows.Remove(row);
                    }
                }
                CalculateTotal();
            }
            else
            {
                MessageBox.Show("Please select a product.");
            }
        }

        private void CalculateTotal()
        {
            if (isClearing) return;

            decimal subTotal = 0;
            foreach (DataGridViewRow row in dgvProducts.Rows)
            {
                if (row.IsNewRow) continue;
                subTotal += Convert.ToDecimal(row.Cells["Total"].Value);
            }

            decimal.TryParse(txtDiscount.Text, out decimal discount);
            decimal.TryParse(txtPaid.Text, out decimal paid);

            if (discount < 0) discount = 0;
            if (discount > 100) discount = 100;

            decimal total = subTotal - (subTotal * discount / 100);
            decimal returnAmount = paid - total;

            txtSubTotal.Text = subTotal.ToString("0.00");
            txtTotal.Text = total.ToString("0.00");
            txtReturn.Text = returnAmount.ToString("0.00");
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void txtPaid_TextChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (selectedCustomerId <= 0)
            {
                MessageBox.Show("Please search and select a customer.");
                return;
            }

            if (dgvProducts.Rows.Count == 0)
            {
                MessageBox.Show("Please add products first.");
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtDiscount.Text) && !decimal.TryParse(txtDiscount.Text, out _))
            {
                MessageBox.Show("Enter a valid Discount %.");
                return;
            }

            if (!decimal.TryParse(txtPaid.Text, out decimal paid))
            {
                MessageBox.Show("Enter a valid Paid Amount.");
                return;
            }

            decimal.TryParse(txtDiscount.Text, out decimal discount);
            if (discount < 0 || discount > 100)
            {
                MessageBox.Show("Discount must be between 0 and 100.");
                return;
            }

            decimal subTotal = 0;
            foreach (DataGridViewRow row in dgvProducts.Rows)
            {
                if (!row.IsNewRow)
                    subTotal += Convert.ToDecimal(row.Cells["Total"].Value);
            }

            decimal total = subTotal - (subTotal * discount / 100);
            decimal returnAmount = paid - total;

            if (paid < total)
            {
                MessageBox.Show("Paid Amount is less than Total.");
                return;
            }

            using SqlConnection con = GetConnection();
            SqlTransaction? transaction = null;

            try
            {
                con.Open();
                transaction = con.BeginTransaction();

                object addedByValue = DBNull.Value;
                if (frmDashboard.LoggedInUserId > 0)
                {
                    addedByValue = frmDashboard.LoggedInUserId;
                }
                else if (!string.IsNullOrWhiteSpace(frmDashboard.LoggedInUser))
                {
                    string userQuery = "SELECT TOP 1 id FROM tbl_users WHERE username = @username";
                    using SqlCommand userCmd = new SqlCommand(userQuery, con, transaction);
                    userCmd.Parameters.AddWithValue("@username", frmDashboard.LoggedInUser.Trim());
                    object? result = userCmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        addedByValue = Convert.ToInt32(result);
                    }
                }

                string query = @"
                    INSERT INTO [Transaction]
                    (CustomerID, SubTotal, DiscountPercent, Total, PaidAmount, ReturnAmount, AddedDate, AddedBy)
                    OUTPUT INSERTED.TransactionID
                    VALUES
                    (@CustomerID, @SubTotal, @Discount, @Total, @Paid, @Return, @Date, @AddedBy)";

                using SqlCommand cmd = new SqlCommand(query, con, transaction);
                cmd.Parameters.AddWithValue("@CustomerID", selectedCustomerId);
                cmd.Parameters.AddWithValue("@SubTotal", subTotal);
                cmd.Parameters.AddWithValue("@Discount", discount);
                cmd.Parameters.AddWithValue("@Total", total);
                cmd.Parameters.AddWithValue("@Paid", paid);
                cmd.Parameters.AddWithValue("@Return", returnAmount);
                cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                cmd.Parameters.AddWithValue("@AddedBy", addedByValue);

                int transactionId = Convert.ToInt32(cmd.ExecuteScalar());

                string updateStock = @"
                    UPDATE tbl_products
                    SET quantity = CAST(TRY_CAST(quantity AS INT) - @Quantity AS NVARCHAR(50))
                    WHERE product_id = @ProductID
                    AND TRY_CAST(quantity AS INT) >= @Quantity";

                string detailQuery = @"
                    INSERT INTO TransactionDetails (TransactionID, ProductID, Price, Quantity, Total)
                    VALUES (@TransactionID, @ProductID, @Price, @Quantity, @Total)";

                using SqlCommand stockCmd = new SqlCommand(updateStock, con, transaction);
                stockCmd.Parameters.Add("@Quantity", SqlDbType.Int);
                stockCmd.Parameters.Add("@ProductID", SqlDbType.Int);

                using SqlCommand detailCmd = new SqlCommand(detailQuery, con, transaction);
                detailCmd.Parameters.AddWithValue("@TransactionID", transactionId);
                detailCmd.Parameters.Add("@ProductID", SqlDbType.Int);
                detailCmd.Parameters.Add("@Price", SqlDbType.Decimal);
                detailCmd.Parameters.Add("@Quantity", SqlDbType.Int);
                detailCmd.Parameters.Add("@Total", SqlDbType.Decimal);

                foreach (DataGridViewRow row in dgvProducts.Rows)
                {
                    if (row.IsNewRow) continue;

                    int productId = Convert.ToInt32(row.Cells["ProductID"].Value);
                    int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                    decimal price = Convert.ToDecimal(row.Cells["Price"].Value);
                    decimal productTotal = price * quantity;

                    stockCmd.Parameters["@Quantity"].Value = quantity;
                    stockCmd.Parameters["@ProductID"].Value = productId;
                    int affected = stockCmd.ExecuteNonQuery();

                    if (affected == 0)
                    {
                        throw new Exception("Product stock changed or insufficient. Please try again.");
                    }

                    detailCmd.Parameters["@ProductID"].Value = productId;
                    detailCmd.Parameters["@Price"].Value = price;
                    detailCmd.Parameters["@Quantity"].Value = quantity;
                    detailCmd.Parameters["@Total"].Value = productTotal;
                    detailCmd.ExecuteNonQuery();
                }

                transaction.Commit();

                MessageBox.Show(
                    "Transaction Saved Successfully!\nTransaction ID: " + transactionId,
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ClearForm();
            }
            catch (Exception ex)
            {
                transaction?.Rollback();

                MessageBox.Show(
                    "Error: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ClearProductFields()
        {
            idtxt.Clear();
            pnametxt.Clear();
            catetxt.Clear();
            pricetxt.Clear();
            quantxt.Clear();
        }

        private void ClearForm()
        {
            isClearing = true;
            try
            {
                selectedCustomerId = 0;

                searchtxt.Clear();
                nametxt.Clear();
                emailtxt.Clear();
                addresstxt.Clear();

                ClearProductFields();

                txtSubTotal.Clear();
                txtDiscount.Clear();
                txtTotal.Clear();
                txtPaid.Clear();
                txtReturn.Clear();

                dgvProducts.Rows.Clear();
            }
            finally
            {
                isClearing = false;
            }
        }
    }
}

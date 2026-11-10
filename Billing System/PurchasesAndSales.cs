using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Billing_System
{
    public partial class PurchasesAndSales : Form
    {
        private int selectedCustomerId = 0;
        private bool isClearing = false;

        public PurchasesAndSales()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(frmDashboard.connString);
        }

        private void InitializeDataGridView()
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
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchtxt.Text))
            {
                MessageBox.Show("Please enter customer phone.");
                return;
            }

            try
            {
                using (SqlConnection con = GetConnection())
                {
                    string query = @"
                        SELECT id, name, email, address
                        FROM tbl_customer
                        WHERE contact = @contact";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@contact", searchtxt.Text.Trim());

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int productId;
            int quantity;

            if (!int.TryParse(idtxt.Text.Trim(), out productId) ||
                !int.TryParse(quantxt.Text.Trim(), out quantity) ||
                quantity <= 0)
            {
                MessageBox.Show("Enter valid Product ID and Quantity.");
                return;
            }

            try
            {
                using (SqlConnection con = GetConnection())
                {
                    string query = @"
                        SELECT product_id, name, category, price, quantity
                        FROM tbl_products
                        WHERE product_id = @product_id";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@product_id", productId);

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (!dr.Read())
                        {
                            MessageBox.Show("Product Not Found!");
                            return;
                        }

                        int stock = dr["quantity"] != DBNull.Value && int.TryParse(dr["quantity"].ToString(), out int parsedStock)
                            ? parsedStock
                            : 0;

                        decimal price = dr["price"] != DBNull.Value && decimal.TryParse(dr["price"].ToString(), out decimal parsedPrice)
                            ? parsedPrice
                            : 0m;

                        if (quantity > stock)
                        {
                            MessageBox.Show("Not Enough Stock!");
                            return;
                        }

                        // Check duplicate product
                        foreach (DataGridViewRow row in dgvProducts.Rows)
                        {
                            if (row.IsNewRow) continue;

                            if (Convert.ToInt32(row.Cells["ProductID"].Value) == productId)
                            {
                                int oldQuantity = Convert.ToInt32(row.Cells["Quantity"].Value);

                                if (oldQuantity + quantity > stock)
                                {
                                    MessageBox.Show("Not Enough Stock!");
                                    return;
                                }

                                int newQuantity = oldQuantity + quantity;

                                row.Cells["Quantity"].Value = newQuantity;
                                row.Cells["Total"].Value = price * newQuantity;

                                CalculateTotal();
                                ClearProductFields();
                                return;
                            }
                        }

                        decimal total = price * quantity;

                        dgvProducts.Rows.Add(
                            dr["product_id"],
                            dr["name"],
                            dr["category"],
                            price,
                            quantity,
                            total
                        );
                    }
                }

                CalculateTotal();
                ClearProductFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void CalculateTotal()
        {
            if (isClearing) return;

            decimal subTotal = 0;

            foreach (DataGridViewRow row in dgvProducts.Rows)
            {
                if (row.IsNewRow) continue;
                subTotal += Convert.ToDecimal(row.Cells["Total"].Value);
            }

            decimal discount = 0;
            decimal paid = 0;

            decimal.TryParse(txtDiscount.Text, out discount);
            decimal.TryParse(txtPaid.Text, out paid);

            if (discount < 0)
                discount = 0;

            if (discount > 100)
                discount = 100;

            decimal total = subTotal - (subTotal * discount / 100);
            decimal returnAmount = paid - total;

            txtSubTotal.Text = subTotal.ToString("0.00");
            txtTotal.Text = total.ToString("0.00");
            txtReturn.Text = returnAmount.ToString("0.00");
        }

        private void btnRemove_Click(object sender, EventArgs e)
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

            decimal discount = 0;
            if (!string.IsNullOrWhiteSpace(txtDiscount.Text) && !decimal.TryParse(txtDiscount.Text, out discount))
            {
                MessageBox.Show("Enter a valid Discount %.");
                return;
            }

            decimal paid;
            if (!decimal.TryParse(txtPaid.Text, out paid))
            {
                MessageBox.Show("Enter a valid Paid Amount.");
                return;
            }

            if (discount < 0 || discount > 100)
            {
                MessageBox.Show("Discount must be between 0 and 100.");
                return;
            }

            CalculateTotal();

            decimal total = Convert.ToDecimal(txtTotal.Text);

            if (paid < total)
            {
                MessageBox.Show("Paid Amount is less than Total.");
                return;
            }

            using (SqlConnection con = GetConnection())
            {
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
                        using (SqlCommand userCmd = new SqlCommand(userQuery, con, transaction))
                        {
                            userCmd.Parameters.AddWithValue("@username", frmDashboard.LoggedInUser.Trim());
                            object result = userCmd.ExecuteScalar();
                            if (result != null && result != DBNull.Value)
                            {
                                addedByValue = Convert.ToInt32(result);
                            }
                        }
                    }

                    // Insert Transaction
                    string query = @"
                        INSERT INTO [Transaction]
                        (CustomerID, SubTotal, DiscountPercent,
                         Total, PaidAmount, ReturnAmount,
                         AddedDate, AddedBy)

                        OUTPUT INSERTED.TransactionID

                        VALUES
                        (@CustomerID, @SubTotal, @Discount,
                         @Total, @Paid, @Return,
                         @Date, @AddedBy)";

                    SqlCommand cmd = new SqlCommand(query, con, transaction);
                    cmd.Parameters.AddWithValue("@CustomerID", selectedCustomerId);
                    cmd.Parameters.AddWithValue("@SubTotal", Convert.ToDecimal(txtSubTotal.Text));
                    cmd.Parameters.AddWithValue("@Discount", discount);
                    cmd.Parameters.AddWithValue("@Total", total);
                    cmd.Parameters.AddWithValue("@Paid", paid);
                    cmd.Parameters.AddWithValue("@Return", paid - total);
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@AddedBy", addedByValue);

                    int transactionId = Convert.ToInt32(cmd.ExecuteScalar());

                    foreach (DataGridViewRow row in dgvProducts.Rows)
                    {
                        if (row.IsNewRow) continue;

                        int productId = Convert.ToInt32(row.Cells["ProductID"].Value);
                        int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                        decimal price = Convert.ToDecimal(row.Cells["Price"].Value);
                        decimal productTotal = price * quantity;

                        // Reduce Product Stock
                        string updateStock = @"
                            UPDATE tbl_products
                            SET quantity = CAST(TRY_CAST(quantity AS INT) - @Quantity AS NVARCHAR(50))
                            WHERE product_id = @ProductID
                            AND TRY_CAST(quantity AS INT) >= @Quantity";

                        SqlCommand stockCmd = new SqlCommand(updateStock, con, transaction);
                        stockCmd.Parameters.AddWithValue("@Quantity", quantity);
                        stockCmd.Parameters.AddWithValue("@ProductID", productId);

                        int affected = stockCmd.ExecuteNonQuery();

                        if (affected == 0)
                        {
                            throw new Exception("Product stock changed. Please try again.");
                        }

                        // Save Product Details
                        string detailQuery = @"
                            INSERT INTO TransactionDetails
                            (TransactionID, ProductID, Price,
                             Quantity, Total)

                            VALUES
                            (@TransactionID, @ProductID, @Price,
                             @Quantity, @Total)";

                        SqlCommand detailCmd = new SqlCommand(detailQuery, con, transaction);
                        detailCmd.Parameters.AddWithValue("@TransactionID", transactionId);
                        detailCmd.Parameters.AddWithValue("@ProductID", productId);
                        detailCmd.Parameters.AddWithValue("@Price", price);
                        detailCmd.Parameters.AddWithValue("@Quantity", quantity);
                        detailCmd.Parameters.AddWithValue("@Total", productTotal);

                        detailCmd.ExecuteNonQuery();
                    }

                    // Commit
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
                    if (transaction != null)
                        transaction.Rollback();

                    MessageBox.Show(
                        "Error: " + ex.Message,
                        "Database Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
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

        private void PurchasesAndSales_Load(object sender, EventArgs e)
        {
            InitializeDataGridView();
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
                using (SqlConnection con = GetConnection())
                {
                    string query = @"
                        SELECT name, category, price
                        FROM tbl_products
                        WHERE product_id = @product_id";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@product_id", productId);

                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
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
                }
            }
            catch
            {
                // Ignore transient lookup issues while typing
            }
        }

        private void nametxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void txtPaid_TextChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }
    }
}

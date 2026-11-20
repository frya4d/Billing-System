using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Billing_System
{
    public partial class frmPurchases : Form
    {
        // بۆ هەڵگرتنی ئایدی ئەو کڕیارەی کە سێرچمان کردووە
        private int selectedCustomerId = 0;

        public frmPurchases()
        {
            InitializeComponent();
        }

        private void frmPurchases_Load(object sender, EventArgs e)
        {
            // دروستکردنی ستوونەکانی خشتەی کاڵاکان
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

        // ==============================================================
        // دوگمەی سێرچکردنی کڕیار بەپێی ژمارەی مۆبایل (Search Customer)
        // ==============================================================
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
                SqlConnection conn = new SqlConnection(Program.connString);
                string query = "SELECT id, name, email, address FROM tbl_customer WHERE contact = @contact";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@contact", phone);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    selectedCustomerId = Convert.ToInt32(dr["id"]);
                    nametxt.Text = dr["name"].ToString();
                    emailtxt.Text = dr["email"].ToString();
                    addresstxt.Text = dr["address"].ToString();
                }
                else
                {
                    selectedCustomerId = 0;
                    nametxt.Clear();
                    emailtxt.Clear();
                    addresstxt.Clear();
                    MessageBox.Show("Customer Not Found!");
                }

                dr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // ==============================================================
        // کاتێک ئایدی بەرهەم دەنووسرێت، زانیارییەکان لە داتابەیس دەهێنێت
        // ==============================================================
        private void idtxt_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(idtxt.Text))
            {
                pnametxt.Clear();
                catetxt.Clear();
                pricetxt.Clear();
                return;
            }

            try
            {
                SqlConnection conn = new SqlConnection(Program.connString);
                string query = "SELECT name, category, price FROM tbl_products WHERE product_id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idtxt.Text.Trim());

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    pnametxt.Text = dr["name"].ToString();
                    catetxt.Text = dr["category"].ToString();
                    pricetxt.Text = dr["price"].ToString();
                }
                else
                {
                    pnametxt.Clear();
                    catetxt.Clear();
                    pricetxt.Clear();
                }

                dr.Close();
                conn.Close();
            }
            catch
            {
                // ئەگەر نووسینەکە لە ژمارە نەچوو، هیچ ناکات
            }
        }

        // ==============================================================
        // دوگمەی زیادکردنی بەرهەم بۆ ناو خشتەکە (Add Product to Grid)
        // ==============================================================
        private void button2_Click(object sender, EventArgs e)
        {
            // پشکنینی ئەوەی کە ئایدی و بڕ پڕکراونەتەوە و دروستن
            if (!int.TryParse(idtxt.Text.Trim(), out int productId) ||
                !int.TryParse(quantxt.Text.Trim(), out int quantity) ||
                quantity <= 0)
            {
                MessageBox.Show("Enter valid Product ID and Quantity.");
                return;
            }

            try
            {
                SqlConnection conn = new SqlConnection(Program.connString);
                string query = "SELECT name, category, price, quantity FROM tbl_products WHERE product_id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", productId);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (!dr.Read())
                {
                    MessageBox.Show("Product Not Found!");
                    dr.Close();
                    conn.Close();
                    return;
                }

                string name = dr["name"]?.ToString() ?? "";
                string category = dr["category"]?.ToString() ?? "";
                decimal price = Convert.ToDecimal(dr["price"]);
                int stock = Convert.ToInt32(dr["quantity"]);

                dr.Close();
                conn.Close();

                // پشکنینی بڕی بەردەست لە مەخزەن
                if (quantity > stock)
                {
                    MessageBox.Show("Not Enough Stock!");
                    return;
                }

                // ئەگەر کاڵاکە پێشتر لەناو خشتەکەدا هەبێت، بڕەکەی زیاد بکە
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

                // ئەگەر نوێ بوو، زیادی بکە بۆ خشتەکە
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

        // ==============================================================
        // سڕینەوەی بەرهەم لە خشتەکە بە دوگمەی Delete
        // ==============================================================
        private void dgvProducts_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && dgvProducts.SelectedRows.Count > 0)
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
        }

        // ==============================================================
        // ژماردنی کۆی گشتی و داشکاندن و پارەی گەڕاوە (Calculate Total)
        // ==============================================================
        private void CalculateTotal()
        {
            decimal subTotal = 0;

            foreach (DataGridViewRow row in dgvProducts.Rows)
            {
                if (row.IsNewRow) continue;
                subTotal += Convert.ToDecimal(row.Cells["Total"].Value);
            }

            decimal discount = 0;
            decimal.TryParse(txtDiscount.Text, out discount);

            if (discount < 0) discount = 0;
            if (discount > 100) discount = 100;

            decimal total = subTotal - (subTotal * discount / 100);

            decimal paid = 0;
            decimal.TryParse(txtPaid.Text, out paid);

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

        // ==============================================================
        // دوگمەی سەیڤکردنی پسووڵە/فرۆشتن (Save Transaction)
        // ==============================================================
        private void button3_Click(object sender, EventArgs e)
        {
            // ١. پشکنینی ئەوەی کڕیار دیاریکراوە
            if (selectedCustomerId <= 0)
            {
                MessageBox.Show("Please search and select a customer.");
                return;
            }

            // ٢. پشکنینی ئەوەی کاڵا لە خشتەکەدا هەیە
            if (dgvProducts.Rows.Count == 0)
            {
                MessageBox.Show("Please add products first.");
                return;
            }

            // ٣. پشکنینی پارەی دراو
            if (!decimal.TryParse(txtPaid.Text, out decimal paid))
            {
                MessageBox.Show("Enter a valid Paid Amount.");
                return;
            }

            decimal discount = 0;
            decimal.TryParse(txtDiscount.Text, out discount);
            if (discount < 0 || discount > 100)
            {
                MessageBox.Show("Discount must be between 0 and 100.");
                return;
            }

            decimal subTotal = 0;
            foreach (DataGridViewRow row in dgvProducts.Rows)
            {
                if (!row.IsNewRow)
                {
                    subTotal += Convert.ToDecimal(row.Cells["Total"].Value);
                }
            }

            decimal total = subTotal - (subTotal * discount / 100);
            decimal returnAmount = paid - total;

            if (paid < total)
            {
                MessageBox.Show("Paid Amount is less than Total.");
                return;
            }

            // ٤. دەستپێکردنی سەیڤکردن لە داتابەیس بە Transaction
            SqlConnection conn = new SqlConnection(Program.connString);
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();

            try
            {
                // ئەوەی کێ بەکارهێنەرە تۆمارکراوە
                int addedBy = frmDashboard.LoggedInUserId;

                // أ- سەیڤکردنی زانیارییە سەرەکییەکانی پسووڵە
                string transQuery = "INSERT INTO [Transaction] (CustomerID, SubTotal, DiscountPercent, Total, PaidAmount, ReturnAmount, AddedDate, AddedBy) " +
                                    "VALUES (@cid, @subtotal, @discount, @total, @paid, @return, @date, @addedBy); " +
                                    "SELECT SCOPE_IDENTITY();";

                SqlCommand cmd = new SqlCommand(transQuery, conn, trans);
                cmd.Parameters.AddWithValue("@cid", selectedCustomerId);
                cmd.Parameters.AddWithValue("@subtotal", subTotal);
                cmd.Parameters.AddWithValue("@discount", discount);
                cmd.Parameters.AddWithValue("@total", total);
                cmd.Parameters.AddWithValue("@paid", paid);
                cmd.Parameters.AddWithValue("@return", returnAmount);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.Parameters.AddWithValue("@addedBy", addedBy);

                int transactionId = Convert.ToInt32(cmd.ExecuteScalar());

                // ب- سەیڤکردنی وردەکاری هەر کاڵایەک و کەمکردنەوەی لە مەخزەن
                foreach (DataGridViewRow row in dgvProducts.Rows)
                {
                    if (row.IsNewRow) continue;

                    int productId = Convert.ToInt32(row.Cells["ProductID"].Value);
                    int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                    decimal price = Convert.ToDecimal(row.Cells["Price"].Value);
                    decimal productTotal = Convert.ToDecimal(row.Cells["Total"].Value);

                    // کەمکردنەوەی لە مەخزەن (Update Stock)
                    string stockQuery = "UPDATE tbl_products SET quantity = CAST(quantity AS INT) - @qty WHERE product_id = @pid";
                    SqlCommand stockCmd = new SqlCommand(stockQuery, conn, trans);
                    stockCmd.Parameters.AddWithValue("@qty", quantity);
                    stockCmd.Parameters.AddWithValue("@pid", productId);
                    stockCmd.ExecuteNonQuery();

                    // زیادکردنی وردەکاری بۆ خشتەی TransactionDetails
                    string detailQuery = "INSERT INTO TransactionDetails (TransactionID, ProductID, Price, Quantity, Total) " +
                                         "VALUES (@tid, @pid, @price, @qty, @total)";
                    SqlCommand detailCmd = new SqlCommand(detailQuery, conn, trans);
                    detailCmd.Parameters.AddWithValue("@tid", transactionId);
                    detailCmd.Parameters.AddWithValue("@pid", productId);
                    detailCmd.Parameters.AddWithValue("@price", price);
                    detailCmd.Parameters.AddWithValue("@qty", quantity);
                    detailCmd.Parameters.AddWithValue("@total", productTotal);
                    detailCmd.ExecuteNonQuery();
                }

                // سەیڤکردنی هەموو گۆڕانکارییەکان
                trans.Commit();

                MessageBox.Show("Transaction Saved Successfully!\nTransaction ID: " + transactionId);
                ClearForm();
            }
            catch (Exception ex)
            {
                // ئەگەر هەڵەیەک ڕوویدا هەمووی هەڵدەوەشێنێتەوە
                trans.Rollback();
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        // پاککردنەوەی خانەکانی کاڵا
        private void ClearProductFields()
        {
            idtxt.Clear();
            pnametxt.Clear();
            catetxt.Clear();
            pricetxt.Clear();
            quantxt.Clear();
        }

        // پاککردنەوەی تەواوی فۆڕمەکە دوای سەیڤکردن
        private void ClearForm()
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
    }
}

namespace Billing_System
{
    partial class frmProducts
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
            lblId = new Label();
            txtId = new TextBox();
            lblName = new Label();
            txtName = new TextBox();
            lblCategory = new Label();
            cmbCategory = new ComboBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            lblQuantity = new Label();
            txtQuantity = new TextBox();
            lblAddedDate = new Label();
            txtAddedDate = new TextBox();
            lblAddedBy = new Label();
            txtAddedBy = new TextBox();
            txtSearch = new TextBox();
            btnSearch = new Button();
            dgvProducts = new DataGridView();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            SuspendLayout();
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblId.Location = new Point(25, 25);
            lblId.Name = "lblId";
            lblId.Size = new Size(27, 21);
            lblId.TabIndex = 0;
            lblId.Text = "ID";
            // 
            // txtId
            // 
            txtId.Font = new Font("Segoe UI", 9.5F);
            txtId.Location = new Point(130, 22);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(185, 29);
            txtId.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblName.Location = new Point(25, 65);
            lblName.Name = "lblName";
            lblName.Size = new Size(56, 21);
            lblName.TabIndex = 2;
            lblName.Text = "Name";
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 9.5F);
            txtName.Location = new Point(130, 62);
            txtName.Name = "txtName";
            txtName.Size = new Size(185, 29);
            txtName.TabIndex = 3;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblCategory.Location = new Point(25, 105);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(80, 21);
            lblCategory.TabIndex = 4;
            lblCategory.Text = "Category";
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.Font = new Font("Segoe UI", 9.5F);
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(130, 102);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(185, 29);
            cmbCategory.TabIndex = 5;
            cmbCategory.DropDown += cmbCategory_DropDown;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblDescription.Location = new Point(25, 145);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(98, 21);
            lblDescription.TabIndex = 6;
            lblDescription.Text = "Description";
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 9.5F);
            txtDescription.Location = new Point(130, 142);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(185, 75);
            txtDescription.TabIndex = 7;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblQuantity.Location = new Point(25, 230);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(77, 21);
            lblQuantity.TabIndex = 8;
            lblQuantity.Text = "Quantity";
            // 
            // txtQuantity
            // 
            txtQuantity.Font = new Font("Segoe UI", 9.5F);
            txtQuantity.Location = new Point(130, 227);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(185, 29);
            txtQuantity.TabIndex = 9;
            // 
            // lblAddedDate
            // 
            lblAddedDate.AutoSize = true;
            lblAddedDate.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblAddedDate.Location = new Point(25, 270);
            lblAddedDate.Name = "lblAddedDate";
            lblAddedDate.Size = new Size(100, 21);
            lblAddedDate.TabIndex = 10;
            lblAddedDate.Text = "Added Date";
            // 
            // txtAddedDate
            // 
            txtAddedDate.Font = new Font("Segoe UI", 9.5F);
            txtAddedDate.Location = new Point(130, 267);
            txtAddedDate.Name = "txtAddedDate";
            txtAddedDate.ReadOnly = true;
            txtAddedDate.Size = new Size(185, 29);
            txtAddedDate.TabIndex = 11;
            // 
            // lblAddedBy
            // 
            lblAddedBy.AutoSize = true;
            lblAddedBy.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblAddedBy.Location = new Point(25, 310);
            lblAddedBy.Name = "lblAddedBy";
            lblAddedBy.Size = new Size(83, 21);
            lblAddedBy.TabIndex = 12;
            lblAddedBy.Text = "Added By";
            // 
            // txtAddedBy
            // 
            txtAddedBy.Font = new Font("Segoe UI", 9.5F);
            txtAddedBy.Location = new Point(130, 307);
            txtAddedBy.Name = "txtAddedBy";
            txtAddedBy.Size = new Size(185, 29);
            txtAddedBy.TabIndex = 13;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 9.5F);
            txtSearch.Location = new Point(345, 22);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(330, 29);
            txtSearch.TabIndex = 14;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSearch.Location = new Point(690, 20);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(110, 32);
            btnSearch.TabIndex = 15;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.BackgroundColor = Color.White;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(345, 62);
            dgvProducts.MultiSelect = false;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(455, 274);
            dgvProducts.TabIndex = 16;
            dgvProducts.CellClick += dgvProducts_CellClick;
            dgvProducts.CellContentClick += dgvProducts_CellContentClick;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnAdd.Location = new Point(410, 355);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(95, 38);
            btnAdd.TabIndex = 17;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnUpdate.Location = new Point(520, 355);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(95, 38);
            btnUpdate.TabIndex = 18;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnDelete.Location = new Point(630, 355);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(95, 38);
            btnDelete.TabIndex = 19;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // frmProducts
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(830, 415);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(dgvProducts);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(txtAddedBy);
            Controls.Add(lblAddedBy);
            Controls.Add(txtAddedDate);
            Controls.Add(lblAddedDate);
            Controls.Add(txtQuantity);
            Controls.Add(lblQuantity);
            Controls.Add(txtDescription);
            Controls.Add(lblDescription);
            Controls.Add(cmbCategory);
            Controls.Add(lblCategory);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Controls.Add(txtId);
            Controls.Add(lblId);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmProducts";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmProducts";
            Activated += frmProducts_Activated;
            Load += frmProducts_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblId;
        private TextBox txtId;
        private Label lblName;
        private TextBox txtName;
        private Label lblCategory;
        private ComboBox cmbCategory;
        private Label lblDescription;
        private TextBox txtDescription;
        private Label lblQuantity;
        private TextBox txtQuantity;
        private Label lblAddedDate;
        private TextBox txtAddedDate;
        private Label lblAddedBy;
        private TextBox txtAddedBy;
        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridView dgvProducts;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
    }
}

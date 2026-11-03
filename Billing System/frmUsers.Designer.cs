namespace Billing_System
{
    partial class frmUsers
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
            pnlHeader = new Panel();
            lblHeaderTitle = new Label();
            lblClose = new Label();
            lblUserId = new Label();
            txtUserId = new TextBox();
            lblFirstName = new Label();
            txtFirstName = new TextBox();
            lblLastName = new Label();
            txtLastName = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblUserName = new Label();
            txtUserName = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblConfirmPassword = new Label();
            txtConfirmPassword = new TextBox();
            lblContact = new Label();
            txtContact = new TextBox();
            lblGender = new Label();
            cmbGender = new ComboBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            lblUserType = new Label();
            cmbUserType = new ComboBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            lblSearch = new Label();
            txtSearch = new TextBox();
            dgvUsers = new DataGridView();
            colUserId = new DataGridViewTextBoxColumn();
            colFirstName = new DataGridViewTextBoxColumn();
            colLastName = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colUserName = new DataGridViewTextBoxColumn();
            colPassword = new DataGridViewTextBoxColumn();
            colContact = new DataGridViewTextBoxColumn();
            colGender = new DataGridViewTextBoxColumn();
            colAddress = new DataGridViewTextBoxColumn();
            colUserType = new DataGridViewTextBoxColumn();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(0, 120, 215);
            pnlHeader.Controls.Add(lblHeaderTitle);
            pnlHeader.Controls.Add(lblClose);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(3, 4, 3, 4);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1084, 56);
            pnlHeader.TabIndex = 0;
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.Dock = DockStyle.Fill;
            lblHeaderTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(0, 0);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(1021, 56);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "Users";
            lblHeaderTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblHeaderTitle.Click += lblHeaderTitle_Click;
            // 
            // lblClose
            // 
            lblClose.Cursor = Cursors.Hand;
            lblClose.Dock = DockStyle.Right;
            lblClose.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblClose.ForeColor = Color.Red;
            lblClose.Location = new Point(1021, 0);
            lblClose.Name = "lblClose";
            lblClose.Size = new Size(63, 56);
            lblClose.TabIndex = 1;
            lblClose.Text = "Close";
            lblClose.TextAlign = ContentAlignment.MiddleCenter;
            lblClose.Click += lblClose_Click;
            // 
            // lblUserId
            // 
            lblUserId.AutoSize = true;
            lblUserId.Font = new Font("Segoe UI", 9.5F);
            lblUserId.ForeColor = Color.White;
            lblUserId.Location = new Point(17, 72);
            lblUserId.Name = "lblUserId";
            lblUserId.Size = new Size(61, 21);
            lblUserId.TabIndex = 1;
            lblUserId.Text = "User ID";
            // 
            // txtUserId
            // 
            txtUserId.Font = new Font("Segoe UI", 9.5F);
            txtUserId.Location = new Point(154, 68);
            txtUserId.Margin = new Padding(3, 4, 3, 4);
            txtUserId.Name = "txtUserId";
            txtUserId.ReadOnly = true;
            txtUserId.Size = new Size(217, 29);
            txtUserId.TabIndex = 2;
            txtUserId.TextChanged += txtUserId_TextChanged;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new Font("Segoe UI", 9.5F);
            lblFirstName.ForeColor = Color.White;
            lblFirstName.Location = new Point(17, 111);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(86, 21);
            lblFirstName.TabIndex = 3;
            lblFirstName.Text = "First Name";
            // 
            // txtFirstName
            // 
            txtFirstName.Font = new Font("Segoe UI", 9.5F);
            txtFirstName.Location = new Point(154, 107);
            txtFirstName.Margin = new Padding(3, 4, 3, 4);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(217, 29);
            txtFirstName.TabIndex = 4;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Segoe UI", 9.5F);
            lblLastName.ForeColor = Color.White;
            lblLastName.Location = new Point(17, 149);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(84, 21);
            lblLastName.TabIndex = 5;
            lblLastName.Text = "Last Name";
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Segoe UI", 9.5F);
            txtLastName.Location = new Point(154, 145);
            txtLastName.Margin = new Padding(3, 4, 3, 4);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(217, 29);
            txtLastName.TabIndex = 6;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9.5F);
            lblEmail.ForeColor = Color.White;
            lblEmail.Location = new Point(17, 188);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(48, 21);
            lblEmail.TabIndex = 7;
            lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 9.5F);
            txtEmail.Location = new Point(154, 184);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(217, 29);
            txtEmail.TabIndex = 8;
            txtEmail.TextChanged += txtEmail_TextChanged;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Segoe UI", 9.5F);
            lblUserName.ForeColor = Color.White;
            lblUserName.Location = new Point(17, 227);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(88, 21);
            lblUserName.TabIndex = 9;
            lblUserName.Text = "User Name";
            // 
            // txtUserName
            // 
            txtUserName.Font = new Font("Segoe UI", 9.5F);
            txtUserName.Location = new Point(154, 223);
            txtUserName.Margin = new Padding(3, 4, 3, 4);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(217, 29);
            txtUserName.TabIndex = 10;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 9.5F);
            lblPassword.ForeColor = Color.White;
            lblPassword.Location = new Point(17, 265);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(76, 21);
            lblPassword.TabIndex = 11;
            lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 9.5F);
            txtPassword.Location = new Point(154, 261);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(217, 29);
            txtPassword.TabIndex = 12;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Font = new Font("Segoe UI", 9.5F);
            lblConfirmPassword.ForeColor = Color.White;
            lblConfirmPassword.Location = new Point(17, 304);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(137, 21);
            lblConfirmPassword.TabIndex = 13;
            lblConfirmPassword.Text = "Confirm Password";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Font = new Font("Segoe UI", 9.5F);
            txtConfirmPassword.Location = new Point(154, 300);
            txtConfirmPassword.Margin = new Padding(3, 4, 3, 4);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.Size = new Size(217, 29);
            txtConfirmPassword.TabIndex = 14;
            // 
            // lblContact
            // 
            lblContact.AutoSize = true;
            lblContact.Font = new Font("Segoe UI", 9.5F);
            lblContact.ForeColor = Color.White;
            lblContact.Location = new Point(17, 343);
            lblContact.Name = "lblContact";
            lblContact.Size = new Size(63, 21);
            lblContact.TabIndex = 15;
            lblContact.Text = "Contact";
            // 
            // txtContact
            // 
            txtContact.Font = new Font("Segoe UI", 9.5F);
            txtContact.Location = new Point(154, 339);
            txtContact.Margin = new Padding(3, 4, 3, 4);
            txtContact.Name = "txtContact";
            txtContact.Size = new Size(217, 29);
            txtContact.TabIndex = 16;
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Font = new Font("Segoe UI", 9.5F);
            lblGender.ForeColor = Color.White;
            lblGender.Location = new Point(17, 381);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(61, 21);
            lblGender.TabIndex = 17;
            lblGender.Text = "Gender";
            // 
            // cmbGender
            // 
            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGender.Font = new Font("Segoe UI", 9.5F);
            cmbGender.FormattingEnabled = true;
            cmbGender.Items.AddRange(new object[] { "Male", "Female", "Other" });
            cmbGender.Location = new Point(154, 377);
            cmbGender.Margin = new Padding(3, 4, 3, 4);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(217, 29);
            cmbGender.TabIndex = 18;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI", 9.5F);
            lblAddress.ForeColor = Color.White;
            lblAddress.Location = new Point(17, 420);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(66, 21);
            lblAddress.TabIndex = 19;
            lblAddress.Text = "Address";
            // 
            // txtAddress
            // 
            txtAddress.Font = new Font("Segoe UI", 9.5F);
            txtAddress.Location = new Point(154, 419);
            txtAddress.Margin = new Padding(3, 4, 3, 4);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.ScrollBars = ScrollBars.Vertical;
            txtAddress.Size = new Size(217, 65);
            txtAddress.TabIndex = 20;
            // 
            // lblUserType
            // 
            lblUserType.AutoSize = true;
            lblUserType.Font = new Font("Segoe UI", 9.5F);
            lblUserType.ForeColor = Color.White;
            lblUserType.Location = new Point(17, 496);
            lblUserType.Name = "lblUserType";
            lblUserType.Size = new Size(78, 21);
            lblUserType.TabIndex = 21;
            lblUserType.Text = "User Type";
            // 
            // cmbUserType
            // 
            cmbUserType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUserType.Font = new Font("Segoe UI", 9.5F);
            cmbUserType.FormattingEnabled = true;
            cmbUserType.Items.AddRange(new object[] { "User", "Admin" });
            cmbUserType.Location = new Point(154, 492);
            cmbUserType.Margin = new Padding(3, 4, 3, 4);
            cmbUserType.Name = "cmbUserType";
            cmbUserType.Size = new Size(217, 29);
            cmbUserType.TabIndex = 22;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(0, 120, 215);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(23, 549);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(105, 45);
            btnAdd.TabIndex = 23;
            btnAdd.Text = "ADD";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(0, 120, 215);
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(143, 549);
            btnUpdate.Margin = new Padding(3, 4, 3, 4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(105, 45);
            btnUpdate.TabIndex = 24;
            btnUpdate.Text = "UPDATE";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(0, 120, 215);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(263, 549);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(109, 45);
            btnDelete.TabIndex = 25;
            btnDelete.Text = "DELETE";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblSearch.ForeColor = Color.White;
            lblSearch.Location = new Point(394, 72);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(71, 21);
            lblSearch.TabIndex = 26;
            lblSearch.Text = "SEARCH";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 9.5F);
            txtSearch.Location = new Point(469, 68);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(583, 29);
            txtSearch.TabIndex = 27;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.BackgroundColor = Color.White;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Columns.AddRange(new DataGridViewColumn[] { colUserId, colFirstName, colLastName, colEmail, colUserName, colPassword, colContact, colGender, colAddress, colUserType });
            dgvUsers.Location = new Point(394, 111);
            dgvUsers.Margin = new Padding(3, 4, 3, 4);
            dgvUsers.MultiSelect = false;
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(658, 484);
            dgvUsers.TabIndex = 28;
            dgvUsers.CellClick += dgvUsers_CellClick;
            dgvUsers.CellContentClick += dgvUsers_CellContentClick;
            // 
            // colUserId
            // 
            colUserId.DataPropertyName = "id";
            colUserId.HeaderText = "User ID";
            colUserId.MinimumWidth = 6;
            colUserId.Name = "colUserId";
            colUserId.ReadOnly = true;
            colUserId.Width = 70;
            // 
            // colFirstName
            // 
            colFirstName.DataPropertyName = "first_name";
            colFirstName.HeaderText = "First Name";
            colFirstName.MinimumWidth = 6;
            colFirstName.Name = "colFirstName";
            colFirstName.ReadOnly = true;
            colFirstName.Width = 90;
            // 
            // colLastName
            // 
            colLastName.DataPropertyName = "last_name";
            colLastName.HeaderText = "Last Name";
            colLastName.MinimumWidth = 6;
            colLastName.Name = "colLastName";
            colLastName.ReadOnly = true;
            colLastName.Width = 90;
            // 
            // colEmail
            // 
            colEmail.DataPropertyName = "email";
            colEmail.HeaderText = "Email";
            colEmail.MinimumWidth = 6;
            colEmail.Name = "colEmail";
            colEmail.ReadOnly = true;
            colEmail.Width = 110;
            // 
            // colUserName
            // 
            colUserName.DataPropertyName = "username";
            colUserName.HeaderText = "User Name";
            colUserName.MinimumWidth = 6;
            colUserName.Name = "colUserName";
            colUserName.ReadOnly = true;
            colUserName.Width = 90;
            // 
            // colPassword
            // 
            colPassword.DataPropertyName = "password";
            colPassword.HeaderText = "Password";
            colPassword.MinimumWidth = 6;
            colPassword.Name = "colPassword";
            colPassword.ReadOnly = true;
            colPassword.Width = 80;
            // 
            // colContact
            // 
            colContact.DataPropertyName = "contact";
            colContact.HeaderText = "Contact";
            colContact.MinimumWidth = 6;
            colContact.Name = "colContact";
            colContact.ReadOnly = true;
            colContact.Width = 85;
            // 
            // colGender
            // 
            colGender.DataPropertyName = "gender";
            colGender.HeaderText = "Gender";
            colGender.MinimumWidth = 6;
            colGender.Name = "colGender";
            colGender.ReadOnly = true;
            colGender.Width = 70;
            // 
            // colAddress
            // 
            colAddress.DataPropertyName = "address";
            colAddress.HeaderText = "Address";
            colAddress.MinimumWidth = 6;
            colAddress.Name = "colAddress";
            colAddress.ReadOnly = true;
            colAddress.Width = 125;
            // 
            // colUserType
            // 
            colUserType.DataPropertyName = "user_type";
            colUserType.HeaderText = "User Type";
            colUserType.MinimumWidth = 6;
            colUserType.Name = "colUserType";
            colUserType.ReadOnly = true;
            colUserType.Width = 85;
            // 
            // frmUsers
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(128, 128, 128);
            ClientSize = new Size(1084, 620);
            Controls.Add(dgvUsers);
            Controls.Add(txtSearch);
            Controls.Add(lblSearch);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(cmbUserType);
            Controls.Add(lblUserType);
            Controls.Add(txtAddress);
            Controls.Add(lblAddress);
            Controls.Add(cmbGender);
            Controls.Add(lblGender);
            Controls.Add(txtContact);
            Controls.Add(lblContact);
            Controls.Add(txtConfirmPassword);
            Controls.Add(lblConfirmPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUserName);
            Controls.Add(lblUserName);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtLastName);
            Controls.Add(lblLastName);
            Controls.Add(txtFirstName);
            Controls.Add(lblFirstName);
            Controls.Add(txtUserId);
            Controls.Add(lblUserId);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmUsers";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Users";
            Load += frmUsers_Load;
            pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlHeader;
        private Label lblHeaderTitle;
        private Label lblClose;
        private Label lblUserId;
        private TextBox txtUserId;
        private Label lblFirstName;
        private TextBox txtFirstName;
        private Label lblLastName;
        private TextBox txtLastName;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblUserName;
        private TextBox txtUserName;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblConfirmPassword;
        private TextBox txtConfirmPassword;
        private Label lblContact;
        private TextBox txtContact;
        private Label lblGender;
        private ComboBox cmbGender;
        private Label lblAddress;
        private TextBox txtAddress;
        private Label lblUserType;
        private ComboBox cmbUserType;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Label lblSearch;
        private TextBox txtSearch;
        private DataGridView dgvUsers;
        private DataGridViewTextBoxColumn colUserId;
        private DataGridViewTextBoxColumn colFirstName;
        private DataGridViewTextBoxColumn colLastName;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colUserName;
        private DataGridViewTextBoxColumn colPassword;
        private DataGridViewTextBoxColumn colContact;
        private DataGridViewTextBoxColumn colGender;
        private DataGridViewTextBoxColumn colAddress;
        private DataGridViewTextBoxColumn colUserType;
    }
}

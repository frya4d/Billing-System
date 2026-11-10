namespace Billing_System
{
    partial class PurchasesAndSales
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            emailtxt = new TextBox();
            searchtxt = new TextBox();
            nametxt = new TextBox();
            addresstxt = new TextBox();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            button1 = new Button();
            button2 = new Button();
            quantxt = new TextBox();
            pricetxt = new TextBox();
            catetxt = new TextBox();
            pnametxt = new TextBox();
            idtxt = new TextBox();
            dgvProducts = new DataGridView();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            label17 = new Label();
            txtReturn = new TextBox();
            txtPaid = new TextBox();
            txtTotal = new TextBox();
            txtDiscount = new TextBox();
            txtSubTotal = new TextBox();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 44);
            label1.Name = "label1";
            label1.Size = new Size(118, 20);
            label1.TabIndex = 0;
            label1.Text = "Search By Phone";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(78, 20);
            label2.TabIndex = 1;
            label2.Text = "Customers";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(610, 84);
            label3.Name = "label3";
            label3.Size = new Size(62, 20);
            label3.TabIndex = 2;
            label3.Text = "Address";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(331, 87);
            label4.Name = "label4";
            label4.Size = new Size(46, 20);
            label4.TabIndex = 3;
            label4.Text = "Email";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 84);
            label5.Name = "label5";
            label5.Size = new Size(49, 20);
            label5.TabIndex = 4;
            label5.Text = "Name";
            // 
            // emailtxt
            // 
            emailtxt.Location = new Point(383, 84);
            emailtxt.Name = "emailtxt";
            emailtxt.ReadOnly = true;
            emailtxt.Size = new Size(221, 27);
            emailtxt.TabIndex = 5;
            // 
            // searchtxt
            // 
            searchtxt.Location = new Point(145, 41);
            searchtxt.Name = "searchtxt";
            searchtxt.Size = new Size(232, 27);
            searchtxt.TabIndex = 6;
            // 
            // nametxt
            // 
            nametxt.Location = new Point(83, 84);
            nametxt.Name = "nametxt";
            nametxt.ReadOnly = true;
            nametxt.Size = new Size(215, 27);
            nametxt.TabIndex = 7;
            nametxt.TextChanged += nametxt_TextChanged;
            // 
            // addresstxt
            // 
            addresstxt.Location = new Point(693, 34);
            addresstxt.Multiline = true;
            addresstxt.Name = "addresstxt";
            addresstxt.ReadOnly = true;
            addresstxt.Size = new Size(221, 70);
            addresstxt.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 140);
            label6.Name = "label6";
            label6.Size = new Size(66, 20);
            label6.TabIndex = 9;
            label6.Text = "Products";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 177);
            label7.Name = "label7";
            label7.Size = new Size(24, 20);
            label7.TabIndex = 10;
            label7.Text = "ID";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(145, 181);
            label8.Name = "label8";
            label8.Size = new Size(49, 20);
            label8.TabIndex = 11;
            label8.Text = "Name";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(398, 185);
            label9.Name = "label9";
            label9.Size = new Size(69, 20);
            label9.TabIndex = 12;
            label9.Text = "Category";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(660, 185);
            label10.Name = "label10";
            label10.Size = new Size(41, 20);
            label10.TabIndex = 13;
            label10.Text = "Price";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(838, 186);
            label11.Name = "label11";
            label11.Size = new Size(65, 20);
            label11.TabIndex = 14;
            label11.Text = "Quantity";
            // 
            // button1
            // 
            button1.Location = new Point(398, 41);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 15;
            button1.Text = "Search";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(1028, 180);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 16;
            button2.Text = "Add";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // quantxt
            // 
            quantxt.Location = new Point(909, 183);
            quantxt.Name = "quantxt";
            quantxt.Size = new Size(108, 27);
            quantxt.TabIndex = 17;
            // 
            // pricetxt
            // 
            pricetxt.Location = new Point(707, 183);
            pricetxt.Name = "pricetxt";
            pricetxt.ReadOnly = true;
            pricetxt.Size = new Size(130, 27);
            pricetxt.TabIndex = 18;
            // 
            // catetxt
            // 
            catetxt.Location = new Point(473, 182);
            catetxt.Name = "catetxt";
            catetxt.ReadOnly = true;
            catetxt.Size = new Size(181, 27);
            catetxt.TabIndex = 19;
            catetxt.TextChanged += textBox7_TextChanged;
            // 
            // pnametxt
            // 
            pnametxt.Location = new Point(202, 178);
            pnametxt.Name = "pnametxt";
            pnametxt.ReadOnly = true;
            pnametxt.Size = new Size(175, 27);
            pnametxt.TabIndex = 20;
            // 
            // idtxt
            // 
            idtxt.Location = new Point(42, 174);
            idtxt.Name = "idtxt";
            idtxt.Size = new Size(88, 27);
            idtxt.TabIndex = 21;
            idtxt.TextChanged += idtxt_TextChanged;
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(12, 222);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(689, 378);
            dgvProducts.TabIndex = 22;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(735, 294);
            label12.Name = "label12";
            label12.Size = new Size(71, 20);
            label12.TabIndex = 23;
            label12.Text = "Sub Total";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(735, 457);
            label13.Name = "label13";
            label13.Size = new Size(94, 20);
            label13.TabIndex = 24;
            label13.Text = "Paid Amount";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(735, 408);
            label14.Name = "label14";
            label14.Size = new Size(42, 20);
            label14.TabIndex = 25;
            label14.Text = "Total";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(735, 347);
            label15.Name = "label15";
            label15.Size = new Size(83, 20);
            label15.TabIndex = 26;
            label15.Text = "Discount %";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(735, 503);
            label16.Name = "label16";
            label16.Size = new Size(101, 20);
            label16.TabIndex = 27;
            label16.Text = "Return Amout";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(735, 242);
            label17.Name = "label17";
            label17.Size = new Size(83, 20);
            label17.TabIndex = 28;
            label17.Text = "Calculation";
            // 
            // txtReturn
            // 
            txtReturn.Location = new Point(835, 500);
            txtReturn.Name = "txtReturn";
            txtReturn.Size = new Size(221, 27);
            txtReturn.TabIndex = 30;
            txtReturn.TextChanged += textBox11_TextChanged;
            // 
            // txtPaid
            // 
            txtPaid.Location = new Point(835, 454);
            txtPaid.Name = "txtPaid";
            txtPaid.Size = new Size(221, 27);
            txtPaid.TabIndex = 31;
            txtPaid.TextChanged += txtPaid_TextChanged;
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(835, 408);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(221, 27);
            txtTotal.TabIndex = 32;
            // 
            // txtDiscount
            // 
            txtDiscount.Location = new Point(835, 347);
            txtDiscount.Name = "txtDiscount";
            txtDiscount.Size = new Size(221, 27);
            txtDiscount.TabIndex = 33;
            txtDiscount.TextChanged += txtDiscount_TextChanged;
            // 
            // txtSubTotal
            // 
            txtSubTotal.Location = new Point(835, 294);
            txtSubTotal.Name = "txtSubTotal";
            txtSubTotal.Size = new Size(221, 27);
            txtSubTotal.TabIndex = 34;
            // 
            // button3
            // 
            button3.Location = new Point(735, 546);
            button3.Name = "button3";
            button3.Size = new Size(321, 29);
            button3.TabIndex = 35;
            button3.Text = "Save";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // PurchasesAndSales
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1134, 614);
            Controls.Add(button3);
            Controls.Add(txtSubTotal);
            Controls.Add(txtDiscount);
            Controls.Add(txtTotal);
            Controls.Add(txtPaid);
            Controls.Add(txtReturn);
            Controls.Add(label17);
            Controls.Add(label16);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(dgvProducts);
            Controls.Add(idtxt);
            Controls.Add(pnametxt);
            Controls.Add(catetxt);
            Controls.Add(pricetxt);
            Controls.Add(quantxt);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(addresstxt);
            Controls.Add(nametxt);
            Controls.Add(searchtxt);
            Controls.Add(emailtxt);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "PurchasesAndSales";
            Text = "PurchasesAndSales";
            Load += PurchasesAndSales_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox emailtxt;
        private TextBox searchtxt;
        private TextBox nametxt;
        private TextBox addresstxt;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Button button1;
        private Button button2;
        private TextBox quantxt;
        private TextBox pricetxt;
        private TextBox catetxt;
        private TextBox pnametxt;
        private TextBox idtxt;
        private DataGridView dgvProducts;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private TextBox txtReturn;
        private TextBox txtPaid;
        private TextBox txtTotal;
        private TextBox txtDiscount;
        private TextBox txtSubTotal;
        private Button button3;
    }
}
namespace Billing_System
{
    partial class frmCustomer
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
            textBox1 = new TextBox();
            typetxt = new ComboBox();
            dataGridView1 = new DataGridView();
            contacttxt = new TextBox();
            nametxt = new TextBox();
            emailtxt = new TextBox();
            addresstxt = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            idtxt = new TextBox();
            searchbtn = new Button();
            addbtn = new Button();
            updatebtn = new Button();
            deletebtn = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 44);
            label1.Name = "label1";
            label1.Size = new Size(87, 20);
            label1.TabIndex = 0;
            label1.Text = "CustomerID";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(434, 37);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(437, 27);
            textBox1.TabIndex = 1;
            // 
            // typetxt
            // 
            typetxt.FormattingEnabled = true;
            typetxt.Items.AddRange(new object[] { "mamosta", "employee" });
            typetxt.Location = new Point(147, 93);
            typetxt.Name = "typetxt";
            typetxt.Size = new Size(208, 28);
            typetxt.TabIndex = 2;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(434, 93);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(570, 327);
            dataGridView1.TabIndex = 3;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // contacttxt
            // 
            contacttxt.Location = new Point(147, 203);
            contacttxt.Name = "contacttxt";
            contacttxt.Size = new Size(208, 27);
            contacttxt.TabIndex = 4;
            contacttxt.TextChanged += contacttxt_TextChanged;
            // 
            // nametxt
            // 
            nametxt.Location = new Point(147, 145);
            nametxt.Name = "nametxt";
            nametxt.Size = new Size(208, 27);
            nametxt.TabIndex = 5;
            // 
            // emailtxt
            // 
            emailtxt.Location = new Point(147, 267);
            emailtxt.Name = "emailtxt";
            emailtxt.Size = new Size(208, 27);
            emailtxt.TabIndex = 6;
            // 
            // addresstxt
            // 
            addresstxt.Location = new Point(147, 328);
            addresstxt.Multiline = true;
            addresstxt.Name = "addresstxt";
            addresstxt.Size = new Size(208, 92);
            addresstxt.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(38, 342);
            label2.Name = "label2";
            label2.Size = new Size(60, 20);
            label2.TabIndex = 8;
            label2.Text = "address";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(38, 274);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 9;
            label3.Text = "email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(38, 210);
            label4.Name = "label4";
            label4.Size = new Size(58, 20);
            label4.TabIndex = 10;
            label4.Text = "contact";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(35, 152);
            label5.Name = "label5";
            label5.Size = new Size(49, 20);
            label5.TabIndex = 11;
            label5.Text = "Name";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(35, 96);
            label6.Name = "label6";
            label6.Size = new Size(40, 20);
            label6.TabIndex = 12;
            label6.Text = "Type";
            // 
            // idtxt
            // 
            idtxt.Location = new Point(147, 41);
            idtxt.Name = "idtxt";
            idtxt.ReadOnly = true;
            idtxt.Size = new Size(208, 27);
            idtxt.TabIndex = 13;
            // 
            // searchbtn
            // 
            searchbtn.Location = new Point(892, 37);
            searchbtn.Name = "searchbtn";
            searchbtn.Size = new Size(94, 29);
            searchbtn.TabIndex = 14;
            searchbtn.Text = "Search";
            searchbtn.UseVisualStyleBackColor = true;
            // 
            // addbtn
            // 
            addbtn.Location = new Point(147, 446);
            addbtn.Name = "addbtn";
            addbtn.Size = new Size(94, 29);
            addbtn.TabIndex = 15;
            addbtn.Text = "Add";
            addbtn.UseVisualStyleBackColor = true;
            addbtn.Click += addbtn_Click;
            // 
            // updatebtn
            // 
            updatebtn.Location = new Point(297, 446);
            updatebtn.Name = "updatebtn";
            updatebtn.Size = new Size(94, 29);
            updatebtn.TabIndex = 16;
            updatebtn.Text = "Update";
            updatebtn.UseVisualStyleBackColor = true;
            updatebtn.Click += updatebtn_Click;
            // 
            // deletebtn
            // 
            deletebtn.Location = new Point(434, 446);
            deletebtn.Name = "deletebtn";
            deletebtn.Size = new Size(94, 29);
            deletebtn.TabIndex = 17;
            deletebtn.Text = "Delete";
            deletebtn.UseVisualStyleBackColor = true;
            deletebtn.Click += deletebtn_Click;
            // 
            // frmCustomer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1032, 501);
            Controls.Add(deletebtn);
            Controls.Add(updatebtn);
            Controls.Add(addbtn);
            Controls.Add(searchbtn);
            Controls.Add(idtxt);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(addresstxt);
            Controls.Add(emailtxt);
            Controls.Add(nametxt);
            Controls.Add(contacttxt);
            Controls.Add(dataGridView1);
            Controls.Add(typetxt);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "frmCustomer";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmCustomer";
            Load += frmCustomer_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private ComboBox typetxt;
        private DataGridView dataGridView1;
        private TextBox contacttxt;
        private TextBox nametxt;
        private TextBox emailtxt;
        private TextBox addresstxt;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox idtxt;
        private Button searchbtn;
        private Button addbtn;
        private Button updatebtn;
        private Button deletebtn;
    }
}
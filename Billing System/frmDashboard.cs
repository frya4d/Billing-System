namespace Billing_System
{
    public partial class frmDashboard : Form
    {
        public static string connString = @"Data Source=Fryad;Initial Catalog=BillingSystemDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";

        public static string LoggedInUser = "Fryad";

        public frmDashboard()
        {
            InitializeComponent();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            lblUser.Text = "User: " + LoggedInUser;
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsers frm = new frmUsers();
            frm.TopLevel = false;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(frm);
            frm.Show();
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategory frm = new frmCategory();
            frm.Show();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProducts frm = new frmProducts();
            frm.Show();
        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblFooter_Click(object sender, EventArgs e)
        {

        }

        private void lblUser_Click(object sender, EventArgs e)
        {

        }
    }
}

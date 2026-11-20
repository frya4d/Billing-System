namespace Billing_System
{
    public static class Program
    {
        public static string connString = @"Data Source=Fryad;Initial Catalog=BillingSystemDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";

        // Password
        public static bool IsValidPassword(string password)
        {
            if (password == null || password.Length < 8)
                return false;

            bool letter = false;
            bool number = false;
            bool symbol = false;

            foreach (char c in password)
            {
                if (char.IsLetter(c))
                    letter = true;
                else if (char.IsDigit(c))
                    number = true;
                else
                    symbol = true;
            }

            return letter && number && symbol;
        }

        // Name
        public static bool IsValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;

            foreach (char c in name)
            {
                if (!char.IsLetter(c) && c != ' ')
                    return false;
            }

            return true;
        }

        // Email
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            if (!email.Contains("@") || !email.Contains("."))
                return false;

            return true;
        }

        // Phone
        public static bool IsValidPhone(string phone)
        {
            if (phone == null || phone.Length != 11)
                return false;

            foreach (char c in phone)
            {
                if (!char.IsDigit(c))
                    return false;
            }

            return true;
        }

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new frmLogin());
        }
    }
}

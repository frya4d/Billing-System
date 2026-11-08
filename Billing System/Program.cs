namespace Billing_System
{
    public static class Program
    {
        // ==============================================================
        // پشکنینی بەهێزیی وشەی نهێنی (Password Policy)
        // ١. لانیکەم ٨ پیت و ژمارە بێت
        // ٢. پیت و ژمارە و هێمای تێدابێت
        // ==============================================================
        public static bool IsValidPassword(string password, out string errorMessage)
        {
            errorMessage = "";

            if (string.IsNullOrEmpty(password) || password.Length < 8)
            {
                errorMessage = "وشەی نهێنی نابێت لە ٨ پیت و ژمارە کەمتر بێت!";
                return false;
            }

            bool hasLetter = false;
            bool hasDigit = false;
            bool hasSymbol = false;

            // پشکنینی پیتەکانی وشەی نهێنی یەک بە یەک
            foreach (char c in password)
            {
                if (char.IsLetter(c))
                {
                    hasLetter = true;
                }
                else if (char.IsDigit(c))
                {
                    hasDigit = true;
                }
                else
                {
                    hasSymbol = true; // هێماکان وەک @, #, $, %, ...
                }
            }

            if (!hasLetter)
            {
                errorMessage = "پێویستە وشەی نهێنی لانیکەم یەک پیتی تێدابێت (Letter)!";
                return false;
            }

            if (!hasDigit)
            {
                errorMessage = "پێویستە وشەی نهێنی لانیکەم یەک ژمارەی تێدابێت (Number)!";
                return false;
            }

            if (!hasSymbol)
            {
                errorMessage = "پێویستە وشەی نهێنی لانیکەم یەک هێمای تێدابێت (Symbol وەک @, #, $, %)!";
                return false;
            }

            return true;
        }

        // ==============================================================
        // پشکنینی ناو (تەنها دەبێت لە پیت و بۆشایی پێکبێت)
        // ==============================================================
        public static bool IsValidName(string name, out string errorMessage)
        {
            errorMessage = "";
            if (string.IsNullOrWhiteSpace(name))
            {
                errorMessage = "تکایە ناو بنووسە!";
                return false;
            }

            string clean = name.Trim();
            foreach (char c in clean)
            {
                if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                {
                    errorMessage = "ناو دەبێت تەنها لە پیت پێکبێت (ژمارە و هێما ڕێگەپێدراو نییە)!";
                    return false;
                }
            }

            return true;
        }

        // ==============================================================
        // پشکنینی شێوازی ئیمەیڵ (Email Validation)
        // ==============================================================
        public static bool IsValidEmail(string email, out string errorMessage)
        {
            errorMessage = "";
            if (string.IsNullOrWhiteSpace(email))
            {
                errorMessage = "تکایە ئیمەیڵ بنووسە!";
                return false;
            }

            string clean = email.Trim();
            int atIndex = clean.IndexOf('@');
            int dotIndex = clean.LastIndexOf('.');

            if (atIndex <= 0 || dotIndex <= atIndex + 1 || dotIndex >= clean.Length - 1 || clean.Contains(" "))
            {
                errorMessage = "شێوازی ئیمەیڵ نادروستە (نموونە: user@example.com)!";
                return false;
            }

            return true;
        }

        // ==============================================================
        // پشکنینی ژمارەی مۆبایل (تەنها ژمارە و دەبێت ڕێک ١١ ژمارە بێت)
        // ==============================================================
        public static bool IsValidPhone(string phone, out string errorMessage)
        {
            errorMessage = "";
            if (string.IsNullOrWhiteSpace(phone))
            {
                errorMessage = "تکایە ژمارەی مۆبایل بنووسە!";
                return false;
            }

            string clean = phone.Trim();
            if (clean.Length != 11)
            {
                errorMessage = "ژمارەی مۆبایل دەبێت تەنها لە ١١ ژمارە پێکبێت (نموونە: 07501234567)!";
                return false;
            }

            foreach (char c in clean)
            {
                if (!char.IsDigit(c))
                {
                    errorMessage = "ژمارەی مۆبایل دەبێت تەنها لە ژمارە پێکبێت!";
                    return false;
                }
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

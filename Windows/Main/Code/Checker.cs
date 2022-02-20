using System.Linq;

namespace Main
{
    public class CheckPassword
    {
        public bool isUpper = false;
        public bool isLower = false;
        public bool isDigit = false;
        public bool isSymbol = false;
        public static int points = 0;

        public static string lettersRow = "abcdefghijklmnopqrstuvwxyz";
        public static string digitsRow = "0123456789";
        public static string symbolsRow = "./^|*&?!@#()_+-=";
        public static int passwordSize = 10;

        public static void Check(string password)
        {
            if (password.Length >= passwordSize && password.Length <= passwordSize + 5)
                points++;
            else if (password.Length >= passwordSize + 5 && password.Length <= passwordSize + 10)
                points += 2;
            else if (password.Length >= passwordSize + 10)
                points += 3;

            isTrue(CountTypes(password, lettersRow.ToUpper()));
            isTrue(CountTypes(password, lettersRow));
            isTrue(CountTypes(password, digitsRow));
            isTrue(CountTypes(password, symbolsRow));
        }

        private static void isTrue(bool checker)
        {
            if (checker)
                points++;
        }
        public static bool CountTypes(string password, string type)
        {
            for (int i = 0; i < type.Length; i++)
            {
                bool result = password.Contains(type[i]);
                if (result)
                    return true;
            }
            return false;
        }
        private bool Existance(bool type)
        {
            if (type)
                return true;
            else
                return false;
        }
    }
}
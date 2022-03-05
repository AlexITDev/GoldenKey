using ExtentionMethods;
using System.Collections.Generic;

namespace Main
{
    public class CheckPassword
    {
        public bool isUpper = false;
        public bool isLower = false;
        public bool isDigit = false;
        public bool isSymbol = false;
        public static int points = 0;

        public static List<string> passwElements = new List<string> { "abcdefghijklmnopqrstuvwxyz", "0123456789", "./^|*&?!@#()_+-=" };
        public static int passwordSize = 10;

        public static void Check(string password)
        {
            if (password.Len() >= passwordSize && password.Len() <= passwordSize + 5)
                points++;
            else if (password.Len() >= passwordSize + 5 && password.Len() <= passwordSize + 10)
                points += 2;
            else if (password.Len() >= passwordSize + 10)
                points += 3;

            isTrue(CountTypes(password, passwElements[0].Upper()));
            isTrue(CountTypes(password, passwElements[0]));
            isTrue(CountTypes(password, passwElements[1]));
            isTrue(CountTypes(password, passwElements[2]));
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
                bool result = password.Existance(type[i].ToString());
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
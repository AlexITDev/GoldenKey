using System;
using System.Linq;

namespace Main
{
    public class CheckPassword
    {
        public bool isUpper = false;
        public bool isLower = false;
        public bool isDigit = false;
        public bool isSymbol = false;
        public int points = 0;

        public string lettersRow = "abcdefghijklmnopqrstuvwxyz";
        public string digitsRow = "0123456789";
        public string symbolsRow = "./^|*&?!@#()_+-=";
        public int passwordSize = 10;

        public void Check(string password)
        {
            if (password.Length >= passwordSize && password.Length <= passwordSize + 5)
                points++;
            else if (password.Length >= passwordSize + 5 && password.Length <= passwordSize + 10)
                points += 2;
            else if (password.Length >= passwordSize + 10)
                points += 3;

            CountTypes(password, lettersRow.ToUpper());
            CountTypes(password, lettersRow);
            CountTypes(password, digitsRow);
            CountTypes(password, symbolsRow);

            isTrue(isUpper);
            isTrue(isLower);
            isTrue(isDigit);
            isTrue(isSymbol);
        }

        public void isTrue(bool checker)
        {
            if (checker)
                points++;
        }
        public bool CountTypes(string password, string type)
        {
            for (int i = 0; i < type.Length; i++)
            {
                bool result = password.Contains(type[i]);
                if (result)
                    return true;
            }
            return false;
        }
        public bool Existance(bool type)
        {
            if (type)
                return true;
            else
                return false;
        }
    }
}

using System;
using System.Linq;

namespace Main
{
    public class CheckPassword: ConsoleCommands
    {
        bool isUpper = false;
        bool isLower = false;
        bool isDigit = false;
        bool isSymbol = false;
        int points = 0;
        public void Check()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\n[+] Write your password: ");
            string password = Console.ReadLine();

            string lettersRow = "abcdefghijklmnopqrstuvwxyz";
            string digitsRow = "0123456789";
            string symbolsRow = "./^|*&?!@#()_+-=";
            int passwordSize = 10;

            if (password.Length >= passwordSize && password.Length <= passwordSize + 5)
                points++;
            else if (password.Length >= passwordSize + 5 && password.Length <= passwordSize + 10)
                points += 2;
            else if (password.Length >= passwordSize + 10)
                points += 3;

            CountTypes(password, lettersRow.ToUpper(), isUpper);
            CountTypes(password, lettersRow, isLower);
            CountTypes(password, digitsRow, isDigit);
            CountTypes(password, symbolsRow, isSymbol);

            isTrue(isUpper);
            isTrue(isLower);
            isTrue(isDigit);
            isTrue(isSymbol);

            ShowResult(password);
        }

        private void isTrue(bool checker)
        {
            if (checker)
                points++;
        }
        private void CountTypes(string password, string type, bool checker)
        {
            for (int i = 0; i < type.Length; i++)
            {
                bool result = password.Contains(type[i]);
                if (result)
                    checker = true;
            }
        }
        private void Existance(bool type)
        {
            if (type)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("True\n");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("False\n");
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
        }
        private void ShowResult(string password)
        {
            Console.Write("[+] Length - ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(password.Length + "\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.Write("[+] Uppercase - ");
            Existance(isUpper);

            Console.Write("[+] Lowercase - ");
            Existance(isLower);

            Console.Write("[+] Numbers - ");
            Existance(isDigit);

            Console.Write("[+] Symbols - ");
            Existance(isSymbol);

            Console.WriteLine("\n[+] Points: " + points);

            Console.Write("<!> Your password is - ");
            if (points <= 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("too weak!\n");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
            else if (points > 3 && points < 5)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("average!\n");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
            else if (points >= 5 && points < 7)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("strong!\n");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("very strong!\n");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
        }
    }
}

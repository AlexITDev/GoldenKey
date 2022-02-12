using System;
using System.Linq;

namespace Main
{
    public class CheckPassword
    {
        bool isUpper = false;
        bool isLower = false;
        bool isNumber = false;
        bool isSymbol = false;
        int points = 0;
        public void Check()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\n[+] Write your password: ");
            string password = Console.ReadLine();

            string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lowercase = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "0123456789";
            string symbols = "./^|*&?!@#()_+-=";

            if (password.Length >= 10 && password.Length <= 15)
            {
                points++;
            }
            else if (password.Length >= 15 && password.Length <= 20)
            {
                points += 2;
            }
            else if (password.Length >= 20)
            {
                points += 3;
            }

            for (int i = 0; i < uppercase.Length; i++)
            {
                bool result = password.Contains(uppercase[i]);
                if (result)
                    isUpper = true;
            }
            for (int j = 0; j < lowercase.Length; j++)
            {
                bool result = password.Contains(lowercase[j]);
                if (result)
                    isLower = true;
            }
            for (int k = 0; k < numbers.Length; k++)
            {
                bool result = password.Contains(numbers[k]);
                if (result)
                    isNumber = true;
            }
            for (int m = 0; m < symbols.Length; m++)
            {
                bool result = password.Contains(symbols[m]);
                if (result)
                    isSymbol = true;
            }

            if (isUpper)
                points++;
            if (isLower)
                points++;
            if (isNumber)
                points++;
            if (isSymbol)
                points++;

            ShowResult(password);
        }

        void Existance(bool type)
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
            Existance(isNumber);

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

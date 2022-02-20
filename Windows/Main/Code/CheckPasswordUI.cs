using System;

namespace Main
{
    class CheckPasswordUI: CheckPassword
    {
        private static void ColorLabel(bool existance)
        {
            if (existance)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("True\n");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("False\n");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
        }

        public static int ShowResult(string password)
        {
            Console.Write("[+] Length - ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(password.Length + "\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.Write("[+] Uppercase - ");
            ColorLabel(CountTypes(password, lettersRow.ToUpper()));

            Console.Write("[+] Lowercase - ");
            ColorLabel(CountTypes(password, lettersRow));

            Console.Write("[+] Numbers - ");
            ColorLabel(CountTypes(password, digitsRow));

            Console.Write("[+] Symbols - ");
            ColorLabel(CountTypes(password, symbolsRow));

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
            return points;
        }
    }
}

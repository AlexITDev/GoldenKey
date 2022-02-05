using System;
using System.Linq;


namespace Main
{ 
    public class GoldenKey
    {
        public void GeneratePassw()
        {
            Console.WriteLine("Generate");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n[01] Only letters");
            Console.WriteLine("[02] Only numbers");
            Console.WriteLine("[03] Only symbols");
            Console.WriteLine("[04] Letters & numbers");
            Console.WriteLine("[05] Symbols & numbers");
            Console.WriteLine("[06] Letters & symbols");
            Console.WriteLine("[07] All");
            Console.WriteLine("[99] Menu");

            Console.Write("\n[+] Select option: ");
            string option = Console.ReadLine();

            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            string numbers = "0123456789";
            string symbols = "./^|*&?!@#()_+-=";

            Console.Write("[+] Password length: ");
            int length = Convert.ToInt32(Console.ReadLine());
            var random = new Random();

            string randomString(int len, string type)
            {
                return new string(Enumerable.Repeat(type, len)
                    .Select(s => s[random.Next(s.Length)]).ToArray());
            }

            void show(string type)
            {
                for (int i = 0; i < 100; i++)
                {
                    if (i < 10)
                    {
                        Console.WriteLine("[0" + i + "]---> " + randomString(length, type));
                    }
                    else
                    {
                        Console.WriteLine("[" + i + "]---> " + randomString(length, type));
                    }

                }
            }

            if (option == "1")
            {
                show(letters);
            }
            else if (option == "2")
            {
                show(numbers);
            }
            else if (option == "3")
            {
                show(symbols);
            }
            else if (option == "4")
            {
                show(letters + numbers);
            }
            else if (option == "5")
            {
                show(symbols + numbers);
            }
            else if (option == "6")
            {
                show(letters + symbols);
            }
            else if (option == "7")
            {
                show(letters + numbers + symbols);
            }
            else
            {
                GeneratePassw();
            }
        }
    }

    public class CheckPassword
    {
        public void Check()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\n[+] Write your password: ");
            string password = Console.ReadLine();

            int points = 0;

            string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lowercase = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "0123456789";
            string symbols = "./^|*&?!@#()_+-=";

            bool isUpper = false;
            bool isLower = false;
            bool isNumber = false;
            bool isSymbol = false;

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
                Boolean result = password.Contains(uppercase[i]);
                if (result)
                    isUpper = true;
            }
            for (int j = 0; j < lowercase.Length; j++)
            {
                Boolean result = password.Contains(lowercase[j]);
                if (result)
                    isLower = true;
            }
            for (int k = 0; k < numbers.Length; k++)
            {
                Boolean result = password.Contains(numbers[k]);
                if (result)
                    isNumber = true;
            }
            for (int m = 0; m < symbols.Length; m++)
            {
                Boolean result = password.Contains(symbols[m]);
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
    public class StartWindow
    {
        private void Options()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("[01] Generate password");
            Console.WriteLine("[02] Check password");
            Console.WriteLine("[..] ");
            Console.WriteLine("[99] Exit");
        }
        private void Choice()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.Write("\n[Windows@User]--> ");

                Console.ForegroundColor = ConsoleColor.White;
                string choice = Console.ReadLine();

                var g = new GoldenKey();
                var cp = new CheckPassword();

                Console.Write("\n");

                if (choice == "1")
                {
                    g.GeneratePassw();
                }
                if (choice == "2")
                {
                    cp.Check();
                }
                if (choice == "99")
                {
                    string strCmdText;
                    strCmdText = "exit";
                    System.Diagnostics.Process.Start("CMD.exe", strCmdText);
                }
                else
                {
                    Choice();
                }
            }
        }
        public void Title()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("  _____       _     _            _   __          ");
            Console.WriteLine(" |  __ |     | |   | |          | | / /          ");
            Console.WriteLine(" | |  || ___ | | __| | ___ _ __ | |/ /  ___ _   _");
            Console.WriteLine(" | | __ / _ || |/ _` |/ _ | '_ ||    | / _ | | ||");
            Console.WriteLine(" | |_| | (_) | | (_| |  __/ | | | ||  |  __/ |_||");
            Console.WriteLine(" |____/| ___/|_||__,_||___|_| |_|_| |_/|___||__,|");
            Console.WriteLine("                                            __/ |");
            Console.WriteLine("                                           |___/ ");
            Console.WriteLine("\n-------------------------------------------------");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Creator: AlexITDev, 2022 year                    ");
            Console.WriteLine("Version: GoldenKey v.0.1.0                       ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-------------------------------------------------\n");

            Console.ForegroundColor = ConsoleColor.White;

            Options();
            Choice();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var s = new StartWindow();
            s.Title();
        }
    }
}

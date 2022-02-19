using System;

namespace Main
{
    class UI
    {
        public CheckPassword checkPassword = new CheckPassword();
        public Generator passwGenerator = new Generator();
        public PasswordManager passwordManager = new PasswordManager();

        public static string option = " ";
        public static int length = 0;

        public void ShowLabel(string productVersion)
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
            Console.WriteLine("Product: GoldenKey " + productVersion);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-------------------------------------------------\n");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("[01] Generate password");
            Console.WriteLine("[02] Check password strength");
            Console.WriteLine("[03] Password manager");
            Console.WriteLine("[..] ");
            Console.WriteLine("[99] Exit");

            Choice();
        }

        private void Choice()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n[GoldenKey]--> ");

                Console.ForegroundColor = ConsoleColor.White;
                string choice = Console.ReadLine();

                Console.Write("\n");

                switch (choice)
                {
                    case "1":
                        GeneratePasswordLabel();
                        GeneratePasswordChoice();
                        break;

                    case "2":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("\n[+] Write your password: ");
                        string password = Console.ReadLine();

                        checkPassword.Check(password);
                        ShowResult(password);
                        break;

                    case "3":
                        passwordManager.Manager();
                        break;

                    case "99":
                        System.Environment.Exit(0);
                        break;

                    default:
                        Choice();
                        break;
                }
            }
        }

        public void GeneratePasswordLabel()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n[01] Only letters");
            Console.WriteLine("[02] Only numbers");
            Console.WriteLine("[03] Only symbols");
            Console.WriteLine("[04] Letters & numbers");
            Console.WriteLine("[05] Symbols & numbers");
            Console.WriteLine("[06] Letters & symbols");
            Console.WriteLine("[07] All");
            Console.WriteLine("[99] Menu");
        }

        public void Show(string type)
        {
            for (int i = 0; i < 100; i++)
            {
                if (i < 10)
                    Console.WriteLine("[0" + i + "]---> " + passwGenerator.RandomString(length, type));
                else
                    Console.WriteLine("[" + i + "]---> " + passwGenerator.RandomString(length, type));
            }
        }

        public void GeneratePasswordChoice()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n[Generator]--> ");
                string option = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("[+] Password length: ");
                length = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case "1":
                        Show(passwGenerator.letters);
                        break;

                    case "2":
                        Show(passwGenerator.numbers);
                        break;

                    case "3":
                        Show(passwGenerator.symbols);
                        break;

                    case "4":
                        Show(passwGenerator.letters + passwGenerator.numbers);
                        break;

                    case "5":
                        Show(passwGenerator.symbols + passwGenerator.numbers);
                        break;

                    case "6":
                        Show(passwGenerator.letters + passwGenerator.symbols);
                        break;

                    case "7":
                        Show(passwGenerator.letters + passwGenerator.numbers + passwGenerator.symbols);
                        break;

                    case "99":
                        Choice();
                        break;

                    default:
                        GeneratePasswordChoice();
                        break;
                }
            }
        }

        private void ColorLabel(bool existance)
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

        public int ShowResult(string password)
        {
            Console.Write("[+] Length - ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(password.Length + "\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.Write("[+] Uppercase - ");
            ColorLabel(checkPassword.CountTypes(password, checkPassword.lettersRow.ToUpper()));

            Console.Write("[+] Lowercase - ");
            ColorLabel(checkPassword.CountTypes(password, checkPassword.lettersRow));

            Console.Write("[+] Numbers - ");
            ColorLabel(checkPassword.CountTypes(password, checkPassword.digitsRow));

            Console.Write("[+] Symbols - ");
            ColorLabel(checkPassword.CountTypes(password, checkPassword.symbolsRow));

            Console.WriteLine("\n[+] Points: " + checkPassword.points);

            Console.Write("<!> Your password is - ");
            if (checkPassword.points <= 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("too weak!\n");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
            else if (checkPassword.points > 3 && checkPassword.points < 5)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("average!\n");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
            else if (checkPassword.points >= 5 && checkPassword.points < 7)
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
            return checkPassword.points;
        }
    }
}

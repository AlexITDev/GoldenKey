using System;

namespace Main
{
    class UI: Program
    {
        public static void ShowLabel()
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
            Console.WriteLine("Product: GoldenKey " + Program.productVersion);
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

        public static void Choice()
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
                        Console.Clear();
                        GeneratorUI.GeneratePasswordLabel();
                        GeneratorUI.GeneratePasswordChoice();
                        break;

                    case "2":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("\n[+] Write your password: ");
                        string password = Console.ReadLine();

                        CheckPassword.Check(password);
                        CheckPasswordUI.ShowResult(password);
                        break;

                    case "3":
                        Console.Clear();
                        PasswordManagerUI.PasswManagerOptions();
                        PasswordManagerUI.PasswManagerChoice();
                        break;

                    case "99":
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Are you sure to exit? [y/n]: ");
                        string exitChoice = Console.ReadLine();

                        if (exitChoice.ToLower() == "y" || exitChoice.ToLower() == "yes")
                            System.Environment.Exit(0);
                        else if (exitChoice.ToLower() == "n" || exitChoice.ToLower() == "no")
                        {
                            Console.Clear();
                            ShowLabel();
                            Choice();
                        }
                        break;

                    default:
                        Choice();
                        break;
                }
            }
        }
    }
        
}

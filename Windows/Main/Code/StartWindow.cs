using System;

namespace Main
{
    public class Window
    {
        String productVersion;
        public Window() {}
        public Window(String version)
        {
            productVersion = version;
        }
        private void Options()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("[01] Generate password");
            Console.WriteLine("[02] Check password strength");
            Console.WriteLine("[03] Password manager");
            Console.WriteLine("[..] ");
            Console.WriteLine("[99] Exit");
        }
        private void Choice()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n[GoldenKey]--> ");

                Console.ForegroundColor = ConsoleColor.White;
                string choice = Console.ReadLine();

                var goldenKey = new GoldenKey();
                var checkPassword = new CheckPassword();
                var passwordManager = new PasswordManager();

                Console.Write("\n");

                if (choice == "1")
                {
                    goldenKey.GeneratePassw();
                }
                if (choice == "2")
                {
                    checkPassword.Check();
                }
                if (choice == "3")
                {
                    passwordManager.Manager();
                }
                if (choice == "99")
                {
                    System.Environment.Exit(0);
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
            Console.WriteLine("Product: GoldenKey " + productVersion);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-------------------------------------------------\n");

            Options();
            Choice();
        }
    }
}

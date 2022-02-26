using System;

namespace Main
{
    public class Window
    {
        String productVersion;

        public Window(String version)
        {
            productVersion = version;
        }

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

                var goldenKey = new GoldenKey();
                var checkPassword = new CheckPassword();

                Console.Write("\n");

                if (choice == "1")
                {
                    goldenKey.GeneratePassw();
                }
                if (choice == "2")
                {
                    checkPassword.Check();
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
            Console.WriteLine("Product: GoldenKey " + productVersion);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-------------------------------------------------\n");

            Console.ForegroundColor = ConsoleColor.White;

            Options();
            Choice();
        }
    }
}

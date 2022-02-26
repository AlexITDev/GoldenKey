using System;

namespace Main
{
    class GeneratorUI: Generator
    {
        private static int length = 0;
        public static void GeneratePasswordLabel()
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

        private static void Show(string type)
        {
            for (int i = 0; i < 100; i++)
            {
                if (i < 10)
                    Console.WriteLine("[0" + i + "]---> " + RandomString(length, type));
                else
                    Console.WriteLine("[" + i + "]---> " + RandomString(length, type));
            }
        }

        private static void askLength()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("[+] Password length: ");
            length = Convert.ToInt32(Console.ReadLine());
        }

        public static void GeneratePasswordChoice()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n[Generator]--> ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        askLength();
                        Show(letters);
                        break;

                    case "2":
                        askLength();
                        Show(numbers);
                        GeneratePasswordLabel();
                        break;

                    case "3":
                        askLength();
                        Show(symbols);
                        GeneratePasswordLabel();
                        break;

                    case "4":
                        askLength();
                        Show(letters + numbers);
                        GeneratePasswordLabel();
                        break;

                    case "5":
                        askLength();
                        Show(symbols + numbers);
                        GeneratePasswordLabel();
                        break;

                    case "6":
                        askLength();
                        Show(letters + symbols);
                        GeneratePasswordLabel();
                        break;

                    case "7":
                        askLength();
                        Show(letters + numbers + symbols);
                        GeneratePasswordLabel();
                        break;

                    case "99":
                        Console.Clear();
                        UI.ShowLabel();
                        UI.Choice();
                        break;

                    default:
                        GeneratePasswordChoice();
                        break;
                }
            }
        }
    }
}

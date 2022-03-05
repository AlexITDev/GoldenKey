using System;

namespace Main
{
    class PasswordManagerUI: PasswordManager
    {
        public static void PasswManagerOptions()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("[01] Setup");
            Console.WriteLine("[02] Add password");
            Console.WriteLine("[03] Show passwords");
            Console.WriteLine("[04] Create Key");
            Console.WriteLine("[99] Menu");
        }

        public static void PasswManagerChoice()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n[PasswMananger]--> ");

                Console.ForegroundColor = ConsoleColor.White;
                string option = Console.ReadLine();



                switch (option)
                {
                    case "1":
                        SetupManager();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("[+] Setup complete succsessfull!");
                        break;

                    case "2":
                        FileManager.Add(GetPassword());
                        break;

                    case "3":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("[+] Write key password: ");
                        string key = Console.ReadLine();
                        string Key = System.IO.File.ReadAllText(keyPath);

                        if (key == EncodePassw(Key))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("[+] Passwords: ");
                            ShowPassw();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("<!> Key is incorrect!");
                        }
                        break;

                    case "4":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("[+] Create your key password: ");
                        string newKey = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("[+] Key created succsessfully!");
                        FileManager.CreateKey(newKey);
                        break;

                    case "99":
                        Console.Clear();
                        UI.ShowLabel();
                        UI.Choice();
                        break;

                    default:
                        PasswManagerChoice();
                        break;
                }
            }
        }

        public static string GetPassword()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("[+] Write your password: ");
            string passw = Console.ReadLine();
            return passw;
        }

        public static void ShowPassw()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string[] lines = FileManager.lines;
            foreach (string line in lines)
                Console.WriteLine(EncodePassw(line));
        }
    }
}

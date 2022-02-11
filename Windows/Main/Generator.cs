using System;
using System.Linq;

namespace Main
{
    public class GoldenKey
    {
        public void GeneratePassw()
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

            Console.Write("\n[+] Select option: ");
            string option = Console.ReadLine();

            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            string numbers = "0123456789";
            string symbols = "./^|*&?!@#()_+-=";

            Console.Write("[+] Password length: ");
            int length = Convert.ToInt32(Console.ReadLine());
            var random = new Random();

            string RandomString(int len, string type)
            {
                return new string(Enumerable.Repeat(type, len)
                    .Select(s => s[random.Next(s.Length)]).ToArray());
            }

            void Show(string type)
            {
                for (int i = 0; i < 100; i++)
                {
                    if (i < 10)
                    {
                        Console.WriteLine("[0" + i + "]---> " + RandomString(length, type));
                    }
                    else
                    {
                        Console.WriteLine("[" + i + "]---> " + RandomString(length, type));
                    }
                }
            }

            if (option == "1")
            {
                Show(letters);
            }
            else if (option == "2")
            {
                Show(numbers);
            }
            else if (option == "3")
            {
                Show(symbols);
            }
            else if (option == "4")
            {
                Show(letters + numbers);
            }
            else if (option == "5")
            {
                Show(symbols + numbers);
            }
            else if (option == "6")
            {
                Show(letters + symbols);
            }
            else if (option == "7")
            {
                Show(letters + numbers + symbols);
            }
            else
            {
                GeneratePassw();
            }
        }
    }
}
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
    class Generator {}
}
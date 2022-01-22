using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Security.Cryptography;

namespace Main
{
    
    public class GoldenKey
    {

        public void cmd(string command)
        {
            System.Diagnostics.Process.Start("CMD.exe", command);
        }
        public void GeneratePassw()
        {
            //cmd("cls");

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

            string randomString(int length, string type)
            {
                return new string(Enumerable.Repeat(type, length)
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

        public void Bruteforce()
        {

        }
    }

    public class StartWindow
    {
        private void Options()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("[01] Generate password");
            Console.WriteLine("[02] Bruteforce");
            Console.WriteLine("[03] ");
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

                Console.Write("\n");

                if (choice == "1")
                {
                    g.GeneratePassw();
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

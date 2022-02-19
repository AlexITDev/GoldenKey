using System;
using System.IO;
using System.Text;

namespace Main
{
    public class PasswordManager
    {
        string dirPath = @"C:\\PasswordManager\\";
        string filePath = @"C:\\PasswordManager\\passw.txt";
        string keyFile = @"C:\\PasswordManager\\key.txt";
        public void Manager()
        {
            Options();
            Choice();
        }

        private void Options()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("[01] Setup");
            Console.WriteLine("[02] Add password");
            Console.WriteLine("[03] Show passwords");
            Console.WriteLine("[04] Create Key");
        }

        private void Choice()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n[PasswordManager]--> ");

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    MakeFile();
                    using (FileStream file = File.Create(keyFile)) { };
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[+] Setup complete");
                }
                if (choice == "2")
                {
                    AddToFile(GetPassword());
                }
                if (choice == "3")
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("[+] Write key password: ");
                    string key = Console.ReadLine();
                    string Key = System.IO.File.ReadAllText(keyFile);

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
                }
                if (choice == "4")
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("[+] Create your key password: ");
                    string key = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("[+] Key created succsessfully!");

                    using (FileStream file = File.Create(keyFile)) { };
                    using (StreamWriter file = File.AppendText(keyFile))
                    {
                        file.WriteLine(DecodePassw(key));
                    }
                }
                else
                {
                    Choice();
                }
            }
        }

        private void MakeFile()
        {
            if (IsExist(filePath))
            {
                string passw = GetPassword();
                AddToFile(passw);
            }
            else
            {
                DirectoryInfo folder = Directory.CreateDirectory(dirPath);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("[+] The directory was created successfully at {0}.", Directory.GetCreationTime(dirPath));
            }
            using (FileStream file = File.Create(filePath)) { };
        }

        private bool IsExist(string path)
        {
            if (Directory.Exists(path))
                return true;
            else
                return false;
        }

        private string GetPassword()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("[+] Write your password: ");
            string passw = Console.ReadLine();
            return passw;
        }

        private void AddToFile(string passw)
        {
            using (StreamWriter file = File.AppendText(filePath))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                file.WriteLine(DecodePassw(passw));
                Console.WriteLine("[+] Password add successfully!");
            }
        }

        private string DecodePassw(string passw)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(passw);
            string decodedPassw = Convert.ToBase64String(bytes);
            return decodedPassw;
        }

        private string EncodePassw(string passw)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(passw);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
        private void ShowPassw()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string[] lines = System.IO.File.ReadAllLines(filePath);
            foreach (string line in lines)
                Console.WriteLine(EncodePassw(line));
        }
    }
}
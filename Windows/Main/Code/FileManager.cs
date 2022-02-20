using System;
using System.IO;

namespace Main
{
    class FileManager: PasswordManager
    {
        public static string[] lines = System.IO.File.ReadAllLines(filePath);

        public static void MakeFile(string filePath, string dirPath)
        {
            if (IsExist(filePath))
            {
                string passw = PasswordManagerUI.GetPassword();
                AddToFile(passw);
            }
            else
            {
                DirectoryInfo folder = Directory.CreateDirectory(dirPath);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("[+] The directory {0} was created successfully at {1}.", dirPath, Directory.GetCreationTime(dirPath));
            }
            using (FileStream file = File.Create(filePath)) { };
        }

        private static bool IsExist(string path)
        {
            if (Directory.Exists(path))
                return true;
            else
                return false;
        }

        public static void AddToFile(string passw)
        {
            using (StreamWriter file = File.AppendText(filePath))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                file.WriteLine(DecodePassw(passw));
                Console.WriteLine("[+] Password add successfully!");
            }
        }

        public static void CreateKey(string key)
        {
            using (FileStream file = File.Create(keyFile)) { };
            using (StreamWriter file = File.AppendText(keyFile))
            {
                file.WriteLine(DecodePassw(key));
            }
        }
    }
}

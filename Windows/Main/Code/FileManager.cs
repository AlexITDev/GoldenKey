using System;
using System.IO;

namespace Main
{
    class FileManager: PasswordManager
    {
        public static string[] lines = System.IO.File.ReadAllLines(filePath);

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
            FileStream keyfile = File.Create(keyPath);
            using (StreamWriter file = File.AppendText(keyPath))
            {
                file.WriteLine(DecodePassw(key));
            }
        }
    }
}

using System;
using System.IO;

namespace Main
{
    class FileManager: PasswordManager
    {
        public static string[] lines = System.IO.File.ReadAllLines(filePath);

        public delegate void Manager(string str);
        public static event Manager create;
        public static Manager add;

        public static void Add(string passw)
        {
            add = AddToFile;
            add(passw);
            add?.Invoke("[+] Password" + passw + " added succsessfully!");
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
            create?.Invoke(ShowData());
            FileStream keyfile = File.Create(keyPath);
            using (StreamWriter file = File.AppendText(keyPath))
            {
                file.WriteLine(DecodePassw(key));
            }
            create?.Invoke("[+] File" + keyPath + " created succsessfully!");
        }

        public static string ShowData()
        {
            string status = $"Current directory: {Environment.CurrentDirectory}";
            return status;
        }
            
    }
}

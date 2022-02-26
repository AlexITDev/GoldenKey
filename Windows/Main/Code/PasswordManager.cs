using System;
using System.IO;
using System.Text;

namespace Main
{
    public class PasswordManager
    {
        public static string dirPath = @"C:\PasswordManager\";
        public static string filePath = @"C:\PasswordManager\passw.txt";
        public static string keyPath = @"C:\PasswordManager\key.txt";

        public static string DecodePassw(string passw)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(passw);
            string decodedPassw = Convert.ToBase64String(bytes);
            return decodedPassw;
        }

        public static string EncodePassw(string passw)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(passw);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static void SetupManager()
        {
            DirectoryInfo folder = Directory.CreateDirectory(dirPath);
            FileStream file = File.Create(filePath);
            FileStream keyfile = File.Create(keyPath);
        }
    }
}
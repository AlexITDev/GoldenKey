using System;
using System.IO;
using System.Text;

namespace Main
{
    public class PasswordManager
    {
        public static string dirPath = @"C:\\PasswordManager\\";
        public static string filePath = @"C:\\PasswordManager\\passw.txt";
        public static string keyFile = @"C:\\PasswordManager\\key.txt";

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
            FileManager.MakeFile(filePath, dirPath);
            using (FileStream file = File.Create(keyFile)) { };
        }
    }
}
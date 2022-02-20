using System;
using System.Linq;

namespace Main
{
    public class Generator
    {
        static Random random = new Random();

        public static string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        public static string numbers = "0123456789";
        public static string symbols = "./^|*&?!@#()_+-=";

        public static string RandomString(int length, string type)
        {
            return new string(Enumerable.Repeat(type, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
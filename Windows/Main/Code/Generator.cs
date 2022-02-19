using System;
using System.Linq;

namespace Main
{
    public class Generator
    {
        Random random = new Random();

        public string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        public string numbers = "0123456789";
        public string symbols = "./^|*&?!@#()_+-=";

        public string RandomString(int len, string type)
        {
            return new string(Enumerable.Repeat(type, len)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
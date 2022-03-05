
namespace ExtentionMethods
{
    public static class Extend
    {
        public static int Len(this string str)
        {
            return str.Length;
        }

        public static string Upper(this string str)
        {
            return str.ToUpper();
        }

        public static bool Existance(this string str, string parametr)
        {
            return str.Contains(parametr);
        }
    }
}

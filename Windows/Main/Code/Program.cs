using System;

namespace Main
{ 
    class Program
    {
        static void Main(string[] args)
        {
            String productVersion = "v0.1.0";
            var s = new Window(productVersion);
            s.Title();
        }
    }
}

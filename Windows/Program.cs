using System;

namespace Main
{ 
    class Program
    {
        static void Main(string[] args)
        {
            String productVersion = "v0.0.7";
            var s = new Window(productVersion);
            s.Title();
        }
    }
}

using System;

namespace Main
{ 
    class Program
    {
        static void Main(string[] args)
        {
            string productVersion = "v0.1.0";
            
            var ui = new UI();
            ui.ShowLabel(productVersion);
        }
    }
}
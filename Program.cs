using System;
using System.Threading;

namespace New_folder
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.ForegroundColor = ConsoleColor.Green;
            var spinner = new Spinner();

            spinner.Start();
            
            Thread.Sleep(10000);

            spinner.Stop();
            Console.ForegroundColor = ConsoleColor.White;
        }     

        
        
    }
}

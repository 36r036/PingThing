using System;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;

namespace New_folder
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IWriter, Writer>()
                .AddSingleton<ISpinner, Spinner>()
                .BuildServiceProvider();

            var spinner = serviceProvider.GetRequiredService<ISpinner>();
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Hello World!");

            spinner.Start();
            
            Thread.Sleep(10000);
            spinner.Stop();
            Console.ForegroundColor = ConsoleColor.White;
        } 

        
        
    }
}

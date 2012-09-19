
using Gateway;
using System;
using TestApplication.Tasks;
namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine.BaseTitle = "Gateway";
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Engine.Start();  
        }
    }
}


using System;
using Gateway;
using Gateway.Rules;
namespace TestApplication.Tasks
{
    public class Task7 
    {
        public void Process()
        {
            int hrana = Input<int>.Get("Zadejte čislo.");

            Console.WriteLine("Číslo je " + (hrana % 2 == 0 ? "sudé" : "liché"));
            Console.WriteLine("Číslo je " + ((hrana & 1) != 1 ? "sudé" : "liché"));
        }
    }
}

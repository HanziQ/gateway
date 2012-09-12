using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gateway;

namespace TestApplication
{
    public class TaskList : ITaskList
    {
        public void Task1()
        {
            Console.WriteLine("Zadejte délku hrany krychle.");
            string input = Console.ReadLine();
            int hrana;
            if (int.TryParse(input, out hrana))
            {
                if (hrana > 0)
                {
                    Console.WriteLine("Objem: " + (hrana * hrana * hrana).ToString());
                    Console.WriteLine("Povrch: " + (6 * hrana * hrana).ToString());
                    Console.WriteLine("Stěnová úhlopříčka: " + (Math.Sqrt(2) * hrana).ToString());
                    Console.WriteLine("Tělesová úhlopříčka: " + (Math.Sqrt(3) * hrana).ToString());
                }
                else
                {
                    Console.WriteLine("Délka hrany musí být kladná.");
                }
            }
            else
            {
                Console.WriteLine("Délka hrany musí být číslo.");
            }
            Console.ReadLine();
        }

        public void Task2()
        {
            Console.WriteLine("Zadejte poloměr kruhu.");
            string input = Console.ReadLine();
            int radius;
            if (int.TryParse(input, out radius))
            {

            }
            else
            {
                Console.WriteLine("Poloměr musí být číslo.");
            }


            Console.ReadLine();
        }
    }
}

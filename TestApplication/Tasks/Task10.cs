using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gateway;

namespace TestApplication.Tasks
{
    public class Task10 
    {
        public void Process()
        {
            Console.WriteLine("Pro lineární rovnici ax + b = 0 :");
            int a = Input<int>.Get("Zadejte a.");
            int b = Input<int>.Get("Zadejte b.");
            if (a == 0)
            {
                if (b == 0)
                {
                    Console.WriteLine("Rovnice má nekonečně mnoho řešení.");
                }
                else
                {
                    Console.WriteLine("Rovnice nemá řešení.");
                }
            }
            else
            {
                Console.WriteLine("Rovnice má 1 řešení : " + -((float)b / a));
            }
        }
    }
}

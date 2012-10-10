using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gateway;

namespace TestApplication.Tasks
{
    public class Task11 : ITask
    {
        public void Process()
        {
            Console.WriteLine("Pro kvadratickou rovnici ax^2 + bx + c = 0 :");
            float a = Input<int>.Get("Zadejte a.");
            float b = Input<int>.Get("Zadejte b.");
            float c = Input<int>.Get("Zadejte c.");

            Console.WriteLine(a + "x^2 + " + b + "x + " + c + " = 0");

            if (a == 0)
            {
                Engine.WriteErrorLine("Toto není kvadratická rovnice.");
                return;
            }

            float D = b * b - 4 * a * c;
            if (D >= 0)
            {
                float Dsqrt = (float)Math.Sqrt(D);
                float result1 = (-b + Dsqrt) / (2 * a);
                float result2 = (-b - Dsqrt) / (2 * a);

                if (D > 0)
                {
                    Console.WriteLine("Rovnice má 2 kořeny : " + result1 + " a " + result2 + ".");
                }
                else
                {
                    Console.WriteLine("Rovnice má 1 dvojitý kořen : " + result1 + ".");
                }
            }
            else
            {
                Console.WriteLine("Rovnice nemá řešení.");
            }
        }
    }
}

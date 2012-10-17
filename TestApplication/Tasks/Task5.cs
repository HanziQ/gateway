using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gateway;
using Gateway.Rules;

namespace TestApplication.Tasks
{
    public class Task6 
    {
        public void Process()
        {
            float x = Input<float>.Get("Zadejte x.");
            Console.WriteLine("Výsledek je: " + (Math.Sin(Math.Sqrt(x)) + 3) / (x * x - 1));
        }
    }
}

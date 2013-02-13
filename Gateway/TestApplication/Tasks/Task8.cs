using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gateway;
using Gateway.Rules;

namespace TestApplication.Tasks
{
    class Task8 
    {
        public void Process()
        {
            int N = Input<int>.Get("Zadejte horní hranici pro náhodné číslo.").AddRule(IntegerRule.Positive);
            Random r = new Random();
            int randomInt = r.Next(0, N);
            int I = Input<int>.Get("Zadejte váš tip.").AddRule(IntegerRule.Positive).AddRule(new Rule<int>((i) => { return i <= N; }, "Číslo musí být menší než zadaná horní hranice - " + N));
            if (I == randomInt)
            {
                Console.WriteLine("Uhodli jste!");
            }
            else
            {
                Console.WriteLine("Neuhodli jste, vygenerované číslo bylo - " + randomInt);
            }
        }
    }
}

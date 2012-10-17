using System;
using System.Collections.Generic;
using Gateway;

namespace TestApplication.Tasks
{
    public class Task13
    {
        public void Process()
        {
            int mesic = Input<int>.Get("Zadejte počet dní v měsíci.").AddRule(new Rule<int>((i) => { return i >= 28 & i <= 31; }, "Zadejte platný počet dnů."));
            int prvniDen = Input<int>.Get("Zadejte číslo prvního dne v měsíci.").AddRule(new Rule<int>((i) => { return i > 0 & i < 8; }, "Zadejte platné číslo."));

            int prvniPatek = (prvniDen < 6) ? 6 - prvniDen : 13 - prvniDen;
            List<string> patky = new List<string>();
            patky.Add(prvniPatek.ToString());
            int den = prvniPatek;

            while (den <= mesic - 7)
            {
                den += 7;
                patky.Add(den.ToString());
            }
            Console.WriteLine("Počet pátků v tomto měsíci je: " + patky.Count + " - " + string.Join("., ", patky) + ".");
        }
    }
}

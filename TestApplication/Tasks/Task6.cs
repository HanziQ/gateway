using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gateway;
using Gateway.Rules;

namespace TestApplication.Tasks
{
    public class Task5 : ITask
    {
        public void Process()
        {
            List<int> bankovky = new List<int>() { 1, 2, 5, 10, 20, 50, 100, 200, 500, 1000, 2000, 5000};
            Dictionary<int, int> pocty = new Dictionary<int, int>();
            bankovky.Reverse();
            bankovky.ForEach((h) => { pocty.Add(h, 0); });
            int castka = Input<int>.Get("Zadejte částku.").AddRule(IntegerRule.NonNegative);
            while (castka != 0)
            {
                foreach (int h in bankovky)
                {
                    if (h <= castka)
                    {
                        pocty[h]++;
                        castka -= h;
                        break;
                    }
                }
            }
            Console.WriteLine("Potřebné počty mincí a bankovek jsou:");
            foreach (KeyValuePair<int, int> pair in pocty)
            {
                if(pair.Value != 0)
                Console.WriteLine(pair.Value.ToString() + "x " + pair.Key.ToString());
            }
        }
    }
}

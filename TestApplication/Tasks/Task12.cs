using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gateway;
using Gateway.Rules;

namespace TestApplication.Tasks
{
    public class Task12 : ITask
    {
        public void Process()
        {
            Dictionary<int, int> vydaje = new Dictionary<int, int>();
            vydaje.Add(1, Input<int>.Get("Zadejte výdaje za 1. čtvrtletí.").AddRule(IntegerRule.NonNegative));
            vydaje.Add(2, Input<int>.Get("Zadejte výdaje za 2. čtvrtletí.").AddRule(IntegerRule.NonNegative));
            vydaje.Add(3, Input<int>.Get("Zadejte výdaje za 3. čtvrtletí.").AddRule(IntegerRule.NonNegative));
            vydaje.Add(4, Input<int>.Get("Zadejte výdaje za 4. čtvrtletí.").AddRule(IntegerRule.NonNegative));

            KeyValuePair<int, int> maxPair = vydaje.First();
            foreach (KeyValuePair<int, int> pair in vydaje)
            {
                if (pair.Value > maxPair.Value)
                    maxPair = pair;
            }

            Console.WriteLine("Největší výdaje byly v " + maxPair.Key + ". období - " + maxPair.Value + ".");
        }
    }
}

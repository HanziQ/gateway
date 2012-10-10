using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gateway.Rules;
using Gateway;

namespace TestApplication.Tasks
{
    public class Task4 : ITask
    {
        public void Process()
        {
            int czk = Input<int>.Get("Zadejte cenu zboží v Kč.").AddRule(IntegerRule.NonNegative);
            float kurz = Input<float>.Get("Zadejde kurz (kolik Kč je 1 €).").AddRule(FloatRule.Positive);

            Console.WriteLine("Cena zboží v € je: " + czk / kurz);
        }
    }
}

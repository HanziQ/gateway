using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gateway;
using Gateway.Rules;

namespace TestApplication.Tasks
{
    public class Task2 : ITask
    {
        public void Process()
        {
            int polomer = Input<int>.Get("Zadejte poloměr kruhu.").AddRule(IntegerRule.Positive);

            Engine.Body.AddLine("Obvod kruhu je: " + Math.PI * 2 * polomer);
            Engine.Body.AddLine("Obsah kruhu je: " + Math.PI * polomer * polomer);

            Console.ReadLine();
        }
    }
}

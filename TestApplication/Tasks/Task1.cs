
using System;
using Gateway;
using Gateway.Rules;
namespace TestApplication.Tasks
{
    public class Task1 : ITask
    {
        public void Process()
        {
            int hrana = Input<int>.Get("Zadejte délku hrany krychle.").AddRule(IntegerRule.Positive);

            Engine.Body.AddLine("Objem: " + (hrana * hrana * hrana).ToString());
            Engine.Body.AddLine("Povrch: " + (6 * hrana * hrana).ToString());
            Engine.Body.AddLine("Stěnová úhlopříčka: " + (Math.Sqrt(2) * hrana).ToString());
            Engine.Body.AddLine("Tělesová úhlopříčka: " + (Math.Sqrt(3) * hrana).ToString());

            Console.ReadLine();
        }
    }
}


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

            Console.WriteLine("Objem: " + (hrana * hrana * hrana).ToString());
            Console.WriteLine("Povrch: " + (6 * hrana * hrana).ToString());
            Console.WriteLine("Stěnová úhlopříčka: " + (Math.Sqrt(2) * hrana).ToString());
            Console.WriteLine("Tělesová úhlopříčka: " + (Math.Sqrt(3) * hrana).ToString());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gateway;
using Gateway.Rules;

namespace TestApplication.Tasks
{
    public class Task3 : ITask
    {
        public void Process()
        {
            float ca = Input<float>.Get("Zadejte úsek přepony přilehlý ke straně a.").AddRule(FloatRule.Positive);
            float cb = Input<float>.Get("Zadejte úsek přepony přilehlý ke straně b.").AddRule(FloatRule.Positive);

            Engine.Body.AddLine("Výška trojúhelníku na stranu c je: " + Math.Sqrt(ca * cb));
            Engine.Body.AddLine("Strana a má délku: " + Math.Sqrt(ca * (ca + cb)));
            Engine.Body.AddLine("Strana b má délku: " + Math.Sqrt(cb * (ca + cb)));
            Console.ReadLine();
        }
    }
}

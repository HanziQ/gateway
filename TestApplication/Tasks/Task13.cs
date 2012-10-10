using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gateway;
using Gateway.Rules;

namespace TestApplication.Tasks
{
    public class Task13 : ITask
    {
        public void Process()
        {
            int mesic = Input<int>.Get("Zadejte počet dní v měsíci.").AddRule(new Rule<int>((i) => {return i >= 28 & i <=31;}, "Zadejte platný počet dnů."));
            int prvniDen = Input<int>.Get("Zadejte číslo prvního dne v měsíci.").AddRule(new Rule<int>((i) => { return i > 0 & i < 8; }, "Zadejte platné číslo."));

            //int prvniPatek = (prvniDen < 6) ? 6 - prvniDen : 
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gateway.Rules
{
    public class StringRule
    {
        public static Rule<string> NotEmpty = new Rule<string>(i => i != "", "Zadaný řetezec nesmí být prázdný.");
    }
}

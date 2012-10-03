
using System;
using System.Collections.Generic;
namespace Gateway
{
    public class Input<T> where T : struct
    {
        string message;
        List<Rule<T>> rules = new List<Rule<T>>();

        public static Input<T> Get(string message)
        {
            return new Input<T>(message);
        }

        private Input(string message)
        {
            this.message = message;
        }

        public Input<T> AddRule(Rule<T> rule)
        {
            rules.Add(rule);
            return this;
        }

        public static implicit operator T(Input<T> input)
        {
            return input.Process();
        }

        public T Process()
        {
            Engine.Body.AddLine(message);
            while (true)
            {
                string input = Engine.ReadLine();
                Engine.Body.AddLine("> " + input);
                T value = default(T);
                    
                value = (T)Convert.ChangeType(input, typeof(T));

                List<RuleException> exceptions = new List<RuleException>();

                foreach (Rule<T> r in rules)
                {
                    try
                    {
                        r.Evaluate(value);
                    }
                    catch (RuleException e)
                    {
                        exceptions.Add(e);
                    }
                }
                if (exceptions.Count == 0)
                {
                    return value;
                }
                else
                {
                    ConsoleEx.TextColor(ConsoleForeground.White, ConsoleBackground.Red);
                    foreach (RuleException e in exceptions)
                    {                        
                        Engine.Body.AddLine(e.Message);
                    }
                    ConsoleEx.ResetColor();
                }
            }
        }
    }
}

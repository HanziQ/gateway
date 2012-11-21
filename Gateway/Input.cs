
using System;
using System.Collections.Generic;
using Gateway.Rules;
namespace Gateway
{
    public class Input<T>
    {
        static Dictionary<Type, string> typeRules = new Dictionary<Type, string>()
        {
            {typeof(int), "Zadejte celé číslo."},
            {typeof(float), "Zadejte číslo."}
        };

        string message;
        List<Rule<T>> rules = new List<Rule<T>>();

        public static Input<T> Get()
        {
            return new Input<T>();
        }

        public static Input<T> Get(string message)
        {
            return new Input<T>(message);
        }

        private Input()
        {

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
            if (message != null && message.Length > 0)
                Console.WriteLine(message);

            while (true)
            {
                string input;

                input = Engine.ReadLine();

                T value = default(T);
                try
                {
                    value = (T)Convert.ChangeType(input, typeof(T));
                }
                catch (FormatException)
                {
                    if (typeRules.ContainsKey(typeof(T)))
                    {
                        Engine.WriteErrorLine(typeRules[typeof(T)]);
                    }
                    continue;
                }
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
                        Console.WriteLine(e.Message);
                    }
                    ConsoleEx.ResetColor();
                }
            }
        }
    }
}

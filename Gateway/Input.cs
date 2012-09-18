
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
            while (true)
            {
                string input = "";// Main.ReadLine();
                T value = (T)Convert.ChangeType(input, typeof(T));

                List<Rule<T>> failedRules = new List<Rule<T>>();

                foreach (Rule<T> r in rules)
                {
                    try
                    {
                        r.Evaluate(value);
                    }
                    catch (RuleException e)
                    {

                    }
                }
                if (failedRules.Count == 0)
                {
                    return value;
                }
                else
                {

                }
            }
        }
    }
}

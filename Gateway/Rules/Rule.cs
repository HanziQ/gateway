
using System;
namespace Gateway.Rules
{
    public interface IRule { }

    public class Rule<T> : IRule
    {
        string message;
        Predicate<T> predicate;

        public Rule(Predicate<T> predicate, string message)
        {
            this.predicate = predicate;
            this.message = message;
        }

        public virtual bool Evaluate(T value)
        {
            if (predicate(value))
            {
                return true;
            }
            else
            {
                throw new RuleException(message);
            }
        }
    }

    public class RuleException : Exception
    {
        public RuleException(string msg)
            : base(msg)
        { }
    }
}


namespace Gateway.Rules
{
    public class IntegerRule
    {
        public static Rule<int> Positive = new Rule<int>(i => i > 0, "The number must be positive.");
        /*public const Rule<int> NonPositive = new Rule<int>(i => i <= 0, "The number must not be positive.");
        public const Rule<int> Negative = new Rule<int>((i) => i < 0, "The number must be negative.");
        public const Rule<int> NonNegative = new Rule<int>((i) => i >= 0, "The number must not be negative.");
        public const Rule<int> Zero = new Rule<int>((i) => i == 0, "The number must be zero.");*/
    }
}

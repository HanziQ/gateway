
namespace Gateway.Rules
{
    public class FloatRule
    {
        public static Rule<float> Positive = new Rule<float>(i => i > 0, "The number must be positive.");
        public static Rule<float> NonPositive = new Rule<float>(i => i <= 0, "The number must not be positive.");
        public static Rule<float> Negative = new Rule<float>((i) => i < 0, "The number must be negative.");
        public static Rule<float> NonNegative = new Rule<float>((i) => i >= 0, "The number must not be negative.");
        public static Rule<float> Zero = new Rule<float>((i) => i == 0, "The number must be zero.");
    }
}

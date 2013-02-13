
namespace Gateway.Rules
{
    public class FloatRule
    {
        public static Rule<float> Positive = new Rule<float>(i => i > 0, "Zadané číslo musí být kladné.");
        public static Rule<float> NonPositive = new Rule<float>(i => i <= 0, "Zadané číslo musí být nekladné.");
        public static Rule<float> Negative = new Rule<float>((i) => i < 0, "Zadané číslo musí být záporné.");
        public static Rule<float> NonNegative = new Rule<float>((i) => i >= 0, "Zadané číslo musí být nezáporné.");
        public static Rule<float> Zero = new Rule<float>((i) => i == 0, "Zadané číslo musí být nula.");
        public static Rule<float> NonZero = new Rule<float>((i) => i != 0, "Zadané číslo nesmí být nula.");
    }
}

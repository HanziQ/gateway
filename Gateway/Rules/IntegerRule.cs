
namespace Gateway.Rules
{
    public class IntegerRule
    {
        public static Rule<int> Positive = new Rule<int>(i => i > 0, "Zadané číslo musí být kladné.");
        public static Rule<int> NonPositive = new Rule<int>(i => i <= 0, "Zadané číslo musí být nekladné.");
        public static Rule<int> Negative = new Rule<int>((i) => i < 0, "Zadané číslo musí být záporné.");
        public static Rule<int> NonNegative = new Rule<int>((i) => i >= 0, "Zadané číslo musí být nezáporné.");
        public static Rule<int> Zero = new Rule<int>((i) => i == 0, "Zadané číslo musí být nula.");
        public static Rule<int> NonZero = new Rule<int>((i) => i != 0, "Zadané číslo nesmí být nula.");
    }
}

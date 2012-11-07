using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gateway;
using Gateway.Rules;
using System.Text.RegularExpressions;

namespace TestApplication.Tasks
{
    public class Tasks
    {
        public void Process14()
        {
            int mesic = Input<int>.Get("Zadejte počet dní v měsíci.").AddRule(new Rule<int>((i) => { return i >= 28 & i <= 31; }, "Zadejte platný počet dnů."));
            int den = Input<int>.Get("Zadejte číslo prvního dne v měsíci.").AddRule(new Rule<int>((i) => { return i > 0 & i < 8; }, "Zadejte platné číslo."));

            int pracovni = 0;

            for (int i = 1; i <= mesic; i++)
            {
                if (den < 6)
                    pracovni++;
                den++;
                if (den > 7)
                    den = 1;
            }

            Console.WriteLine("V tomto měsíci je " + pracovni.ToString() + " pracovních dnů.");
        }

        public void Process15()
        {
            int count = Input<int>.Get("Zadejte počet tříd.").AddRule(IntegerRule.Positive);

            List<int> tridy = new List<int>();
            for (int i = 1; i <= count; i++)
            {
                tridy.Add(Input<int>.Get("Zadejte počet žáků ve třídě " + i.ToString() + ".").AddRule(IntegerRule.Positive));
            }
            Console.WriteLine("Průměrný počet žáků ve třídě je " + tridy.Average().ToString() + ".");
        }

        public void Process16()
        {
            int count = Input<int>.Get("Zadejte počet čísel.").AddRule(IntegerRule.Positive);

            List<int> cisla = new List<int>();
            for (int i = 1; i <= count; i++)
            {
                cisla.Add(Input<int>.Get("zadejte " + i.ToString() + ". číslo."));
            }

            bool lichaPozice = true;
            float liche = 0, licheCount = 0, sude = 0, sudeCount = 0;

            foreach (int i in cisla)
            {
                if (lichaPozice)
                {
                    liche += i;
                    licheCount++;
                }
                else
                {
                    sude += i;
                    sudeCount++;
                }
                lichaPozice = !lichaPozice;
            }

            Console.WriteLine("Průměr čísel na lichých pozicích je " + liche / licheCount + ", na sudých pozicích " + sude / sudeCount + ".");
        }

        public void Process17()
        {
            float x = Input<float>.Get("Zadejte x.");
            int n = Input<int>.Get("Zadejte n.");
            Console.WriteLine("Mocnina (" + x + ")^(" + n + ") je rovna číslu " + Math.Pow(x, n) + ".");
        }

        Int64[] factors64 = { 0, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880, 3628800, 39916800, 479001600, 6227020800, 87178291200, 1307674368000, 20922789888000, 355687428096000, 6402373705728000, 121645100408832000, 2432902008176640000 };

        public void Process18()
        {
            int n = Input<int>.Get("Zadejte n pro n!.").AddRule(IntegerRule.Positive).AddRule(new Rule<int>((i) => { return i <= 20; }, "n musí být menší než 21 (kvůli limitu velikosti čísla)"));
            Console.WriteLine("n! = " + factors64[n]);
        }

        public void Process19()
        {
            int n = Input<int>.Get("Zadejte n.").AddRule(IntegerRule.Positive);
            float soucet = 0;

            for (int i = 1; i <= n; i++)
            {
                soucet += 1f / i;
            }

            Console.WriteLine("Součet převrácených hodnot je " + soucet + ".");
        }

        public void Process20()
        {
            int n, k;
            do
            {
                n = Input<int>.Get("Zadejte n.").AddRule(IntegerRule.NonNegative).AddRule(new Rule<int>((i) => { return i < 20; }, "n musí být menší než 21 (kvůli limitu velikosti čísla)"));
                k = Input<int>.Get("Zadejte k.").AddRule(IntegerRule.NonNegative).AddRule(new Rule<int>((i) => { return i < 20; }, "k musí být menší než 21 (kvůli limitu velikosti čísla)"));
                if (n < k)
                    Console.WriteLine("n musí být větší než k");
                else
                    break;
            }
            while (true);

            float res = ((float)factors64[n]) / (factors64[k] * factors64[n - k]);
            if (k == 0 || n == k)
                res = 1;

            Console.WriteLine("Kombinační číslo C(" + n + "," + k + ") = " + res + ".");

        }

        public void Process21()
        {
            List<int> nums = new List<int>();
            for (int i = 1; i <= 9; i++)
            {
                for (int k = 1; k <= 9; k++)
                {
                    if (i == k)
                        continue;
                    for (int j = 1; j <= 9; j++)
                    {
                        if (k == j)
                            continue;
                        nums.Add(100 * i + 10 * k + j);
                    }
                }
            }

            Console.WriteLine(string.Join(",", nums.ConvertAll<string>(x => x.ToString())));
            Console.WriteLine("Čísel je " + nums.Count + ".");

        }

        public void Process22()
        {
            List<int> nums = new List<int>();
            for (int a = 1; a <= 9; a++)
            {
                for (int b = 1; b <= 9; b++)
                {
                    for (int c = 1; c <= 9; c++)
                    {
                        for (int d = 1; d <= 9; d++)
                        {
                            if (((a == b) & (b == c)) | ((a == b) & (b == d)) | ((a == c) & (c == d)) | ((b == c) & (c == d)))
                                nums.Add(1000 * a + 100 * b + 10 * c + d);
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(",", nums.ConvertAll<string>(x => x.ToString())));
            Console.WriteLine("Čísel je " + nums.Count + ".");
        }

        public void Process23()
        {
            List<int> nums = new List<int>();
            int n = Input<int>.Get("Zadejte n.").AddRule(IntegerRule.Positive);
            for (int i = 1; i < n; i++)
            {
                bool pass = true;
                foreach (int d in Array.ConvertAll<string, int>(Regex.Split(i.ToString(), @"(?!^)(?!$)"), str => int.Parse(str)))
                {
                    if (d != 2 & d != 3 & d != 5)
                        pass = false;
                }
                if (pass)
                    nums.Add(i);
            }

            Console.WriteLine(string.Join(",", nums.ConvertAll<string>(x => x.ToString())));
        }

        public void Process24()
        {
            Console.WriteLine("Zadejte ceny nákupů, ukončete sekvenci nulou.");

            List<int> nums = new List<int>();
            while (true)
            {
                int i = Input<int>.Get("").AddRule(IntegerRule.NonNegative);
                if (i == 0)
                    break;
                nums.Add(i);
            }
            Console.WriteLine("Průměrná cena nákupu je " + nums.Average() + ".");
        }

        public void Process25()
        {
            Console.WriteLine("Zadejte čísla, ukončete nulou.");

            int count = 0;
            while (true)
            {
                int i = Input<int>.Get("").AddRule(IntegerRule.NonNegative);
                if (i == 0)
                    break;
                if (i % 3 == 0 & i % 2 == 1)
                    count++;
            }

            Console.WriteLine("Počet lichých násobků tří v dané posloupnosti je " + count + ".");
        }


        public void Process26()
        {
            List<int> cjl = new List<int>();
            List<int> mat = new List<int>();
            List<int> anj = new List<int>();
            int n = 1;

            while (true)
            {
                Console.WriteLine("Zadejte známky pro žáka " + n);
                int c = Input<int>.Get("CJL").AddRule(IntegerRule.NonNegative).AddRule(new Rule<int>((z) => { return z <= 5; }, "Známka musí být menší než 6."));
                int m = Input<int>.Get("MAT").AddRule(IntegerRule.NonNegative).AddRule(new Rule<int>((z) => { return z <= 5; }, "Známka musí být menší než 6."));
                int a = Input<int>.Get("ANJ").AddRule(IntegerRule.NonNegative).AddRule(new Rule<int>((z) => { return z <= 5; }, "Známka musí být menší než 6."));
                if (c == 0 & m == 0 & a == 0)
                    break;
                cjl.Add(c);
                mat.Add(m);
                anj.Add(a);
                n++;
            }
            Console.WriteLine("Průměrný prospěch z ANJ je " + anj.Average() + ".");
            Console.WriteLine("Jedniček z CJL je " + cjl.Count((i) => { return i == 1; }) + ", z MAT " + mat.Count((i) => { return i == 1; }) + " a z ANJ " + anj.Count((i) => { return i == 1; }) + ".");

            int same1 = 0;
            int zadna45 = 0;
            for (int i = 0; i < cjl.Count; i++)
            {
                int c = cjl[i];
                int a = anj[i];
                int m = mat[i];
                if (c == 1 & m == 1 & a == 1)
                    same1++;
                if (c < 4 & m < 4 & a < 4)
                    zadna45++;
            }
            Console.WriteLine("Počet žáků, kteří mají jedničku ze všech tří předmětů je " + same1 + ".");
            Console.WriteLine("Počet žáků, kteří nemají žádnou čtyřku ani pětku je " + zadna45 + ".");

        }

        public void Process27()
        {
            Console.WriteLine("Zadejte hodnoty vkladů.");
            List<float> vklady = new List<float>();
            while (true)
            {
                int i = Input<int>.Get(null).AddRule(IntegerRule.NonZero);
                if (i < 0)
                    break;
                vklady.Add(1.04f * (float)i);
            }

            Console.WriteLine("Vklady po jednom roce činí:");
            foreach (float f in vklady)
            {
                Console.WriteLine(f.ToString("F2"));
            }
        }

        public void Process28()
        {
            string input = Input<String>.Get("Zadejte větu.").AddRule(new Rule<String>((s) => { return s[s.Length - 1] == '.'; }, "Věta musí končit tečkou."));
            input = input.Trim('.', ' ');

            int a = 0;
            int capital = 0;

            foreach (char c in input)
            {
                if (c == 'a' || c == 'A')
                    a++;
                if (char.IsUpper(c))
                    capital++;
            }

            Console.WriteLine("Počet slov - " + input.Split(' ').Count());
            Console.WriteLine("Počet písmen 'a' - " + a);
            Console.WriteLine("Počet velkých písmen - " + capital);
        }

        public void Process29()
        {
            List<int> cisla = new List<int>();
            int nejvetsi = int.MinValue;
            while (true)
            {
                int i = Input<int>.Get("").AddRule(IntegerRule.NonNegative);
                if (i == 0)
                    break;
                cisla.Add(i);
                if (i > nejvetsi)
                    nejvetsi = i;
            }

            Console.WriteLine("Počet největších čísel v posloupnosti je - " + cisla.Count((i) => { return i == nejvetsi; }));
        }

        public void Process30()
        {
            int maxInt = 0; ;
            int maxAbs = int.MinValue;
            while (true)
            {
                int i = Input<int>.Get("");
                if (i == 0)
                    break;
                if (Math.Abs(i) > maxAbs)
                {
                    maxInt = i;
                    maxAbs = Math.Abs(i);
                }
            }

            Console.WriteLine("Číslo s největší absolutní hodnotou je - " + maxInt);
        }

        public void Process31()
        {
            List<int> nums = new List<int>();
            while (true)
            {
                int i = Input<int>.Get("");
                if (i == 0)
                    break;
                nums.Add(i);
            }
            if (nums.Count == 0)
                return;
            int minDist = Math.Abs(100 - nums[0]);
            List<int> closestNums = new List<int>() { nums[0] };
            nums.RemoveAt(0);
            foreach (int k in nums)
            {
                if (Math.Abs(100 - k) < minDist)
                {
                    minDist = Math.Abs(100 - k);
                    closestNums.Clear();
                    closestNums.Add(k);
                }
                else if (Math.Abs(100 - k) == minDist)
                {
                    if (!closestNums.Contains(k))
                        closestNums.Add(k);
                }
            }

            Console.WriteLine("Čísla nejbližší číslu 100 jsou:");
            Console.WriteLine(string.Join(", ", closestNums));
        }

        public void Process32()
        {
            List<int> nums = new List<int>();
            for (int i = 1; i <= 20; i++)
            {
                nums.Add(Input<int>.Get(i + ". číslo").AddRule(new Rule<int>((n) => { return !nums.Contains(n); }, "Toto číslo jste už zadali.")));
            }

            nums.Remove(nums.Max());
            Console.WriteLine("Druhé největší číslo je " + nums.Max());
        }

        public void Process33()
        {
            string s = Input<string>.Get("Zadejte větu.");
            SortedDictionary<char, int> counts = new SortedDictionary<char, int>();
            foreach (char c in s)
            {
                if (!char.IsLetter(c))
                    continue;
                if (counts.ContainsKey(c))
                    counts[c]++;
                else
                    counts.Add(c, 1);
            }
            Console.WriteLine("Četnost písmen:");

            foreach (KeyValuePair<char, int> pair in counts)
            {
                Console.WriteLine(pair.Key + " - " + pair.Value);
            }
        }

        public void Process34()
        {
            int w = Input<int>.Get("Zadejte počet sloupců.").AddRule(IntegerRule.Positive);
            int h = Input<int>.Get("Zadejte počet řádků.").AddRule(IntegerRule.Positive);

            IntegerTable table = new IntegerTable(w, h);

            for (int i = 0; i < h; i++)
            {
                string line = Input<string>.Get("Zadejte čísla pro řádek " + (i + 1) + ", oddělte čárkou.").AddRule(new Rule<string>((s) => { return s.Split(',').Count() == w; }, "Počet sloupců musí být " + w));

                int column = 0;
                foreach (string s in line.Split(','))
                {
                    int n;
                    if (int.TryParse(s, out n))
                    {
                        table[i, column] = n;
                    }
                    else
                    {
                        Console.WriteLine("Neplatný vstup.");
                        return;
                    }
                    column++;
                }
            }

            table.PrintToConsole();
        }

        public void Process35()
        {
            int w = Input<int>.Get("Zadejte počet sloupců.").AddRule(IntegerRule.Positive);
            int h = Input<int>.Get("Zadejte počet řádků.").AddRule(IntegerRule.Positive);

            IntegerTable table = new IntegerTable(h, w);

            for (int i = 0; i < h; i++)
            {
                string line = Input<string>.Get("Zadejte čísla pro řádek " + (i + 1) + ", oddělte čárkou.").AddRule(new Rule<string>((s) => { return s.Split(',').Count() == w; }, "Počet sloupců musí být " + w));

                int column = 0;
                foreach (string s in line.Split(','))
                {
                    int n;
                    if (int.TryParse(s, out n))
                    {
                        table[i, column] = n;
                    }
                    else
                    {
                        Console.WriteLine("Neplatný vstup.");
                        return;
                    }
                    column++;
                }
            }

            table.PrintToConsoleWithMaxMin();
        }

        public void Process36()
        {
            int size = Input<int>.Get("Zadejte velikost tabulky.").AddRule(IntegerRule.Positive);

            IntegerTable table = new IntegerTable(size);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (j == i)
                        table[j, i] = 1;
                    else
                        table[j, i] = 0;
                }
            }

            table.PrintToConsole();
        }
        public void Process37()
        {
            int size = Input<int>.Get("Zadejte velikost tabulky.").AddRule(IntegerRule.Positive);
            IntegerTable table = new IntegerTable(size);
            for (int i = 0; i < size; i++)
            {
                string line = Input<string>.Get("Zadejte čísla pro řádek " + (i + 1) + ", oddělte čárkou.").AddRule(new Rule<string>((s) => { return s.Split(',').Count() == size; }, "Počet sloupců musí být " + size));
                int column = 0;
                foreach (string s in line.Split(','))
                {
                    int n;
                    if (int.TryParse(s, out n))
                    {
                        table[i, column] = n;
                    }
                    else
                    {
                        Console.WriteLine("Neplatný vstup.");
                        return;
                    }
                    column++;
                }
            }

            for (int i = 0; i < size; i++)
            {
                int temp = table[i, i];
                table[i, i] = table[i, size - i - 1];
                table[i, size - i - 1] = temp;
            }


            table.PrintToConsole();
        }

        public void Process38()
        {
            int size = Input<int>.Get("Zadejte velikost tabulky.").AddRule(IntegerRule.Positive);
            IntegerTable table = new IntegerTable(size);

            int row = 0, col = -1;
            int value = 1;

            bool horizontal = true;
            bool increasing = true;
            bool finished = false;

            while (!finished)
            {

                finished = true;
                if (horizontal && increasing)
                {
                    while (tryAndSet(table, row, col + 1, value))
                    {
                        finished = false;
                        col++;
                        value++;
                    }
                }
                else if (horizontal && !increasing)
                {
                    while (tryAndSet(table, row, col - 1, value))
                    {
                        finished = false;
                        col--;
                        value++;
                    }
                }
                else if (!horizontal && increasing)
                {
                    while (tryAndSet(table, row + 1, col, value))
                    {
                        finished = false;
                        row++;
                        value++;
                    }
                }
                else
                {
                    while (tryAndSet(table, row - 1, col, value))
                    {
                        finished = false;
                        row--;
                        value++;
                    }
                }

                if (!horizontal)
                {
                    increasing = !increasing;
                }
                horizontal = !horizontal;
            }
            table.PrintToConsole();
        }

        private bool tryAndSet(IntegerTable table, int row, int col, int value)
        {
            if (row < 0 || col < 0 || row >= table.Height || col >= table.Width || table[row, col] != 0)
            {
                return false;
            }
            table[row, col] = value;
            return true;
        }

        public void Process39()
        {

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gateway.Rules;
using System.Text.RegularExpressions;
using System.Globalization;
using Gateway;
using System.Numerics;
using System.IO;
using System.Security.Cryptography;
using System.Collections;
using System.Diagnostics;

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

        Int64[] factors64 = { 1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880, 3628800, 39916800, 479001600, 6227020800, 87178291200, 1307674368000, 20922789888000, 355687428096000, 6402373705728000, 121645100408832000, 2432902008176640000 };

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
            string veta = Input<string>.Get("Zadejte větu.").AddRule(StringRule.NotEmpty);
            string[] data = veta.Split(' ');
            int longest = 0;
            List<string> longestStrings = new List<string>();
            foreach (string s in data)
            {
                string d = s.Trim(' ', ',', '.', '!', '?');
                if (d.Length == longest)
                    longestStrings.Add(d);
                else if (d.Length > longest)
                {
                    longest = d.Length;
                    longestStrings.Clear();
                    longestStrings.Add(d);
                }
                Console.WriteLine(d + " - " + d.Length);
            }
            Console.WriteLine();
            Console.WriteLine("Nejdelší:");
            foreach (string w in longestStrings)
            {
                Console.WriteLine("\t" + w + " - " + w.Length);
            }
        }

        public void Process40()
        {
            string datum = Input<string>.Get("Zadejte větu.").AddRule(StringRule.NotEmpty);
            DateTime dt;
            if (DateTime.TryParse(datum, new CultureInfo("cs-CZ"), DateTimeStyles.None, out dt))
            {
                Console.WriteLine(dt.ToString("D"));
            }
            else
            {
                Console.WriteLine("Datum je ve špatném formátu.");
            }
        }

        public void Process41()
        {
            string jm = Input<string>.Get("Zadejte jméno a příjmení.").AddRule(StringRule.NotEmpty);
            string[] data = jm.Split(' ');
            if (data.Length == 2)
            {
                Console.WriteLine("Jméno - " + data[0]);
                Console.WriteLine("Příjmení - " + data[1]);
            }
            else
            {
                Console.WriteLine("Zadali jste jméno a příjmení ve špatném formátu.");
            }
        }

        public void Process42()
        {
            string input = Input<string>.Get("Zadejte větu pro šifrování.");
            int key = Input<int>.Get("Zadejte číslo pro Caesarovu šifru (1-25).").AddRule(IntegerRule.GetRange(1, 25));

            char[] buffer = input.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                char letter = buffer[i];

                letter = (char)(letter + key);

                if (letter > 'z')
                {
                    letter = (char)(letter - 26);
                }
                else if (letter < 'a')
                {
                    letter = (char)(letter + 26);
                }
                buffer[i] = letter;
            }
            Console.WriteLine(input);
            Console.WriteLine(new string(buffer));
        }

        public void Process43()
        {
            char[] samohl = "bcčdďfghjklmnňpqrřsštťvwxzž".ToCharArray();
            string input = Input<string>.Get("Zadejte větu.").AddRule(StringRule.NotEmpty);
            List<string> dvoj = new List<string>();
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (samohl.Contains(input[i]) && samohl.Contains(input[i + 1]))
                {
                    dvoj.Add(input[i].ToString() + input[i + 1].ToString());
                }
            }
            Console.WriteLine("Počet dvojic - " + dvoj.Count);
            Console.WriteLine(string.Join(",", dvoj));
        }

        public void Process44()
        {
            char[] allowed = "bcčdďfghjklmnňpqrřsštťvwxzž".ToCharArray();
            string input = Input<string>.Get("Zadejte větu.").AddRule(StringRule.NotEmpty);
            foreach (char c in allowed)
            {
                input = input.Replace(c, ' ');
            }
            Console.WriteLine(input);
        }

        public class ComplexFormatter : IFormatProvider, ICustomFormatter
        {
            public object GetFormat(Type formatType)
            {
                if (formatType == typeof(ICustomFormatter))
                    return this;
                else
                    return null;
            }

            public string Format(string format, object arg,
                                 IFormatProvider provider)
            {
                if (arg is Complex)
                {
                    Complex c1 = (Complex)arg;
                    // Check if the format string has a precision specifier. 
                    int precision;
                    string fmtString = String.Empty;
                    if (format.Length > 1)
                    {
                        try
                        {
                            precision = Int32.Parse(format.Substring(1));
                        }
                        catch (FormatException)
                        {
                            precision = 0;
                        }
                        fmtString = "N" + precision.ToString();
                    }
                    if (format.Substring(0, 1).Equals("I", StringComparison.OrdinalIgnoreCase))
                        return c1.Real.ToString(fmtString) + " + " + c1.Imaginary.ToString(fmtString) + "i";
                    else if (format.Substring(0, 1).Equals("J", StringComparison.OrdinalIgnoreCase))
                        return c1.Real.ToString(fmtString) + " + " + c1.Imaginary.ToString(fmtString) + "j";
                    else
                        return c1.ToString(format, provider);
                }
                else
                {
                    if (arg is IFormattable)
                        return ((IFormattable)arg).ToString(format, provider);
                    else if (arg != null)
                        return arg.ToString();
                    else
                        return String.Empty;
                }
            }
        }

        public void Process45()
        {
            Console.WriteLine("Povolené operace - 1 = sčítání, 2 = odčítání, 3 = násobení, 4 = dělení");
            int i = Input<int>.Get("Zadejte číslo operace.").AddRule(IntegerRule.GetRange(1, 4));
            float a1 = Input<float>.Get("Zadejte a pro 1. komplexní číslo ve tvaru a + bi.");
            float b1 = Input<float>.Get("Zadejte b pro 1. komplexní číslo ve tvaru a + bi.");
            Complex c1 = new Complex(a1, b1);
            Console.WriteLine(string.Format(new ComplexFormatter(), "{0:I2}", c1));

            float a2 = Input<float>.Get("Zadejte a pro 2. komplexní číslo ve tvaru a + bi.");
            float b2 = Input<float>.Get("Zadejte b pro 2. komplexní číslo ve tvaru a + bi.");
            Complex c2 = new Complex(a2, b2);
            Console.WriteLine(string.Format(new ComplexFormatter(), "{0:I2}", c2));

            Complex c3 = Complex.Zero;

            switch (i)
            {
                case 1:
                    c3 = c1 + c2;
                    break;
                case 2:
                    c3 = c1 - c2;
                    break;
                case 3:
                    c3 = c1 * c2;
                    break;
                case 4:
                    c3 = c1 / c2;
                    break;
            }
            Console.WriteLine("Výsledek je:");
            Console.WriteLine(string.Format(new ComplexFormatter(), "{0:I2}", c3));
        }

        struct Osoba
        {
            public string jmeno, prijmeni, ulice, mesto;
            public DateTime datumNarozeni;
        }

        public void Process46()
        {
            List<Osoba> osoby = new List<Osoba>();
            int count = Input<int>.Get("Zadejte počet osob.").AddRule(IntegerRule.Positive);
            for (int i = 1; i <= count; i++)
            {
                Osoba o = new Osoba();
                o.jmeno = Input<string>.Get("Zadejte jméno pro osobu č." + i).AddRule(StringRule.NotEmpty);
                o.prijmeni = Input<string>.Get("Zadejte příjmení pro osobu č." + i).AddRule(StringRule.NotEmpty);
                o.ulice = Input<string>.Get("Zadejte ulici pro osobu č." + i).AddRule(StringRule.NotEmpty);
                o.mesto = Input<string>.Get("Zadejte město pro osobu č." + i).AddRule(StringRule.NotEmpty);

                bool succeeded;
                do
                {
                    succeeded = false;
                    string datum = Input<string>.Get("Zadejte datum narození pro osobu č." + i).AddRule(StringRule.NotEmpty);
                    DateTime dt;
                    if (DateTime.TryParse(datum, new CultureInfo("cs-CZ"), DateTimeStyles.None, out dt))
                    {
                        succeeded = true;
                        o.datumNarozeni = dt;
                    }
                }
                while (!succeeded);

                osoby.Add(o);
            }

            Table<string> t = new Table<string>(count + 1, 6);
            t[0, 0] = "ID";
            t[0, 1] = "Jméno";
            t[0, 2] = "Příjmení";
            t[0, 3] = "Datum narození";
            t[0, 4] = "Ulice";
            t[0, 5] = "Město";

            for (int i = 1; i <= osoby.Count; i++)
            {
                Osoba o = osoby[i - 1];
                t[i, 0] = (i).ToString();
                t[i, 1] = o.jmeno;
                t[i, 2] = o.prijmeni;
                t[i, 3] = o.datumNarozeni.ToString("d");
                t[i, 4] = o.ulice;
                t[i, 5] = o.mesto;
            }

            t.PrintToConsole();
        }

        public void Process47()
        {
            StreamWriter sw = File.CreateText("a.txt");
            Random r = new Random();
            sw.Write(BitConverter.ToString(SHA256Managed.Create().ComputeHash(Encoding.UTF8.GetBytes(r.Next().ToString()))));
            sw.Close();
            File.Copy("a.txt", "b.txt");
        }

        public void Process48()
        {
            StreamWriter sw = File.CreateText("a.txt");
            sw.Write("Lorem ipsum dolor sit amet, consectetur adipiscing elit.\r\nVestibulum vulputate massa sed justo tincidunt a ultrices mauris bibendum.\r\nDuis justo tortor, posuere at dignissim id, tempor in massa.\r\nNulla tempus facilisis diam at aliquam.\r\nPhasellus nisl ante, iaculis vitae tristique at, molestie vitae orci.\r\nSed fringilla, justo eget ultrices aliquet, diam lorem bibendum augue, sed mollis eros quam non sem.\r\nDonec tincidunt urna quis ante feugiat facilisis.\r\nNullam diam massa, ornare vitae viverra sit amet, pellentesque non mi.\r\nQuisque fermentum nisl sed massa porta vitae porta turpis scelerisque.\r\nQuisque tellus quam, molestie vitae aliquet vitae, ultricies vel ligula.\r\nProin ac felis eget risus aliquam scelerisque.");
            sw.Close();
            string text = File.ReadAllText("a.txt");
            sw = File.CreateText("b.txt");
            sw.Write(new string(text.Where(c => " aeiouyAEIOUY".Contains(c)).ToArray()));
            sw.Close();
        }

        public void Process49()
        {
            StreamWriter sw = File.CreateText("a.txt");
            sw.Write("ab\r\nLorem ipsum dolor sit amet, consectetur adipiscing elit.\r\nVestibulum vulputate massa sed justo tincidunt a ultrices mauris bibendum.\r\nDuis justo tortor, posuere at dignissim id, tempor in massa.\r\nNulla tempus facilisis diam at aliquam.\r\nPhasellus nisl ante, iaculis vitae tristique at, molestie vitae orci.\r\nSed fringilla, justo eget ultrices aliquet, diam lorem bibendum augue, sed mollis eros quam non sem.\r\nDonec tincidunt urna quis ante feugiat facilisis.\r\nNullam diam massa, ornare vitae viverra sit amet, pellentesque non mi.\r\nQuisque fermentum nisl sed massa porta vitae porta turpis scelerisque.\r\nQuisque tellus quam, molestie vitae aliquet vitae, ultricies vel ligula.\r\nProin ac felis eget risus aliquam scelerisque.");
            sw.Close();
            string[] lines = File.ReadAllLines("a.txt");
            sw = File.CreateText("b.txt");
            foreach (string line in lines)
            {
                sw.WriteLine(line.Length.ToString());
            }
            sw.Close();
        }

        public void Process50()
        {
            StreamWriter sw = File.CreateText("c.txt");
            sw.Write(File.ReadAllText("a.txt"));
            sw.Write(File.ReadAllText("b.txt"));
            sw.Close();
        }

        public void Process51()
        {
            StreamWriter sw = File.CreateText("a.txt");
            sw.Write("ab\r\nLorem ipsum dolor sit amet, consectetur adipiscing elit.\r\nVestibulum vulputate massa sed justo tincidunt a ultrices mauris bibendum.\r\nDuis justo tortor, posuere at dignissim id, tempor in massa.\r\nNulla tempus facilisis diam at aliquam.\r\nPhasellus nisl ante, iaculis vitae tristique at, molestie vitae orci.\r\nSed fringilla, justo eget ultrices aliquet, diam lorem bibendum augue, sed mollis eros quam non sem.\r\nDonec tincidunt urna quis ante feugiat facilisis.\r\nNullam diam massa, ornare vitae viverra sit amet, pellentesque non mi.\r\nQuisque fermentum nisl sed massa porta vitae porta turpis scelerisque.\r\nQuisque tellus quam, molestie vitae aliquet vitae, ultricies vel ligula.\r\nProin ac felis eget risus aliquam scelerisque.");
            sw.Close();
            string[] lines = File.ReadAllLines("a.txt");
            sw = File.CreateText("b.txt");
            foreach (string line in lines)
            {
                sw.WriteLine("     " + line);
            }
            sw.Close();
        }

        public void Process52()
        {
            int counter = 0;
            string[] lines = File.ReadAllLines("a.txt");
            foreach (string line in lines)
            {
                counter += line.Split(' ').Count();
            }
            Console.WriteLine("Počet slov: " + counter.ToString());
        }

        public void Process53()
        {
            string text = File.ReadAllText("a.txt");
            int count = text.Length - text.Replace("pes", "fg").Length;
            Console.WriteLine("Počet instancí slova pes v textu: " + count.ToString());
        }

        public void Process54()
        {
            float num = Input<float>.Get("Zadejte číslo.");
            Console.WriteLine("Třetí mocnina = " + (num * num * num).ToString());
        }

        public void Process55()
        {
            float x = Input<float>.Get("Zadejte x.");
            int n = Input<int>.Get("Zadejte n.");
            Console.WriteLine("Mocnina (" + x + ")^(" + n + ") je rovna číslu " + Math.Pow(x, n) + ".");
        }

        public void Process56()
        {
            Console.WriteLine("Zadejte 3 celá čísla.");
            List<int> ints = new List<int>();
            ints.Add(Input<int>.Get());
            ints.Add(Input<int>.Get());
            ints.Add(Input<int>.Get());
            ints.Sort();
            Console.WriteLine("Prostřední číslo je: " + ints[1].ToString());
        }

        public int gcd(int a, int b)
        {
            int t;
            while (b != 0)
            {
                t = b;
                b = a % t;
                a = t;
            }
            return a;
        }

        public int gcdRec(int a, int b)
        {
            if (b == 0)
                return a;
            return gcdRec(b, a % b);
        }

        public int lcm(int a, int b)
        {
            return (a * b) / gcd(a, b);
        }

        public void Process57()
        {
            int a = Input<int>.Get("Zadejte číslo a.").AddRule(IntegerRule.Positive);
            int b = Input<int>.Get("Zadejte číslo b.").AddRule(IntegerRule.Positive);
            Console.WriteLine("LSM(a, b) = " + lcm(a, b).ToString());
        }

        public void Process58()
        {
            int a = Input<int>.Get("Zadejte číslo a.").AddRule(IntegerRule.Positive);
            int b = Input<int>.Get("Zadejte číslo b.").AddRule(IntegerRule.Positive);
            Console.WriteLine("GCD(a, b) = " + gcd(a, b).ToString());
        }

        public void Process59()
        {
            float a = Input<float>.Get("Zadejte číslo a.");
            float b = Input<float>.Get("Zadejte číslo b.");
            Complex c = new Complex(a, b);
            double angle = (180 * c.Phase / Math.PI);
            Console.WriteLine("[" + (angle >= 0 ? angle : angle + 360) + "°, " + c.Magnitude + "]");
        }

        public void Process60()
        {
            int year = Input<int>.Get("Zadejte rok.").AddRule(new Rule<int>((i) => { return i > 1582; }, "Rok musí být větší než 1582."));
            Console.WriteLine("Rok " + year + (DateTime.IsLeapYear(year) ? " je " : " není ") + "přestupný.");
        }

        public void Process61()
        {
            int year = Input<int>.Get("Zadejte rok.").AddRule(new Rule<int>((i) => { return i > 1582; }, "Rok musí být větší než 1582."));
            int dayInYear = Input<int>.Get("Zadejte pořadové číslo dne.").AddRule(IntegerRule.Positive).AddRule(new Rule<int>((i) => { return i < (DateTime.IsLeapYear(year) ? 367 : 366); }, "Pořadové číslo musí být menší než " + (DateTime.IsLeapYear(year) ? 367 : 366) + "."));
            DateTime dt = new DateTime(year, 1, 1);

            Console.WriteLine(dt.AddDays(dayInYear - 1).ToShortDateString());
        }

        public void Process62()
        {
            int num = Input<int>.Get("Zadejte číslo.").AddRule(IntegerRule.NonNegative);
            char[] nums = num.ToString().ToCharArray();
            Array.Reverse(nums);
            Console.WriteLine(new string(nums));
        }

        public void Process63()
        {
            int count = Input<int>.Get("Zadejte počet disků").AddRule(IntegerRule.GetRange(3, 6));
            Console.WriteLine("Disky A, B, C");
            hanoi(count, 'A', 'C', 'B');
        }

        static void hanoi(int x, char from, char to, char help)
        {
            if (x > 0)
            {
                hanoi(x - 1, from, help, to);
                hanoiMove(x, from, to);
                hanoi(x - 1, help, to, from);
            }

        }

        static void hanoiMove(int x, char from, char to)
        {
            Console.WriteLine(" Disk " + x + " : " + from + " -> " + to);
        }

        public void Process64()
        {
            int a = Input<int>.Get("Zadejte číslo a.").AddRule(IntegerRule.Positive);
            int b = Input<int>.Get("Zadejte číslo b.").AddRule(IntegerRule.Positive);
            Console.WriteLine("GCD(a, b) = " + gcdRec(a, b).ToString());
        }

        private long over(int n, int k)
        {
            return factors64[n] / (factors64[k] * factors64[n - k]);
        }

        public void Process65()
        {
            int n = Input<int>.Get("Zadejte číslo n (počet prvků).").AddRule(IntegerRule.Positive).AddRule(new Rule<int>((i) => { return i <= 20; }, "n musí být menší než 21 (kvůli limitu velikosti čísla)"));
            int k = Input<int>.Get("Zadejte číslo k (třída).").AddRule(IntegerRule.Positive);
            Console.WriteLine("Vk(n) = " + factors64[n] / factors64[n - k]);
        }

        public void Process66()
        {
            int n = Input<int>.Get("Zadejte číslo n (počet prvků).").AddRule(IntegerRule.Positive);
            int k = Input<int>.Get("Zadejte číslo k (třída).").AddRule(IntegerRule.Positive);
            Console.WriteLine("V'k(n) = " + Math.Pow(n, k));
        }

        public void Process67()
        {
            int n = Input<int>.Get("Zadejte číslo n (počet prvků).").AddRule(IntegerRule.Positive).AddRule(new Rule<int>((i) => { return i <= 20; }, "n musí být menší než 21 (kvůli limitu velikosti čísla)"));
            int k = Input<int>.Get("Zadejte číslo k (třída).").AddRule(IntegerRule.Positive).AddRule(new Rule<int>((i) => { return i <= 20; }, "k musí být menší než 21 (kvůli limitu velikosti čísla)"));
            Console.WriteLine("Ck(n) = " + over(n, k));
        }

        public void Process68()
        {
            int n = Input<int>.Get("Zadejte číslo n (počet prvků).").AddRule(IntegerRule.Positive).AddRule(new Rule<int>((i) => { return i <= 20; }, "n musí být menší než 21 (kvůli limitu velikosti čísla)"));
            int k = Input<int>.Get("Zadejte číslo k (třída).").AddRule(IntegerRule.Positive);
            Console.WriteLine("C'k(n) = " + over(n + k - 1, k));
        }

        public void Process69()
        {
            int n = Input<int>.Get("Zadejte číslo pro převod z decimální do binární soustavy.");
            Console.WriteLine(Convert.ToString(n, 2));
        }

        public void Process70()
        {
            string n = Input<string>.Get("Zadejte číslo pro převod z binární do desítkové soustavy.").AddRule(new Rule<string>((i) => { return i.Replace("1", "").Replace("0", "").Count() == 0; }, "Číslo není správně zadané."));
            Console.WriteLine(Convert.ToInt32(n, 2));
        }

        int[] perfectN = new int[] { 2, 3, 5, 7, 13 };

        public void Process71()
        {
            int max = Input<int>.Get("Zadejte horní limit pro spočtení dokonalých čísel.").AddRule(IntegerRule.Positive);
            List<string> results = new List<string>();
            for (int i = 0; i < perfectN.Count(); i++)
            {
                int n = perfectN[i];
                int perfect = (int)(Math.Pow(2, n - 1) * (Math.Pow(2, n) - 1));
                if (perfect > max)
                    break;
                results.Add(perfect.ToString());
            }
            Console.WriteLine("Dokonalá čísla jsou: " + string.Join(",", results));
        }

        int[] GetNumDigits(int num)
        {
            List<int> listOfInts = new List<int>();
            while (num > 0)
            {
                listOfInts.Add(num % 10);
                num = num / 10;
            }
            listOfInts.Reverse();
            return listOfInts.ToArray();
        }

        public void Process72()
        {
            int max = Input<int>.Get("Zadejte horní limit pro spočtení Armstrongových čísel.").AddRule(IntegerRule.Positive);
            List<string> results = new List<string>();
            for (int i = 1; i < max; i++)
            {
                int a = 0;
                foreach (int d in GetNumDigits(i))
                {
                    a += (int)Math.Pow(d, 3);
                }

                if (a == i)
                    results.Add(a.ToString());
            }
            Console.WriteLine("Armstrongova čísla jsou: " + string.Join(",", results));
        }

        List<int> GetDivisors(int num)
        {
            List<int> divisors = new List<int>() { 1 };
            for (int j = 2; j < num; j++)
            {
                if (num % j == 0)
                    divisors.Add(j);
            }
            return divisors;
        }

        public void Process73()
        {
            int max = Input<int>.Get("Zadejte horní limit pro spočtení dokonalých čísel 2. řádu.").AddRule(IntegerRule.Positive);
            List<string> results = new List<string>();
            for (int i = 1; i < max; i++)
            {
                int mul = 1;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                        mul *= j;
                }
                if (mul == i)
                    results.Add(i.ToString());
            }
            Console.WriteLine("Dokonalá čísla 2. řádu jsou: " + string.Join(",", results));
        }

        public void Process74()
        {
            int max = Input<int>.Get("Zadejte horní limit pro spočtení spřátelených čísel.").AddRule(IntegerRule.Positive);
            Console.WriteLine("Dokonalá čísla 2. řádu jsou:");
            Dictionary<int, int> res = new Dictionary<int, int>();
            for (int i = 1; i < max; i++)
            {
                for (int j = 1; j < max; j++)
                {
                    if (i == j)
                        continue;
                    if (GetDivisors(i).Sum() == j && GetDivisors(j).Sum() == i && !res.ContainsValue(i))
                    {
                        res.Add(i, j);
                    }
                }
            }

            foreach (KeyValuePair<int, int> pair in res)
            {
                Console.WriteLine(pair.Key.ToString() + " - " + pair.Value.ToString());
            }
        }

        public void Process75()
        {
            Console.WriteLine("Zadejte čísla, ukončete záporným číslem.");

            List<int> nums = new List<int>();
            while (true)
            {
                int i = Input<int>.Get("");
                if (i < 0)
                    break;
                nums.Add(i);
            }
            nums.Reverse();
            Console.WriteLine("Čísla v opačném pořadí jsou: " + string.Join(", ", nums));
        }

        public void Process76()
        {
            Console.WriteLine("Zadejte čísla, ukončete záporným číslem.");

            List<int> nums = new List<int>();
            while (true)
            {
                int i = Input<int>.Get("");
                if (i < 0)
                    break;
                nums.Add(i);
            }
            Console.WriteLine("Čísla jsou: " + string.Join(", ", nums));
        }

        public void Process77()
        {
            Console.WriteLine("Zadejte čísla, ukončete záporným číslem.");

            LinkedList<int> nums = new LinkedList<int>();
            while (true)
            {
                int i = Input<int>.Get("");
                if (i < 0)
                    break;
                nums.AddLast(i);
            }
            Console.WriteLine("Čísla jsou: " + string.Join(", ", nums));
        }

        public void Process78()
        {
            Console.WriteLine("Zadejte čísla, ukončete záporným číslem.");

            LinkedList<int> nums = new LinkedList<int>();
            while (true)
            {
                int i = Input<int>.Get("");
                if (i < 0)
                    break;
                nums.AddLast(i);
            }
            Console.WriteLine("Předposlední prvek je: " + nums.Last.Previous.Value.ToString());
        }

        public void Process79()
        {
            Console.WriteLine("Zadejte čísla, ukončete záporným číslem.");

            CircularLinkedList<int> nums = new CircularLinkedList<int>();
            while (true)
            {
                int i = Input<int>.Get("");
                if (i < 0)
                    break;
                nums.AddLast(i);
            }
            List<int> ints = new List<int>();
            IEnumerator<int> en = nums.GetEnumerator();
            while (en.MoveNext())
                ints.Add(en.Current);
            Console.WriteLine(string.Join(",", ints));

            ints.Clear();

            en = nums.GetReverseEnumerator();
            while (en.MoveNext())
                ints.Add(en.Current);
            Console.WriteLine(string.Join(",", ints));
        }

        public void Process80()
        {
            Console.WriteLine("Zadejte čísla, ukončete záporným číslem.");

            List<int> nums = new List<int>();
            while (true)
            {
                int i = Input<int>.Get("");
                if (i < 0)
                    break;
                nums.Add(i);
            }
            Console.WriteLine(string.Join(",", nums));

            int search = Input<int>.Get("Zadejte číslo pro vyhledání.");
            int res = nums.BinarySearch(search);
            if (res < 0)
            {
                Console.WriteLine("Číslo nebylo nalezeno.");
            }
            else
            {
                Console.WriteLine("Číslo se nachází na pozici " + res + ".");
            }
        }

        public void Process81()
        {
            Random r = new Random();
            List<int> randomNums = new List<int>();
            const int LIST_SIZE = 20;
            for (int i = 0; i < LIST_SIZE; i++)
            {
                randomNums.Add(r.Next(0, 200));
            }
            Console.WriteLine("Náhodná čísla pro řazení jsou: " + string.Join(",", randomNums));
            Console.WriteLine("Vyberte si způsob řazení:");
            Console.WriteLine("(1) řazení dle množiny\n(2) řazení vkládáním\n(3) řazení vkládáním\n(4) řazení výměnou");
            Console.WriteLine("(5) Shellsortem\n(6) Heapsortem\n(7) Quicksortem");
            int sortalg = Input<int>.Get().AddRule(IntegerRule.GetRange(1, 7));
            List<int> res = new List<int>();
            switch (sortalg)
            {
                case 1:
                    break;
                case 2:
                    res = insertionSort(randomNums);
                    break;
                case 3:
                    res = selectionSort(randomNums);
                    break;
                case 4:
                    res = bubbleSort(randomNums);
                    break;
                case 5:
                    res = shellSort(randomNums);
                    break;
                case 6:
                    res = heapSort(randomNums);
                    break;
                case 7:
                    res = quickSort(randomNums, 0, randomNums.Count - 1);
                    break;
            }
            Console.WriteLine(string.Join(",", res));
        }

        #region sortalgs

        public List<int> insertionSort(List<int> input)
        {
            for (int i = 0; i < input.Count; i++)
            {
                int value = input[i];
                int hole = i;
                while (hole > 0 && value < input[hole - 1])
                {
                    input[hole] = input[hole - 1];
                    hole--;
                }
                input[hole] = value;
            }
            return input;
        }

        public List<int> selectionSort(List<int> input)
        {
            for (int i = 0; i < input.Count - 1; i++)
            {
                int min = int.MaxValue;
                int minpos = 0;
                for (int j = i + 1; j < input.Count; j++)
                {
                    if (input[j] < min)
                    {
                        min = input[j];
                        minpos = j;
                    }
                }
                int tmp = input[i];
                input[i] = min;
                input[minpos] = tmp;
            }
            return input;
        }

        public List<int> bubbleSort(List<int> input)
        {
            bool sorted;
            do
            {
                sorted = true;
                for (int i = 0; i < input.Count - 1; i++)
                {
                    if (input[i] > input[i + 1])
                    {
                        sorted = false;
                        int tmp = input[i];
                        input[i] = input[i + 1];
                        input[i + 1] = tmp;
                        break;
                    }
                }
            }
            while (!sorted);
            return input;
        }

        public List<int> shellSort(List<int> input)
        {
            int i, j, increment, temp;

            increment = 3;

            while (increment > 0)
            {
                for (i = 0; i < input.Count; i++)
                {
                    j = i;
                    temp = input[i];

                    while ((j >= increment) && (input[j - increment] > temp))
                    {
                        input[j] = input[j - increment];
                        j = j - increment;
                    }

                    input[j] = temp;
                }

                if (increment / 2 != 0)
                {
                    increment = increment / 2;
                }
                else if (increment == 1)
                {
                    increment = 0;
                }
                else
                {
                    increment = 1;
                }
            }

            return input;
        }

        public List<int> heapSort(List<int> input)
        {
            //Build-Max-Heap
            int heapSize = input.Count;
            for (int p = (heapSize - 1) / 2; p >= 0; p--)
                input = maxHeapify(input, heapSize, p);

            for (int i = input.Count - 1; i > 0; i--)
            {
                //Swap
                int temp = input[i];
                input[i] = input[0];
                input[0] = temp;

                heapSize--;
                input = maxHeapify(input, heapSize, 0);
            }

            return input;
        }

        public List<int> maxHeapify(List<int> input, int heapSize, int index)
        {
            int left = (index + 1) * 2 - 1;
            int right = (index + 1) * 2;
            int largest = 0;

            if (left < heapSize && input[left] > input[index])
                largest = left;
            else
                largest = index;

            if (right < heapSize && input[right] > input[largest])
                largest = right;

            if (largest != index)
            {
                int temp = input[index];
                input[index] = input[largest];
                input[largest] = temp;

                input = maxHeapify(input, heapSize, largest);
            }

            return input;
        }

        private List<int> quickSort(List<int> input, int left, int right)
        {
            int i = left;
            int j = right;
            double pivotValue = ((left + right) / 2);
            int x = input[Convert.ToInt32(pivotValue)];
            int w = 0;
            while (i <= j)
            {
                while (input[i] < x)
                {
                    i++;
                }
                while (x < input[j])
                {
                    j--;
                }
                if (i <= j)
                {
                    w = input[i];
                    input[i++] = input[j];
                    input[j--] = w;
                }
            }
            if (left < j)
            {
                quickSort(input, left, j);
            }
            if (i < right)
            {
                quickSort(input, i, right);
            }
            return input;
        }

#endregion

        public void Process82()
        {
            Console.WriteLine("Generuji náhodná čísla.");
            Random r = new Random();
            List<int> randomNums = new List<int>();
            const int LIST_SIZE = 10000;
            for (int i = 0; i < LIST_SIZE; i++)
            {
                randomNums.Add(r.Next(0, 100000));
            }
            List<long> times = new List<long>();
            List<List<int>> results = new List<List<int>>();
            Console.WriteLine("Testuji...");
            Stopwatch s = new Stopwatch();

            s.Start();
            results.Add(insertionSort(randomNums));
            times.Add(s.ElapsedMilliseconds);
            s.Reset();

            s.Start();
            results.Add(selectionSort(randomNums));
            times.Add(s.ElapsedMilliseconds);
            s.Reset();

            s.Start();
            results.Add(bubbleSort(randomNums));
            times.Add(s.ElapsedMilliseconds);
            s.Reset();

            s.Start();
            results.Add(shellSort(randomNums));
            times.Add(s.ElapsedMilliseconds);
            s.Reset();

            s.Start();
            results.Add(heapSort(randomNums));
            times.Add(s.ElapsedMilliseconds);
            s.Reset();

            s.Start();
            results.Add(quickSort(randomNums, 0, randomNums.Count - 1));
            times.Add(s.ElapsedMilliseconds);
            s.Reset();

            string[] nazvy = new string[] { "insertion", "selection", "bubble", "shell", "heap", "quick" };
            for (int i = 0; i < nazvy.Length; i++)
            {
                Console.WriteLine(nazvy[i] + " - " + times[i].ToString());
            }
            Console.WriteLine();
            List<int> checkNums = new List<int>();
            for (int i = 0; i < 200; i++)
            {
                checkNums.Add(r.Next(0, LIST_SIZE - 1));
            }
            bool fail = false;
            int failIndex = -1;
            foreach (int n in checkNums)
            {
                int check = -1;
                int rescounter = 0;
                foreach (List<int> res in results)
                {
                    if (check == -1)
                        check = res[n];
                    if (check != res[n])
                    {                 
                        fail = true;
                        failIndex = rescounter;
                        break;
                    }
                    rescounter++;
                }
                if (fail)
                    break;
            }
            if (fail)
            {
                Console.WriteLine("fail: " + nazvy[failIndex]);
            }
        }
    }
}

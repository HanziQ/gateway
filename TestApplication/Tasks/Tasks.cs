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
            int n = Input<int>.Get("Zadejte n pro n!.").AddRule(IntegerRule.Positive).AddRule(new Rule<int>((i) => {return i <= 20; }, "n musí být menší než 21 (kvůli limitu velikosti čísla)"));
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
                foreach(int d in Array.ConvertAll<string, int>(Regex.Split(i.ToString(), @"(?!^)(?!$)"), str => int.Parse(str)))
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

            List<int> nums = new List<int>();
            while (true)
            {
                int i = Input<int>.Get("").AddRule(IntegerRule.NonNegative);
                if (i == 0)
                    break;
                nums.Add(i);
            }
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
                int c = Input<int>.Get("CJL").AddRule(IntegerRule.NonNegative).AddRule(new Rule<int>((z) => {return z <= 5; }, "Známka musí být menší než 6."));
                int m = Input<int>.Get("MAT").AddRule(IntegerRule.NonNegative).AddRule(new Rule<int>((z) => { return z <= 5; }, "Známka musí být menší než 6."));
                int a = Input<int>.Get("ANJ").AddRule(IntegerRule.NonNegative).AddRule(new Rule<int>((z) => { return z <= 5; }, "Známka musí být menší než 6."));
                if(c == 0 & m == 0 & a == 0)
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
    }
}

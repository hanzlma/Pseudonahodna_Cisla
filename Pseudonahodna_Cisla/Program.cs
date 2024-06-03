using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
namespace Pseudonahodna_Cisla
{
    internal class Program
    {
        
         static void Main(string[] args)
        {
            Random rand = new Random();
            Console.Write("Zadej minimalni hodnotu: ");
            int min = Convert.ToInt32(Console.ReadLine());
            Console.Write("Zadej maximalni hodnotu: ");
            int max = Convert.ToInt32(Console.ReadLine());
            Console.Write("Zadej pocet hodnot: ");
            int x = Convert.ToInt32(Console.ReadLine());

            int mean = (min+max)/2;
            double std = Math.Abs(min + max) / 8.0;
            double[] vals = new double [x];
            int[] rovn_rozd = new int[x];
            for (int i = 0;i < x ;i++)
            {
                double u1 = 1.0 - rand.NextDouble();
                double u2 = 1.0 - rand.NextDouble();
                double stdNorm = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
                double Norm = mean + std * stdNorm;
                Console.WriteLine(Norm.ToString());
                vals[i] = Norm;
                rovn_rozd[i] = rand.Next(min, max + 1);
            }
            Console.WriteLine();
            Console.WriteLine("Test dobre shody");
            double ex1, ex2, ex3, ex4, ex5, ex6, ex7, ex8;
            ex1 = ex8 = 0.001 * x;
            ex2 = ex7 = 0.021 * x;
            ex3 = ex6 = 0.136 * x;
            ex4 = ex5 = 0.341 * x;
            //ocekavany pocet
            int gen1, gen2, gen3, gen4, gen5, gen6, gen7, gen8;
            gen1 = gen2 = gen3 = gen4 = gen5 = gen6 = gen7 = gen8 = 0;
            foreach(double val in vals)
            {
                switch (true)
                {
                    case true when val >= min && val < min + std:
                        gen1++;
                        break;
                    case true when val >= min + std && val < min + 2 * std:
                        gen2++;
                        break;
                    case true when val >= min + 2*std && val < min + 3 * std:
                        gen3++;
                        break;
                    case true when val >= min + 3*std && val < min + 4 * std:
                        gen4++;
                        break;
                    case true when val >= min + 4*std && val < min + 5 * std:
                        gen5++;
                        break;
                    case true when val >= min + 5*std && val < min + 6 * std:
                        gen6++;
                        break;
                    case true when val >= min + 6*std && val < min + 7 * std:
                        gen7++;
                        break;
                    case true when val >= min + 7*std && val < min + 8 * std:
                        gen8++;
                        break;
                }
            }
            Console.WriteLine("Generovani v normalnim rozdeleni");
            Console.WriteLine($"Usek 1 ({min} - {min + std}): Ocekavano {              ex1  }; Vygenerovano: {gen1}");
            Console.WriteLine($"Usek 2 ({min + std} - {min + 2*std}): Ocekavano {      ex2  }; Vygenerovano: {gen2}");
            Console.WriteLine($"Usek 3 ({min + 2 * std} - {min + 3 * std}): Ocekavano {ex3  }; Vygenerovano: {gen3}");
            Console.WriteLine($"Usek 4 ({min + 3 * std} - {min + 4 * std}): Ocekavano {ex4  }; Vygenerovano: {gen4}");
            Console.WriteLine($"Usek 5 ({min + 4 * std} - {min + 5 * std}): Ocekavano {ex5  }; Vygenerovano: {gen5}");
            Console.WriteLine($"Usek 6 ({min + 5 * std} - {min + 6 * std}): Ocekavano {ex6  }; Vygenerovano: {gen6}");
            Console.WriteLine($"Usek 7 ({min + 6 * std} - {min + 7 * std}): Ocekavano {ex7  }; Vygenerovano: {gen7}");
            Console.WriteLine($"Usek 8 ({min + 7 * std} - {min + 8 * std}): Ocekavano {ex8  }; Vygenerovano: {gen8}");
            double x2 = (Math.Pow(gen1 - ex1, 2) / ex1) + (Math.Pow(gen2 - ex2, 2) / ex2) + (Math.Pow(gen3 - ex3, 2) / ex3) + (Math.Pow(gen4 - ex4, 2) / ex4) + (Math.Pow(gen5 - ex5, 2) / ex5) + (Math.Pow(gen6 - ex6, 2) / ex6) + (Math.Pow(gen7 - ex7, 2) / ex7) + (Math.Pow(gen8 - ex8, 2) / ex8);
            Console.WriteLine($"Chi kvadrat: {x2}");
            Console.WriteLine($"5% hladina vyznamnosti pro 7 stupnu volnosti: 14,067; Test dobre shody dopadl {((x2 > 14.067) ? "neuspesne": "uspesne" )}");

            
            gen1 = gen2 = gen3 = gen4 = gen5 = gen6 = gen7 = gen8 = 0;
            foreach (int val in rovn_rozd)
            {
                switch (true)
                {
                    case true when val >= min && val < min + std:
                        gen1++;
                        break;
                    case true when val >= min + std && val < min + 2 * std:
                        gen2++;
                        break;
                    case true when val >= min + 2 * std && val < min + 3 * std:
                        gen3++;
                        break;
                    case true when val >= min + 3 * std && val < min + 4 * std:
                        gen4++;
                        break;
                    case true when val >= min + 4 * std && val < min + 5 * std:
                        gen5++;
                        break;
                    case true when val >= min + 5 * std && val < min + 6 * std:
                        gen6++;
                        break;
                    case true when val >= min + 6 * std && val < min + 7 * std:
                        gen7++;
                        break;
                    case true when val >= min + 7 * std && val < min + 8 * std:
                        gen8++;
                        break;
                }
            }
            Console.WriteLine("Generovani v rovnomernem rozdeleni");
            Console.WriteLine($"Usek 1 ({min} - {min + std}): Ocekavano {ex1}; Vygenerovano: {gen1}");
            Console.WriteLine($"Usek 2 ({min + std} - {min + 2 * std}): Ocekavano {ex2}; Vygenerovano: {gen2}");
            Console.WriteLine($"Usek 3 ({min + 2 * std} - {min + 3 * std}): Ocekavano {ex3}; Vygenerovano: {gen3}");
            Console.WriteLine($"Usek 4 ({min + 3 * std} - {min + 4 * std}): Ocekavano {ex4}; Vygenerovano: {gen4}");
            Console.WriteLine($"Usek 5 ({min + 4 * std} - {min + 5 * std}): Ocekavano {ex5}; Vygenerovano: {gen5}");
            Console.WriteLine($"Usek 6 ({min + 5 * std} - {min + 6 * std}): Ocekavano {ex6}; Vygenerovano: {gen6}");
            Console.WriteLine($"Usek 7 ({min + 6 * std} - {min + 7 * std}): Ocekavano {ex7}; Vygenerovano: {gen7}");
            Console.WriteLine($"Usek 8 ({min + 7 * std} - {min + 8 * std}): Ocekavano {ex8}; Vygenerovano: {gen8}");
            x2 = (Math.Pow(gen1 - ex1, 2) / ex1) + (Math.Pow(gen2 - ex2, 2) / ex2) + (Math.Pow(gen3 - ex3, 2) / ex3) + (Math.Pow(gen4 - ex4, 2) / ex4) + (Math.Pow(gen5 - ex5, 2) / ex5) + (Math.Pow(gen6 - ex6, 2) / ex6) + (Math.Pow(gen7 - ex7, 2) / ex7) + (Math.Pow(gen8 - ex8, 2) / ex8);
            Console.WriteLine($"Chi kvadrat: {x2}");
            Console.WriteLine($"5% hladina vyznamnosti pro 7 stupnu volnosti: 14,067; Test dobre shody dopadl {((x2 > 14.067) ? "neuspesne" : "uspesne")}");

            Console.ReadLine();

        }
    }
}

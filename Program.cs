using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Polynomial
{
    class Polynom
    {
        private int Power;
        private List<int> Coef { get; set; }
        public Polynom(int power, List<int> coef)
        {
            Power = power;
            Coef = coef;
        }
        public Polynom()
        {
        }
        public void Print()
        {
            Console.Write("Polynom: ");
            for (int i = 0; i <= Power; i++)
            {
                if (i != Power)
                {
                    if (Power - i == 1)
                    {
                        Console.Write(Coef[i] + "x" + " + ");
                        continue;
                    }
                    Console.Write(Coef[i] + "x^" + (Power - i) + " + ");
                }
                else
                {
                    Console.Write(Coef[i] + "\n");
                }
            }
        }
        public static Polynom operator +(Polynom p1, Polynom p2)
        {
            Polynom polynom = new Polynom();
            polynom.Power = (p1.Power > p2.Power) ? p1.Power : p2.Power;//у нового полинома будет степень большего из данных
            polynom.Coef = new List<int>(polynom.Power + 1);

            p1.Coef.Reverse();
            p2.Coef.Reverse();

            for (int i = 0; i < polynom.Power + 1; i++)
            {
                if (i >= p1.Coef.Count)
                {
                    polynom.Coef.Add(p2.Coef[i]);
                }
                else if(i>= p2.Coef.Count)
                {
                    polynom.Coef.Add(p1.Coef[i]);
                }
                else
                {
                    polynom.Coef.Add(p1.Coef[i] + p2.Coef[i]);
                }
            }
            polynom.Coef.Reverse();
            return polynom;
        }
        public static Polynom operator -(Polynom p1, Polynom p2)
        {
            Polynom polynom = new Polynom();
            polynom.Power = (p1.Power > p2.Power) ? p1.Power : p2.Power;//у нового полинома будет степень большего из данных
            polynom.Coef = new List<int>(polynom.Power + 1);

            p1.Coef.Reverse();
            p2.Coef.Reverse();

            for (int i = 0; i < polynom.Power + 1; i++)
            {
                if (i >= p1.Coef.Count)
                {
                    polynom.Coef.Add(p2.Coef[i]);
                }
                else if (i >= p2.Coef.Count)
                {
                    polynom.Coef.Add(p1.Coef[i]);
                }
                else
                {
                    polynom.Coef.Add(p1.Coef[i] - p2.Coef[i]);
                }
            }
            polynom.Coef.Reverse();
            return polynom;
        }
        public static Polynom operator *(Polynom p1, Polynom p2)
        {
            Polynom polynom = new Polynom();
            polynom.Power = (p1.Power > p2.Power) ? p1.Power : p2.Power;//у нового полинома будет степень большего из данных
            polynom.Coef = new List<int>(polynom.Power + 1);

            p1.Coef.Reverse();
            p2.Coef.Reverse();

            for (int i = 0; i < polynom.Power + 1; i++)
            {
                if (i >= p1.Coef.Count)
                {
                    polynom.Coef.Add(p2.Coef[i]);
                }
                else if (i >= p2.Coef.Count)
                {
                    polynom.Coef.Add(p1.Coef[i]);
                }
                else
                {
                    polynom.Coef.Add(p1.Coef[i] * p2.Coef[i]);
                }
            }
            polynom.Coef.Reverse();
            return polynom;
        }
        public static Polynom operator ++(Polynom p1)
        {
            Polynom polynom = new Polynom(p1.Power, p1.Coef);
            for (int i = 0; i < polynom.Power + 1; i++)
            {
                polynom.Coef[i]++;
            }
            return polynom;
        }
        public Polynom CreatePolynom()
        {
            Console.Write("Enter power:");
            int power = Convert.ToInt32(Console.ReadLine());
            List<int> coef = new List<int>(power + 1);
            for (int i = 0; i < power+1; i++)
            {
                Console.Write("Enter coefficient: ");
                coef.Add(Convert.ToInt32(Console.ReadLine()));
            }
            Power = power;
            Coef = coef;
            return this;
        }
        public void RecreatePolynom()
        {
            Polynom p1 = new Polynom();
            CreatePolynom();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Polynomial 1");
            Polynom p1 = new Polynom();
            p1.CreatePolynom();
            p1.Print();
            Console.WriteLine();

            Console.WriteLine("Polynomial 2");
            Polynom p2 = new Polynom();
            p2.CreatePolynom();
            p2.Print();
            Console.WriteLine();

            Polynom p3;
            while (true)
            {
                Console.WriteLine("1. Add polynomials.");
                Console.WriteLine("2. Subtract polynomials.");
                Console.WriteLine("3. Multiply polynomials.");
                Console.WriteLine("4. Increment polynomial.");
                Console.WriteLine("5. Recreate polynomials.");
                Console.Write("Select menu item: ");
                int key = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                switch (key)
                {
                    case 1:
                        p3 = p1 + p2;
                        p3.Print();
                        Console.WriteLine();
                        break;
                    case 2:
                        p3 = p1 - p2;
                        p3.Print();
                        Console.WriteLine();
                        break;
                    case 3:
                        p3 = p1 - p2;
                        p3.Print();
                        Console.WriteLine();
                        break;
                    case 4:
                        p3 = p1++;
                        p3.Print();
                        Console.WriteLine();
                        break;
                    case 5:
                        Console.WriteLine("Polynomial 1");
                        p1.RecreatePolynom();
                        p1.Print();
                        Console.WriteLine();
                        Console.WriteLine("Polynomial 2");
                        p2.RecreatePolynom();
                        p2.Print();
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("\nThere are no such menu item!\nPlease try again!\n");
                        break;
                }
            }

        }
    }
}

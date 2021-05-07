﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            RationalNumber n1 = new RationalNumber(1, 2);
            RationalNumber n2 = new RationalNumber(3, 4);
            RationalNumber n = n1 + n2;
            Console.WriteLine($"{n1} + {n2} = " + n);
            n = n1 - n2;
            Console.WriteLine($"{n1} - {n2} = " + n.ToString("."));
            n = n1 * n2;
            Console.WriteLine($"{n1} * {n2} = " + n);
            n = n1 / n2;
            Console.WriteLine($"{n1} / {n2} = " + n);
            Console.WriteLine($"{n1} > {n2} " + (n1 > n2));
            Console.WriteLine($"{n1} < {n2} " + (n1 < n2));
            Console.WriteLine($"{n1} == {n2} " + (n1 == n2));
            Console.WriteLine($"{n1} != {n2} " + (n1 != n2));
            Console.WriteLine("parse -1.3 " + RationalNumber.Parse("-1.3"));
            Console.WriteLine("parse -1/3 " + RationalNumber.Parse("-1/3"));
            n.Reduce();
            Console.WriteLine("reduce 4/6 " + n);
            Console.WriteLine($"(int){n} " + (int)n);
            Console.WriteLine($"(double){n} " + (double)n);
            Console.ReadKey();

        }
    }
}
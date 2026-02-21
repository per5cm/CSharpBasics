using System;
using System.Collections.Generic;
using System.Text;

namespace Recursive
{
    internal class Fibonacci
    {
        public static double FibonacciRecursive(int x)
        {
            if (x <= 1) return x;
            Console.WriteLine(x);
            return FibonacciRecursive(x - 1) + FibonacciRecursive(x - 2);
        }

        public static long FibonacciFor(int x)
        {
            long previous = 0;
            long current = 1;
            long tempVariable;

            for (int i = 1; i <= x; i++)
            {
                tempVariable = previous;
                previous = current;
                current = tempVariable + current;
                Console.WriteLine($"Fibonacci iteration step +{i} => result: {current}");
            }
            return current;
        }
    }
}

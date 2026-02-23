using System;
using System.Collections.Generic;
using System.Text;

namespace Recursive
{
    internal class Factorial
    {
        // factorial is usefull for calculating odds in lottery or brute force a guess on password.
        public static int FactorialFor(int x = 5)
        {
            int sum = 1;

            for (int i = 1; i <= x; i++)
            {
                sum *= i;
                Console.WriteLine(sum);
            }
            return sum;
        }

        public static int FactorialWhile(int x = 5)
        {
            int sum = 1;
            int up = 1;

            while (up <= x)
            {
                sum *= up;
                up++;
                Console.WriteLine(sum);
            }

            return sum;
        }

        public static int FactorialRecursive(int x)
        {
            if (x <= 1)
            {
                return 1;
            }
            else
            {
                return x * FactorialRecursive(x - 1);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Recursive
{
    internal class Power
    {
        public static double PowerOf(int number, int power)
        {
            double result = 1;

            if (power > 0)
            {
                for (int i = 1; i <= power; i++)
                {
                    result *= number;
                }
            }

            else if (power < 0)
            {
                for (int i = -1; i >= power; i--)
                {
                    result /= number;
                }
            }

            return result;
        }
    }
}

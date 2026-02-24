using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Loops
{
    internal class ForLoop
    {
        internal static (int Width, int Height) UglyFor(int x = 3, int y = 10)
        {
            int total = 0;

            for (int row = 1; row <= y; row++)
            {
                //for (int column = 0; column < x; column++)
                {
                    //total += x;
                    Console.Write(row * x);
                    if (x < y) Console.Write(", ");
                }
                //Console.WriteLine();
            }

            return (x, y);
        }
    }
}

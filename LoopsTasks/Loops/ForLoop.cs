using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Loops
{
    internal class ForLoop
    {
        internal static (int Step, int Total) UglyFor(int x = 3, int total = 10)
        {
            //int total = 0;

            for (int step = 1; step <= total; step++)
            {
                //total += x;
                Console.Write(step * x);
                if (x < total) Console.Write(", ");
                
                //Console.WriteLine();
            }

            return (x, total);
        }
    }
}

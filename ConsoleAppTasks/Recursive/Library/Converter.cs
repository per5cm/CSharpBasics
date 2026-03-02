using System;
using System.Collections.Generic;
using System.Text;

namespace Recursive.Library
{
    internal class Converter
    {
        public static double CircularRadius(double radius)
        {
            return radius * radius * Math.PI;
        }

        public static string PrintDual(int binary)
        {
            // decimal to binary converter.
            return Convert.ToString(binary, 2);
        }

        public static string Octal(int oct)
        {
            return Convert.ToString(oct, 8);
        }

        public static string PrintHex(int hex)
        {
            return Convert.ToString(hex, 16);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Recursive.Library.ComplexLib
{
    // readonly makes Complex get imutable. no mutations anywhere even inside methods.
    internal readonly struct Complex
    {
        internal double Real { get; }
        internal double Imaginary { get; }

        internal Complex(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }
    }
}

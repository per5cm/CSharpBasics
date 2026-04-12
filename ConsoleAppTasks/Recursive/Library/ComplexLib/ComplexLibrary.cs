using System;
using System.Collections.Generic;
using System.Text;

namespace Recursive.Library.ComplexLib

/*
    Eigenschaft	    struct	        class
    ===============================================
    Typ	            Werttyp	        Referenztyp
    Speicher	    Stack	        Heap
    Vererbung	    nein	        ja
    Null möglich	nein	        ja
    Kopieren	    Wertkopie	    Referenz
    Performance	    kleine Daten	komplexe Objekte
 */

/*====================================================================
  a = C1.realeZahl
  b = C1.imaginaereZahl
  c = C2.realeZahl
  d = C2.imaginaereZahl
====================================================================*/
{
    internal static class ComplexLibrary
    {
        //internal static readonly Complex complex1 = new (2.0, 3.0);
        //internal static readonly Complex complex2 = new (4.0, 5.0);

        internal static void PrintComplex(Complex complex)
        {
            if (complex.Imaginary == 0)
            {
                Console.WriteLine(complex.Real);
                return;
            }

            string sign = complex.Imaginary > 0 ? "+" : "-";
            double absIn = Math.Abs(complex.Imaginary);

            if (complex.Real == 0)
                Console.WriteLine($"{absIn}{sign}i");
            else
                Console.WriteLine($"{complex.Real}{sign}{absIn}i");
        }
        internal static Complex AdditionComplex(Complex complex1, Complex complex2)
        {
            // (a + b * i) + (c + d * i) = (a + c) + (b + d) * i

            // real part: a + b * i
            double realPart = complex1.Real + complex2.Real;

            // imaginary part: b + d * i
            double imaginaryPart = complex1.Imaginary + complex2.Imaginary;

            return new Complex(realPart, imaginaryPart);
        }

        internal static Complex SubtractionComplex(Complex complex1, Complex complex2)
        {
            //(a + b · i) − (c + d · i) = (a − c) + (b − d)· i

            // a − c * i
            double realPart = complex1.Real - complex2.Real;

            // b − d * i
            double imaginaryPart = complex1.Imaginary - complex2.Imaginary;

            return new Complex(realPart, imaginaryPart);
        }

        internal static Complex MultiplicationComplex(Complex complex1, Complex complex2)
        {
            // (a + b · i) · (c + d · i) = (a · c – b · d) + (a · d + b · c) · i

            // (a · c – b · d)
            double realPart = (complex1.Real * complex2.Real) - (complex1.Imaginary * complex2.Imaginary);

            // (a · d + b · c)
            double imaginaryPart = (complex1.Real * complex2.Imaginary) + (complex1.Imaginary * complex2.Real); 
            
            return new Complex(realPart, imaginaryPart);
        }

        internal static Complex DivisionComplex(Complex complex1, Complex complex2)
        {
            double denominator = complex2.Real * complex2.Real + complex2.Imaginary * complex2.Imaginary;
            if (Math.Abs(denominator) < 1e-12)
                throw new DivideByZeroException("Division durch Null - Komplex.");

            double realPart = (complex1.Real * complex2.Real + complex1.Imaginary * complex2.Imaginary) / denominator;
            double imaginaryPart = (complex1.Imaginary * complex2.Real - complex1.Real * complex2.Imaginary) / denominator;

            return new Complex(realPart, imaginaryPart);
        }

        internal static double Norm(Complex complex)
        {
            double square = (complex.Real * complex.Real + complex.Imaginary * complex.Imaginary);

            return Math.Sqrt(square);
        }

        internal static uint Threshold(Complex complex, double escapeRadius, uint maxIterations)
        {
            Complex currentPart = new (0, 0);
            uint iteration = 0;

            while (Norm(currentPart)  <= escapeRadius && iteration < maxIterations) // hardcoded 1000 medium range, see table for rough render time multiplier.
            {
                currentPart = MultiplicationComplex(currentPart, currentPart);
                currentPart = AdditionComplex(currentPart, complex);

                iteration++;
            }

            return iteration;
        }

        internal static uint ThresholdFast(Complex complex, double escapeRadius, uint maxIterations)
        {
            double realPart = 0, imaginaryPart = 0;
            uint iteration = 0;
            double escapeRadiusSquared = escapeRadius * escapeRadius;

            while ((realPart * realPart + imaginaryPart * imaginaryPart) <= escapeRadiusSquared && iteration < maxIterations)
            {
                double newRealPart = (realPart * realPart - imaginaryPart * imaginaryPart) + complex.Real;
                double newImaginaryPart = (2 * realPart * imaginaryPart) + complex.Imaginary;
                realPart = newRealPart; 
                imaginaryPart = newImaginaryPart;
                iteration++;
            }

            return iteration;
        }
    }
}

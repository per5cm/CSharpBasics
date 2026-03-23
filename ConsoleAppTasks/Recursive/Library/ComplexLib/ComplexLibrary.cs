using System;
using System.Collections.Generic;
using System.Text;

namespace Recursive.Library.ComplexStruct

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
            if (complex.Imaginary == 0) Console.WriteLine($"{complex.Real}");
            else if (complex.Imaginary > 0) Console.WriteLine($"{complex.Real} + {complex.Imaginary}i");
            // < 0
            else Console.WriteLine($"{complex.Real} - {Math.Abs(complex.Imaginary)}i");
            
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

        internal static Complex SubstractionComplex(Complex complex1, Complex complex2)
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
                throw new DivideByZeroException("Division durch Null Komplex.");

            double realPart = (complex1.Real * complex2.Real + complex1.Imaginary * complex2.Imaginary) / denominator;
            double imaginaryPart = (complex1.Imaginary * complex2.Real - complex1.Real * complex2.Imaginary) / denominator;

            return new Complex(realPart, imaginaryPart);
        }

        internal static int Norm(Complex c)
        {
            int x = 0;
            return x;
        }

        internal static uint Waves(Complex c, double waveValue)
        {
            uint x = 0;
            return x;
        }
    }
}

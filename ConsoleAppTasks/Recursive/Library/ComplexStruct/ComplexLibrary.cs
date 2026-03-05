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
    internal class ComplexLibrary
    {
        Complex comeplex;
        Complex complex1 = new Complex(2.0, 3.0);
        Complex complex2 = new Complex(4.0, 5.0);
    

    internal static void PrintComplex(Complex complex)
        {
            if (complex.imaginary == 0) Console.WriteLine($"{complex.real}");
            else if (complex.imaginary > 0) Console.WriteLine($"{complex.real} + {complex.imaginary}i");
            // < 0
            else Console.WriteLine($"{complex.real} - {Math.Abs(complex.imaginary)}i");
            
        }
        internal Complex AddComplex(Complex complex1, Complex complex2)
        {
            // (a + b * i) + (c + d * i) = (a + c) + (b + d) * i

            // real part: a + b * i
            double newReal = complex1.real + complex2.real;

            // imaginary part: b + d * i
            double newImaginary = complex1.imaginary + complex2.imaginary;

            return new Complex(newReal, newImaginary);
        }

        internal Complex MultComplex(Complex complex1, Complex complex2)
        {
            // (a + b · i) · (c + d · i) = (a · c – b · d) + (a · d – b · c) · i

            // (a · c – b · d)
            double real = complex1.real * complex2.real - complex1.imaginary * complex2.imaginary;

            // (a · d – b · c)
            double imaginary = complex1.real * complex2.imaginary + complex1.imaginary * complex2.real; 
            
            return new Complex(real, imaginary);
        }

        internal int Norm(Complex c)
        {

        }

        internal static uint Waves(Complex c, double waveValue)
        {

        }
    }
}

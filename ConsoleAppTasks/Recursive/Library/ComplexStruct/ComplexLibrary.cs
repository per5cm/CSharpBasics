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
        Complex comeplex0;
        Complex complex1 = new Complex(2.0, 3.0);
        Complex complex2 = new Complex(4.0, 5.0);
    

    internal static void PrintComplex(Complex complex0)
        {
            
        }
        internal Complex AddComplex(Complex complex1, Complex complex2)
        {

            Console.WriteLine("{0} + {1} = {2}", complex1, complex2, complex1 + complex2);
        }

        internal Complex MultComplex(Complex complex1, Complex complex2)
        {

        }

        internal int Norm(Complex c)
        {

        }

        internal static uint Waves(Complex c, double waveValue)
        {

        }
    }
}

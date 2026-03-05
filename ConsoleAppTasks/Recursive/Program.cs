
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using static System.Runtime.InteropServices.JavaScript.JSType;
using SixLabors.ImageSharp.Formats.Png;
using Recursive.Library;
using System.Security.Cryptography;

namespace Recursive
{
    internal class Program
    {   
        public static void Main(string[] args)
        {

            GeometryDraw.DrawImage();
            //int numberFactorial = 5;
            //Console.WriteLine($"\n with For loop -> {Factorial.FactorialFor()}");
            //Console.WriteLine($"\n with While loop -> {Factorial.FactorialWhile()}");
            //Console.WriteLine($"\n with Recursive -> {Factorial.FactorialRecursive(5)}");

            //Console.WriteLine($"\nFibonacci = {Fibonacci.FibonacciFor(10)}");

            //Console.WriteLine($"\npattern x width, y height: {ChainLoop.Chain(8, 10)}");

            //Console.WriteLine("\nSome power examples");
            //Console.WriteLine("\n2^ 3 = " + Power.PowerOf(2, 3));
            //Console.WriteLine("5^ 2 = " + Power.PowerOf(5, 2));
            //Console.WriteLine("3^ -2 = \n" + Power.PowerOf(3, -2));

            //Power.AsText();

            //int zahl = -142;

            //string s = zahl.ToString();
            //if (zahl < 0) Console.Write("minus ");
            //foreach (char c in s) Power.PrintLetter(Convert.ToInt32(c - '0'));

        }
    }
}
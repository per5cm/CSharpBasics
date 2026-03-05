
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
        static void DrawImage()
        {
            Image<Rgba32> img = new(600, 400);

            Rgba32 c1 = new Rgba32(0, 0, 255);
            

            Geometry.Background(img, c1);

            for (int i = 0; i < 10; i++)
            {
                int x = RandomNumberGenerator.GetInt32(19) + 1;
                Rgba32 c2 = new Rgba32(x*10, x*12, x*20, 200);

                Geometry.FillRect(img, c2, x, x, x + 20, x + 20);
            }

            string timeStamp = DateTime.Now.ToString("fff_dd.MM.yyyy");
            string fileName = $"image_{timeStamp}.png";

            string dir = "Images";
            Directory.CreateDirectory(dir);

            string path = Path.Combine(dir, fileName);

            img.Save(path, new PngEncoder());
        }

        public static void Main(string[] args)
        {

            DrawImage();
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
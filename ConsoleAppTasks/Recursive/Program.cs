
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using static System.Runtime.InteropServices.JavaScript.JSType;
using SixLabors.ImageSharp.Formats.Png;

namespace Recursive
{
    internal class Program
    {          
        static public void AsText()
        {
            Console.WriteLine("Bitte ganze zahl eingeben, kann negative sein: ");
            int input = Convert.ToInt32(Console.ReadLine());

            if(input == 0)
            {
                PrintLetter(0);
                return;
            }

            if (input < 0)
            {
                Console.Write("minus ");
                input =- input;
            }
            HighestPowerOfTen(input);
            //if (number >= 100)
            //{
            //    int hundret = number / 100;
            //    PrintLetter(hundret);
            //    number = number % 100;
            //}

            //if (number >= 10)
            //{
            //    int ten = number / 10;
            //    PrintLetter(ten);
            //    number = number % 10;
            //}

            //if (number > 0)
            //{
            //    PrintLetter(number);
            //}
        }

        public static int HighestPowerOfTen(int number)
        {
            List<int> numbers = new ();

            while (number > 0)
            {
                int digit = number % 10;
                //PrintLetter(digit);
                numbers.Add(digit);
                number = number / 10;               
            }

            numbers.Reverse();

            foreach (int digit in numbers)
            {
                PrintLetter(digit);
            }
            return numbers.Count;
        }

        public static void PrintLetter(int number)
        {
            var numberToLetter = new Dictionary<int, string>
            {
                { 0, "null" },
                { 1, "eins" },
                { 2, "zwei" },
                { 3, "drei" },
                { 4, "vier" },
                { 5, "fünf" },
                { 6, "sechs" },
                { 7, "sieben" },
                { 8, "acht" },
                { 9, "neun" }
            };

            //with! you can reverse bool try.
            numberToLetter.TryGetValue(number, out var letter);
            Console.Write(letter + " - ");

            //switch (number)
            //{
            //    case 0: Console.Write("null "); break;
            //    case 1: Console.Write("eins, "); break;
            //    case 2: Console.Write("zwei, "); break;
            //    case 3: Console.Write("drei, "); break;
            //    case 4: Console.Write("vier, "); break;
            //    case 5: Console.Write("fünf, "); break;
            //    case 6: Console.Write("sechs, "); break;
            //    case 7: Console.Write("sieben, "); break;
            //    case 8: Console.Write("acht, "); break;
            //    case 9: Console.Write("neun, "); break;
            //}

            // // it can be huge if else if block as list.

        }

        public static void Main(string[] args)
        {
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

            //AsText();

            //int zahl = -142;

            //string s = zahl.ToString();
            //if (zahl < 0) Console.Write("minus ");
            //foreach (char c in s) PrintLetter(Convert.ToInt32(c -'0'));

            Image<Rgba32> img = new (400, 300);
            Rgba32 c1 = new Rgba32(155, 255, 55);
            Rgba32 c2 = new Rgba32(255, 155, 55);
            Rgba32 c3 = new Rgba32(120, 55, 120);

            Geometry.Background(img, c1);
            Geometry.FillRect(img, c2, 50, 50, 40, 30);
            Geometry.DrawLine(img, c3, 10, 10, 30, 30);
            Geometry.DrawLine(img, c3, 10, 30, 30, 10);

            string timeStamp = DateTime.Now.ToString("fff_dd.MM.yyyy");
            string fileName = $"image_{timeStamp}.png";

            string dir = "Images";
            Directory.CreateDirectory(dir);

            string path = Path.Combine(dir, fileName);

            img.Save(path, new PngEncoder());
        }
    }
}
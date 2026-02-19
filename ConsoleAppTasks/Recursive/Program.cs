
namespace Recursive
{
    internal class Program
    {
        public static int FactorialFor(int x = 5)
        {
            int sum = 1;

            for(int i = 1; i <= x; i++)
            {
                sum *= i;
                Console.WriteLine(sum);
            }
            return sum;
        }

        public static int FactorialWhile(int x = 5)
        {
            int sum = 1;
            int up = 1;

            while(up <= x)
            {
                sum *= up;
                up++;
                Console.WriteLine(sum);
            }

            return sum;
        }

        public static int FactorialRecursive(int x)
        {
            if (x <= 1)
            {
                return 1;
            }
            else
            {
                return x * FactorialRecursive(x - 1);
            }
        }

        public static double FibonacciRecursive(int x)
        {
            if (x <= 1) return x;
            Console.WriteLine(x);
            return FibonacciRecursive(x - 1) + FibonacciRecursive(x - 2);
        }

        public static long FibonacciFor(int x)
        {
            long previous = 0;
            long current = 1;
            long tempVariable;

            for (int i = 1; i <= x; i++)
            {
                tempVariable = previous;
                previous = current;
                current = tempVariable + current;
                Console.WriteLine($"Fibonacci iteration step +{i} => result: {current}");
            }
            return current;
        }

        public static double Power(int number, int power)
        {
            double result = 1;

            if (power > 0)
            {
                for (int i = 1; i <= power; i++)
                {
                    result *= number;
                }
            }

            else if (power < 0)
            {
                for (int i = -1; i >= power; i--)
                {
                    result /= number;
                }
            }

            return result;
        }

        static public int Chain(int x)
        {
            for(int row = 0; row < x; row++)
            {
                for(int colum = 0; colum < x; colum++)
                {
                    if (colum == row || colum == x - 1 - row)
                    {
                        Console.Write(".");
                    }
                    else
                    {
                        Console.Write("X");
                    }
                }
                Console.WriteLine();
            }
            return x;
        }

        public static void Main(string[] args)
        {
            //int numberFactorial = 5;
            Console.WriteLine($"\n with For loop -> {FactorialFor()}");
            Console.WriteLine($"\n with While loop -> {FactorialWhile()}");
            Console.WriteLine($"\n with Recursive -> {FactorialRecursive(5)}");

            Console.WriteLine($"\nFibonacci = {FibonacciFor(10)}");

            Console.WriteLine($"\nX pattern: {Chain(15)}");

            Console.WriteLine("\nSome power examples");
            Console.WriteLine("\n2^ 3 = " + Power(2, 3));
            Console.WriteLine("5^ 2 = " + Power(5, 2));
            Console.WriteLine("3^ -2 = \n" + Power(3, -2));
        }
    }
}

namespace Recursive
{
    internal class Program
    {
        public static int FactorialFor(int x)
        {
            int sum = 1;

            for(int i = 1; i <= x; i++)
            {
                sum *= i;
                Console.WriteLine(sum);
            }
            return sum;
        }

        public static int FactorialWhile(int x)
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

        public static int Fibonachi(int x)
        {
            int a = 0, b = 1; x = 0;

            {
                for(int i = 2; i < x; i++)
                {
                    x = a + b;
                    a = b;
                    b = x;
                }

                return x;
            }
        }

        public static void Main(string[] args)
        {
            int number = 5;

            //Console.WriteLine(FactorialFor(number));
            //Console.WriteLine(FactorialWhile(number));
            //Console.WriteLine(FactorialRecursive(number));
            Console.WriteLine(Fibonachi(number));
        }
    }
}
namespace Loops
{
    internal class ForLoop
    {
        internal static (int Step, int Total) UglyFor(int x = 3, int total = 10)
        {
            //int total = 0;

            for (int step = 1; step <= total; step++)
            {
                //total += x;
                Console.Write(step * x);
                if (x < total) Console.Write(", ");
                
                //Console.WriteLine();
            }

            return (x, total);
        }
        internal static void DuePay()
        {
            Console.WriteLine("Principal amount in Euro: ");
            if (!double.TryParse(Console.ReadLine(), out double principal) || principal <= 0) goto Error;

            Console.WriteLine("Enter a interest rate: ");
            if (!double.TryParse(Console.ReadLine(), out double interest) || interest <= 0) goto Error;

            Console.WriteLine("Enter a time period: ");
            if (!double.TryParse(Console.ReadLine(), out double time) || time <= 0) goto Error;

            double rate = interest / 100;

            for(int start = 1; start <= time; start++ )
            {
                principal *= (1 + rate);

                Console.WriteLine($"Interest after {time} Year will be: {principal:F2}");
            }

        Error:
            Console.WriteLine("Invalid input. Try again.");
        }

        internal static void PrintNumbers()
        {
            for (int i = 0; i <= 20; i++)
            {
                Console.WriteLine($"print: {i}");
            }
        }

        internal static void EvenOrOdd(int number = 20)
        {
            
        }
    }
}

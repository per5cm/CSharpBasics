namespace Loops.Library
{
    internal class ForLoop
    {
        internal static void Ex1_1()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"for line print: {i}");
            }
        }

        internal static void Ex1_4()
        {
            int sum = 0;
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"current number: {i}");
                sum += 1;
            }
            
            Console.WriteLine($"total sum: {sum}");
        }

        internal static void Ex2_1()
        {
            for (int i = 1; i <= 50; i++)
            {
                if (i > 40) break;
                if (i % 3 == 0) continue;
                
                Console.WriteLine($"result: {i}");
            }
        }

        internal static void Ex2_2()
        {
            for (int i = 1; i <= 30; i++)
            {
                if (i % 3 == 0) Console.WriteLine("Fizz");
                if (i % 5 == 0) Console.WriteLine("Buzz");
                if (i % 15 == 0) Console.WriteLine("FizzBuzz");
            }
        }

        internal static void Ex2_3()
        {
            for (int row = 1; row <= 5; row++)
            {
                for (int col = 1; col <= 5; col++)
                {
                    Console.Write(row * col + ",");
                }
                
                Console.WriteLine();
            }
        }

        internal static void Ex2_4()
        {
            for (int row = 1; row <= 6; row++)
            {
                for (int col = 1; col <= 6; col++)
                {
                    if (row >= col)
                    {
                        Console.Write("*");
                    }
                }
                
                Console.WriteLine();
            }
        }

        internal static void Ex2_5()
        {
            int[] data = { 4, 8, 15, 16, 23, 42 };
            int target = 16;
            int foundAt = -1;

            for (int i = 0; i < data.Length; i++)
            {
                if (target == data[i]);
                {
                    foundAt = i;
                    break;
                }
            }
            
            Console.WriteLine($"index found at: {foundAt}");
        }

        internal static void Ex3_1()
        {
            int[,] grid =
            {
                {1, 2, 3, 4},
                {5, 6, 7, 8},
                {9, 10, 11, 12},
            };

            int grand = 0;
            for (int row = 0; row < grid.GetLength(0); row++)
            {
                int rowSum = 0;
                for (int col = 0; col < grid.GetLength(1); col++)
                {
                    rowSum += grid[row, col];
                }

                Console.WriteLine($"row sum: {rowSum}");
                grand += rowSum;
            }
            
            Console.WriteLine($"grand total: {grand}");
        }

        internal static void Ex3_2()
        {
            int[] array = { 5, 2, 9, 1, 7, 3 };
            
            for (int pass = 0; pass < array.Length - 1; pass++)
            {
                for (int i = 0; i < array.Length - 1 - pass; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        (array[i], array[i + 1]) = (array[i + 1], array[i]);
                    }
                }
            }
            
            Console.WriteLine("Sorted Array: ");
            string s = string.Join(", ", array);
            Console.WriteLine($"Values: {s}");
        }

        internal static void Ex3_3()
        {
            for (int n = 2; n <= 50; n++)
            {
                bool isPrime = true;
                for (int d = 2; d * d <= n; d++)
                {
                    if (n % d == 0)
                    {
                        isPrime = false;
                        Console.WriteLine($"Not prime number: {n}");
                        break;
                    }
                }
                
                if (isPrime) Console.WriteLine($"Is prime number: {n}");
            }
        }
    }
}

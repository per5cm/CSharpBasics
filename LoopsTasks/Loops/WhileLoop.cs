using System;
using System.Collections.Generic;
using System.Text;

namespace Loops
{
    internal class WhileLoop
    {
        internal static void UglyWhile(int condition = 1)
        {
            Console.WriteLine("Enter the number to check divisible: ");
            int number = Convert.ToInt32(Console.ReadLine());

            if (number == 0)
            {
                Console.WriteLine("Number cant be 0.");
            }

            while (condition <= number)
            {
                if (number % condition == 0)
                {
                    Console.WriteLine($"Divisible number of {number} are: {condition}");                    
                }
                condition++;
            }
        }

        internal static void UglyDoWhile()
        {

        }
    }
}

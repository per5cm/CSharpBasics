namespace Loops.Library
{
    internal class ForEachLoop
    {
        internal static void Ex1_5()
        {
            string[] fruits = { "apple", "banana", "cherry", "date" };
            int pos = 1;

            foreach (var fruit in fruits)
            {
                Console.WriteLine($"Position: {pos}, Fruit name: {fruit}");
                pos++;
            }
        }

        internal static void Ex2_6()
        {
            int[] squares = new int[10];

            for (int i = 0; i < squares.Length; i++)
            {
                squares[i] = (i + 1) * (i + 1);
                // Console.Write(squares[i] + " ");
            }

            var evens = new List<int>();
            foreach (var s in squares)
            {
                if (s % 2 == 0) evens.Add(s);
                // Console.Write(s + ",");
            }

            int running = 0;
            foreach (var e in evens)
            {
                running += e;
                Console.Write(e + "," + running + ":");
            }
        }
    }
}


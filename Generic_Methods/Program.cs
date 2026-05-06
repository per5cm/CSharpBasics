namespace Generic_Methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Swap
            int a = 5, b = 10;
            Console.WriteLine($"a = {a}, b = {b}");
            
            Swap(ref a, ref b);
            Console.WriteLine($"a = {a}, b = {b}");
            // a = 10, b = 5

            string x = "hello", y = "world";
            Swap(ref x, ref y);
            // x = "world", y = "hello"
            
            PrintAll(new List<int> { 1, 2, 3 });
            
            PrintAll(new List<string> { "cat", "dog", "bird" });
        }

        private static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        private static void PrintAll<T>(List<T> list) // or T[] for an array
        {
            foreach (T item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
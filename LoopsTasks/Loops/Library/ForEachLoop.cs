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
            }

            var evens = new List<int>();
            foreach (var s in squares)
            {
                if (s % 2 == 0) evens.Add(s);
            }

            int running = 0;
            foreach (var e in evens)
            {
                running += e;
                Console.Write(e + "," + running + ":");
            }
        }
        
        internal static void Ex3_4()
        {
            string sentence = "the cat sat on the mat the cat ran the matt";
            string[] raw = sentence.Split(' ');

            var words = new List<string>();
            
            // Stage A
            foreach (var w in raw)
            {
                words.Add(w.ToLower());
            }

            var counts = new Dictionary<string, int>();
            
            // Stage B
            foreach (var w in words)
            {
                if (counts.ContainsKey(w))
                {
                    counts[w] += 1;
                }
                else
                {
                    counts.Add(w, 1);
                }
            }

            int max = 0;
            
            // Stage C
            foreach (var kvp in counts)
            {
                if (kvp.Value >= max)
                {
                    max = kvp.Value;
                }
            }
            
            // Stage D
            foreach (var kvp in counts)
            {
                if (kvp.Value == max)
                {
                    Console.WriteLine($"Word: {kvp}");
                }
            }
        }
    }
}


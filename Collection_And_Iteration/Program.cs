namespace Collection_And_Iteration
{
    internal class Program
    {
        // private readonly List<string> _words = new() { "apple", "banana", "apple", "cherry", "banana", "apple" };

        private static Dictionary<string, int> CountWords(List<string> words)
        {
            var wordCount = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (wordCount.TryGetValue(word, out int count))
                    wordCount[word] = count + 1;
                else
                    wordCount[word] = 1;
                // short version
                // wordCount[word] = wordCount.GetValueOrDefault(word) + 1;
            }
            return wordCount;
        }

        internal static void Main(string[] args)
        {
            var words = new List<string> { "apple", "banana", "apple", "cherry", "banana", "apple" };
            var result = CountWords(words);
            
            // for each its just a debug to display on terminal the output of dictionary.
            foreach (var word in result)
                Console.WriteLine($"{word.Key}: {word.Value}");
        }
        
    }
}
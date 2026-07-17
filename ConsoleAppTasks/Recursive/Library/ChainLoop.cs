namespace Recursive.Library
{
    internal class ChainLoop
    {
        //tuple (int width, int height)
        static public (int Width, int Height) Chain(int x, int y)
        {
            for (int row = 0; row < x; row++)
            {
                for (int column = 0; column < y; column++)
                {
                    if (column == row || column == y - 1 - row)
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
            return (x, y);
        }
    }
}

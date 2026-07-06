using Playground.Library;

namespace Playground
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try { Divide.DivideCheck(10, 0); }
            catch (Exception e) { Console.WriteLine($"Error: {e.Message}"); }
            finally { Console.WriteLine("Press any key to exit."); Console.ReadKey(); }
            
            try { Divide.DivideCheck(-5, 2); }
            catch (Exception e) { Console.WriteLine($"Error: {e.Message}"); }
            finally { Console.WriteLine("Press any key to exit."); Console.ReadKey(); }
            
            try { Divide.DivideCheck(10, 2); }
            catch (Exception e) { Console.WriteLine($"Error: {e.Message}"); }
            finally { Console.WriteLine("Press any key to exit."); Console.ReadKey(); }
        }
    }
}
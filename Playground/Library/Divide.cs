namespace Playground.Library;

public class Divide
{
    internal double DivideCheck(double num1, double num2)
    {
        if (num2 == 0)
            throw new DivideByZeroException("cant divide 0");
        
        if (num1 < 0 || num2 < 0)
            throw new ArgumentOutOfRangeException(nameof(num1), nameof(num2), "number cant be negative");
        
        return num1 / num2;
    }
}
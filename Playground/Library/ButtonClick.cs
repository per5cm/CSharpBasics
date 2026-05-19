namespace Playground.Library;

public class ButtonClick
{
    // Button fires OnClick when Clicked() is called
    // Multiple subscribers can listen to the same event

    internal static ButtonClick Divide = new ButtonClick();
    Button button = new("Submit");

    button.OnClick += (sender, msg) => Console.WriteLine($"Handler 1: {msg}");
    button.OnClick += (sender, msg) => Console.WriteLine($"Handler 2: {msg}");

    button.Click();

    // Output:
    // Handler 1: Submit was clicked!
    // Handler 2: Submit was clicked!
}
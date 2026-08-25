using OOPTasks.Library;

namespace OOPTasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1.1, 1.2, 1.3
            Book alchemist = new Book("Alchemist", 300);
            alchemist.Describe();
            
            // 1.4
            // BankAccount account = new BankAccount();
            // account.Deposit(-500);
            // account.Withdraw(-200);

            // 1.5
            // Counter  a = new Counter(0);
            // Counter b = new Counter(0);
            //
            // a.Increment();
            // b.Increment();
            // b.Reset();
            // Console.WriteLine($"output a: {a.Value}, output b: {b.Value}");

            Point a = new Point(1, 1);
            Point b = a;
            b.Move(5, 5);
            
            Console.WriteLine($"a position: {a.X}, b position: {b.X}");
            
            // 2.2 static members

            MathUtils.Square(1);
            MathUtils.Square(2);
            MathUtils.Square(3);
            Console.WriteLine(MathUtils.CallCount);
            
            // 2.3, 2.4
    
            Dog husky = new Dog(name:"Bob", energy:100);
            Console.WriteLine(husky);
            husky.Speak();
            husky.Fetch();
            
            // 2.5

            Car newCar = new Car(make:"Ford", door:4);
            Console.WriteLine($"{newCar.Make}, {newCar.Door}");
            
            // 2.6

            Manager bob = new Manager(salary: 200, bonus:20);
            Console.WriteLine($"Salary: {bob.Salary}, Bonus {bob.Bonus}, Total: {bob.GrossPay()}");
        }
    }
}
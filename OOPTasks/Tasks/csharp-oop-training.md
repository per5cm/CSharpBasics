# C# OOP Training — Minimal → Medium → Advanced

Same rules as the loops set: fill the `// TODO` gaps, no solutions to scroll to. Compile, run, check against the "Check" notes under each exercise.

OOP is less about output and more about **structure** — so for many of these the real check is "does it compile with the access rules I intended, and can I explain why a field is `private` vs `protected`?" Where output matters, it's noted.

Suggested setup: one file per tier, or one class per file if your IDE prefers that. Put a small `Main` at the bottom that news-up your objects and calls their methods.

---

## TIER 1 — MINIMAL (a single class, fields, methods, encapsulation)

### 1.1 — Your first class
A `Book` with a title and page count. A method that prints a one-line summary.

```csharp
class Book
{
    // TODO: two fields — title (string), pages (int)

    // TODO: a method Describe() that prints "Title — N pages"
}

// in Main:
// TODO: create a Book, set its fields, call Describe()
```

### 1.2 — Constructor
Same `Book`, but force title and pages to be set at creation. No object should exist without them.

```csharp
class Book
{
    private string title;
    private int pages;

    // TODO: constructor taking title and pages, assigning the fields

    public void Describe() { /* TODO */ }
}
```
Check: can you still create a `Book` with no arguments? Should you be able to?

### 1.3 — Properties (get/set)
Replace raw public fields with **properties**. Expose `Title` read/write, but make `Pages` settable only inside the class (private set).

```csharp
class Book
{
    public string Title { get; set; }
    public int Pages { get; /* TODO: add a setter here, but make it private */ }

    public Book(string title, int pages)
    {
        // TODO assign via the properties
    }
}
```

### 1.4 — Encapsulation with validation
A `BankAccount`. Balance must never go negative. `Deposit` and `Withdraw` are the only ways to change it; the balance field itself is private and has no public setter.

```csharp
class BankAccount
{
    private decimal balance;

    public decimal Balance => balance;   // read-only view

    public void Deposit(decimal amount)
    {
        // TODO reject non-positive amounts, otherwise add
    }

    public bool Withdraw(decimal amount)
    {
        // TODO reject if amount <= 0 or amount > balance; return false
        // TODO otherwise subtract and return true
    }
}
```
Check: from `Main`, try to set `account.balance = -500;` — it should not compile. That failure *is* encapsulation working.

### 1.5 — `this` and method interaction
A `Counter` with `Increment()`, `Reset()`, and a `Value` property. `Increment` uses `this.count`. Wire three counters and prove they're independent.

```csharp
class Counter
{
    private int count;
    public int Value => count;

    // TODO Increment(), Reset()
}
```

---

## TIER 2 — MEDIUM (structs, static, inheritance, protected)

### 2.1 — `struct` vs `class` (value vs reference)
Make a `Point` **struct** with `X` and `Y` and a `Move(dx, dy)` method. Then run the experiment below and explain the output.

```csharp
struct Point
{
    public int X;
    public int Y;

    public Point(int x, int y) { /* TODO */ }

    public void Move(int dx, int dy) { /* TODO mutate X and Y */ }
}

// Experiment in Main:
Point a = new Point(1, 1);
Point b = a;          // copy or reference?
b.Move(5, 5);
// TODO print a and b. Are they the same? WHY?
// Now change 'struct' to 'class' and re-run. What changes?
```
This is the whole point of the exercise — write down the difference in one sentence before moving on.

### 2.2 — `static` members
A `MathUtils` class with no instances. A static method `Square(int)` and a static field `CallCount` that increments every time `Square` is called.

```csharp
static class MathUtils
{
    public static int CallCount;   // TODO think: why does static make sense here?

    public static int Square(int n)
    {
        // TODO bump CallCount, return n*n
    }
}
```
Check: you should never write `new MathUtils()`. Why does `static class` forbid it?

### 2.3 — Basic inheritance
An `Animal` base class with a `Name` and a `Speak()` method that prints a generic sound. A `Dog` subclass that inherits `Name` but overrides nothing yet — it just adds a `Fetch()` method.

```csharp
class Animal
{
    public string Name { get; }
    public Animal(string name) { Name = name; }

    public void Speak() { Console.WriteLine($"{Name} makes a sound."); }
}

class Dog : Animal
{
    // TODO constructor that passes name up to the base (: base(name))
    // TODO Fetch() method
}
```
Check: a `Dog` can call `Speak()` even though `Dog` didn't define it. Why?

### 2.4 — `protected`
Add a `protected` field `energy` to `Animal`. `Dog.Fetch()` should decrease it. Prove that `energy` is reachable from `Dog` but **not** from `Main`.

```csharp
class Animal
{
    protected int energy = 100;
    // ...
}

class Dog : Animal
{
    public void Fetch()
    {
        // TODO reduce energy, print it
    }
}

// in Main:
// TODO try to read dog.energy directly — confirm it won't compile.
```
Write down the difference between `private` and `protected` in your own words.

### 2.5 — `base` constructor chaining
A `Vehicle(string make)` base and a `Car(string make, int doors)` subclass. `Car`'s constructor must call the base constructor and then set its own field.

```csharp
class Vehicle
{
    public string Make { get; }
    public Vehicle(string make) { Make = make; }
}

class Car : Vehicle
{
    public int Doors { get; }

    // TODO constructor: pass make to base, set Doors
}
```

### 2.6 — Method chain across a hierarchy
`Employee` with `GrossPay()`. `Manager : Employee` adds a bonus. `Manager.GrossPay()` should reuse the base calculation via `base.GrossPay()` and add to it — not duplicate the formula.

```csharp
class Employee
{
    protected decimal baseSalary;
    public Employee(decimal s) { baseSalary = s; }

    public virtual decimal GrossPay() => baseSalary;   // note: virtual — needed for 2.6 & Tier 3
}

class Manager : Employee
{
    private decimal bonus;
    public Manager(decimal s, decimal b) : base(s) { bonus = b; }

    public override decimal GrossPay()
    {
        // TODO return base.GrossPay() + bonus
    }
}
```

---

## TIER 3 — ADVANCED (abstract, virtual/override, interfaces, polymorphism)

### 3.1 — `abstract` class + `abstract` method
A `Shape` that **cannot be instantiated** and forces every subclass to implement `Area()`. Implement `Circle` and `Rectangle`.

```csharp
abstract class Shape
{
    // TODO abstract method Area() returning double — no body

    public void Print() => Console.WriteLine($"Area = {Area():F2}");
}

class Circle : Shape
{
    private double r;
    public Circle(double r) { this.r = r; }
    // TODO override Area()
}

class Rectangle : Shape
{
    private double w, h;
    public Rectangle(double w, double h) { this.w = w; this.h = h; }
    // TODO override Area()
}
```
Check: `new Shape()` must not compile. `Circle` and `Rectangle` reuse the inherited `Print()` for free.

### 3.2 — `virtual` / `override` / `base`
Add a `virtual` `Describe()` to `Shape` that prints the area. Have `Circle` override it to *also* print the radius, but still call `base.Describe()` for the shared part.

```csharp
abstract class Shape
{
    public abstract double Area();

    public virtual void Describe()
    {
        // TODO print the area
    }
}

class Circle : Shape
{
    // ...
    public override void Describe()
    {
        base.Describe();           // reuse
        // TODO also print radius
    }
}
```

### 3.3 — Polymorphism through a base reference
Put mixed shapes in a `List<Shape>` and loop once, calling `Area()` on each. The **same call site** produces different behaviour per object — that's polymorphism.

```csharp
static void Ex3_3()
{
    var shapes = new List<Shape>
    {
        new Circle(2),
        new Rectangle(3, 4),
        // TODO add more
    };

    foreach (Shape s in shapes)
    {
        // TODO call s.Print() or s.Describe()
        // Note: the variable is 'Shape', but the RIGHT override runs. Why?
    }
}
```

### 3.4 — `interface`
Define `IMovable` with a `Move()` method and `IDescribable` with `ToText()`. A `Robot` that implements **both**. Interfaces are a contract, not an implementation.

```csharp
interface IMovable
{
    void Move(int dx, int dy);   // no body — interfaces declare, don't define
}

interface IDescribable
{
    string ToText();
}

class Robot : IMovable, IDescribable
{
    private int x, y;

    // TODO implement Move
    // TODO implement ToText (e.g. "Robot at (x, y)")
}
```
Check: a variable typed `IMovable r = new Robot();` can call `Move` but not the robot's other members. Why is that useful?

### 3.5 — Interface polymorphism
A method that accepts **any** `IDescribable` and prints its text. Pass it a `Robot`, and a second unrelated class (say `Report`) that also implements `IDescribable`. One method, unrelated types — that's the power of coding to an interface.

```csharp
static void PrintDescription(IDescribable item)
{
    // TODO print item.ToText()
}

// TODO: a Report class implementing IDescribable
// TODO: call PrintDescription with a Robot AND a Report
```

### 3.6 — Abstract + interface + polymorphism together (the "all that jazz")
Model a tiny payment system.

- `interface IPayable { decimal AmountDue(); }`
- `abstract class Invoice : IPayable` with a `protected decimal amount` and an abstract `AmountDue()`.
- `TaxedInvoice : Invoice` — adds tax in `AmountDue()`.
- `DiscountedInvoice : Invoice` — subtracts a discount in `AmountDue()`.
- A `static decimal Total(List<IPayable> items)` that sums `AmountDue()` across a mixed list.

```csharp
interface IPayable
{
    decimal AmountDue();
}

abstract class Invoice : IPayable
{
    protected decimal amount;
    protected Invoice(decimal amount) { this.amount = amount; }

    public abstract decimal AmountDue();
}

class TaxedInvoice : Invoice
{
    private decimal taxRate;
    public TaxedInvoice(decimal amount, decimal taxRate) : base(amount) { this.taxRate = taxRate; }

    // TODO AmountDue() = amount * (1 + taxRate)
}

class DiscountedInvoice : Invoice
{
    private decimal discount;
    public DiscountedInvoice(decimal amount, decimal discount) : base(amount) { this.discount = discount; }

    // TODO AmountDue() = amount - discount (floor at 0)
}

static decimal Total(List<IPayable> items)
{
    decimal sum = 0;
    // TODO loop, accumulate AmountDue()
    return sum;
}
```
Check: `Total` never mentions `TaxedInvoice` or `DiscountedInvoice` by name — it only knows `IPayable`. You can add a third invoice type later and `Total` needs zero changes. Sit with why that matters.

### 3.7 — `sealed` and hiding
Make `TaxedInvoice` `sealed` so nobody can subclass it. Then, separately, explore method **hiding**: define a `new` method in a subclass and observe how it differs from `override` when called through a base reference.

```csharp
sealed class TaxedInvoice : Invoice { /* ... */ }

// Hiding experiment:
class A { public virtual void Say() => Console.WriteLine("A"); }
class B : A { public new void Say() => Console.WriteLine("B"); }   // 'new', not 'override'

A obj = new B();
obj.Say();     // TODO predict the output BEFORE running. Is it A or B?
```
The difference between `override` and `new` here is one of the most common C# interview traps. Make sure you can explain the result.

---

## Stretch challenges (no skeleton — you're on your own)

1. Add an `IComparable<T>` implementation to `Invoice` so a `List<Invoice>` can be sorted by amount due with `Sort()`.
2. Build a `readonly struct` `Money` (currency + amount) with operator overloading for `+`. Why `readonly struct` here and not a class?
3. Give `Shape` a static factory method `Shape.Create(string kind, ...)` that returns the right subclass — an intro to the factory pattern.
4. Redo the payment system so invoices are `record` types instead of classes. What do you get for free, and what breaks?

---

### How to self-check
- Every field: can you justify `private` vs `protected` vs a property? If it's `public` and mutable, why?
- `abstract` vs `interface`: could you explain to someone when you'd reach for each?
- For each `override`: does removing `virtual` from the base break it? (It should.)
- Polymorphism exercises: the base-typed variable calls the derived behaviour — can you say *why* out loud, referencing the vtable / dynamic dispatch idea?
- Did anything only work because you made a field `public`? If so, that's a smell — can you tighten it?

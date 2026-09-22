# C# OOP Training — Minimal → Medium → Advanced

Same rules as the loops set: fill the `// TODO` gaps, no solutions to scroll to. Compile, run, check against the "Check" notes under each exercise.

OOP is less about output and more about **structure** — so for many of these the real check is "does it compile with the access rules I intended, and can I explain why a field is `private` vs `protected`?" Where output matters, it's noted.

---

## Setup (read this first — it prevents name clashes)

Several exercises reuse the same class names (`Book`, `Animal`, `Shape`, `TaxedInvoice`...). Two classes with the same name in the same namespace won't compile. So: **one file per exercise, each with its own namespace**, and a `Demo.Run()` method as the entry point.

```csharp
// File: Ex1_2.cs
namespace KataOop.Ex1_2;      // file-scoped namespace — everything in this file lives here

class Book
{
    // ...
}

static class Demo
{
    public static void Run()
    {
        // your "Main" code for this exercise goes here
    }
}
```

```csharp
// File: Program.cs — only calls the exercise you're working on
KataOop.Ex1_2.Demo.Run();
```

Whenever an exercise says "in Run()" — that's this method. Helper methods marked `static` (like `Total` in 3.6) also go inside `Demo`, because C# methods must live inside a type.

When an exercise says "same class as before", **copy** the class from the previous exercise into the new file and change it there. That way the old version still compiles and you can compare.

Two small C# gotchas you'll hit here:
- `decimal` literals need the `m` suffix: `100.5m`. Writing `100.5` is a `double` and won't convert implicitly.
- `Console.WriteLine(someObject)` prints the type name, not the fields — unless the class overrides `ToString()`. Print the fields/properties you want explicitly.

---

## TIER 1 — MINIMAL (a single class, fields, methods, encapsulation)

### 1.1 — Your first class
A `Book` with a title and page count. A method that prints a one-line summary.

```csharp
class Book
{
    // TODO: two fields — title (string), pages (int)
    //       think: what access modifier do they need so Run() can set them?

    // TODO: a method Describe() that prints "Title — N pages"
}

// in Run():
// TODO: create a Book, set its fields, call Describe()
```
Expected output (for a book "Dune" with 412 pages): `Dune — 412 pages`

Check: remove the access modifier from the fields. What's the default, and what compile error do you get in `Run()`? This is why 1.2+ move away from public fields.

### 1.2 — Constructor
Same `Book`, but force title and pages to be set at creation. No object should exist without them.

```csharp
class Book
{
    private string title;
    private int pages;

    // TODO: constructor taking title and pages, assigning the fields

    public void Describe() { /* TODO same output as 1.1 */ }
}
```
Check:
- Can you still write `new Book()` with no arguments? Try it. What does the error say, and why did adding *your* constructor remove the default one?
- Try `book.title = "X";` from `Run()`. Why does that fail now when it worked in 1.1?

### 1.3 — Properties (get/set)
Replace the private fields from 1.2 with **properties**. `Title` is read/write from anywhere. `Pages` can be read from anywhere but only changed inside the class. Add a method `AddChapter(int extraPages)` — that's the only legal way to change the page count from outside.

```csharp
class Book
{
    public string Title { get; set; }
    public int Pages { get; /* TODO: add a setter, but make it private */ }

    public Book(string title, int pages)
    {
        // TODO assign via the properties
    }

    public void AddChapter(int extraPages)
    {
        // TODO reject extraPages <= 0 (print a message, change nothing)
        // TODO otherwise increase Pages
    }

    public void Describe() { /* TODO */ }
}
```
Check:
- `book.Title = "New title";` from `Run()` → compiles.
- `book.Pages = 999;` from `Run()` → must NOT compile. Read the error message.
- Why is `AddChapter` better than a public setter? (Hint: what can a public setter not stop?)

### 1.4 — Encapsulation with validation
A `BankAccount`. Balance must never go negative. `Deposit` and `Withdraw` are the only ways to change it; the balance field itself is private and has no public setter.

```csharp
class BankAccount
{
    private decimal balance;

    public decimal Balance => balance;   // read-only property (shorthand for get { return balance; })

    public void Deposit(decimal amount)
    {
        // TODO reject non-positive amounts (print a message), otherwise add
    }

    public bool Withdraw(decimal amount)
    {
        // TODO reject if amount <= 0 or amount > balance; return false
        // TODO otherwise subtract and return true
    }
}
```
Test sequence in `Run()` — predict each line before running:
1. Deposit 100m → Balance?
2. Deposit -20m → Balance? (rejected)
3. Withdraw 30m → returns? Balance?
4. Withdraw 500m → returns? Balance?

Expected final balance: `70`

Check:
- `account.balance = -500;` → must not compile (private field).
- `account.Balance = -500;` → must not compile either, but for a *different* reason. What's the difference between the two errors?
- `Deposit` returns `void`, `Withdraw` returns `bool`. Which caller would care about the result, and is this inconsistency a problem?

### 1.5 — `this` and independent objects
A `Counter` with `Increment()`, `Reset()`, a `Value` property, and a `SetTo(int count)` method. The parameter of `SetTo` is deliberately named the same as the field.

```csharp
class Counter
{
    private int count;
    public int Value => count;

    // TODO Increment() — adds 1
    // TODO Reset() — back to 0

    public void SetTo(int count)
    {
        // TODO assign the parameter to the field
        //      the parameter 'count' hides the field 'count' — how do you reach the field?
    }
}
```
In `Run()`: create three counters `a`, `b`, `c`. Increment `a` once, `b` three times, leave `c` alone. Then `SetTo(10)` on `c` and `Reset()` on `a`. Print all three.

Expected output: `a=0 b=3 c=10`

Check:
- In `SetTo`, write `count = count;` without `this`. It compiles (maybe with a warning) — what does it actually do, and why does `c` stay at 0?
- Why don't the three counters affect each other?

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

// Experiment in Run():
Point a = new Point(1, 1);
Point b = a;          // copy or reference?
b.Move(5, 5);
// TODO print a.X, a.Y and b.X, b.Y. Are they the same? WHY?
// Now change 'struct' to 'class' and re-run. What changes?
```
Part 2 — same idea with a method call:

```csharp
static void Shift(Point p)
{
    p.Move(100, 100);
}

// in Run():
// TODO create a Point, call Shift on it, print it.
// Did the original move? Try again with 'class'.
```
This is the whole point of the exercise — write down the difference in one sentence before moving on.

### 2.2 — `static` members
A `MathUtils` class with no instances. A static method `Square(int)` and a static `CallCount` that counts every call to `Square`.

```csharp
static class MathUtils
{
    public static int CallCount { get; /* TODO: who should be allowed to change this? */ }

    public static int Square(int n)
    {
        // TODO bump CallCount, return n*n
    }
}
```
In `Run()`: call `Square` with 3, 4 and 5, print each result, then print `MathUtils.CallCount`.

Expected: `9`, `16`, `25`, then `CallCount = 3`

Check:
- `new MathUtils()` must not compile. Why does `static class` forbid it?
- Try `MathUtils.CallCount = 0;` from `Run()`. If it compiles, your setter is too open — fix it.
- Why is a counter a good fit for `static`, but a `Book`'s title isn't?

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
    // TODO Fetch() method — prints "<Name> fetches the ball."
}
```
Check:
- A `Dog` can call `Speak()` even though `Dog` didn't define it. Why?
- `Animal x = new Dog("Rex");` — can `x` call `Fetch()`? Why not, if the object *is* a dog?
- Remove the `: base(name)` part. What's the error, and why does the compiler care?

### 2.4 — `protected`
Copy `Animal` and `Dog` from 2.3. Add a `protected` field `energy` to `Animal`. `Dog.Fetch()` costs 30 energy. When energy would drop below 0, the dog refuses instead.

```csharp
class Animal
{
    protected int energy = 100;
    // ... rest from 2.3
}

class Dog : Animal
{
    // ... constructor from 2.3

    public void Fetch()
    {
        // TODO if energy < 30: print "<Name> is too tired." and stop
        // TODO otherwise reduce energy by 30 and print "<Name> fetches! Energy: <energy>"
    }
}

// in Run():
// TODO call Fetch() four times on the same dog.
// TODO try to read dog.energy directly — confirm it won't compile.
```
Expected: energy goes 70, 40, 10, then "too tired".

Check:
- Change `protected` to `private`. What breaks, and where?
- Write down the difference between `private` and `protected` in your own words.
- `Run()` can't *read* the energy either. If you wanted it readable but not writable from outside — what would you add? (Tier 1 has the answer.)

### 2.5 — `base` constructor chaining
A `Vehicle(string make)` base and a `Car(string make, int doors)` subclass. `Car`'s constructor must call the base constructor and then set its own field. Add a `Describe()` on `Car` that prints both.

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
    // TODO Describe() — prints e.g. "VW with 5 doors"
}
```
Check:
- Remove the base call. Why does the error mention a parameterless constructor?
- Add a `Console.WriteLine` inside both constructors. In which order do they run when you create a `Car`? Why that order?

### 2.6 — Extending a method across a hierarchy
`Employee` with `GrossPay()`. `Manager : Employee` adds a bonus. `Manager.GrossPay()` should reuse the base calculation via `base.GrossPay()` and add to it — not duplicate the formula.

(This previews `virtual`/`override` — Tier 3 goes deeper. Here, just focus on *reusing* the base version.)

```csharp
class Employee
{
    protected decimal baseSalary;
    public Employee(decimal s) { baseSalary = s; }

    public virtual decimal GrossPay() => baseSalary;   // virtual = subclasses MAY replace this
}

class Manager : Employee
{
    private decimal bonus;
    public Manager(decimal s, decimal b) : base(s) { bonus = b; }

    public override decimal GrossPay()
    {
        // TODO return the base calculation + bonus — don't touch baseSalary directly
    }
}
```
In `Run()`:
```csharp
Employee e = new Employee(3000m);
Employee m = new Manager(4000m, 500m);   // note: typed as Employee
// TODO print e.GrossPay() and m.GrossPay()
```
Expected: `3000` and `4500`

Check:
- Remove `virtual` from the base. What error do you get on `override`?
- `m` is typed as `Employee`, yet you got the manager's pay. Hold that thought — it's 3.3.
- Why is `base.GrossPay() + bonus` better than `baseSalary + bonus`, even though both give 4500? (Imagine `Employee.GrossPay()` later adds a holiday allowance.)

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
    // TODO override Area()  (Math.PI exists)
}

class Rectangle : Shape
{
    private double w, h;
    public Rectangle(double w, double h) { this.w = w; this.h = h; }
    // TODO override Area()
}
```
Expected: `new Circle(2).Print()` → `Area = 12.57`, `new Rectangle(3, 4).Print()` → `Area = 12.00`

Check:
- `new Shape()` must not compile.
- Delete `Rectangle`'s `Area()`. What does the compiler say? That error *is* the "contract" of `abstract`.
- `Print()` isn't abstract, but it calls `Area()`. How does it know which `Area()` to call?

### 3.2 — `virtual` / `override` / `base`
Copy `Shape`, `Circle` and `Rectangle` from 3.1. Add a `virtual` `Describe()` to `Shape` that prints the area. `Circle` overrides it to *also* print the radius, but still calls `base.Describe()` for the shared part. `Rectangle` does **not** override it.

```csharp
abstract class Shape
{
    public abstract double Area();

    public virtual void Describe()
    {
        // TODO print the area (reuse the format from Print)
    }
}

class Circle : Shape
{
    // ... from 3.1
    public override void Describe()
    {
        base.Describe();           // reuse
        // TODO also print radius
    }
}
```
Expected for `Circle(2)`: area line, then `Radius = 2`. For `Rectangle(3, 4)`: only the area line.

Check:
- `Area()` is `abstract`, `Describe()` is `virtual`. What's the practical difference for a subclass?
- Remove `base.Describe();` from `Circle`. What's lost?

### 3.3 — Polymorphism through a base reference
Put mixed shapes in a `List<Shape>` and loop once. The **same call site** produces different behaviour per object — that's polymorphism.

Add a third shape `Square : Rectangle` (a square *is* a rectangle with equal sides — one constructor parameter, passed on to the base twice).

```csharp
// in Demo:
public static void Run()
{
    var shapes = new List<Shape>
    {
        new Circle(2),
        new Rectangle(3, 4),
        // TODO add a Square and one more of your choice
    };

    foreach (Shape s in shapes)
    {
        // TODO call s.Describe()
        // Note: the variable is 'Shape', but the RIGHT override runs. Why?
    }

    // TODO afterwards: compute and print the total area of all shapes in one loop
}
```
Check:
- `Square` needs zero `Area()` code. Why does it still work?
- Add a new shape class *without* touching the loop. Does the loop need changes?

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
    // TODO implement ToText → "Robot at (x, y)"
}
```
In `Run()`: create a robot, move it `(2, 3)` then `(-1, 4)`, print `ToText()`.

Expected: `Robot at (1, 7)`

Check:
- Implement `Move` without the `public` keyword. Read the error — why must interface members be public in the class?
- `IMovable r = new Robot();` — `r` can call `Move` but not `ToText`. Why is that useful? (Think: handing the robot to code that should only be allowed to move it.)

### 3.5 — Interface polymorphism
A method that accepts **any** `IDescribable` and prints its text. Pass it a `Robot`, and a second unrelated class `Report` that also implements `IDescribable`. One method, unrelated types — that's the power of coding to an interface.

```csharp
// inside Demo:
static void PrintDescription(IDescribable item)
{
    // TODO print item.ToText()
}

// TODO: a Report class with a title and a page count, implementing IDescribable
//       ToText → e.g. "Report 'Q3 Sales' (12 pages)"
// TODO: call PrintDescription with a Robot AND a Report
```
Check:
- `Robot` and `Report` share no base class (apart from `object`). What *do* they share?
- Could you have solved this with an abstract base class instead? Why would that be a bad fit here?

### 3.6 — Abstract + interface + polymorphism together (the "all that jazz")
Model a tiny payment system.

- `interface IPayable { decimal AmountDue(); }`
- `abstract class Invoice : IPayable` with a `protected decimal amount` and an abstract `AmountDue()`.
- `TaxedInvoice : Invoice` — adds tax in `AmountDue()`.
- `DiscountedInvoice : Invoice` — subtracts a fixed discount in `AmountDue()`, never below 0.
- A `static decimal Total(IEnumerable<IPayable> items)` that sums `AmountDue()` across a mixed collection.

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
    private decimal taxRate;   // 0.19m = 19 %
    public TaxedInvoice(decimal amount, decimal taxRate) : base(amount) { this.taxRate = taxRate; }

    // TODO AmountDue() = amount * (1 + taxRate)
}

class DiscountedInvoice : Invoice
{
    private decimal discount;
    public DiscountedInvoice(decimal amount, decimal discount) : base(amount) { this.discount = discount; }

    // TODO AmountDue() = amount - discount, but never below 0
}

// inside Demo:
static decimal Total(IEnumerable<IPayable> items)
{
    decimal sum = 0;
    // TODO loop, accumulate AmountDue()
    return sum;
}
```
Test data for `Run()`:

| Invoice | Expected `AmountDue()` |
|---|---|
| `TaxedInvoice(100m, 0.19m)` | 119 |
| `DiscountedInvoice(50m, 10m)` | 40 |
| `DiscountedInvoice(5m, 10m)` | 0 |

Expected `Total` = `159`

Check:
- `Total` never mentions `TaxedInvoice` or `DiscountedInvoice` by name — it only knows `IPayable`. You can add a third invoice type later and `Total` needs zero changes. Sit with why that matters.
- Change the parameter to `List<IPayable>` and pass it a `List<Invoice>`. It won't compile, even though every `Invoice` is an `IPayable`. Read the error. Why does `IEnumerable<IPayable>` accept it? (Search term: *covariance*.)
- Why is `Invoice`'s constructor `protected` instead of `public`?

### 3.7 — `sealed` and hiding
**Part A:** Copy the 3.6 classes. Make `TaxedInvoice` `sealed`.

```csharp
sealed class TaxedInvoice : Invoice { /* ... from 3.6 */ }

// TODO try: class SpecialTaxedInvoice : TaxedInvoice { }
//      confirm it won't compile. When would you WANT to forbid subclassing?
```

**Part B:** Separately, explore method **hiding**: define a `new` method in a subclass and compare it with `override` when called through a base reference.

```csharp
class A { public virtual void Say() => Console.WriteLine("A"); }
class B : A { public new void Say() => Console.WriteLine("B"); }        // hides
class C : A { public override void Say() => Console.WriteLine("C"); }   // overrides

// in Run():
A ab = new B();
A ac = new C();
B bb = new B();

ab.Say();   // TODO predict BEFORE running: A or B?
ac.Say();   // TODO predict: A or C?
bb.Say();   // TODO predict: A or B?
```
Check:
- Fill in this sentence: with `override`, the method is chosen by the type of the ______; with `new`, by the type of the ______.
- Remove the word `new` from `B`. It still compiles — what warning do you get, and what is the compiler trying to tell you?
- Don't confuse this `new` (hiding) with `new` in `new B()` (creating an object). Same keyword, unrelated meaning.

The difference between `override` and `new` here is one of the most common C# interview traps. Make sure you can explain the result.

---

## Stretch challenges (no skeleton — you're on your own)

1. Implement `IComparable<Invoice>` on `Invoice` so a `List<Invoice>` can be sorted by `AmountDue()` with `.Sort()`. Print the list before and after.
2. Build a `readonly struct Money` (currency + amount) with an overloaded `+` operator. Decide: what should happen when you add EUR to USD? Why `readonly struct` here and not a class?
3. Give `Shape` a static factory method `Shape.Create(string kind, params double[] values)` that returns the right subclass (`"circle"`, `"rectangle"`, ...), and handles an unknown kind sensibly — an intro to the factory pattern.
4. Redo the payment system with `record` types instead of classes. Print an invoice with `Console.WriteLine` and compare two invoices with `==`. What do you get for free, and what breaks or feels odd (hint: `protected` fields, mutability)?

---

### How to self-check
- Every field: can you justify `private` vs `protected` vs a property? If it's `public` and mutable, why?
- `abstract` vs `interface`: could you explain to someone when you'd reach for each?
- For each `override`: does removing `virtual` from the base break it? (It should.)
- Polymorphism exercises: the base-typed variable calls the derived behaviour — can you say *why* out loud, referencing the vtable / dynamic dispatch idea?
- Did anything only work because you made a field `public`? If so, that's a smell — can you tighten it?
- Did every "Expected" output match? If not, find out *why* before moving on — a wrong number is usually a wrong assumption, not a typo.

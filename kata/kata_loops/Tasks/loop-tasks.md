# C# Loop Training — Minimal → Medium → Advanced

Fill in the gaps marked `// TODO`. Don't scroll to a solution — there isn't one. Google syntax freely.
Each exercise says **what** to produce, not **how**. Compile, run, check output against the expected result.

---

## Setup

Simplest option: put everything in `Program.cs`. Modern .NET templates use **top-level statements** (no `Main` method), so the exercise methods become local functions:

```csharp
// Program.cs
Ex1_1();          // call the one you're working on, comment out the rest
// Ex1_2();

static void Ex1_1()
{
    // ...
}

static void Ex1_2()
{
    // ...
}
```

Calls go at the **top**, methods below. If you split tiers into separate files, the methods need to live inside a class (e.g. `static class Tier1 { public static void Ex1_1() { ... } }`) and you call `Tier1.Ex1_1();`.

One warning you'll meet: `Console.ReadLine()` returns `string?` (it can be `null`). `int.TryParse` accepts that without complaint; `int.Parse` gives a nullable warning. The self-check at the end asks for zero warnings — so prefer `TryParse` for user input.

---

## TIER 1 — MINIMAL (mechanics of a single loop)

### 1.1 — `for` basics

Print numbers 1 through 10, one per line.

```csharp
static void Ex1_1()
{
    for (int i = /* TODO start */; i /* TODO condition */; i /* TODO step */)
    {
        // TODO print i
    }
}
```

Expected: `1 2 3 ... 10` (each on its own line).

Check: change `<=` to `<` (or the other way round). Which number disappears? Off-by-one errors look exactly like this.

### 1.2 — `while` basics

Same output as 1.1 but with a `while` loop. You manage the counter yourself.

```csharp
static void Ex1_2()
{
    int i = 1;
    while (/* TODO condition */)
    {
        // TODO print
        // TODO increment
    }
}
```

Check: put the increment *before* the print. What's the output now, and how do you fix the condition to get 1..10 again?

### 1.3 — `do-while`

Ask the user for a number. Keep asking until they type a positive number. `do-while` runs the body at least once — that's the point here.

```csharp
static void Ex1_3()
{
    int n;
    do
    {
        Console.Write("Enter a positive number: ");
        // TODO read + parse input into n with int.TryParse
        //      (if parsing fails, TryParse sets n to 0 — which the condition already rejects)
    }
    while (/* TODO repeat while n is not positive */);

    Console.WriteLine($"Thanks: {n}");
}
```

Test inputs, in this order: `-5`, `0`, `abc`, `7` → should only accept `7`.

Check: try `int.Parse` instead and type `abc`. What happens? (B.2 comes back to this.)

### 1.4 — Countdown + accumulation

Print 10 down to 1, then print the **sum** of 1..10 on the last line.

```csharp
static void Ex1_4()
{
    int sum = 0;
    for (/* TODO count down from 10 to 1 */)
    {
        // TODO print current number
        // TODO add current number to sum
    }
    // TODO print sum   (expected: 55)
}
```

### 1.5 — `foreach`

Given an array, print each fruit prefixed with its 1-based position (`1. apple`).

```csharp
static void Ex1_5()
{
    string[] fruits = { "apple", "banana", "cherry", "date" };
    int pos = 1;
    foreach (/* TODO element declaration */ in fruits)
    {
        // TODO print "pos. fruit"
        // TODO bump pos
    }
}
```

Expected: `1. apple` … `4. date`

Check: inside the `foreach`, try assigning a new value to the loop variable (e.g. `fruit = "kiwi";`). What does the compiler say? When would you need a `for` loop instead?

---

## TIER 2 — MEDIUM (control flow, nesting, chained logic)

### 2.1 — `break` and `continue`

Loop 1..50. Skip multiples of 3 (`continue`). Stop entirely the first time you pass 40 (`break`). Print the rest.

```csharp
static void Ex2_1()
{
    for (int i = 1; i <= 50; i++)
    {
        // TODO if i > 40 -> stop the loop
        // TODO if i is a multiple of 3 -> skip to next iteration
        // TODO print i
    }
}
```

Expected: starts `1 2 4 5 7 8 …`, last number printed is `40`, **27 numbers** in total.

Check: could you get the same result without `break`, just by changing the loop header? Which version is clearer?

### 2.2 — FizzBuzz

1..30. Multiples of 3 → `Fizz`, of 5 → `Buzz`, of both → `FizzBuzz`, otherwise the number.

```csharp
static void Ex2_2()
{
    for (int i = 1; i <= 30; i++)
    {
        // TODO build the fizz/buzz logic. Watch the order of your checks.
    }
}
```

Expected: `15` and `30` print `FizzBuzz`. If they print `Fizz`, your check order is wrong — figure out why.

### 2.3 — Nested loop: multiplication table

Print a 5×5 multiplication grid. Rows and columns 1..5. Align it however you like (`\t` is fine).

```csharp
static void Ex2_3()
{
    for (int row = 1; row <= 5; row++)
    {
        for (int col = 1; col <= 5; col++)
        {
            // TODO print row*col, no newline, with a separator
        }
        // TODO newline after each row
    }
}
```

Expected last row: `5  10  15  20  25`

Check: how many times does the inner loop body run in total? What would it be for a 10×10 grid?

### 2.4 — Nested loop: triangle

Print a left-aligned triangle of `*` with 6 rows (row 1 has 1 star, row 6 has 6).

```
*
**
***
...
```

```csharp
static void Ex2_4()
{
    for (int row = 1; row <= 6; row++)
    {
        // TODO inner loop that prints 'row' stars
        // TODO newline
    }
}
```

Variant (after it works): flip it upside down (6 stars first). What's the *only* thing you need to change?

### 2.5 — Search with a sentinel value

Given an array, find whether `target` exists. Print its index or "not found". Break as soon as you find it. `foundAt = -1` acts as the flag: `-1` can never be a real index.

```csharp
static void Ex2_5()
{
    int[] data = { 4, 8, 15, 16, 23, 42 };
    int target = 16;
    int foundAt = -1;

    for (int i = 0; i < data.Length; i++)
    {
        // TODO if match: record index, break
    }

    // TODO print result based on foundAt
}
```

Expected: `target = 16` → `Found at index 3`. Then test `target = 99` → `not found`, and `target = 4` (first element) and `42` (last) — the edges are where bugs hide.

### 2.6 — Loop chain (sequential pipeline)

Three loops in a row, each feeding the next. This is the "loop chain" idea: transform data in stages.

Stage A: fill an `int[10]` with squares (1, 4, 9, ...).
Stage B: loop that array, keep only the even values into a `List<int>`.
Stage C: loop the list and print the running total.

```csharp
static void Ex2_6()
{
    int[] squares = new int[10];
    // Stage A
    for (int i = 0; i < squares.Length; i++)
    {
        // TODO squares[i] = (i+1) squared
    }

    var evens = new List<int>();
    // Stage B
    foreach (var s in squares)
    {
        // TODO if s is even, add to evens
    }

    // Stage C
    int running = 0;
    foreach (var e in evens)
    {
        // TODO running += e; print e and running
    }
}
```

Expected Stage C output:

| e | running |
|---|---|
| 4 | 4 |
| 16 | 20 |
| 36 | 56 |
| 64 | 120 |
| 100 | 220 |

Check: why is Stage B's result a `List<int>` and not an `int[]`? (What don't you know in advance?)

---

## TIER 3 — ADVANCED (nested chains, 2D data, algorithmic loops)

### 3.1 — 2D grid processing

Given a `int[3,4]` matrix, compute the sum of each row and the grand total. Use nested loops with `GetLength(0)` / `GetLength(1)` — don't hardcode dimensions.

```csharp
static void Ex3_1()
{
    int[,] grid =
    {
        { 1, 2, 3, 4 },
        { 5, 6, 7, 8 },
        { 9, 10, 11, 12 }
    };

    int grand = 0;
    for (int r = 0; r < /* TODO row count */; r++)
    {
        int rowSum = 0;
        for (int c = 0; c < /* TODO col count */; c++)
        {
            // TODO add to rowSum
        }
        // TODO print rowSum, add to grand
    }
    // TODO print grand
}
```

Expected: row sums `10`, `26`, `42`, grand total `78`.

Extension: also print the sum of each **column** (`15 18 21 24`). Which loop has to be on the outside now?

Check: what does `grid.Length` return here, and why is it not what you want for the loop bounds?

### 3.2 — Bubble sort (nested loop algorithm)

Sort an array ascending, by hand, no `Array.Sort`. Outer pass loop + inner compare-and-swap loop.

```csharp
static void Ex3_2()
{
    int[] a = { 5, 2, 9, 1, 7, 3 };

    for (int pass = 0; pass < a.Length - 1; pass++)
    {
        for (int i = 0; i < a.Length - 1 - pass; i++)
        {
            // TODO if a[i] > a[i+1], swap them (you'll need a temp variable)
        }
    }

    // TODO print sorted array
}
```

Expected: `1 2 3 5 7 9`

Check:
- Why does the inner bound shrink by `pass` each time? (Print the array after every pass and watch the right end.)
- Remove the `- 1` from the inner condition. What exception do you get, and why?
- Improvement: add a `bool swapped` flag and stop early if a whole pass made no swaps. Test it on an already sorted array — how many passes now?

### 3.3 — Primes by trial division (loop + inner divisor test)

Print all primes from 2 to 50. Outer loop over candidates, inner loop tests divisibility. Use a flag and `break` early.

```csharp
static void Ex3_3()
{
    for (int n = 2; n <= 50; n++)
    {
        bool isPrime = true;
        for (int d = 2; d /* TODO sensible bound, e.g. d*d <= n */; d++)
        {
            // TODO if n % d == 0 -> not prime, break
        }
        // TODO if still prime, print n
    }
}
```

Expected: `2 3 5 7 11 13 17 19 23 29 31 37 41 43 47` (15 primes).

Check: why is `d * d <= n` enough — why don't you need to test divisors up to `n - 1`? (Hint: if `36 = a * b`, can both `a` and `b` be bigger than 6?)

(This is *not* a sieve — the real Sieve of Eratosthenes is in the stretch challenges.)

### 3.4 — Chained transform pipeline (the real "all that jazz")

Four stages, each a loop, output of one is input to the next. Produce a frequency report.

Input: a sentence string.
Stage A: split into words (given), loop to normalise each to lowercase into a `List<string>`.
Stage B: loop that list, build a `Dictionary<string,int>` word → count.
Stage C: loop the dictionary, find the max count.
Stage D: loop again, print only words whose count equals the max (the mode words — there can be more than one).

```csharp
static void Ex3_4()
{
    string sentence = "The cat sat on the mat the Cat ran cat";
    string[] raw = sentence.Split(' ');

    var words = new List<string>();
    // Stage A
    foreach (var w in raw)
    {
        // TODO add w.ToLower() to words
    }

    var counts = new Dictionary<string, int>();
    // Stage B
    foreach (var w in words)
    {
        // TODO if key exists increment, else add with 1
        //      (look up ContainsKey — and find out what counts[w]++ does on a missing key)
    }

    int max = 0;
    // Stage C
    foreach (var kvp in counts)
    {
        // TODO track the largest kvp.Value
    }

    // Stage D
    foreach (var kvp in counts)
    {
        // TODO if kvp.Value == max, print "word: count"
    }
}
```

Expected: `the: 3` and `cat: 3` (a tie — both must print).

Check:
- Skip Stage A (use `raw` directly in Stage B). What changes in the output, and why?
- Could Stages C and D be merged into one loop? What would go wrong?

### 3.5 — Breaking out of nested loops

C# has no labelled `break` (unlike Java) — `break` only leaves the innermost loop. Search a 2D grid for a target; when found, you must exit BOTH loops. Solve it three ways:

1. With a `bool found` flag (skeleton below).
2. By moving the search into its own method and using `return`.
3. (Optional, for understanding only) with `goto`.

```csharp
static void Ex3_5()
{
    int[,] grid =
    {
        { 3, 7, 1 },
        { 9, 4, 6 },
        { 2, 8, 5 }
    };
    int target = 4;

    bool found = false;
    for (int r = 0; r < grid.GetLength(0) && !found; r++)
    {
        for (int c = 0; c < grid.GetLength(1); c++)
        {
            // TODO if grid[r,c] == target: print (r,c), set found, break inner
        }
    }
    // TODO if !found print "not found"
}
```

For version 2, a starting point:

```csharp
static (int row, int col) FindInGrid(int[,] grid, int target)
{
    // TODO nested loops; return (r, c) the moment you find it
    // TODO after the loops: return something that means "not found"
}
```

Expected: `4` → `(1, 1)`. Also test `99` → `not found`.

Check: in version 1, remove `&& !found` from the outer loop. What happens after the inner `break`? Which version reads cleanest to you?

### 3.6 — Collatz (unbounded while, real termination logic)

For a starting `n`, repeatedly: if even → `n/2`, if odd → `3n+1`, until `n == 1`. Count and print the steps. Try it for n = 27 (it's a long one — good stress test).

```csharp
static void Ex3_6()
{
    long n = 27;
    int steps = 0;
    while (/* TODO until n reaches 1 */)
    {
        // TODO even/odd branch, update n
        // TODO steps++
    }
    // TODO print total steps  (for 27, expect 111)
}
```

Extension: also track the **highest value** `n` reaches on the way (for 27: `9232`).

Check: why is `n` a `long` and not an `int`? (Not needed for 27 — but some starting values climb very high.)

---

## BONUS TIER — `while` / `do-while` deep dive

`while` earns its keep when you **don't know the iteration count up front**. Every exercise here is one where a `for` loop would be the wrong tool. The recurring hazard: you own the termination condition, so you own the infinite loop.

### B.1 — Digit stripping

Given `int n = 9384`, print each digit **in reverse order** (4, 8, 3, 9) and the digit sum. No strings, no `ToString()` — use `% 10` and `/ 10`.

```csharp
static void ExB_1()
{
    int n = 9384;
    int sum = 0;
    while (/* TODO what makes this stop? */)
    {
        // TODO extract last digit with % 10, print it
        // TODO add to sum
        // TODO chop the last digit off n with / 10
    }
    // TODO print sum   (expected: 24)
}
```

Traps to test:
- `n != 0` vs `n > 0` — what happens with `n = -9384` in each case?
- `n = 0` — how many digits does it have, and how many does your loop print? Would `do-while` fix it?

### B.2 — Input validation loop

Keep prompting until the user enters a valid integer between 1 and 100. Reject non-numeric input **without crashing** (`int.TryParse`, not `int.Parse`). Use different messages for "not a number" and "out of range".

```csharp
static void ExB_2()
{
    int value = 0;
    bool valid = false;

    while (!valid)
    {
        Console.Write("Enter 1-100: ");
        string? input = Console.ReadLine();
        // TODO TryParse into value
        // TODO if parse failed -> message, continue
        // TODO if out of range -> message, continue
        // TODO otherwise valid = true
    }

    Console.WriteLine($"Accepted: {value}");
}
```

Test inputs: `abc`, (empty Enter), `0`, `101`, `-5`, `1`. Only `1` is accepted. Also try `1` and `100` separately — are the boundaries included?

### B.3 — Sentinel-controlled loop

Read numbers from the user until they type `-1` (the sentinel). Then print the count, sum, and average of everything entered *before* the sentinel. The sentinel must not be counted. Non-numeric input: print a message and ask again (don't count it, don't crash).

```csharp
static void ExB_3()
{
    int count = 0;
    int sum = 0;
    int input;

    while (true)
    {
        Console.Write("Number (-1 to finish): ");
        // TODO read + TryParse into input; on failure -> message, continue
        // TODO if input is the sentinel -> break BEFORE counting it
        // TODO otherwise accumulate
    }

    // TODO print count, sum, average — guard against divide-by-zero
}
```

Test: enter `3`, `4`, `x`, `-1` → count `2`, sum `7`, average `3.5`.

Trap: if your average prints `3`, you did integer division. `sum / count` with two `int`s throws away the decimals — how do you get `3.5`?

Also test: type `-1` immediately. Nothing should crash.

### B.4 — Menu loop (`do-while`)

Classic console menu. Show options, act on the choice, repeat until they pick Quit. `do-while` because the menu must display at least once.

```csharp
static void ExB_4()
{
    string? choice;
    do
    {
        Console.WriteLine("\n1) Greet  2) Current time  3) Quit");
        Console.Write("Choice: ");
        choice = Console.ReadLine();

        // TODO switch or if-chain on choice
        //      1 -> ask for a name, print "Hello, <name>!"
        //      2 -> print the current time (look up DateTime.Now)
        //      3 -> do nothing here, the loop condition handles it
        //      anything else -> "Invalid choice"
    }
    while (/* TODO loop while choice is not the quit option */);

    Console.WriteLine("Bye.");
}
```

Check: why does this need `do-while`, while B.2 worked fine with `while`?

### B.5 — Convergence loop (unknown iteration count)

Compute the square root of 2 using Newton's method. Start with `guess = 1.0`. Each step: `guess = (guess + 2 / guess) / 2`. Stop when the change between iterations is smaller than `0.0000001`. Print the guess and iteration count each step.

```csharp
static void ExB_5()
{
    double guess = 1.0;
    double previous;
    int iterations = 0;

    do
    {
        previous = guess;
        // TODO apply the Newton step
        // TODO iterations++
        // TODO print iteration and guess
    }
    while (/* TODO while Math.Abs(guess - previous) is still too big */);

    // TODO print final result and compare to Math.Sqrt(2)
}
```

Expected: done after **5** iterations, first step gives `1.5`.

Extension: replace the `2` with a variable `x` so it works for any number. Try `x = 1000000`. More or fewer iterations?

This is the exercise that proves the point: you cannot write this as a `for` loop, because nothing knows in advance how many steps it takes.

### B.6 — GCD by subtraction

Euclid's algorithm, subtraction variant. While `a != b`, subtract the smaller from the larger. When they're equal, that value is the GCD.

```csharp
static void ExB_6()
{
    int a = 48, b = 18;

    while (/* TODO */)
    {
        // TODO subtract smaller from larger
    }

    // TODO print GCD (expected: 6)
}
```

Trap: what happens with `a = 48, b = 0`? Predict it before you run it (be ready to stop the program).

Part 2 — the modulo variant. Idea: instead of subtracting `b` from `a` again and again, jump straight to the remainder.

```csharp
static void ExB_6b()
{
    int a = 48, b = 18;
    int iterations = 0;

    while (/* TODO loop until b becomes 0 */)
    {
        // TODO remember b in a temp variable
        // TODO b becomes a % b
        // TODO a becomes the old b
        // TODO iterations++
    }

    // TODO print a (the GCD) and iterations
}
```

Add an iteration counter to Part 1 too, then compare both for `a = 1000000, b = 3`. Does the modulo version survive the `b = 0` trap?

### B.7 — Nested `while` with a chain

Two nested `while` loops. The outer walks a queue of tasks; the inner retries each task until it "succeeds" or runs out of attempts. The random generator is seeded, so the output is the same every run.

```csharp
static void ExB_7()
{
    var queue = new Queue<string>(new[] { "alpha", "beta", "gamma" });
    var rng = new Random(42);

    while (/* TODO while queue has items */)
    {
        string task = queue.Dequeue();
        int attempt = 0;
        bool success = false;

        while (!success && attempt < 5)
        {
            attempt++;
            // TODO succeed when rng.Next(0, 3) == 0
            // TODO print "task: attempt N -> ok/failed"
        }

        // TODO print whether the task ultimately succeeded or exhausted retries
    }

    // TODO after the outer loop: print how many tasks succeeded and how many failed
}
```

Extension: when a task exhausts its retries, put it **back** at the end of the queue — but only once (it gets one second chance). How do you stop a task from being re-queued forever? (Hint: the queue could hold more than just the name.)

Check: remove the seed (`new Random()`). Why do the results change every run now, and why is a seed useful when testing?

### B.8 — Infinite loop autopsy

Each of these is broken. **Don't run them yet** — first write down *why* each never terminates (or terminates in a surprising way). Then fix A, B and C with a one-line change.

```csharp
// A
int i = 0;
while (i < 10)
{
    Console.WriteLine(i);
}

// B
int n = 10;
while (n != 0)
{
    Console.WriteLine(n);
    n -= 3;
}

// C
double d = 0.0;
while (d != 1.0)
{
    d += 0.1;
}

// D
int x = 1;
while (x > 0)
{
    x = x * 2;
}
```

C and D are the interesting ones. C is about floating-point equality — print `d` each step with `d.ToString("R")` to see what's really stored. D terminates eventually — but not the way you'd expect. Work out what actually happens: print `x` inside the loop, and count the iterations.

Then for D: wrap the loop body in `checked { ... }` and run it again. What changes, and what does that tell you about C#'s default behaviour?

(Bonus riddle for B: it *also* ends eventually, for the same underlying reason as D — just after billions of iterations. Why?)

---

## Stretch challenges (no skeleton — you're on your own)

1. Print a **hollow** square of `*` (border only) of size N. Test N = 1 and N = 2 — do they still look right?
2. Pascal's triangle, 8 rows, using only loops and a jagged array (`int[][]`).
3. Given two sorted arrays, merge them into one sorted array using a single `while` loop with two index pointers (the merge step of merge sort). Don't forget the leftovers when one array runs out first.
4. The real **Sieve of Eratosthenes**: a `bool[51]` array, cross out multiples instead of testing divisors. Compare the output with 3.3.
5. Rewrite Ex3_4's whole pipeline using LINQ — then decide for yourself whether the explicit loops were clearer.

---

### How to self-check

- Does it compile with zero warnings?
- Does the output match the "Expected" notes where given?
- Did you test the edges — empty input, first/last element, 0, negatives?
- For the pipelines: can you explain out loud what each stage's loop hands to the next?
- Where you used `break`/`continue`, could a cleaner condition have avoided it?
- For every `while`: can you point at the line that makes the condition eventually false?

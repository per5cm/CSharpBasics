# C# Loop Training — Minimal → Medium → Advanced

Fill in the gaps marked `// TODO`. Don't scroll to a solution — there isn't one. Google syntax freely.
Each exercise says **what** to produce, not **how**. Compile, run, check output against the expected result.

Suggested setup: one `.cs` file per tier, or throw them all into `Program.cs` and comment-toggle the `Main` calls.

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

### 1.3 — `do-while`
Ask the user for a number. Keep asking until they type a positive number. `do-while` runs the body at least once — that's the point here.

```csharp
static void Ex1_3()
{
    int n;
    do
    {
        Console.Write("Enter a positive number: ");
        // TODO read + parse input into n  (int.TryParse or int.Parse)
    }
    while (/* TODO repeat while n is not positive */);

    Console.WriteLine($"Thanks: {n}");
}
```

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

### 2.5 — Search with a flag
Given an array, find whether `target` exists. Print its index or "not found". Break as soon as you find it.

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
            // TODO if a[i] > a[i+1], swap them
        }
    }

    // TODO print sorted array
}
```

### 3.3 — Prime sieve (loop + inner divisor test)
Print all primes from 2 to 50. Outer loop over candidates, inner loop tests divisibility. Use a flag or `break` early.

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

### 3.4 — Chained transform pipeline (the real "all that jazz")
Four stages, each a loop, output of one is input to the next. Produce a frequency report.

Input: a sentence string.
Stage A: split into words (given), loop to normalise each to lowercase into a `List<string>`.
Stage B: loop that list, build a `Dictionary<string,int>` word → count.
Stage C: loop the dictionary, find the max count.
Stage D: loop again, print only words whose count equals the max (the mode words).

```csharp
static void Ex3_4()
{
    string sentence = "the cat sat on the mat the cat ran";
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

### 3.5 — Nested loop with labelled exit
C# has no `goto`-free multi-level break by default. Search a 2D grid for a target; when found, you must break out of BOTH loops. Solve it once with a `bool found` flag, then (optional) once with `goto`.

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
Trap: if your condition is `n != 0` vs `n > 0`, what happens with a negative input? Try `n = -9384`.

### B.2 — Input validation loop
Keep prompting until the user enters a valid integer between 1 and 100. Reject non-numeric input **without crashing** (`int.TryParse`, not `int.Parse`).

```csharp
static void ExB_2()
{
    int value = 0;
    bool valid = false;

    while (!valid)
    {
        Console.Write("Enter 1-100: ");
        string input = Console.ReadLine();
        // TODO TryParse into value
        // TODO if parse failed -> message, continue
        // TODO if out of range -> message, continue
        // TODO otherwise valid = true
    }

    Console.WriteLine($"Accepted: {value}");
}
```

### B.3 — Sentinel-controlled loop
Read numbers from the user until they type `-1` (the sentinel). Then print the count, sum, and average of everything entered *before* the sentinel. The sentinel must not be counted.

```csharp
static void ExB_3()
{
    int count = 0;
    int sum = 0;
    int input;

    while (true)
    {
        Console.Write("Number (-1 to finish): ");
        // TODO read + parse into input
        // TODO if input is the sentinel -> break BEFORE counting it
        // TODO otherwise accumulate
    }

    // TODO print count, sum, average — guard against divide-by-zero
}
```

### B.4 — Menu loop (`do-while`)
Classic console menu. Show options, act on the choice, repeat until they pick Quit. `do-while` because the menu must display at least once.

```csharp
static void ExB_4()
{
    string choice;
    do
    {
        Console.WriteLine("\n1) Greet  2) Current time  3) Quit");
        Console.Write("Choice: ");
        choice = Console.ReadLine();

        // TODO switch or if-chain on choice
        // TODO handle invalid choices gracefully
    }
    while (/* TODO loop while choice is not the quit option */);

    Console.WriteLine("Bye.");
}
```

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
Then: rewrite it with the modulo variant (`while (b != 0) { temp = b; b = a % b; a = temp; }`) and count iterations for both. Note the difference for inputs like `a = 1000000, b = 3`.

### B.7 — Nested `while` with a chain
Two `while` loops feeding each other. Outer walks a queue of tasks; inner retries a task until it "succeeds". Simulate with a counter.

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
            // TODO print attempt outcome
        }

        // TODO print whether the task ultimately succeeded or exhausted retries
    }
}
```

### B.8 — Infinite loop autopsy
Each of these is broken. **Don't fix them yet** — first write down *why* each never terminates. Then fix each with a one-line change.

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
C and D are the interesting ones. C is about floating-point equality. D terminates eventually — but not the way you'd expect. Work out what actually happens.

---

## Stretch challenges (no skeleton — you're on your own)

1. Print a **hollow** square of `*` (border only) of size N.
2. Pascal's triangle, 8 rows, using only loops and a jagged array.
3. Given two sorted arrays, merge them into one sorted array using a single `while` loop with two index pointers (the merge step of merge sort).
4. Rewrite Ex3_4's whole pipeline using LINQ — then decide for yourself whether the explicit loops were clearer.

---

### How to self-check
- Does it compile with zero warnings?
- Does the output match the "Expected" notes where given?
- For the pipelines: can you explain out loud what each stage's loop hands to the next?
- Where you used `break`/`continue`, could a cleaner condition have avoided it?

# C# Ternary & Null-Coalescing Training — Minimal → Medium → Advanced

Same rules as the loops and OOP sets: fill the `// TODO` gaps, no solutions to scroll to. Compile, run, check against the "Check" notes.

One difference with this topic: these operators are small, so the difficulty isn't writing them — it's **precedence, associativity, and type inference**. Several exercises ask you to *predict the output before running*. Do that honestly; the prediction is the exercise.

Operators in scope: `?:` (ternary), `??` (null-coalescing), `??=` (null-coalescing assignment), `?.` and `?[]` (null-conditional), plus nullable types (`int?`) that make them necessary.

---

## Setup (read this first)

**1. Nullable reference types are ON by default** in new .NET projects (`<Nullable>enable</Nullable>` in the `.csproj`). With it on, every `string s = null;` in this set produces a warning. For Tiers 1–3 and the Bonus, switch it off — either for the project:

```xml
<Nullable>disable</Nullable>
```

or just for the exercise file, by putting this as its first line:

```csharp
#nullable disable
```

Stretch challenge 3 switches it back on — that's where you'll see what the compiler thinks of your code.

**2. `using` directives** — `System` and `System.Collections.Generic` are already included via implicit usings in modern templates. Nothing to add.

**3. File layout with top-level statements:** calls first, then the `static` exercise methods, then **all classes at the very bottom**. A class declared between two methods gives error CS8803 ("Top-level statements must precede namespace and type declarations").

```csharp
// Program.cs
Ex2_5();

static void Ex2_5() { /* ... */ }

// classes last:
class Address { public string City { get; set; } }
class Person  { public Address Home { get; set; } }
```

**4. Printing `null`:** `Console.WriteLine` prints an **empty line** for a null `string` or a null `int?`. When a prediction is "null", wrap it to make it visible: `Console.WriteLine($"[{x}]");` → `[]`.

---

## TIER 1 — MINIMAL (one operator, one decision)

### 1.1 — Your first ternary

Rewrite an `if/else` as a ternary. Given an int, produce `"even"` or `"odd"`.

```csharp
static void Ex1_1()
{
    int n = 7;

    // The long form:
    string resultIf;
    if (n % 2 == 0) resultIf = "even"; else resultIf = "odd";

    // TODO: the same thing as a single ternary expression
    string resultTernary = /* TODO */;

    Console.WriteLine($"{resultIf} / {resultTernary}");   // both must match
}
```

Expected: `odd / odd`. Change `n` to `8` → `even / even`.

Check: a ternary is an **expression** — it produces a value. An `if` is a **statement** — it doesn't. That's why you can write `string x = cond ? a : b;` but not `string x = if (...)`.

### 1.2 — Ternary for a value, not a message

Return the larger of two ints without `Math.Max`.

```csharp
static int Max(int a, int b)
{
    // TODO single-line ternary return
}
```

Test: `Max(3, 9)` → `9`, `Max(9, 3)` → `9`, `Max(4, 4)` → `4`, `Max(-2, -7)` → `-2`.

Extension: write `Max3(int a, int b, int c)` — once by calling `Max` twice, once with a nested ternary. Which is easier to read?

### 1.3 — Ternary inside string interpolation

Print `"You have 1 item"` or `"You have 3 items"` — correct pluralisation.

```csharp
static void Ex1_3()
{
    int count = 3;
    // TODO: interpolated string with a ternary picking "item" / "items"
    Console.WriteLine(/* TODO */);
}
```

Test with `count` = `0`, `1`, `3`. (English says "0 items" — does yours?)

Trap: try writing it **without** wrapping the ternary in parentheses first. The compiler will complain. Work out why before you add the parens — the hint is that `:` already means something special inside an interpolation hole (think `{price:F2}`).

### 1.4 — First `??`

Given a possibly-null string, print it, or `"(unknown)"` if it's null.

```csharp
static void Ex1_4()
{
    string name = null;

    // Long form:
    string safeIf = (name != null) ? name : "(unknown)";

    // TODO: the same with ?? — shorter
    string safeCoalesce = /* TODO */;

    Console.WriteLine(safeCoalesce);
}
```

Expected: `(unknown)`. Then set `name = "Alchemist"` → prints the name.

Check: `??` returns the left side **unless it is null**, in which case it returns the right side. Nothing more. (Remember this sentence — Bonus F tests it.)

### 1.5 — Nullable value types

`int` can't hold null. `int?` can. Get the value out safely.

```csharp
static void Ex1_5()
{
    int? maybe = null;

    // TODO: print whether it has a value  (.HasValue)
    // TODO: get the value or 0 using ??
    // TODO: get the value or 0 using .GetValueOrDefault()

    int? other = 42;
    // TODO: same three things for 'other'
}
```

Expected: `False 0 0`, then `True 42 42`.

Check:
- Try `int x = null;` — read the error. Then `int? x = null;`. What does the `?` change?
- `.GetValueOrDefault(-1)` exists too. When would a default other than `0` matter?

Trap: what happens if you write `int x = maybe.Value;` when `maybe` is null? Try it. Note the exception type.

---

## TIER 2 — MEDIUM (chaining, `?.`, `??=`)

### 2.1 — Null-conditional `?.`

Safely get the length of a possibly-null string, with no `if` and no crash.

```csharp
static void Ex2_1()
{
    string s = null;

    // TODO: get the length using ?. — what TYPE must the variable be?
    /* TODO type */ len = s?.Length;

    Console.WriteLine($"[{len}]");       // TODO predict: what prints for null?
}
```

Then set `s = "hello"` and run again.

Check: `s?.Length` on a `string` does **not** give you an `int`. Work out what it gives you and why. If you wrote `int len = s?.Length;` and it wouldn't compile, that's the lesson.

### 2.2 — `?.` combined with `??`

The everyday pairing: safe access with a fallback. Length, or 0 if the string is null.

```csharp
static void Ex2_2()
{
    string a = "hello";
    string b = null;

    // TODO: int with the length, or 0 if null — one expression each
    int lenA = /* TODO */;
    int lenB = /* TODO */;

    Console.WriteLine($"{lenA} {lenB}");   // expected: 5 0
}
```

Check: the result is now a plain `int`, not `int?`. Which of the two operators "removed" the `?` from the type?

### 2.3 — `??=` (null-coalescing assignment)

Assign a default **only if** the variable is currently null.

```csharp
static void Ex2_3()
{
    string config = null;
    // TODO: use ??= to set it to "default.json"
    Console.WriteLine(config);

    string existing = "custom.json";
    // TODO: same ??= line again
    Console.WriteLine(existing);   // TODO predict BEFORE running
}
```

Check: did the second one change? Explain in one sentence what `??=` does that a plain `=` doesn't.

Extension: a "cache" pattern. Write a method `GetGreeting()` that uses a static field `cached` and `??=` so the greeting is built only on the first call. Print something inside the builder to prove it runs once when you call `GetGreeting()` three times.

### 2.4 — Lazy evaluation

`??` and `??=` do **not** evaluate the right-hand side unless they need it. Prove it.

```csharp
static string ExpensiveDefault()
{
    Console.WriteLine("  >> ExpensiveDefault() was called");
    return "computed";
}

static void Ex2_4()
{
    string filled = "already here";
    string empty = null;

    Console.WriteLine("Case A:");
    string a = filled ?? ExpensiveDefault();

    Console.WriteLine("Case B:");
    string b = empty ?? ExpensiveDefault();

    // TODO predict: how many times does ">> ExpensiveDefault()" print, and under which case?
    // TODO print a and b
}
```

Check: this is why `??` beats `if (x == null) x = Compute();` when `Compute()` is costly. Does the ternary `cond ? A() : B()` also skip the branch it doesn't pick? Write a quick test to find out.

### 2.5 — Chaining `?.` through objects

Reach a nested value where any link might be null.

```csharp
static void Ex2_5()
{
    Person p1 = new Person { Home = new Address { City = "Köln" } };
    Person p2 = new Person { Home = null };
    Person p3 = null;
    Person p4 = new Person { Home = new Address { City = null } };

    // TODO: for each, get the city or "(none)" in ONE expression
    // TODO: print all four
}

// at the bottom of the file:
class Address { public string City { get; set; } }
class Person  { public Address Home { get; set; } }
```

Expected: `Köln`, `(none)`, `(none)`, `(none)`.

Check:
- `p3?.Home.City` — if `p3` is null, does the `.Home.City` part even run? Reason it out, then confirm. This short-circuiting is the whole reason `?.` chains work.
- Now try `p2?.Home.City` (only one `?`). What happens, and why doesn't the first `?.` protect you here?

### 2.6 — `?[]` on collections and safe method calls

Null-conditional works on indexers and method calls too.

```csharp
static void Ex2_6()
{
    List<string> items = null;
    List<string> full = new List<string> { "a", "b", "c" };

    // TODO: safely get element [1] from each, defaulting to "(empty)"
    // TODO: safely get .Count from each, defaulting to 0

    Action callback = null;
    // TODO: invoke callback safely with ?.Invoke()  — no crash, no if
    // TODO: then assign callback = () => Console.WriteLine("called!"); and invoke again
}
```

Expected: `(empty)` / `b`, `0` / `3`, then nothing, then `called!`.

Check:
- Try `full?[10]`. Does `?[]` protect you here? What exactly does it guard against — and what doesn't it?
- `callback?.Invoke()` is the standard way to raise events in C#. Why is `if (callback != null) callback();` actually worse in multithreaded code?

### 2.7 — Ternary chain (an else-if ladder as one expression)

Grade a score: 90+ → `"A"`, 80+ → `"B"`, 70+ → `"C"`, else `"F"`.

```csharp
static string Grade(int score)
{
    // TODO: a chained ternary. Format it across multiple lines for readability.
    return /* TODO */;
}
```

Test: `95` → `A`, `90` → `A`, `89` → `B`, `70` → `C`, `69` → `F`, `0` → `F`. The boundary values (90, 70) are where off-by-one bugs live.

Then: rewrite it as a `switch` expression (`score switch { >= 90 => "A", ... }`) and decide which you find clearer. There's no correct answer — but have an opinion.

Check: swap the order of your conditions (check `>= 70` first). What grade does `95` get now? Why does order matter in a ternary chain *and* in a switch expression?

---

## TIER 3 — ADVANCED (precedence, associativity, type inference, traps)

### 3.1 — Associativity

Both `?:` and `??` are **right-associative**. Prove you know what that means by adding the parentheses the compiler adds.

```csharp
static void Ex3_1()
{
    bool a = false, b = true;
    string x = null, y = "Y", z = "Z";

    // TODO: rewrite each with explicit parentheses showing how it actually groups.

    // A:
    string g = a ? "1" : b ? "2" : "3";
    //  => TODO

    // B:
    string h = x ?? y ?? z;
    //  => TODO

    // TODO: print g and h, and check them against your parenthesised versions.
}
```

Then: for B, if `x` is null and `y` is `"Y"`, is the right-most part evaluated at all? A plain variable can't tell you — replace `z` with a method that prints something (like `ExpensiveDefault()` from 2.4) and find out.

### 3.2 — The precedence trap

Predict the output of each line **before running**. One of these is a classic bug.

```csharp
static void Ex3_2()
{
    string name = null;
    int? num = 5;

    // A
    Console.WriteLine("Hello " + name ?? "Guest");
    // TODO predict. Hint: is + higher or lower precedence than ??
    //      and can the left-hand side of that ?? ever BE null?

    // B
    Console.WriteLine(num ?? 0 + 1);
    // TODO predict: is this (num ?? 0) + 1, or num ?? (0 + 1)?
    // TODO then set num = null and predict again.

    // TODO: fix both with parentheses so they do the obvious thing
}
```

Check for B: with `num = null`, both readings give the same answer. That's exactly why this bug survives testing — it only shows up when the value is **not** null. What does that tell you about which test cases to write?

Case A is the one to remember — it silently produces the wrong string rather than failing to compile.

### 3.3 — Ternary type inference

The two branches of a ternary must agree on a type. Explore where that bites.

```csharp
static void Ex3_3()
{
    bool flag = true;

    // A — does this compile?
    var a = flag ? 1 : "one";
    // TODO predict, then try. Explain the compiler's complaint.

    // B — does this compile?
    var b = flag ? 1 : null;
    // TODO predict, then try.

    // C — does this?
    int? c = flag ? 1 : null;
    // TODO predict, then try. Why might B and C differ?

    // D
    object d = flag ? 1 : "one";
    // TODO predict, then try. Why does this one behave differently from A?
}
```

(Comment out the lines that don't compile so you can test the rest.)

Check: the compiler works out a single type for the whole expression. In B vs C, note what information the compiler has available in each case. Look up "target-typed conditional expression" once you've formed your own theory — and note which C# version introduced it.

### 3.4 — `?? throw`

`??` pairs with `throw` to make a one-line guard clause. Common in constructors.

```csharp
class Service
{
    private readonly string endpoint;

    public Service(string endpoint)
    {
        // Long form:
        // if (endpoint == null) throw new ArgumentNullException(nameof(endpoint));
        // this.endpoint = endpoint;

        // TODO: the same in ONE line using ?? throw
        this.endpoint = /* TODO */;
    }
}
```

Test: `new Service("https://api")` works; `new Service(null)` throws. Catch it with `try/catch` and print the exception's `ParamName` — why is `nameof(endpoint)` better than typing `"endpoint"`?

Check: `throw` used to be a statement only. Since C# 7 it can appear as an expression in specific positions — this is one. (Also look up `ArgumentNullException.ThrowIfNull` — the newer alternative. When would you prefer which?)

### 3.5 — Nullable value type arithmetic

Operations on `int?` propagate null. Predict each result.

```csharp
static void Ex3_5()
{
    int? a = 5;
    int? b = null;

    // TODO predict each BEFORE running:
    int? sum   = a + b;        // ?
    bool eq    = a == b;       // ?
    bool gt    = a > b;        // ?
    bool lt    = a < b;        // ?

    // TODO: print all four (remember: null prints as an empty string)

    // Round two:
    bool nullEq  = b == null;  // ?
    bool nullGte = b >= b;     // ?  compare to b == b
}
```

The trap: `gt` and `lt` are **both** false. That means `!(a > b)` does not imply `a <= b` once nulls are involved. And `b == b` is true while `b >= b` is false. Sit with that — it breaks assumptions you rely on everywhere else.

### 3.6 — `?.` short-circuit on a whole chain

Predict what gets printed, and how many times `Get()` runs.

```csharp
static void Ex3_6()
{
    Node n = null;

    var result = n?.Get().Get().Name;
    // TODO predict: does this throw? How many "Get() ran" lines print?
    // TODO print result

    // Round two:
    Node lonely = new Node { Name = "solo", Next = null };
    // TODO predict: what happens with lonely?.Get().Get().Name ?
    //      Then try it. Then fix it so it can't throw.
}

// at the bottom:
class Node
{
    public string Name;
    public Node Next;
    public Node Get() { Console.WriteLine("  Get() ran"); return Next; }
}
```

Check: once a `?.` short-circuits, the **entire rest of the chain** is skipped — not just the next link. Many people expect the second `.Get()` to throw in round one. But in round two, the first `?.` *doesn't* short-circuit — so what protects the second `.Get()`?

### 3.7 — Refactor a nested mess

Here's ugly defensive code. Collapse it into one expression using `?.` and `??`, with no `if` at all.

```csharp
// Uses Person/Address from 2.5, plus (at the bottom of the file):
class Company { public Person Owner { get; set; } }

static string OwnerCityOld(Company c)
{
    if (c == null) return "(unknown)";
    if (c.Owner == null) return "(unknown)";
    if (c.Owner.Home == null) return "(unknown)";
    if (c.Owner.Home.City == null) return "(unknown)";
    return c.Owner.Home.City;
}

static string OwnerCityNew(Company c)
{
    // TODO: one line, same behaviour
}
```

Then write a test: put these five cases in a `List<Company>` and loop over them, printing both results and `MATCH` / `MISMATCH`:

1. `null`
2. company with `Owner = null`
3. owner with `Home = null`
4. home with `City = null`
5. fully populated (`"Köln"`)

Expected: five `MATCH` lines, four `(unknown)` and one `Köln`.

### 3.8 — When NOT to use these

Add this class at the bottom of your file:

```csharp
class User
{
    public bool IsBanned { get; set; }
    public bool IsPremium { get; set; }
    public bool TrialEnded { get; set; }
    public bool HasVerifiedEmail { get; set; }
}
```

Here's the nested ternary to untangle:

```csharp
static string Status(User user)
{
    return user == null
        ? "anonymous"
        : user.IsBanned
            ? "banned"
            : user.IsPremium
                ? (user.TrialEnded ? "premium" : "trial")
                : user.HasVerifiedEmail ? "member" : "unverified";
}
```

1. **Before running anything**, work out the status for each of these on paper:
   - `null`
   - banned **and** premium
   - premium, trial not ended
   - not premium, email verified
   - nothing set at all (all `false`)
2. Rewrite `Status` as `StatusIf` with `if/else` (or early `return`s), and as `StatusSwitch` with a `switch` expression.
3. Run all three versions on your five users and check they agree with your paper answers.

Question hiding in the logic: `TrialEnded == true` gives `"premium"`, `false` gives `"trial"`. Does that read right to you, or is it a bug in the original? How easy was it to spot in each version?

The exercise is judgement, not syntax. Write down the line count of each version and which one you could debug at 2am.

---

## BONUS — Trap autopsy

Each snippet is wrong or surprising. **First write down what you think happens and why.** Then run it. Then fix it.

```csharp
// A
int? count = 5;
int total = count ?? 0 + 10;
// What is total? Is that what the author wanted (probably 15)?
// Then set count = null — why does the bug hide in that case?

// B
string s = null;
if (s?.Length > 0) Console.WriteLine("has content");
else Console.WriteLine("empty or null");
// A null compared with > — does this throw? Which branch runs?

// C
string a = null;
string b = a ?? "";
bool same = b == a ?? "";
// Does this even compile? If not — read the error and work out how the compiler grouped it.

// D
List<int> nums = null;
foreach (var n in nums ?? new List<int>()) Console.WriteLine(n);
// Safe or not? What would happen WITHOUT the ?? part?

// E
int? x = null;
Console.WriteLine(x == null ? "null" : x.Value.ToString());
Console.WriteLine(x?.ToString() ?? "null");
// Both print the same thing. Is one better? Why?

// F
string name = "";
string display = name ?? "Anonymous";
Console.WriteLine($"[{display}]");
// Prints "[]", not "[Anonymous]". Why? What did the author actually want?
// Fix it — then also test name = "   " (spaces only). Does your fix handle that?
```

F is the single most common misunderstanding of `??` in real code. Make sure you can state the rule precisely.

---

## Stretch challenges (no skeleton — you're on your own)

1. Write `Coalesce<T>(params T[] values)` that returns the first non-null value, or `default`. What happens when `T` is `int` (not `int?`) — can a value ever be null? Then compare it to just chaining `??` — which reads better, and when?
2. Take a method with four `if (x == null) return default;` guards and reduce it to one expression. Then argue against your own refactor.
3. Switch nullable reference types back **on** (`<Nullable>enable</Nullable>`, or remove the `#nullable disable` line). Fix every warning in your Tier 2 answers — mostly by changing types to `string?`, `Address?` etc. Note where the compiler was right and where you had to use `!` to override it — and be suspicious of every `!` you wrote.
4. Build a small config resolver: value from command-line arg, else environment variable (`Environment.GetEnvironmentVariable`), else a config file, else hard-coded default. Write it once with nested `if`, once with a `??` chain. Time yourself reading each a day later.

---

### How to self-check

- For every `??`: are you defaulting on **null**, or did you actually mean "null or empty"? (See trap F.)
- For every `?.` on a value type: did the result become nullable? Did you handle that, or paper over it?
- For every precedence test: did you test with a **non-null** value too? (See 3.2 B and trap A.)
- For every chained ternary longer than two levels: would an `if/else` or `switch` expression be kinder to the next reader?
- Can you state the precedence of `??` relative to `+` and `==` without looking it up?
- Did you add parentheses because you *needed* them, or because you weren't sure? The second reason is fine — but go find out which it was.

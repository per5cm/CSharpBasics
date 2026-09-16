# C# Ternary & Null-Coalescing Training — Minimal → Medium → Advanced

Same rules as the loops and OOP sets: fill the `// TODO` gaps, no solutions to scroll to. Compile, run, check against the "Check" notes.

One difference with this topic: these operators are small, so the difficulty isn't writing them — it's **precedence, associativity, and type inference**. Several exercises ask you to *predict the output before running*. Do that honestly; the prediction is the exercise.

Operators in scope: `?:` (ternary), `??` (null-coalescing), `??=` (null-coalescing assignment), `?.` and `?[]` (null-conditional), plus nullable types (`int?`) that make them necessary.

Needs `using System;` and `using System.Collections.Generic;`. A few snippets reference variables declared elsewhere (`user`, for example) — those are illustrative, so declare whatever you need to make them compile.

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
Check: a ternary is an **expression** — it produces a value. An `if` is a **statement** — it doesn't. That's why you can write `string x = cond ? a : b;` but not `string x = if (...)`.

### 1.2 — Ternary for a value, not a message
Return the larger of two ints without `Math.Max`.

```csharp
static int Max(int a, int b)
{
    // TODO single-line ternary return
}
```

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
Trap: try writing it **without** wrapping the ternary in parentheses first. The compiler will complain. Work out why before you add the parens — the hint is that `:` already means something special inside an interpolation hole.

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
Check: `??` returns the left side **unless it is null**, in which case it returns the right side. Nothing more.

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

    Console.WriteLine(len);       // TODO predict: what prints for null?
}
```
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

    // TODO predict: how many times does ">> ExpensiveDefault()" print?
}
```
Check: this is why `??` beats `if (x == null) x = Compute();` when `Compute()` is costly.

### 2.5 — Chaining `?.` through objects
Reach a nested value where any link might be null.

```csharp
class Address { public string City { get; set; } }
class Person  { public Address Home { get; set; } }

static void Ex2_5()
{
    Person p1 = new Person { Home = new Address { City = "Köln" } };
    Person p2 = new Person { Home = null };
    Person p3 = null;

    // TODO: for each, get the city or "(none)" in ONE expression
    // TODO: print all three
}
```
Check: `p3?.Home.City` — if `p3` is null, does the `.Home.City` part even run? Reason it out, then confirm. This short-circuiting is the whole reason `?.` chains work.

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
}
```
Check: `callback?.Invoke()` is the standard way to raise events in C#. Why is `if (callback != null) callback();` actually worse in multithreaded code?

### 2.7 — Ternary chain (an else-if ladder as one expression)
Grade a score: 90+ → `"A"`, 80+ → `"B"`, 70+ → `"C"`, else `"F"`.

```csharp
static string Grade(int score)
{
    // TODO: a chained ternary. Format it across multiple lines for readability.
    return /* TODO */;
}
```
Then: rewrite it as a `switch` expression (`score switch { >= 90 => "A", ... }`) and decide which you find clearer. There's no correct answer — but have an opinion.

---

## TIER 3 — ADVANCED (precedence, associativity, type inference, traps)

### 3.1 — Associativity
Both `?:` and `??` are **right-associative**. Prove you know what that means by adding the parentheses the compiler adds.

```csharp
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
```
Then: for B, if `x` is null and `y` is `"Y"`, is `z` evaluated at all?

### 3.2 — The precedence trap
Predict the output of each line **before running**. One of these is a classic bug.

```csharp
static void Ex3_2()
{
    string name = null;
    int? num = null;

    // A
    Console.WriteLine("Hello " + name ?? "Guest");
    // TODO predict. Hint: is + higher or lower precedence than ??
    //      and can the left-hand side of that ?? ever BE null?

    // B
    Console.WriteLine(num ?? 0 + 1);
    // TODO predict: is this (num ?? 0) + 1, or num ?? (0 + 1)?

    // TODO: fix both with parentheses so they do the obvious thing
}
```
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
Check: the compiler works out a single type for the whole expression. In B vs C, note what information the compiler has available in each case. Look up "target-typed conditional expression" once you've formed your own theory.

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
Check: `throw` used to be a statement only. Since C# 7 it can appear as an expression in specific positions — this is one.

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

    // TODO: print all four.
}
```
The trap: `gt` and `lt` are **both** false. That means `!(a > b)` does not imply `a <= b` once nulls are involved. Sit with that — it breaks an assumption you rely on everywhere else.

### 3.6 — `?.` short-circuit on a whole chain
Predict what gets printed, and how many times `Get()` runs.

```csharp
class Node
{
    public string Name;
    public Node Next;
    public Node Get() { Console.WriteLine("  Get() ran"); return Next; }
}

static void Ex3_6()
{
    Node n = null;

    var result = n?.Get().Get().Name;
    // TODO predict: does this throw? How many "Get() ran" lines print?
    // TODO print result
}
```
Check: once a `?.` short-circuits, the **entire rest of the chain** is skipped — not just the next link. Many people expect the second `.Get()` to throw. Confirm what actually happens.

### 3.7 — Refactor a nested mess
Here's ugly defensive code. Collapse it into one expression using `?.` and `??`, with no `if` at all.

```csharp
// Given Person/Address from 2.5, plus:
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
Then write a small test loop that calls both with several inputs (null company, company with null owner, fully populated) and asserts the two always agree.

### 3.8 — When NOT to use these
Rewrite this back into an `if/else`, then decide which version you'd ship.

```csharp
string status = user == null
    ? "anonymous"
    : user.IsBanned
        ? "banned"
        : user.IsPremium
            ? (user.TrialEnded ? "premium" : "trial")
            : user.HasVerifiedEmail ? "member" : "unverified";
```
The exercise is judgement, not syntax. Write down the line count of each version and which one you could debug at 2am.

---

## BONUS — Trap autopsy

Each snippet is wrong or surprising. **First write down what you think happens and why.** Then run it. Then fix it.

```csharp
// A
int? count = null;
int total = count ?? 0 + 10;
// What is total? Is that what the author wanted?

// B
string s = null;
if (s?.Length > 0) Console.WriteLine("has content");
else Console.WriteLine("empty or null");
// A null compared with > — does this throw? Which branch runs?

// C
string a = null;
string b = a ?? "";
bool same = b == a ?? "";
// Does this even compile? If so, what is 'same'?

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
```
F is the single most common misunderstanding of `??` in real code. Make sure you can state the rule precisely.

---

## Stretch challenges (no skeleton — you're on your own)

1. Write `Coalesce<T>(params T[] values)` that returns the first non-null value, or `default`. Then compare it to just chaining `??` — which reads better, and when?
2. Take a method with four `if (x == null) return default;` guards and reduce it to one expression. Then argue against your own refactor.
3. Enable nullable reference types (`<Nullable>enable</Nullable>` in the .csproj). Fix every warning in your Tier 2 answers. Note where the compiler was right and where you had to use `!` to override it — and be suspicious of every `!` you wrote.
4. Build a small config resolver: value from command-line arg, else environment variable, else config file, else hard-coded default. Write it once with nested `if`, once with a `??` chain. Time yourself reading each a day later.

---

### How to self-check
- For every `??`: are you defaulting on **null**, or did you actually mean "null or empty"? (See trap F.)
- For every `?.` on a value type: did the result become nullable? Did you handle that, or paper over it?
- For every chained ternary longer than two levels: would an `if/else` or `switch` expression be kinder to the next reader?
- Can you state the precedence of `??` relative to `+` and `==` without looking it up?
- Did you add parentheses because you *needed* them, or because you weren't sure? The second reason is fine — but go find out which it was.

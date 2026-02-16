// See https://aka.ms/new-console-template for more information


bool isRainy = true;
bool hasUmbrella = false;

// Logical Operators
// AND &&
// OR  ||
// NOT !

// Variants of OR statements
// true || true -> true
// true || false -> true
// false|| true -> true
// false|| false -> false

// Variants of the AND operator/statements
// true  && true -> true
// true  && false -> false
// false && true -> false
// false && false -> false


if (isRainy && !hasUmbrella)
{
    Console.WriteLine("I'M getting wet!");
}
Console.WriteLine("Ay OK!");
Console.ReadKey();
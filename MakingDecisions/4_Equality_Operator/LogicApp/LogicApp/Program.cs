// See https://aka.ms/new-console-template for more information

int num1 = 0;
int num2 = 0;

bool isEqual = num1 == num2;

bool isNotEqual = num1 != num2;

Console.WriteLine("Please enter a whole number");

if (num1 == int.Parse(Console.ReadLine()))
{
    Console.WriteLine("Numbers are equal!");
}
else
{
    Console.WriteLine("Numbers aren't equal");
}

/*

int age = 16;
bool isWithParents = true;

if(age >= 13 && isWithParents)
{
    Console.WriteLine("Go party in the club with your parents!");
}else if (age > 18)
{
    Console.WriteLine("Go party in the club!");
}
else
{
    Console.WriteLine("Go party in Kindergarten!");
}

*/

Console.ReadKey();





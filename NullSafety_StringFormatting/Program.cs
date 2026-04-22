using System;
using System.Collections.Generic;

namespace NullSafety_StringFormatting
{
    internal class Program
    {
        record User(string? FirstName, string? LastName, int? Age);
        
        static void Main(string[] args)
        {
            User user = new User(FirstName: null,LastName: null, Age: 18);
            
            Console.WriteLine(GetGreeting(user));
        }

        static string GetGreeting(User user)
        {
            // If FirstName is null → use "stranger"
            string? greeting = user.FirstName == null
                ? $"Hello stranger {user.FirstName}"
                : $"Hello {user.FirstName}, {user.LastName}, {user.Age}";

            // If LastName is null → omit it entirely
            string? lastName = user.LastName ?? null;
            
            // If Age is null → omit it, otherwise append "aged X"
            int? age = user.Age == null ? null : user.Age;
            
            return $"Hello {user.FirstName} {user.LastName} {user.Age} years old. {lastName}!";
        }
    }
}
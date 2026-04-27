using System;
using System.Collections.Generic;

namespace NullSafety_StringFormatting
{
    internal class Program
    {
        record User(string? FirstName, string? LastName, int? Age);
        
        static void Main(string[] args)
        {
            User user = new User(FirstName: null,LastName: "Bottom", Age: null);
            User newUser = new User(FirstName: "John", LastName: "Doe", Age: 18);
            
            Console.WriteLine(GetGreeting(user));
            Console.WriteLine(GetGreeting(newUser));
        }

        static string GetGreeting(User user)
        {
            // If FirstName is null → use "stranger"
            string name = user.FirstName ?? "stranger";
            
            // If LastName is null → omit it entirely
            string last = user.LastName != null ? " " + user.LastName : "";
            
            // If Age is null → omit it, otherwise append "aged X"
            string age = user.Age != null ? $" aged {user.Age}" : "";
            
            return $"Hello, {name}{last}{age}";
        }
        
        #region Old Code
        
        // // If LastName is null → omit it entirely
        // string? lastName = user.LastName ?? null;
        //     
        // // If Age is null → omit it, otherwise append "aged X"
        // int? age = user.Age == null ? null : user.Age;
        //     
        // // If FirstName is null → use "stranger"
        // string? greeting = user.FirstName == null
        //         ? $"Hello stranger {user.FirstName} {lastName}"
        //         : $"Hello {user.FirstName}, {lastName}, is {age} years old "; 
        //     
        //     // return $"Hello {user.FirstName} {user.LastName} {user.Age} years old. {lastName}!";
        //     return greeting;
        
        #endregion
    }
}
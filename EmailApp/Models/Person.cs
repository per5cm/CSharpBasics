using System;
using System.Collections.Generic;
using System.Text;

namespace EmailApp.Models
{
    internal class Person
    {
        internal string Name { get; set; } = string.Empty;
        internal DateTime BirthDate { get; set; }
        internal string Email { get; set; } = string.Empty;
        internal string PhoneNumber { get; set; } = string.Empty;
        internal DateTime LastSent { get; set; }
        internal bool IsSent { get; set; } = false;
        internal string PreferredMessageStyle { get; set; } = string.Empty;
        internal string RelationshipTag { get; set; } = "friend";
        internal string Intrest { get; set; } = string.Empty;


        internal bool IsBirthdayToday(DateTime today)
        {
            return today.Month == BirthDate.Month && today.Day == BirthDate.Day;
        }

        internal int GetAge(DateTime today)
        {
            int age = today.Year - BirthDate.Year;
            return age;
        }
    }
}

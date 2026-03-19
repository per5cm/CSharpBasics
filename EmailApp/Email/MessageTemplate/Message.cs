using EmailApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmailApp.Email.MessageTemplate
{
    
    internal class Message
    {
        internal static string SubjectHappyBirthday(Person person)
        {
            return $"Happy Birthday, {person.Name}!";
        }
    }
}

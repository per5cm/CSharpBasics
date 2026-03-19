using System;
using System.Collections.Generic;
using System.Text;
using EmailApp.Person;

namespace EmailApp.Email.EmailSender
{
    internal class EmailSenderStatus
    {
        public bool Send(PersonConstructor person, string subject, string body)
        {
            Console.WriteLine("+==================================+");
            Console.WriteLine($"Sending email to: {person.Email}");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Body: {body}");
            Console.WriteLine("+==================================+");

            return true;
        }
    }
}

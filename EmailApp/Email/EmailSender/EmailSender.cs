using EmailApp.Email.MessageTemplate;
using EmailApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmailApp.Email.EmailSender
{
    internal class SenderBoilerPlate
    {
        public static bool Send(Person person, Subject subject, Message body)
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

using EmailApp.Email.MessageTemplate;
using EmailApp.Person;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmailApp.Email.EmailSender
{
    internal class EmailSenderStatus
    {
        public bool Send(PersonConstructor person, MessageTemplateSubject subject, MessageTemplateBody body)
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

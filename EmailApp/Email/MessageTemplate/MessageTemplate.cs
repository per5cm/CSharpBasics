using EmailApp.Person;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmailApp.Email.MessageTemplate
{
    internal class MessageTemplateSubject
    {
        internal string Subject(string subject = "Greeting.")
        {
            return subject;
        }
    }
    internal class MessageTemplateBody
    {
        internal string SubjectHappyBirthday(PersonConstructor person)
        {
            return $"Happy Birthday, {person.Name}!";
        }
    }
}

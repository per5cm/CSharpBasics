using EmailApp.Person;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmailApp.Email.MessageTemplate
{
    internal class MessageTemplateComposer
    {
        internal string SubjectHappyBirthday(PersonConstructor person)
        {
            return $"Happy Birthday, {person.Name}!";
        }
    }
}

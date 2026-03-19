using System;
using System.Collections.Generic;
using System.Text;

namespace EmailApp.Email.MessageTemplate
{
    internal class Subject
    {
        internal class SubjectGreeting
        {
            internal static string Subject(string subject = "Greeting.")
            {
                return subject;
            }
        }
    }
}

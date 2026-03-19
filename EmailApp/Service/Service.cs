using EmailApp.Person;
using EmailApp.Email.MessageTemplate;
using EmailApp.Email.EmailSender;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmailApp.Service
{
    internal class BirthdayService
    {
        private readonly List<PersonConstructor> constructors;
        private readonly EmailSenderStatus sender;

        internal BirthdayService(List<PersonConstructor> constructor, EmailSenderStatus sender)
        {
            this.constructors = constructor;
            this.sender = sender;

            this.constructors.Add(new PersonConstructor { Name = "Karen", BirthDate = new DateTime(19, 3, 1960), Email = "karen.longbottom@gmail.com", RelationshipTag = "friend" });
        }
    }
}

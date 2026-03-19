using EmailApp.Models;
using EmailApp.Email.MessageTemplate;
using EmailApp.Email.EmailSender;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmailApp.Service
{
    internal class BirthdayService
    {
        private readonly List<Person> reciever;
        private readonly SenderBoilerPlate sender;

        internal BirthdayService(List<Person> reciever, SenderBoilerPlate sender)
        {
            this.reciever = reciever;
            this.sender = sender;

            this.reciever.Add(new Person { Name = "Karen", BirthDate = new DateTime(19, 3, 1960), Email = "karen.longbottom@gmail.com", RelationshipTag = "friend" });
        }
    }
}

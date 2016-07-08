using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CreatingObjects.Builders.Interfaces;
using CreatingObjects.Common;
using CreatingObjects.Interfaces;

namespace CreatingObjects.Builders.Person
{
    public class PersonBuilder: IFirstNameHolder, ILastNameHolder, IPrimaryContactHolder,IContactHolder, IPersonBuilder
    {
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private IList<IContactInfo>  Contacts { get; set; } = new List<IContactInfo>();
        private IContactInfo PrimaryContact { get; set; }

        public static IFirstNameHolder Person()
        {
            return new PersonBuilder();
        }

        public ILastNameHolder WithFirstName(string firstName)
        {
            return new PersonBuilder
            {
                FirstName = firstName
            };
        }

        public IPrimaryContactHolder WithLastName(string lastName)
        {
            return new PersonBuilder
            {
                FirstName = this.FirstName,
                LastName = lastName
            };
        }

        public IContactHolder WithSecondatyContact(IContactInfo contact) => WithContacts(contact);

        public PersonBuilder WithContacts(IContactInfo contact)
        {
            return new PersonBuilder
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                Contacts = new List<IContactInfo>(this.Contacts) { contact },
                PrimaryContact = this.PrimaryContact
            };
        }

        public IPersonBuilder AddNoMoreContacts() => this;

        public IContactHolder WithPrimaryContact(IContactInfo contact)
        {
            if (contact == null)
                throw new ArgumentNullException();

            PersonBuilder builder = this.WithContacts(contact);
            builder.PrimaryContact = contact;
            return builder;
        }

        public Models.Person Build()
        {
            Models.Person person = new Models.Person();

            person.Name = this.FirstName;
            person.Surname = this.LastName;
            
            foreach (var contactInfo in this.Contacts)
            {
                person.ContactsLsit.Add(contactInfo);
            }

            person.PrimaryContact = this.PrimaryContact;

            return person;
        }
    }
}

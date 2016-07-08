using System;
using System.Collections.Generic;
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
        private INonEmptyStringState FirstNameState { get; set; } = new UninitializedString();
        private INonEmptyStringState LastNameState { get; set; }= new UninitializedString();
        private IList<IContactInfo>  Contacts { get; } = new List<IContactInfo>();
        private IPrimaryContactState PrimaryContactState { get; set; }

        private PersonBuilder()
        {
            this.Contacts = new List<IContactInfo>();
            this.PrimaryContactState = new UninitializedPrimaryContact(this.Contacts.Contains);
        }

        public static IFirstNameHolder Person()
        {
            return new PersonBuilder();
        }

        public ILastNameHolder WithFirstName(string firstName)
        {
            this.FirstNameState = this.FirstNameState.Set(firstName);
            return this;
        }

        public IPrimaryContactHolder WithLastName(string lastName)
        {
            this.LastNameState = this.LastNameState.Set(lastName);
            return this;
        }

        public IContactHolder WithSecondatyContact(IContactInfo contact)
        {
            if (contact == null)
                throw new ArgumentNullException();

            if (Contacts.Contains(contact))
                throw new ArgumentException();

            this.Contacts.Add(contact);
            return this;
        }

        public IPersonBuilder AddNoMoreContacts()
        {
            return this;
        }

        public IContactHolder WithPrimaryContact(IContactInfo contact)
        {
            if (contact == null)
                throw new ArgumentNullException();

            this.WithSecondatyContact(contact);
            this.PrimaryContactState = this.PrimaryContactState.Set(contact);
            return this;
        }

        public Models.Person Build()
        {
            Models.Person person = new Models.Person(this.FirstNameState.Get(), this.LastNameState.Get());

            foreach (var contactInfo in this.Contacts)
            {
                person.Add(contactInfo);
            }

            person.SetPrimaryContact(this.PrimaryContactState.Get());

            return person;
        }
    }
}

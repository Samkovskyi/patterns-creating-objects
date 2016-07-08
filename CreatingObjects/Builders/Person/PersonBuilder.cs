using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CreatingObjects.Common;
using CreatingObjects.Interfaces;

namespace CreatingObjects.Builders.Person
{
    public class PersonBuilder
    {
        private INonEmptyStringState FirstNameState { get; set; } = new UninitializedString();
        private INonEmptyStringState LastNameState { get; set; }= new UninitializedString();
        private IList<IContactInfo>  Contacts { get; } = new List<IContactInfo>();
        private IPrimaryContactState PrimaryContactState { get; set; }

        public PersonBuilder()
        {
            this.Contacts = new List<IContactInfo>();
            this.PrimaryContactState = new UninitializedPrimaryContact(this.Contacts.Contains);
        }

        public void SetFirstName(string firstName)
        {
            this.FirstNameState = this.FirstNameState.Set(firstName);
        }

        public void SetLastName(string lastName)
        {
            this.LastNameState = this.LastNameState.Set(lastName);
        }

        public void Add(IContactInfo contact)
        {
            if (contact == null)
                throw new ArgumentNullException();

            if (Contacts.Contains(contact))
                throw new ArgumentException();

            this.Contacts.Add(contact);
        }

        public void SetPrimaryContact(IContactInfo contact)
        {
            if (contact == null)
                throw new ArgumentNullException();

            this.PrimaryContactState = this.PrimaryContactState.Set(contact);
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

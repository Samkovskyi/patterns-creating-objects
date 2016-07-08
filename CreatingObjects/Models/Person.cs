using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreatingObjects.Interfaces;

namespace CreatingObjects.Models
{
    public class Person : IUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        private IList<IContactInfo>  Contacts { get; } = new List<IContactInfo>();
        private IContactInfo PrimaryContact { get; set; }

        public Person(string name, string surname)
        {
            if(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname))
                throw new ArgumentException();

            this.Name = name;
            this.Surname = surname;
        }

        public void SetIdentity(IUserIdentity identity) { }

        public bool CanAcceptIdentity(IUserIdentity identity) => identity is IdentityCard;
        public void Add(IContactInfo contact)
        {
           if (contact == null)
                throw new ArgumentNullException();

           if (this.Contacts.Contains(contact))
                throw new ArgumentException();

           Contacts.Add(contact);
        }

        public void SetPrimaryContact(IContactInfo contact)
        {
            if (contact == null)
                throw new ArgumentNullException();

            if (!this.Contacts.Contains(contact))
                throw new ArgumentException();

            PrimaryContact = contact;
        }

        public override string ToString() => $"{this.Name} {this.Surname}";
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreatingObjects.Interfaces;

namespace CreatingObjects.Common
{
    public class ValidPrimaryContact: IPrimaryContactState
    {
        private IContactInfo Contact { get; }
        private Func<IContactInfo, bool>  Predicate { get; }

        public ValidPrimaryContact(IContactInfo contact, Func<IContactInfo, bool> predicate)
        {
            if (contact == null || predicate == null) 
                throw new ArgumentNullException();

            if (!predicate(contact))
                throw new ArgumentException();

            this.Contact = contact;
            this.Predicate = predicate;
        }
        public IPrimaryContactState Set(IContactInfo contact) => 
            new ValidPrimaryContact(contact, this.Predicate);

        public IContactInfo Get() => this.Contact;
    }
}

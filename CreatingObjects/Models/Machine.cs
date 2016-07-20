using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreatingObjects.Interfaces;

namespace CreatingObjects.Models
{
    public class Machine: IUser
    {
        public Producer Producer { get; set; }
        public string Model { get; set; }
        private LegalEntity Owner { get; }
        public IContactInfo PrimaryContact => this.Owner.EmailAddress;

        public Machine(Producer producer, string model, LegalEntity owningBussines)
        {
            Contract.Requires<ArgumentNullException>(producer != null);
            Contract.Requires<ArgumentNullException>(string.IsNullOrEmpty(model));
            Contract.Requires<ArgumentNullException>(owningBussines != null);

            this.Producer = producer;
            this.Model = model;
            this.Owner = owningBussines;
        }

        public void SetIdentity(IUserIdentity identity)
        {
            throw new NotImplementedException();
        }

        public bool CanAcceptIdentity(IUserIdentity identity)
        {
            throw new NotImplementedException();
        }

        public void Add(IContactInfo contact)
        {
            throw new NotImplementedException();
        }

        public void SetPrimaryContact(IContactInfo contact)
        {
            throw new NotImplementedException();
        }
    }
}

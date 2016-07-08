using System;
using System.Collections.Generic;
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

        public Machine(Producer producer, string model)
        {
            this.Producer = producer;
            this.Model = model;
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

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
        public string Name { get; internal set; }
        public string Surname { get; internal set; }
        public IEnumerable<IContactInfo>  Contacts => this.ContactsLsit;
        public IContactInfo PrimaryContact { get; internal set; }

        internal IList<IContactInfo> ContactsLsit { get; } = new List<IContactInfo>();

        internal Person()
        {
        }

        public void SetIdentity(IUserIdentity identity) { }

        public bool CanAcceptIdentity(IUserIdentity identity) => identity is IdentityCard;
 
        public override string ToString() => $"{this.Name} {this.Surname}";
    }
}


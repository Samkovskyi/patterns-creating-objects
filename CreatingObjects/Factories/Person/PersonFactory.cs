using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreatingObjects.Factories.Interfaces;
using CreatingObjects.Interfaces;
using CreatingObjects.Models;

namespace CreatingObjects.Factories.Person
{
    public class PersonFactory: IUserFactory
    {
        public IUser CreateUser(string firstName, string lastName)
        {
            return new Models.Person(firstName, lastName);
        }

        public IUserIdentity CreateIdentity()
        {
            return new IdentityCard();
        }
    }
}

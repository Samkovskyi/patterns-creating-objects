using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreatingObjects.Builders.Person;
using CreatingObjects.Interfaces;

namespace CreatingObjects.Models
{
    public class HumanPersonManager : PersonalManager
    {
        protected override Func<IUser> CreateUser
        {
            get
            {
                return () => PersonBuilder
                    .Person()
                    .WithFirstName("Taras")
                    .WithLastName("Samkovskyi")
                    .WithPrimaryContact(new EmailAddress("cool@email.com"))
                    .WithSecondatyContact(new EmailAddress("alternate@email.com"))
                    .AddNoMoreContacts()
                    .Build();
            }
        }
    }
}

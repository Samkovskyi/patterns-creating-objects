using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreatingObjects.Builders.Person;
using CreatingObjects.Interfaces;

namespace CreatingObjects.Models
{
    public static class UserFactory
    {
        public static Func<IUser> PersonFactory => PersonBuilder
            .Person()
            .WithFirstName("Taras")
            .WithLastName("Samkovskyi")
            .WithPrimaryContact(new EmailAddress("cool@email.com"))
            .WithSecondatyContact(new EmailAddress("alternate@email.com"))
            .AddNoMoreContacts()
            .Build;
    }
}

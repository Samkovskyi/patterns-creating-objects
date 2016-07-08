using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreatingObjects.Builders.Person;
using CreatingObjects.Factories.Interfaces;
using CreatingObjects.Factories.Person;
using CreatingObjects.Interfaces;
using CreatingObjects.Models;

namespace CreatingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigureUserBuilder();

            Console.WriteLine("Reached end of demonstration...");
            Console.ReadLine();
        }


        static void ConfigureUserFactory()
        {
            IUserFactory factory = new PersonFactory();
            IUser user = factory.CreateUser("Taras", "Samkovskyi");
            IUserIdentity id = factory.CreateIdentity();
            user.SetIdentity(id);
        }

        static void ConfigureUserBuilder()
        {
            Person person = PersonBuilder
                .Person()
                .WithFirstName("Taras")
                .WithLastName("Samkovskyi")
                .WithPrimaryContact(new EmailAddress("cool@email.com"))
                .WithSecondatyContact(new EmailAddress("alternate@email.com"))
                .AddNoMoreContacts()
                .Build();

            Console.WriteLine(person);
            Console.WriteLine();
        }
    }
}

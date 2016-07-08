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
            ConfigureUser();

            Console.WriteLine("Reached end of demonstration...");
            Console.ReadLine();
        }


        static void ConfigureUser()
        {
            PersonalManager mgr = new PersonalManager(PersonBuilder
                .Person()
                .WithFirstName("Taras")
                .WithLastName("Samkovskyi")
                .WithPrimaryContact(new EmailAddress("cool@email.com"))
                .WithSecondatyContact(new EmailAddress("alternate@email.com"))
                .AddNoMoreContacts()
                .Build);
            mgr.Notify("Hello");
            Console.WriteLine();
        }
    }
}

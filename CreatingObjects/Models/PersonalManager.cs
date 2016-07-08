using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreatingObjects.Interfaces;

namespace CreatingObjects.Models
{
    public class PersonalManager
    {
        private Func<IUser> UserFactory { get; }

        public PersonalManager(Func<IUser> userFactoryFacrotry)
        {
            this.UserFactory = userFactoryFacrotry;
        }
        
        public void Notify(string message)
        {
           this.Enqueue(this.GetPrimaryContact(), message); 
        }

        private IContactInfo GetPrimaryContact()
        {
            return this.UserFactory().PrimaryContact;
        }

        private void Enqueue(IContactInfo contact, string message)
        {
            Console.WriteLine($"Sending {message} to {contact}.");
        }
    }
}

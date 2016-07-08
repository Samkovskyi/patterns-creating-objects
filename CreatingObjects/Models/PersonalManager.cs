using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreatingObjects.Interfaces;

namespace CreatingObjects.Models
{
    public abstract class PersonalManager
    {
        protected abstract Func<IUser> CreateUser { get; }
        public void Notify(string message)
        {
           this.Enqueue(this.GetPrimaryContact(), message); 
        }

        private IContactInfo GetPrimaryContact()
        {
            return this.CreateUser().PrimaryContact;
        }

        private void Enqueue(IContactInfo contact, string message)
        {
            Console.WriteLine($"Sending {message} to {contact}.");
        }
    }
}

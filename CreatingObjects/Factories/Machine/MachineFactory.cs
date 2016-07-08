using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreatingObjects.Factories.Interfaces;
using CreatingObjects.Interfaces;
using CreatingObjects.Models;

namespace CreatingObjects.Factories.Machine
{
    public class MachineFactory: IUserFactory 
    {
        private Dictionary<string, Producer> NameToProducer { get; set; }

        public MachineFactory(Dictionary<string, Producer> nameToProducer)
        {
            if (nameToProducer == null)
                throw new ArgumentNullException(nameof(nameToProducer));
            this.NameToProducer = nameToProducer;
        }
        public IUser CreateUser(string producerName, string model)
        {
            Producer producer = this.GetProducer(producerName);
            return new Models.Machine(producer, model);
        }

        public IUserIdentity CreateIdentity()
        {
           return new MacAddress();
        }

        private Producer GetProducer(string name)
        {
            Producer producer;
            if (!this.NameToProducer.TryGetValue(name, out producer))
                throw new ArgumentException();
            return producer;
        }
    }
}

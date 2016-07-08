using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreatingObjects.Interfaces;

namespace CreatingObjects.Models
{
    public class EmailAddress: IContactInfo
    {
        private string email;
        public EmailAddress(string email)
        {
            this.email = email;
        }

        public override string ToString()
        {
            return email;
        }
    }
}

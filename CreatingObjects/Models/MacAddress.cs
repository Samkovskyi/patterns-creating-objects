using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreatingObjects.Interfaces;

namespace CreatingObjects.Models
{
    public class MacAddress : IUserIdentity
    {
        public string RawAddress { get; set; }
    }
}

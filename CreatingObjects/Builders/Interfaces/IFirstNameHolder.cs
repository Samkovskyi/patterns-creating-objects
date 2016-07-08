using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatingObjects.Builders.Interfaces
{
    public interface IFirstNameHolder
    {
        ILastNameHolder WithFirstName(string name);
    }
}

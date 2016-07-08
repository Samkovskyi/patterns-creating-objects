using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatingObjects.Common
{
    public class UninitializedString: INonEmptyStringState
    {
        public INonEmptyStringState Set(string value) => new NonEmptyString(value);

        public string Get()
        {
            throw new InvalidOperationException();
        }
    }
}

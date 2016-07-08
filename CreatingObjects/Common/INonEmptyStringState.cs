using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatingObjects.Common
{
    public interface INonEmptyStringState
    {

        INonEmptyStringState Set(string value);
        string Get();
    }
}

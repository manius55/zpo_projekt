using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zpo_projekt
{
    internal interface IValidable
    {
        public void ValidateOrThrow();
    }
}

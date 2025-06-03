using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zpo_projekt.Entities;

namespace zpo_projekt.Alcohols
{
    internal class Wine : BaseAlcohol
    {
        public Wine(Alcohol alcohol) : base(alcohol)
        {
        }

        public override int MaxPercentageAllowed()
        {
            return 18;
        }
    }
}

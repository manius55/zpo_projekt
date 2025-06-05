using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zpo_projekt.Entities;

namespace zpo_projekt.Alcohols
{
    internal class Wine : Alcohol
    {
        public Wine(AlcoholEntity alcohol) : base(alcohol)
        {
        }

        public override int MaxPercentageAllowed()
        {
            return 18;
        }

        public override bool ZeroAlcoholPercentageAllowed()
        {
            return true;
        }
    }
}

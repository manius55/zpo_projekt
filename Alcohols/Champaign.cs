using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zpo_projekt.Entities;

namespace zpo_projekt.Alcohols
{
    internal class Champaign: Alcohol
    {
        public Champaign(AlcoholEntity alcohol) : base(alcohol)
        {
        }

        public override int MaxPercentageAllowed()
        {
            return 16;
        }

        public override bool ZeroAlcoholPercentageAllowed()
        {
            return true;
        }
    }
}

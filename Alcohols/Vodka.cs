using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zpo_projekt.Entities;

namespace zpo_projekt.Alcohols
{
    internal class Vodka : BaseAlcohol
    {
        public Vodka(Alcohol alcohol) : base(alcohol)
        {
        }

        public override int MaxPercentageAllowed()
        {
            return 45;
        }
    }
}

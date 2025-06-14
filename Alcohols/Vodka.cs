﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zpo_projekt.Entities;

namespace zpo_projekt.Alcohols
{
    internal class Vodka : Alcohol
    {
        public Vodka(AlcoholEntity alcohol) : base(alcohol)
        {
        }

        public override int MaxPercentageAllowed()
        {
            return 45;
        }

        public override int MinPercentageAllowed()
        {
            return 20;
        }
    }
}

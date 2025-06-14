using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zpo_projekt.Alcohols;
using zpo_projekt.Entities;
using zpo_projekt.Exceptions;
using zpo_projekt.Interfaces;

namespace zpo_projekt
{
    internal class AlcoholFromEntityMaker: IMaker<AlcoholEntity, Alcohol>
    {
        public Alcohol make(AlcoholEntity alcoholEntity)
        {
            switch (alcoholEntity.Type)
            {
                case 1:
                    return new Beer(alcoholEntity);
                case 2:
                    return new Whiskey(alcoholEntity);
                case 3:
                    return new Vodka(alcoholEntity);
                case 4:
                    return new Wine(alcoholEntity);
                case 5:
                    return new Champaign(alcoholEntity);
                default:
                    throw new UnknownAlcoholTypeException();
            }
        }
    }
}

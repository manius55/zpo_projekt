using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using zpo_projekt.Alcohols;
using zpo_projekt.Entities;
using zpo_projekt.Exceptions;
using zpo_projekt.Interfaces;

namespace zpo_projekt
{
    internal class AlcoholsFromEntitiesMaker: IMaker
    {
        public static List<Alcohol> make(List<AlcoholEntity> entities)
        {
            List<Alcohol> alcohols = new List<Alcohol>();

            foreach (var entity in entities)
            {
                try
                {
                    Alcohol alcohol = AlcoholFromEntityMaker.make(entity);
                    alcohols.Add(alcohol);
                }
                catch (UnknownAlcoholTypeException)
                {
                    MessageBox.Show("Nieznany typ alkoholu, poproś administratora o obsłużenie typu alkoholu o numerze:" + entity.Type);
                }
            }

            return alcohols;
        }
    }
}

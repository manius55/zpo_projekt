using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zpo_projekt.Entities;
using zpo_projekt.Exceptions;

namespace zpo_projekt.Alcohols
{
    abstract internal class BaseAlcohol
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Percentage { get; set; }
        public string TypeName { get; set; }
        public Alcohol AlcoholEntity { get; set; }

        public BaseAlcohol(Alcohol alcohol)
        {
            this.AlcoholEntity = alcohol;
            this.Id = alcohol.Id;
            this.Name = alcohol.Name;
            this.Description = alcohol.Description;
            this.TypeName = getInitialTypeName(alcohol.Type);
        }

        private BaseAlcohol() { }

        abstract public int MaxPercentageAllowed();
        public string getInitialTypeName(int alcoholType)
        {
            switch (alcoholType)
            {
                case 1:
                    return "Piwo";
                case 2:
                    return "Whisky";
                case 3:
                    return "Wódka";
                case 4:
                    return "Wino";
                case 5:
                    return "Szampan";
                default:
                    throw new UnknownAlcoholTypeException();
            }
        }
    }
}

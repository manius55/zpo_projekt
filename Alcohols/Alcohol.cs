﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zpo_projekt.Entities;
using zpo_projekt.Exceptions;
using zpo_projekt.Interfaces;
using zpo_projekt.Repositories;

namespace zpo_projekt.Alcohols
{
    abstract public class Alcohol: IValidable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public double Percentage { get; set; }
        public string TypeName { get; set; }
        public int Type { get; set; }
        public AlcoholEntity AlcoholEntity { get; set; }
        public int Count { get; set; }

        public Alcohol(AlcoholEntity alcohol)
        {
            this.AlcoholEntity = alcohol;
            this.Id = alcohol.Id;
            this.Name = alcohol.Name;
            this.Description = alcohol.Description;
            this.Percentage = alcohol.Percentage;
            this.Type = alcohol.Type;
            this.TypeName = GetAlcoholTypeName.Get(alcohol.Type);
            this.Count = alcohol.Count;
        }

        public void ValidateOrThrow()
        {
            if (Percentage > MaxPercentageAllowed())
            {
                throw new AlcoholPercentageIsTooBigException();
            }

            if (Percentage < MinPercentageAllowed())
            {
                throw new AlcoholPercentageIsTooLowException();
            }

            if (Percentage == 0 && !ZeroAlcoholPercentageAllowed())
            {
                throw new ZeroAlcoholPercentageNotAllowedException();
            }
            AlcoholRepository alcoholRepository = new AlcoholRepository();
            int allProductsCount = alcoholRepository.CountAllAlcoholProducts();

            if (Count + allProductsCount > Config.GetInstance().MaxProductCount)
            {
                throw new MaxProducsFromConfigExceededException();
            }
        }

        public virtual int MaxPercentageAllowed()
        {
            return 90;
        }

        public virtual int MinPercentageAllowed()
        {
            return 0;
        }

        public virtual bool ZeroAlcoholPercentageAllowed()
        {
            return false;
        }
    }
}

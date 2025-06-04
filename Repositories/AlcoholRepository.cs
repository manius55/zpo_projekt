using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zpo_projekt.Alcohols;
using zpo_projekt.Entities;

namespace zpo_projekt.Repositories
{
    internal class AlcoholRepository: Repository<AlcoholEntity>
    {
        public AlcoholRepository() : base(new AlcoholsDbContext())
        {
        }

        public List<AlcoholEntity> getAllAlcoholsByType(AlcoholType type)
        {
            return base.getAll().Where(x => x.Type == (int)type).ToList();
        }
    }
}

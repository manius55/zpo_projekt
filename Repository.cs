using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zpo_projekt.Alcohols;

namespace zpo_projekt
{
    internal class Repository <T> where T: Alcohol
    {
        private AlcoholsDbContext alcoholsDbContext { get; set; }

        public Repository()
        {
            this.alcoholsDbContext = new AlcoholsDbContext();
        }

        public List<T> getAll()
        {
            return db
        }
    }
}

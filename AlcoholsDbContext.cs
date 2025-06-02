using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using zpo_projekt.Entities;

namespace zpo_projekt
{
    public class AlcoholsDbContext: DbContext
    {
        public DbSet<Alcohol> Alcohols { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=alcohols.db");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using zpo_projekt.Entities;
using zpo_projekt.Exceptions;

namespace zpo_projekt
{
    public class AlcoholsDbContext: DbContext
    {
        public DbSet<AlcoholEntity> Alcohols { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = Config.GetInstance().DatabasePath;

            optionsBuilder
                .UseSqlite($"Data Source={dbPath}")
                .LogTo(msg => Debug.WriteLine(msg), LogLevel.Information);
        }
    }
}

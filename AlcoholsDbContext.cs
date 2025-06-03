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

namespace zpo_projekt
{
    public class AlcoholsDbContext: DbContext
    {
        public DbSet<Alcohol> Alcohols { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            var projectDir = Directory.GetParent(baseDir).Parent.Parent.Parent.FullName;
            var dbPath = Path.Combine(projectDir, "alcohols.db");
            Debug.WriteLine(dbPath);

            optionsBuilder
                .UseSqlite($"Data Source={dbPath}")
                .LogTo(msg => Debug.WriteLine(msg), LogLevel.Information);
        }
    }
}

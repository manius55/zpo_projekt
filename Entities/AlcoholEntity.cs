using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zpo_projekt.Entities
{
    public class AlcoholEntity
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public double Percentage { get; set; }

        public int Type { get; set; }

        public string? Description { get; set; }

        public int Count { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zpo_projekt
{
    internal class AlcoholsTypesResource
    {
        public int Type { get; set; }
        public int Count { get; set; }
        public string TypeName { get; set; }

        public AlcoholsTypesResource(int type, int count, string typeName)
        {
            Type = type;
            Count = count;
            TypeName = typeName;
        }
    }
}

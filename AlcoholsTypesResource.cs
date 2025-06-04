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
        public int DifferentProductsCount { get; set; }
        public string TypeName { get; set; }
        public int ProductsCount { get; set; }

        public AlcoholsTypesResource(int type, int differentProductsCount, string typeName, int productCount)
        {
            Type = type;
            DifferentProductsCount = differentProductsCount;
            TypeName = typeName;
            ProductsCount = productCount;
        }
    }
}

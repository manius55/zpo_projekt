using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zpo_projekt.Exceptions;

namespace zpo_projekt
{
    public static class GetAlcoholTypeName
    {
        public static string Get(int alcoholType)
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

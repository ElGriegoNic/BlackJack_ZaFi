using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack_ZaFi.Utils
{
    public static class Conversiones
    {
        public static Boolean IsLetter(this String s, Int32 index)
        {
            return Char.IsLetter(s, index);
        }
    }
}

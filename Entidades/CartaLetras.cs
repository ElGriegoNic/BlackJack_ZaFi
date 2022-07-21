using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack_ZaFi.Entidades
{
    public class CartaLetras
    {
        private CartaLetras(string value) { Value = value; }

        public string Value { get; private set; }

        public static CartaLetras Ace { get { return new CartaLetras("A"); } }
        public static CartaLetras Dos  { get { return new CartaLetras("2"); } }
        public static CartaLetras Tres { get { return new CartaLetras("3"); } }
        public static CartaLetras Cuatro { get { return new CartaLetras("4"); } }
        public static CartaLetras Cinco { get { return new CartaLetras("5"); } }
        public static CartaLetras Seis { get { return new CartaLetras("6"); } }
        public static CartaLetras Siete { get { return new CartaLetras("7"); } }
        public static CartaLetras Ocho { get { return new CartaLetras("8"); } }
        public static CartaLetras Nueve { get { return new CartaLetras("9"); } }
        public static CartaLetras Diez { get { return new CartaLetras("10"); } }
        public static CartaLetras Jack { get { return new CartaLetras("J"); } }
        public static CartaLetras Reina { get { return new CartaLetras("Q"); } }
        public static CartaLetras Rey { get { return new CartaLetras("K"); } }

    }

}

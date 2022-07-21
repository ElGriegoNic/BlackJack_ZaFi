using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack_ZaFi.Entidades
{
    public class Palos
    {
        public enum PalosCartas : byte
        {
            Corazones,
            Diamantes,
            Treboles,
            Picas
        }
        public enum TiposCartas : byte
        {
            CardA = 1,
            Card02 = 2,
            Card03 = 3,
            Card04 = 4,
            Card05 = 5,
            Card06 = 6,
            Card07 = 7,
            Card08 = 8,
            Card09 = 9,
            Card10 = 10,
            CardJ = 10,
            CardQ = 10,
            CardK = 10
        }

        public PalosCartas Tipo { get; private set; }
        public char Simbolo { get; private set; }

        public Palos(PalosCartas tipo, char simbolo)
        {
            Tipo = tipo;
            Simbolo = simbolo;
        }
    }
}

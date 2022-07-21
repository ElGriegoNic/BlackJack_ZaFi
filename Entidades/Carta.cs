using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BlackJack_ZaFi.Entidades.Palos;

namespace BlackJack_ZaFi.Entidades
{
    public class Carta
    {
        public Palos Palo { get; set; }
        public TiposCartas Tipo { get; set; }
        public string Simbolo { get; set; }
        public int ValorPrincipal => ((int) Tipo);
        public int ValorSecundario { get; set; }
        public bool EsMultiple => ValorSecundario != 0;

        public Carta(Palos palo, TiposCartas tipo, String simbolo, int valorSecundario = 0)
        {
            Palo = palo;
            Tipo = tipo;
            Simbolo = simbolo;
            ValorSecundario = valorSecundario;
        }
    }



}

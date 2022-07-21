using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BlackJack_ZaFi.Entidades.Palos;

namespace BlackJack_ZaFi.Entidades
{
    public class Baraja 
    {
        private Random rnd = new Random();

        private List<Palos> _palos;
        public List<Palos> Palos
        {
            get
            {
                _palos = _palos ?? ObtenerPalos();
                return _palos;
            }
        }
        private List<Carta> _cartas;
        public List<Carta> Cartas
        {
            get
            {
                _cartas = _cartas ?? inicializarCartas(Palos);
                return _cartas;
            }
        }

        private List<Palos> ObtenerPalos() =>
            new List<Palos> {
                new Palos(PalosCartas.Corazones, '♡'),
                new Palos(PalosCartas.Diamantes, '♢'),
                new Palos(PalosCartas.Picas, '♠'),
                new Palos(PalosCartas.Treboles, '♣'),
            };

        private List<Carta> inicializarCartas(List<Palos> palos)
        {
            var cartas = new List<Carta>();

            palos.ForEach(palo =>
            {
                cartas.Add(new Carta(palo, TiposCartas.CardA,  "A", 11));
                cartas.Add(new Carta(palo, TiposCartas.Card02, "2"));
                cartas.Add(new Carta(palo, TiposCartas.Card03, "3"));
                cartas.Add(new Carta(palo, TiposCartas.Card04, "4"));
                cartas.Add(new Carta(palo, TiposCartas.Card05, "5"));
                cartas.Add(new Carta(palo, TiposCartas.Card06, "6"));
                cartas.Add(new Carta(palo, TiposCartas.Card07, "7"));
                cartas.Add(new Carta(palo, TiposCartas.Card08, "8"));
                cartas.Add(new Carta(palo, TiposCartas.Card09, "9"));
                cartas.Add(new Carta(palo, TiposCartas.Card10, "10"));
                cartas.Add(new Carta(palo, TiposCartas.CardJ, "J"));
                cartas.Add(new Carta(palo, TiposCartas.CardQ, "Q"));
                cartas.Add(new Carta(palo, TiposCartas.CardK, "K"));
            });

            return cartas;
        }



    }
}

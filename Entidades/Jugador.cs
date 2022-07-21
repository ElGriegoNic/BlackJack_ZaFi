using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack_ZaFi.Entidades
{
    public class Jugador
    {
        public string NombreJugador { get; private set; }
        //public bool EsSeparable { get; set; }
        public bool EsPrimerTurno { get; private set; }
        public Shoe Shoe { get; private set; }

        public List<ManoJugador> manosJugador = new List<ManoJugador>();

        public Jugador(string nombreJugador, Carta primeraCarta, Carta segundaCarta, Shoe shoe, bool esPrimerTurno = true)
        {
            EsPrimerTurno=esPrimerTurno;
            Shoe=shoe;
            manosJugador.Add(new ManoJugador(primeraCarta,segundaCarta,this));
            NombreJugador = nombreJugador;
        }

        public void Separar(ManoJugador manoDividir)
        {
            //Separar o Dividir en 2 manos al tener 2 cartas iguales
            var card = manoDividir.Cartas.ElementAt(0);
            manoDividir.Cartas.RemoveAt(0);
            manoDividir.Cartas.Add(Shoe.SiguienteCarta());
            //manoDividir.EsSeparable = manoDividir.Cartas.First().ValorPrincipal.Equals(manoDividir.Cartas.Last().ValorPrincipal);

            ManoJugador mn = new ManoJugador(card, Shoe.SiguienteCarta(),this);
            manosJugador.Add(mn);
        }

        public void Pedir(ManoJugador mano)
        {

        }

        public void Ganar(ManoJugador mano)
        {

        }

        public void Perder(ManoJugador mano)
        {

        }

        public void Empatar(ManoJugador mano)
        {

        }
    }
}

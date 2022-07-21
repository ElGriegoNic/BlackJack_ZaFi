using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack_ZaFi.Entidades
{
    public class Juego
    {
        public int NumeroJugadores;
        public static readonly int DealerDetenerse = 17;
        public Dealer Dealer { get; private set; }
        public List<Jugador> Jugadores { get; private set; } = new List<Jugador>();

        public Juego(int numeroJugadores = 3)
        {
            NumeroJugadores = numeroJugadores;
        }

        public void IniciarJuego()
        {
            Shoe shoe = new Shoe();
            Dealer = new Dealer(shoe);

            //Dealer ordena la Baraja aleatoriamente
            Dealer.Ordenar(shoe);

            //Crear los jugadores y asignar Primer turno
            for (var i = 1; i <= NumeroJugadores; i++)
            {
                //Inicialmente se reparten 2 cartas al jugador
                Jugador j = new Jugador("Jugador"+i, shoe.SiguienteCarta(), shoe.SiguienteCarta(), shoe);
                Jugadores.Add(j);
            }

            //Se genera y muestra una carta del Dealer
            Dealer.Mano.CartasDealer.Add(shoe.SiguienteCarta());
            

            //Interacciones de Jugadores
            Interacciones.PreguntarJugador(Jugadores,Dealer);

            //Turno del Dealer
            Dealer.IniciarJuego();

            //Imprimir Resultados
            Interacciones.ImprimirResultados(Jugadores,Dealer);

            Console.WriteLine();
        }


    }
}

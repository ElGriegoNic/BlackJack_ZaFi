using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack_ZaFi.Entidades
{
    public class Interacciones
    {

        public static void ImprimirResultados(List<Jugador> jugadores, Dealer dealer)
        {
            Console.WriteLine("--------------");
            Console.WriteLine("--------------");
            Console.WriteLine("JUGADORES");

            foreach (var jugador in jugadores)
            {
                Console.WriteLine("JUGADOR: " + jugador.NombreJugador);

                foreach (ManoJugador mn in jugador.manosJugador)
                {
                    Console.WriteLine("MANO ID: " + mn.Id);
                    Console.WriteLine("Valor Mano: " + mn.ValorMano);
                }
            }
            Console.WriteLine("-------------");
            Console.WriteLine("RESULTADOS DEALER");
            Console.WriteLine("Valor de Mano " + dealer.Mano.ValorMano);
            Console.ReadLine();
        }

        //public static void ImprimirManoDealer(ManoDealer mn)
        //{
        //    var cartaObtenida = mn.CartasDealer.Last();
        //    Console.WriteLine("La carta obtenida es: " + cartaObtenida.Simbolo + cartaObtenida.Palo.Simbolo);
        //    Console.WriteLine(String.Format("El valor de la Mano del Dealer es : {0}", mn.ValorMano));
        //}

        public static void ImprimirManoDealer(ManoDealer mn)
        {
            Console.WriteLine("JUGADOR DEALER");
            foreach (var carta in mn.CartasDealer)
                Console.WriteLine("Carta " + carta.Simbolo + carta.Palo.Simbolo);

            Console.WriteLine("Valor Mano: " + mn.ValorMano);
            Console.WriteLine("-----------------");
        }

        public static void ImprimirManoJugador(ManoJugador mn, Dealer dealer)
        {
            Console.WriteLine("JUGADOR : " + mn.Jugador.NombreJugador);
            Console.WriteLine("MANO ID: " + mn.Id);

            var cartaDealer = dealer.Mano.CartasDealer.FirstOrDefault();
            Console.WriteLine("Carta del Dealer: " + cartaDealer.Simbolo + cartaDealer.Palo.Simbolo);

            foreach (var carta in mn.Cartas)
                Console.WriteLine("Carta " + carta.Simbolo + carta.Palo.Simbolo);

            Console.WriteLine("Valor Mano: " + mn.ValorMano);
            Console.WriteLine("-----------------");
        }


        public static void PreguntarJugador(List<Jugador> jugadores, Dealer dealer)
        {
            foreach (var jugador in jugadores)
            {
                bool restart = false;
                do
                {
                    restart = false;
                    foreach (ManoJugador mn in jugador.manosJugador.Where(a => a.Activo))
                    {
                        if (mn.EsSeparable)
                        {
                            char resp;
                            do
                            {
                                Console.WriteLine("JUGADOR : " + mn.Jugador.NombreJugador);
                                Console.WriteLine("Mano ID: " + mn.Id);
                                foreach (var carta in mn.Cartas)
                                    Console.WriteLine("Carta " + carta.Simbolo + carta.Palo.Simbolo);
                                Console.WriteLine("Esta mano contiene 2 cartas con el mismo valor. Desea separar esta mano? S/N");
                                resp = char.Parse(Console.ReadLine());

                                if (resp == 'S' || resp == 's')
                                {
                                    jugador.Separar(mn);
                                    restart = true;
                                    break;
                                }

                            } while (resp != 'S' || resp != 's' || resp != 'N' || resp != 'n');
                        }

                        if (restart)
                            break;

                        InteraccionJugador(mn, dealer);
                        mn.Activo = false;
                    }

                } while (restart);


            }

        }

        public static void InteraccionJugador(ManoJugador manoJugador, Dealer dealer)
        {
            do
            {

                Acciones accion = Acciones.Ninguna;
                do
                {
                    ImprimirManoJugador(manoJugador, dealer);
                    Console.WriteLine("Seleccione la accion del Jugador ");
                    Console.WriteLine("1. Pedir");
                    Console.WriteLine("2. Asegurar");
                    Console.WriteLine("3. Rendirse");
                    try
                    {
                        int opcion = int.Parse(Console.ReadLine());
                        accion = (Acciones)opcion;
                    }
                    catch (FormatException)
                    {
                        accion = Acciones.Ninguna;
                    }

                    switch (accion)
                    {
                        case Acciones.Pedir:
                            manoJugador.PedirCarta();
                            var cartaObtenida = manoJugador.Cartas.Last();
                            Console.WriteLine("La carta obtenida es: " + cartaObtenida.Simbolo + cartaObtenida.Palo.Simbolo);
                            Console.WriteLine(String.Format("El valor de la Mano {0} es : {1}", manoJugador.Id, manoJugador.ValorMano));
                            Console.WriteLine("RESULTADO : "+manoJugador.resultado.ToString());
                            Console.WriteLine("-----------------");
                            Console.WriteLine();

                            break;
                        case Acciones.Asegurar:
                            manoJugador.Asegurar();
                            break;
                        case Acciones.Rendirse:
                            //manoJugador.Rendirse();
                            break;
                    }

                } while (accion.Equals(Acciones.Ninguna));
            } while (manoJugador.Activo);

        }
    }

}


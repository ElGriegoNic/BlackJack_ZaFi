using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack_ZaFi.Entidades
{
    public enum Acciones 
    {
        Ninguna = 0,
        Pedir =1,
        Asegurar =2,
        Rendirse = 3
    }
    public enum Resultado : byte
    {
        Pendiente,
        Ganador,
        Perdedor,
        Empate,
        BlackJack
    }

    public class ManoJugador
    {
        private static int _counter = 0;
        public int Id { get; private set; }

        public List<Carta> Cartas = new List<Carta>();
        public bool EsPrimerTurno => Cartas.Count == 2;
        //public bool EsSeparable { get; set; } = false;
        public bool EsSeparable => EsPrimerTurno && Cartas.ElementAt(0).Tipo == Cartas.ElementAt(1).Tipo; //Si son 2 cartas y ambas son iguales
        public int ValorMano => SumatoriaCartas();
        public bool EsBlackJack => ValorMano == 21;
        public bool EsBust => ValorMano > 21;
        public Resultado resultado { get; private set; } = Resultado.Pendiente;
        public bool Activo { get; set; }
        public Jugador Jugador { get; private set; }


        //public ManoJugador(Jugador jugador)
        //{
        //    Jugador = jugador;
        //}

        //public ManoJugador(Jugador jugador, Carta primeraCarta)
        //{
        //    Jugador = jugador;
        //    Cartas.Add(primeraCarta);
        //}

        //public ManoJugador(bool activo = true)
        //{
        //    Activo = activo;
        //}
        public ManoJugador()
        {

        }
        public ManoJugador(Jugador jugador, bool activo = true)
        {
            Activo = activo;
            Jugador = jugador;
            Id = System.Threading.Interlocked.Increment(ref _counter);
        }

        public ManoJugador(Carta primeraCarta, Carta segundaCarta, Jugador jugador, bool activo = true)
        {
            Cartas.Add(primeraCarta);
            Cartas.Add(segundaCarta);
            //EsSeparable = primeraCarta.ValorPrincipal.Equals(segundaCarta.ValorPrincipal);
            Jugador = jugador;
            Activo = activo;
            Id = System.Threading.Interlocked.Increment(ref _counter);
        }

        private int SumatoriaCartas()
        {
            int sum = 0;
            int sumNoAce = 0;

            if (Cartas.Any(a => a.EsMultiple))
            {
                sumNoAce = Cartas.Where(b=>!b.EsMultiple).Sum(a=>a.ValorPrincipal);
                sum = MejorValor(sumNoAce, Cartas.Where(b => b.EsMultiple).Count());
            }
            else
                sum = Cartas.Sum(s => s.ValorPrincipal);

            return sum;
        }

        public int MejorValor(int noAcesValor, int numeroAces )
        {
            int sumMejorValor = 0;

            List<int> posiblesValores = new List<int>();
            for (int k = 0; k <= numeroAces; k++)
            {
                int value = k * 11 + (numeroAces - k) * 1;
                posiblesValores.Add(value);
            }
            posiblesValores = posiblesValores.Distinct().ToList();

            posiblesValores.ForEach(p =>
            {
                int valor = noAcesValor + p;

                if (valor <= 21)
                    if (valor >= sumMejorValor)
                        sumMejorValor = valor;               
            });
            return sumMejorValor;
        }

        //METODOS
        public void Ganar()
        {
            resultado = Resultado.Ganador;
            //Jugador.Ganar(this);
        }

        public void Perder()
        {
            resultado = Resultado.Perdedor;
            //Jugador.Perder(this);
        }

        public void Empatar()
        {
            resultado = Resultado.Empate;
            //Jugador.Empatar(this);
        }

        public void PedirCarta()
        {
            //Pedir una carta del Shoe
            var carta = Jugador.Shoe.SiguienteCarta();
            Cartas.Add(carta);
            Verificar();
        }
        public void Asegurar()
        {
            Activo = false;
        }
        public void Rendirse()
        {
            Activo = false;
            resultado = Resultado.Perdedor;
        }

        public void Verificar()
        {

            if (EsBlackJack)
            {
                Activo = false;
                resultado = Resultado.BlackJack;
            }
            if (EsBust)
            {
                Activo = false;
                resultado = Resultado.Perdedor;
            }
        }
    }
}

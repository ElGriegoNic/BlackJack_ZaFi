using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack_ZaFi.Entidades
{
    public class ManoDealer
    {
        public List<Carta> CartasDealer = new List<Carta>();
        public int ValorMano => SumatoriaCartas();

        public bool EsBlackJack => ValorMano == 21;
        public bool EsBust => ValorMano > 21;
        public Dealer Dealer { get; private set; }

        private int DealerDetenerse = 17;
        public Resultado resultado { get; private set; } = Resultado.Pendiente;
        public bool Activo { get; set; }

        public ManoDealer(Dealer dealer, bool activo = true)
        {
            Dealer = dealer;
            Activo = activo;
        }
        public void Jugar()
        {
            while (Activo)
            {
                PedirCarta();
                Interacciones.ImprimirManoDealer(this);
                Console.ReadLine();
            }
        }

        public void PedirCarta()
        {
            //Pedir una carta del Shoe
            var carta = Dealer.Shoe.SiguienteCarta();
            CartasDealer.Add(carta);
            Verificar();
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

            if (ValorMano.Equals(DealerDetenerse))
                Activo = false;
        }

        private int SumatoriaCartas()
        {
            int sum = 0;
            int sumNoAce = 0;

            if (CartasDealer.Any(a => a.EsMultiple))
            {
                sumNoAce = CartasDealer.Where(b => !b.EsMultiple).Sum(a => a.ValorPrincipal);
                sum = MejorValor(sumNoAce, CartasDealer.Where(b => b.EsMultiple).Count());
            }
            else
                sum = CartasDealer.Sum(s => s.ValorPrincipal);

            return sum;
        }

        public int MejorValor(int noAcesValor, int numeroAces)
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

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack_ZaFi.Entidades
{
    public class Dealer
    {

        private Random rnd = new Random();
        public ManoDealer Mano { get; private set; }
        public Shoe Shoe { get; private set; }

        public Dealer(Shoe shoe)
        {
            Mano = new ManoDealer(this);
            Shoe = shoe;
        }

        public void IniciarJuego()
        {
            Mano.Jugar();
        }

        public void Ordenar(Shoe shoe)
        {
            var cartas = shoe.Cartas;
            var cartasOrdenadas = new List<Carta>();
            while (cartas.Any())
            {
                var index = rnd.Next(cartas.Count);
                cartasOrdenadas.Add(cartas.ElementAt(index));
                cartas.RemoveAt(index);
            }
            shoe.Recargar(cartasOrdenadas);
        }

        public void Detenerse()
        {

        }
        public void Dividir()
        {

        }
    }
}

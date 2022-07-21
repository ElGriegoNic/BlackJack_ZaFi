using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack_ZaFi.Entidades
{
    public class Shoe 
    {
        private readonly int barajaCount = 52;
        private readonly int CantidadBarajas = 1;
        private int tCarta = 0;
        public int Remaining => Cartas.Count; 
        public void Recargar(List<Carta> cartas) => _cartas = cartas;

        private List<Carta> _cartas;
        public List<Carta> Cartas
        {
            get
            {
                _cartas = _cartas ?? ObtenerCartas();
                return _cartas;
            }
        }
        private List<Baraja> _barajas;
        private List<Baraja> barajas
        {
            get
            {
                _barajas = _barajas ?? ObtenerBarajas();
                return _barajas;
            }
        }

        public Carta SiguienteCarta()
        {
            try
            {
                var card = Cartas.ElementAt(tCarta);
                Cartas.RemoveAt(tCarta);
                return card;
            }
            catch
            {
                throw new Exception("Shoe Vacio.");
            }
        }

        private List<Baraja> ObtenerBarajas() =>
            Enumerable.Range(1, CantidadBarajas).Select(i => new Baraja()).ToList();

        private List<Carta> ObtenerCartas() => barajas.SelectMany(d => d.Cartas).OrderBy(a=>a.ValorPrincipal).ToList();
    }
}

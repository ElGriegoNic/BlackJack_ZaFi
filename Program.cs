using BlackJack_ZaFi.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack_ZaFi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //test();
            Juego juego = new Juego();
            juego.IniciarJuego();
            Console.WriteLine("this");
        }


    }
}

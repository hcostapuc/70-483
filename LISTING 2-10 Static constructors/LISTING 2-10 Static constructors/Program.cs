using System;

namespace LISTING_2_10_Static_constructors
{
    class Alien
    {
        public int X;
        public int Y;
        public int Lives;

        //CTO: o construtor estatico de uma classe é chamado apenas a primeira vez que a classe é instanciada, é boa pratica para carregar resources e inicializar valores que serão usados
        // pela instancia da classe.
        static Alien()
        {
            Console.WriteLine("My first Alien");
        }

        public Alien(int x, int y, int lives)
        {
            if (x < 0 || y < 0)
                throw new Exception("Invalid position");

            X = x;
            Y = y;
            Lives = lives;
        }

        public Alien(int x, int y) : this(x, y, 3)
        {
        }

        public override string ToString()
        {
            return string.Format("X: {0} Y: {1} Lives: {2}", X, Y, Lives);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Alien x = new Alien(100, 100);
            Console.WriteLine("x {0}", x);

            Alien y = new Alien(50, 50);
            Console.WriteLine("y {0}", y);

            Console.ReadKey();
        }
    }
}

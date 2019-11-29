using System;

namespace LISTING_1_61_logical_expressions
{
    class Program
    {
        static int mOne()
        {
            Console.WriteLine("mOne called");
            return 1;
        }

        static int mTwo()
        {
            Console.WriteLine("mTwo called");
            return 1;
        }

        static void Main(string[] args)
        {
            //CTO: a diferença do & e o && é que o & valida toda as condições do if e o && se a primeira ja for false ele descarta o resto da comparação no caso o mTwo
            //já a diferença do | para o || é que o | valida toda as condições do if e o || se a primeira ja for true ele descarta o resto da condição
            if (mOne() == 2 && mTwo() == 1)
                Console.WriteLine("Hello world");

            Console.ReadKey();
        }
    }
}

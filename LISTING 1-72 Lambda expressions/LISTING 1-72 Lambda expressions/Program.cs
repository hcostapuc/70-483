using System;

namespace LISTING_1_72_Lambda_expressions
{
    class Program
    {
        delegate int IntOperation(int a, int b);

        //add is a delegate, with the type of IntOperation
        static IntOperation add = (a, b) => a + b;

        delegate int op(int i);
        //square is a delegate, with the type of op
        static op square = i => i * i;

        static void Main(string[] args)
        {
            Console.WriteLine("Calling add {0}", add(2, 2));
            Console.WriteLine("Calling square {0}", square(2));

            //CTO: estrutura do lambda é variavel => funcao no qual a variavel é mapeada para a função
            add = (a, b) =>
            {
                Console.WriteLine("Add called");
                return a + b;
            };

            add(2, 2);

            Console.ReadKey();
        }
    }
}

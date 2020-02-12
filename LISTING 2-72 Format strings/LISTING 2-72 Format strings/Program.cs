using System;

namespace LISTING_2_72_Format_strings
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 99;
            double pi = 3.141592654;

            //CTO: o primeiro numero é o place holder
            //o segundo numero é a quantidade de caracteres que o item ocupara (se negativo ele alinha a esquerda e justificado)
            // depois do ":" vem o real formato, se é "D" formata decimal se "X" hexadecimal e "N" é float point number
            Console.WriteLine(" {0,-10:D}{0, -10:X}{1,5:N2}", i, pi);

            Console.ReadKey();
        }
    }
}

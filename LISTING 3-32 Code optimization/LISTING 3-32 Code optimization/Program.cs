using System;

namespace LISTING_3_32_Code_optimization
{
    class Program
    {
        static void Main(string[] args)
        {
            //CTO: se gerarmos o assemblye em modo RELEASE, todas as variaveis não utilizadas e comentarios
            //são excluidos do assemblie, ja em modo DEBUG, não.
            //Os breakpoints também são gravados no assemblye em modo DEBUG como "nop" (no operation) já no release não
            int i = 99;
            int j = 100;
            Console.WriteLine("The value in j is {0} ", j);
        }
    }
}

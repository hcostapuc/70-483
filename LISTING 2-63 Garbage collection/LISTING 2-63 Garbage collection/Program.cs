namespace LISTING_2_63_Garbage_collection
{
    class Person
    {
        long[] personArray = new long[1000000];
    }

    class Program
    {
        static void Main(string[] args)
        {


            //CTO: o garbage collector é chamado quando a quantidade de memória disponível para novos objetos fica abaixo de um limite
            //no grafico do process memory é mostrado o tamanho da area do "heap"

            /*
              The stack automatically grows and contracts as programs run.
              Upon entry to a new block the .NET runtime will allocate space on the stack for values that are declared local to that block. 
              When the program leaves the block the .NET runtime will automatically contract the stack space, which removes the memory allocated for those variables:
              The following block will not make any work for the garbage collector as the value 99 will be
              stored in the local stack frame. 

                {
                 int i=99;
                }
             */
            //CTO: O Garbage collector possui 3 fases:
            /*
                "Mark": marca todos os objetos que estão em uso no programa com uma flag e fica procurando todas as variaveis em uso e todas as referencias dessas variaveis
                        para setar a flag caso esteja em uso.

                "Compact": remove todos os objetos que não possui a flag.

                "Compaction":  The objects still in use must be moved down memory so that the available space on the stack is in one large
                               block, rather than a large number of holes where unused objects have been removed. 
             */

            //CTO: todas as threads são suspensas quando o GC ta rodando, ou seja o programa nao ira responder a inputs enquanto o GC estiver rodando.

            //O GC é recomendado chamar manualmente  if there are points in your application when you know a large number of objects have been released. 
            //mesmo assim só o chame quando você tiver um problema.
            for ( long i=0;i<100000000000;i++)
            {
                Person p = new Person();
                System.Threading.Thread.Sleep(3);
            }
        }
    }
}

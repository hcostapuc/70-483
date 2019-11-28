using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTING_1_43_Using_locking
{
    class Program
    {
        static long sharedTotal;

        // make an array that holds the values 0 to 5000000
        static int[] items = Enumerable.Range(0, 500001).ToArray();

        static object sharedTotalLock = new object();

        static void addRangeOfValues(int start, int end)
        {
            while (start < end)
            {
                //CTO: Diferente do exemplo 1-42 (operação nao atomic) o exemplo 1-43 (operação atomic) mostra o resultado correto utilizando locking
                //no qual somente uma task podera estar dentro do lock acessando a variavel sharedTotal, enquanto as outras que desejam o mesmo devem esperar a operação locking acabar
                //quando a mesma acaba é liberado para outra o acesso ao bloco locking.
                
                //CTO: há um problema nessa implementação que é a sincronicidade que gerará na fila de espera para utilizarem o bloco de codigo locking, assim fazendo com que a aplicação
                //demore para ser executada pois toda thread terá que esperar sua vez para acessar o bloco de codigo locking.
                //a solução para esse problema esta no exemplo 1-44

                //CTO: locks devem ser rápidos, pois a task que esta utilizando o bloco bloqueia todas as outras, é como se fosse um banheiro
                //enquanto você estiver utilizando, tera uma fila que também quer utiliza-lo, o proximo da fila so irá usar quando o que estiver no banheiro liberar.

                //CTO: Jamais utilizar IO dentro de um locking, ou whiles.
                lock (sharedTotalLock)
                {
                    sharedTotal = sharedTotal + items[start];
                }
                start++;
            }
        }

        static void Main(string[] args)
        {
            List<Task> tasks = new List<Task>();

            int rangeSize = 1000;
            int rangeStart = 0;

            while (rangeStart < items.Length)
            {
                int rangeEnd = rangeStart + rangeSize;

                if (rangeEnd > items.Length)
                    rangeEnd = items.Length;

                // create local copies of the parameters
                int rs = rangeStart;
                int re = rangeEnd;

                tasks.Add(Task.Run(() => addRangeOfValues(rs, re)));
                rangeStart = rangeEnd;
            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine("The total is: {0}", sharedTotal);
            Console.ReadKey();
        }
    }
}

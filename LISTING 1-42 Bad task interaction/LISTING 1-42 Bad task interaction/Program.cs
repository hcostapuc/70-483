using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LISTING_1_42_Bad_task_interaction
{

    class Program
    {
        //CTO: esse exemplo deveria retornar o mesmo resultado do listining 1-41, nao retorna pois o 1 é sincrono e esse assincrono
        //O real motivo esta na ma utilização da assincronicidade, se pegarmos um cenario do exemplo o mesmo acontece da seguinte forma:
        // A task 1 busca o valor sharedTotal na CPU e adiciona o valor, mas a mesma CPU é responsavel por escrever o resultado na memoria mas o SO para a task 1 e vai pra 2
        // A task 2 tambem quer alterar o valor do sharedTotal, entao ela busca o valor do sharedTotal e entao escreve o resultado dela na memória, agora o SO retorna o controle para a task 1
        // entao a task 1 escreve o valor que ela iria retornar pra memoria, assim sobreescrevendo/perdendo o valor do retorno da task 2
        // Esse problema se chama "Called a race condition" e pode ser corrigido com os "Concurrent Collections" ou locking
        static long sharedTotal;

        // make an array that holds the values 0 to 5000000
        static int[] items = Enumerable.Range(0, 500001).ToArray();

        static void addRangeOfValues(int start, int end)
        {
            while (start < end)
            {
                sharedTotal = sharedTotal + items[start];
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

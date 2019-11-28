using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LISTING_1_48_interlock_total
{
    class Program
    {
        //CTO: uma variavel com o keyword volatile significa que a mesma nao sera feito cach da variavel no processador
        //assim sempre recuperando da copia em memoria
        static long sharedTotal;

        // make an array that holds the values 0 to 5000000
        static int[] items = Enumerable.Range(0, 500001).ToArray();

        static void addRangeOfValues(int start, int end)
        {
            long subTotal = 0;

            while (start < end)
            {
                subTotal = subTotal + items[start];
                start++;
            }
            //CTO: a classe interlocked é como se fosse uma abstração do lock, a mesma com uma unica linha permite acessar a variavel de modo atomic.
            //nela podemos adicionar decrementar exchange (troca uma variavel por outra)
            Interlocked.Add(ref sharedTotal, subTotal);
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

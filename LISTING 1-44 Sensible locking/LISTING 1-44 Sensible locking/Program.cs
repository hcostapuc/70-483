﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTING_1_44_Sensible_locking
{
    class Program
    {
        static long sharedTotal;

        // make an array that holds the values 0 to 5000000
        static int[] items = Enumerable.Range(0, 500001).ToArray();

        static object sharedTotalLock = new object();

        static void addRangeOfValues(int start, int end)
        {
            long subTotal = 0;
            //CTO: nesse exemplo daremos lock somente quando cada range de valor estiver preenchido seu subtotal, no exemplo anterior
            //estavamos dando lock para cada adição de valor, nesse implementamos o subtotal, o mesmo agi como um buffer, quando soma todos os valores do range
            //ele adiciona no total e encerra a task, assim dando muito menos locking do que o exemplo anterior 1-43
            while (start < end)
            {
                subTotal = subTotal + items[start];
                start++;
            }
            lock (sharedTotalLock)
            {
                sharedTotal = sharedTotal + subTotal;
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

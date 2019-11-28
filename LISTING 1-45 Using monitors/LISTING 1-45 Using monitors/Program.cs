﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LISTING_1_45_Using_monitors
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

            while (start < end)
            {
                subTotal = subTotal + items[start];
                start++;
            }
            //CTO: Monitor tem o mesmo objetivo que o lock, suas unicas duas diferenças são que:
            // 1 - caso sua operação atomic der throw, no lock a task é liberada automaticamente, no Monitor você necessita char o exit, em um exemplo pratico
            //utilizar try catch e no finally sempre colocar o Monitor.Exit para nao ficar nenhuma task travada.
            //2 - Com o monitor você consegue criar condição para saber se o objeto esta com lock ou não e assim criar um novo fluxo.

            //codigo original:
            Monitor.Enter(sharedTotalLock);
            sharedTotal = sharedTotal + subTotal;
            Monitor.Exit(sharedTotalLock);


            //codigo implementando o item 2
            if (Monitor.TryEnter(sharedTotalLock))
            {
                //code controlled by the lock
            }
            else
            {
                //do something else because the lock object is in use
            }

            //codigo implementando o item 1
            try
            {
                Monitor.Enter(sharedTotalLock);
                sharedTotal = sharedTotal + subTotal;
                //throw criado de proposito simulando um erro de sistema
                throw new Exception();
            }
            finally
            {
                Monitor.Exit(sharedTotalLock);
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

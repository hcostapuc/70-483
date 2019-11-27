﻿using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace LISTING_1_36_Block_ConcurrentStack
{
    class Program
    {
        static void Main(string[] args)
        {
            //CTO: utilizando o ConcurrentStack o mesmo adicionara com a regra "last in first out" do contrario por default
            //utiliza o blockingCollection utiliza o ConcurrentQueue que é o "First in first out". Ja o ConcurrentBag não possui ordenação alguma, é aleatório.
            
            // Blocking collection that can hold 5 items
            BlockingCollection<int> data = new BlockingCollection<int>(new ConcurrentStack<int>(), 5);

            Task.Run(() =>
            {
                // attempt to add 10 items to the collection - blocks after 5th
                for (int i = 0; i < 10; i++)
                {
                    data.Add(i);
                    Console.WriteLine("Data {0} added successfully.", i);
                }
                // indicate we have no more to add
                data.CompleteAdding();
            });

            Console.ReadKey();
            Console.WriteLine("Reading collection");

            Task.Run(() =>
            {
                while (!data.IsCompleted)
                {
                    try
                    {
                        int v = data.Take();
                        Console.WriteLine("Data {0} taken successfully.", v);
                    }
                    catch (InvalidOperationException) { }
                }
            });

            Console.ReadKey();
        }
    }
}

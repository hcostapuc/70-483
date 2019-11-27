using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace LISTING_1_35_Using_BlockingCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            //CTO: Blocking collection é usada quando você necessita que uma task retorne um valor e outra task consuma o mesmo
            //se chama blocking pois o mesmo bloqueia a ação do Take quando não há datos para serem recuperados
            // Blocking collection that can hold 5 items
            BlockingCollection<int> data = new BlockingCollection<int>(5);
            Task.Run(() =>
            {
                // attempt to add 10 items to the collection - blocks after 5th
                for(int i=0;i<10;i++)
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
                    //CTO: o try catch serve para tratar um possivel erro: Quando IsCompleted for false e 
                    //por um acaso a outra thread de add chamar o completeAdding o objeto data tentarar chamar o take
                    //com isso ira dar throw

                    //CTO: O BlockingCollection possui os metodos TryAdd e TryTake que pode ser substituidos pelos exemplos que foram escritos
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

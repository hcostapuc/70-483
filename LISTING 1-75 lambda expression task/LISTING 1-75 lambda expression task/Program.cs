using System;
using System.Threading;
using System.Threading.Tasks;

namespace LISTING_1_75_lambda_expression_task
{
    class Program
    {
        static void Main(string[] args)
        {
            //CTO: essa representacao de expressao lambda se chama "anonymous method" pois a mesma nao possue nome
            Task.Run( () =>
           {
               for (int i = 0; i < 5 ; i++)
               {
                   Console.WriteLine(i);
                   Thread.Sleep(500);
               }
           });

            Console.WriteLine("Task running..");
            Console.ReadKey();
        }
    }
}

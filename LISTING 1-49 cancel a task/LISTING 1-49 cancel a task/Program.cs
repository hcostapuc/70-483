using System;
using System.Threading;
using System.Threading.Tasks;

namespace LISTING_1_49_cancel_a_task
{
    class Program
    {
        static CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        //CTO: para cancelar uma task o objeto de cancelamento CancellationTokenSource deve ser visivel para a task chamadora e a task a ser chamada
        static void Clock()
        {
            while (!cancellationTokenSource.IsCancellationRequested)
            {
                Console.WriteLine("Tick");
                Thread.Sleep(500);
            }
        }

        static void Main(string[] args)
        {
            Task.Run(() => Clock());
            Console.WriteLine("Press any key to stop the clock");
            Console.ReadKey();
            cancellationTokenSource.Cancel();

            
            Console.WriteLine("Clock stopped");
            Console.ReadKey();
        }
    }
}

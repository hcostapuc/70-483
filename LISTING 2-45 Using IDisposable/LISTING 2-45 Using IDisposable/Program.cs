using System;

namespace LISTING_2_45_Using_IDisposable
{
    class CrucialConnection : IDisposable
    {
        /* CTO:
         The IDisposable interface provides a way that an object can indicate that it contains an
        explicit Dispose method that can be used to tidy up an object when an application has finished
        using it. A disposed object may exist in memory, but any attempts to use it will result in the
        ObjectDisposedException being thrown. 
         */
        public void Dispose()
        {
            Console.WriteLine("Dispose called");
        }

        public void ThrowException()
        {
            throw new Exception("Bang");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            //CTO: There are two ways to make sure that Dispose is called correctly; you can call the
            //method yourself in your application, or you can make use of the C# "using" construction.

            //CTO: quando o using acaba é chamado o dispose do objeto ao qual esta sendo usado
            using (CrucialConnection c = new CrucialConnection())
            {
                // do something with the crucial connection
            }

            Console.ReadKey();
        }
    }
}

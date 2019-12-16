using System;

namespace LISTING_2_41_Get_an_enumerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get an enumerator that can iterate through a string
            var stringEnumerator = "Hello world".GetEnumerator();

            while(stringEnumerator.MoveNext())
            {

                //CTO: Current - which is a reference to the currently selected item in the enumerator
                //O exemplo posterior aborda uma melhor implementação
                Console.Write(stringEnumerator.Current);
            }

            Console.ReadKey();
        }
    }
}

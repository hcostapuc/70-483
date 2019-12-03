using System;

namespace LISTING_1_83_Inner_exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                try
                {
                    Console.Write("Enter an integer: ");
                    string numberText = Console.ReadLine();
                    int result;
                    result = int.Parse(numberText);
                }//CTO: usando re-throw com inner exception
                catch (Exception ex)
                {
                    throw new Exception("Calculator failure", ex);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException.Message);
                Console.WriteLine(ex.InnerException.StackTrace);
            }

            Console.ReadKey();
        }
    }
}

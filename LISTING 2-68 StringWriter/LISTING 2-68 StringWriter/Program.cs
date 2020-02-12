using System;
using System.IO;

namespace LISTING_2_68_StringWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            //CTO:
            /*
             You have used the StringWriter class in a previous example; the program Listing 2-57
             CodeDOM object, which creates some C# from a CodeDOM object, and sends the C# code to a
             StringWriter instance so that it can be printed on the screen
             */

            StringWriter writer = new StringWriter();

            writer.WriteLine("Hello World");

            writer.Close();

            Console.Write(writer.ToString());

            Console.ReadKey();
        }
    }
}

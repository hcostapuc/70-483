using System;

namespace LISTING_2_21_Boxing_and_unboxing
{
    class Program
    {
        static void Main(string[] args)
        {


            // the value 99 is boxed into an object
            object o = 99;

            

            // the boxed object is unboxed back into an int | The process of converting from a reference type(reference o) into a value type(the integer oVal) is called unboxing. 
            int oVal = (int)o;

            /*
             Note that casting cannot be used to convert between different types, for example with an
             integer and string. In other words, the following statement will fail to compile:
                int i = (int)"99";

             Casting is also used when converting references to objects that may be part of class hierarchies or expose interfaces
             */

            //CTO:  The need to box and unbox values in a solution is a symptom of poor design
            Console.WriteLine(oVal);

            Console.ReadKey();
        }

    }
}

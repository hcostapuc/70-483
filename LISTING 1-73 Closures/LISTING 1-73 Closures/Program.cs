using System;

namespace LISTING_1_73_Closures
{
    class Program
    {
        delegate int GetValue();

        static GetValue getLocalInt;

        static void SetLocalInt()
        {
            // Local variable set to 99
            int localInt = 99;

            // Set delegate getLocalInt to a lambda function that
            // returns the value of localInt
            getLocalInt = () => localInt;
        }

        static void Main(string[] args)
        {
            SetLocalInt();
            GC.Collect();
            //CTO: na teoria o valor do localInt nesse ponto ja teria sido limpo. Lambda expressions can access variables in
            //the code around it, the compiler extend the lifetime of variables used in labda expressions, this extension of variables life
            //is called a "clousures"
            Console.WriteLine("Value of localInt {0}", getLocalInt());
            Console.ReadKey();
        }
    }
}

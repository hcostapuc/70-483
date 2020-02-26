using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTING_3_12_Using_Convert
{
    class Program
    {
        static void Main(string[] args)
        {
            /*CTO:
             Here are some items to keep in mind whenconsidering the three different ways of converting values:
                •	 int.Parse will throw an exception if the supplied argument is null or if a string does not
                contain text that represents a valid value.
                •	 int.TryParse will return false if the supplied argument is null or if a string does not
                contain text that represents a valid value.
                •	 Convert.ToInt32 will throw an exception if the supplied string argument does not
                contain text that represents a valid value. It will not, however, throw an exception if
                the supplied argument is null. It instead returns the default value for that type. If the
                supplied argument is null the ToInt32 method returns 0.
             */
            string stringValue = "99";

            int intValue = Convert.ToInt32(stringValue);
            Console.WriteLine("intValue: {0}", intValue);


           // intValue = int.Parse(null);
            bool b = int.TryParse(null, out intValue);
            intValue = Convert.ToInt32("boom");

            stringValue = "True";
            bool boolValue = Convert.ToBoolean(null);
            Console.WriteLine("boolValue: {0}", boolValue);

            Console.ReadKey();

        }
    }
}

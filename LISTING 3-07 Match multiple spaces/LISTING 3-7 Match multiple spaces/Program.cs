using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LISTING_3_7_Match_multiple_spaces
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "Rob    Mary David   Jenny  Chris   Imogen       Rodney";

            //O simbolo + representa diz que onde houver o caracter anterior, no caso o espaço, ele irar buscar,
            //ou seja pegara todos os espaços que houver na string
            string regularExpressionToMatch = " +";
            string patternToReplace = ",";

            string replaced = Regex.Replace(input, regularExpressionToMatch, patternToReplace);

            Console.WriteLine(replaced);
            Console.ReadKey();
        }
    }
}

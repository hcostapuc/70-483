using System;
using System.Collections.Generic;

namespace LISTING_4_60_Set_example
{
    class Program
    {
        static void Main(string[] args)
        {
            //CTO: o hash set é uma classe generia de lista muito util, para quando:
            // - a lista não pode conter itens repetidos, o hashset adiciona somente itens unicos, ignorando adição de itens duplicados como o exemplo do "Fast"
            //   do hasset t1Styles
            // - comparar uma lista com a outra para identificar se contem itens em comum de ambos
            // - diferenciar lista, uni-las e testa-las
            HashSet<string> t1Styles = new HashSet<string>();
            t1Styles.Add("Electronic");
            t1Styles.Add("Disco");
            t1Styles.Add("Fast");
            t1Styles.Add("Fast");

            HashSet<string> t2Styles = new HashSet<string>();
            t2Styles.Add("Orchestral");
            t2Styles.Add("Classical");
            t2Styles.Add("Fast");

            HashSet<string> search = new HashSet<string>();
            search.Add("Fast");
            search.Add("Disco");

            if (search.IsSubsetOf(t1Styles))
                Console.WriteLine("All search styles present in T1");

            if (search.IsSubsetOf(t2Styles))
                Console.WriteLine("All search styles present in T2");

            Console.ReadKey();
        }
    }
}

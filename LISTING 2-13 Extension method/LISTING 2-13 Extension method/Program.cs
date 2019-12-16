using System;

namespace ExtensionMethods
{
    public static class MyExtensions
    {
        //CTO: o parametro passado por parametro junto com o this, é o tipo no qual o extension irá ser usado.

        //Extension methods devem ser declarados em uma classe estatica

        //a palavra "this" no parametro ja diz que é um extension
        public static int LineCount(this String str)
        {
            return str.Split(new char[] { '\n' },
                             StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}

namespace LISTING_2_13_Extension_method
{
    using ExtensionMethods;

    class Program
    {
        static void Main(string[] args)
        {
            string text = @"A rocket explorer called Wright,
Once travelled much faster than light,
He set out one day,
In a relative way,
And returned on the previous night";
            Console.WriteLine(text.LineCount());
            Console.ReadKey();
        }
    }
}

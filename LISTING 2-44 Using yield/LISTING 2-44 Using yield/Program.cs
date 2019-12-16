using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTING_2_44_Using_yield
{
    class EnumeratorThing : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 1; i < 10; i++)
                //CTO: quando necessita retornar uma lista que sera interagida com um loop, ou seja o for, usa o yield, o mesmo precede o retorno do valor do item sendo iterado no caso a variavel "i"
                //ou seja não há necessidade de criar uma variavel local para armazenar a lista e logo retorna-la

                /*
                 The yield keyword does two things. It specifies the value to be returned for a given iteration, and it also returns control to the iterating method. You can express an iterator that returns
                 the values 1, 2, 3, as follows. 
                 */
                yield return i;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private int limit;

        public EnumeratorThing(int limit)
        {
            this.limit = limit;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            EnumeratorThing e = new EnumeratorThing(10);

            foreach (int i in e)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }
    }
}

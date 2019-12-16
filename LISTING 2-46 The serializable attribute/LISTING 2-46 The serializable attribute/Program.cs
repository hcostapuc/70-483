using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTING_2_46_The_serializable_attribute
{

    [Serializable]
    public class Person
    {
        public string Name;

        public int Age;

        //CTO: Metadata is “data about data.” como Age da classe Person é um metadata
        //CTO: A serializer takes the entire contents of a class and sends it into a stream
        [NonSerialized]
        // No need to save this
        private int screenPosition;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
            screenPosition = 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}

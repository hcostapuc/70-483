using System;

namespace LISTING_2_66_String_intern
{
    class Program
    {
        static void Main(string[] args)
        {
            //CTO: string trabalha por referencia e é imutável
            //CTO: quando criado duas referencias para a mesma string, igual a variavel s1 e s2, as mesmas apontam para o mesmo objeto isso se chama string interning (String interning only happens when the program is compiled, String interning doesn’t happen when a program is running)

            // Create hello at compile time
            string s1 = "hello";
            string s2 = "hello";

            if ((object)s1 == (object)s2)
                Console.WriteLine("s1 and s2 are the same object");

            // Create "hello" at runtime
            string h1 = "he";
            string h2 = "llo";
            string s3 = h1 + h2;

            //CTO: podemos forçar a string em runtime ser interned utilizando a seguinte função:
            //s3 = string.Intern(s3);

            if ((object)s1 != (object)s3)
                Console.WriteLine("s1 and s3 are differnent objects");

            // Intern s3
                
            if ((object)s1 == (object)s3)
                Console.WriteLine("s1 and s3 are the same object");

            Console.ReadKey();
        }
    }
}

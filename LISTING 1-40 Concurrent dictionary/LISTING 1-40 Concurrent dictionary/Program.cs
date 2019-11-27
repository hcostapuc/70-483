using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTING_1_40_Concurrent_dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcurrentDictionary<string, int> ages = new ConcurrentDictionary<string, int>();
            //CTO: o tryAdd do dictionary retorna falso quando o item ja existir
            if (ages.TryAdd("Rob", 21))
                Console.WriteLine("Rob added successfully.");
            Console.WriteLine("Rob's age: {0}", ages["Rob"]);
            //CTO: o tryupdate existe para que quando mais de uma thread tenta alterar a idade de 21 para 22, sem o tryupdate
            //os 2 metodos das duas threads iriam atualizar e a idade iria para 23 que no caso estaria errado, com o tryupdate um
            //unico metodo tera sucesso e executara a alteração.

            // Set Rob's age to 22 if it is 21
            if (ages.TryUpdate("Rob", 22, 21))
                Console.WriteLine("Age updated successfully");
            Console.WriteLine("Rob's new age: {0}", ages["Rob"]);
            //CTO: esse metodo simplismente verifica se existe o item, se sim ele da update se não ele adiciona
            // Increment Rob's age atomically using factory method
            Console.WriteLine("Rob's age updated to: {0}",
                ages.AddOrUpdate("Rob", 1, (name, age) => age = age + 1));
            Console.WriteLine("Rob's new age: {0}", ages["Rob"]);
            Console.ReadKey();
        }
    }
}

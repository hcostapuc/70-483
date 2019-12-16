using System;

namespace LISTING_2_6_Using_generic_types
{
    class Program
    {
        //CTO: where é o constraint, no qual deixa ser criado qualquer tipo que faça as condições na qual foi escrito, nesse cenario seria qualquer tipo que seja por referencia (class).
        //abaixo a tabela que representa outros constraints:
        /*
         Constraint Behavior
            where T : class The type T must be a reference type.
            where T : struct The type T must be a value type.
            where T : new() The type T must have a public, parameterless, constructor. Specify this
            constraint last if you are specifying a list of constraints
            where T : <base class> The type T must be of type base class or derive from base class.
            where T : <interface name> The type T must be or implement the specified interface. You can specify
            multiple interfaces.
            where T : unmanaged The type T must not be a reference type or contain any members which are
            reference types.
             */
        class MyStack<T> where T:class
        { 
            int stackTop = 0;
            T[] items = new T[100];

            public void Push(T item)
            {
                if (stackTop == items.Length)
                    throw new Exception("Stack full");
                items[stackTop] = item;
                stackTop++;
            }

            public T Pop()
            {
                if (stackTop == 0)
                    throw new Exception("Stack empty");
                stackTop--;
                return items[stackTop];
            }
        }

        static void Main(string[] args)
        {
            MyStack<string> nameStack = new MyStack<string>();
            nameStack.Push("Rob");
            nameStack.Push("Mary");
            Console.WriteLine(nameStack.Pop());
            Console.WriteLine(nameStack.Pop());
            Console.ReadKey();
        }
    }
}

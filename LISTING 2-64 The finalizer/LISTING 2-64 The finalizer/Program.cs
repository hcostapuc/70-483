﻿using System;

namespace LISTING_2_64_The_finalizer
{
    public class Person
    {
        long[] personArray = new long[1000000];


        //CTO: chamado quando o GC destruir o objeto. O mesmo nao é uma boa pratica pois ele analisa todos os objetos que tem finalizer colocando os em uma pilha e logo executa uma thread para eles e espera essa thread acabar
        //o é melhor é utilizar o IDisposable
        ~Person()
        {
            // This is where the person would be finalized
            Console.WriteLine("Finalizer called");

            // This will "bring the object back from the dead"
            // by creating a new refernce to the object from the 
            // program
            //Program.zombie = this;

            // This will break the garbage collection process
            // as it slows it down so that it can't complete
            // faster than objects are being created
            //System.Threading.Thread.Sleep(100);
        }
    }

    public class Program
    {
        public static Person zombie;

        static void Main(string[] args)
        {
            for (long i = 0; i < 100000000000; i++)
            {
                Person p = new Person();
                System.Threading.Thread.Sleep(3);
            }

            Console.ReadKey();
        }
    }
}

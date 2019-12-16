﻿using System;

namespace LISTING_2_49_Creating_an_attribute_class
{
    class ProgrammerAttribute : Attribute
    {
        private string programmerValue;

        public ProgrammerAttribute(string programmer)
        {
            programmerValue = programmer;
        }

        public string Programmer
        {
            get
            {
                return programmerValue;
            }
          }
    }

    [ProgrammerAttribute(programmer:"Fred")]
    class Person
    {
        //CTO: o atributo pode ser setado em variavel, metodo, classe e propriedades, qualquer tipo de objeto
        // We can add attributes to any element
        [ProgrammerAttribute(programmer: "Fred")]
        public string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}

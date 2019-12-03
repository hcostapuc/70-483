using System;

namespace LISTING_1_82_Conditional_clauses
{
    class CalcException : Exception
    {
        public enum CalcErrorCodes
        {
            InvalidNumberText,
            DivideByZero
        }

        public CalcErrorCodes Error { get; set; }

        public CalcException(string message, CalcErrorCodes error) : base(message)
        {
            Error = error;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                throw new CalcException("Calc failed", CalcException.CalcErrorCodes.DivideByZero);
            }//CTO: Esse metodo de criação de exeption é melhor que fazer um re-throw, porque o .NET runtime
            //nao precisa rebuildar the exception object prior to re-throwing it
            catch (CalcException ce) when (ce.Error == CalcException.CalcErrorCodes.DivideByZero)
            {
                Console.WriteLine("Divide by zero error");
            }
            Console.ReadKey();
        }
    }
}

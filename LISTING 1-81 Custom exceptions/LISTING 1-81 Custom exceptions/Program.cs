using System;

namespace LISTING_1_81_Custom_exceptions
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
                throw new CalcException("Calc failed", CalcException.CalcErrorCodes.InvalidNumberText);
            }
            catch (CalcException ce) 
            {
                //CTO: re-throw dentro de catch é uma má pratica, pois você perde todas as informações do stacktrace substituindo pelo local do throw
                //e nao pelo local do erro exato, para solucionar basta inserir em um inner exception o original exception
                Console.WriteLine("Error: {0}", ce.Error);
            }
            Console.ReadKey();
        }
    }
}

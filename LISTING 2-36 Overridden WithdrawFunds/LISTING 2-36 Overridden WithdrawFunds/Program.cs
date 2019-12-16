using System;

namespace LISTING_2_36_Overridden_WithdrawFunds
{
    public interface IAccount
    {
        void PayInFunds(decimal amount);
        bool WithdrawFunds(decimal amount);
        decimal GetBalance();
    }

    public class BankAccount : IAccount
    {
        protected decimal _balance = 0;

        //CTO: The C# language does not allow the overriding of explicit implementations of interface methods. ou seja nao foi usado o WithdrawFunds da interface
        public virtual bool WithdrawFunds(decimal amount)
        {
            if (_balance < amount)
            {
                return false;
            }
            _balance = _balance - amount;
            return true;
        }

        void IAccount.PayInFunds(decimal amount)
        {
            _balance = _balance + amount;
        }

        decimal IAccount.GetBalance()
        {
            return _balance;
        }
    }
    /*
    CTO: The 'is' operator determines if the type of a given object is in a particular class hierarchy or
           implements a specified interface. You apply the is operator between a reference variable and a
           type or interface and the operator returns true if the reference can be made to refer to objects
           of that type.
           The code below prints out a message if the variable x refers to an object that implements
           the IAccount interface.

           if (x is IAccount)
            Console.WriteLine("this object can be used as an account");

           The 'as' operator takes a reference and a type and returns a reference of the given type, or
           null if the reference cannot be made to refer to the object.
           The code below creates an IAccount reference called y that either refers to x (if x implements the IAccount interface) or is null (if x does not implement the IAccount interface).

           IAccount y = x as IAccount;

           as se parefe com o cast mas a diferença dos dois é que se o cast der errado o programa da throw ja o 'as' caso de errado retorna nulo

        */

    public class BabyAccount : BankAccount, IAccount
    {
        public override bool WithdrawFunds(decimal amount)
        {
            if (amount > 10)
            {
                return false;
            }

            if (_balance < amount)
            {
                return false;
            }
            _balance = _balance - amount;
            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IAccount b = new BabyAccount();
            b.PayInFunds(50);
            if (b.WithdrawFunds(10))
                Console.WriteLine("Withdraw succeeded");
            else
                Console.WriteLine("Withdraw failed");

            Console.ReadKey();
        }
    }
}

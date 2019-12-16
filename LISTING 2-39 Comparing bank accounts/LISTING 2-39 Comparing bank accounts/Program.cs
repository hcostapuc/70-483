using System;
using System.Collections.Generic;

namespace LISTING_2_39_Comparing_bank_accounts
{
    public interface IAccount
    {
        void PayInFunds(decimal amount);
        bool WithdrawFunds(decimal amount);
        decimal GetBalance();
    }

    public class BankAccount : IAccount, IComparable
    {
        private decimal balance;

        public virtual bool WithdrawFunds(decimal amount)
        {
            if (balance < amount)
            {
                return false;
            }
            balance = balance - amount;
            return true;
        }

        void IAccount.PayInFunds(decimal amount)
        {
            balance = balance + amount;
        }

        decimal IAccount.GetBalance()
        {
            return balance;
        }
        /*
         CTO:  If the value returned is less than 0 it indicates that this
object should be placed before the one it is being compared with. If the value returned is zero,
it indicates that this object should be placed at the same position as the one it is being compared with and if the value returned is greater than 0 it means that this object should be placed
after the one it is being compared with.
             */
        public int CompareTo(object obj)
        {
            // if we are being compared with a null object we are definitely after it
            if (obj == null) return 1;
            
            //CTO: No exemplo posterior mostra a implementação do Icomparable tipado, ou seja nao necessitando do cast

            // Convert the object reference into an account reference
            IAccount account = obj as IAccount;

            // as generates null if the conversion fails
            if (account == null)
                throw new ArgumentException("Object is not an account");

            // use the balance value as the basis of the comparison
            return this.balance.CompareTo(account.GetBalance());
        }

        public BankAccount(decimal initialBalance)
        {
            balance = initialBalance;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create 20 accounts with random balances
            List<IAccount> accounts = new List<IAccount>();
            Random rand = new Random(1);
            for(int i=0; i<20; i++)
            {
                IAccount account = new BankAccount(rand.Next(0, 10000));
                accounts.Add(account);
            }

            //CTO: Sort é um metodo da collection List
            // Sort the accounts
            accounts.Sort();

            // Display the sorted accounts
            foreach(IAccount account in accounts)
            {
                Console.WriteLine(account.GetBalance());
            }

            Console.ReadKey();
        }
    }
}

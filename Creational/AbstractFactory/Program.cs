using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public interface ISavingAccount
    {
    }

    public interface ILoanAccount
    {
    }

    public class CITISavingAccount : ISavingAccount
    {
        public CITISavingAccount()
        {
            Console.WriteLine("This is CITI Saving Account.");
        }
    }

    public class CITILoanAccount : ILoanAccount
    {
        public CITILoanAccount()
        {
            Console.WriteLine("This is CITI Loan Account.");
        }
    }

    public class NationalSavingAccount : ISavingAccount
    {
        public NationalSavingAccount()
        {
            Console.WriteLine("This is National Saving Account.");
        }
    }

    public class NationalLoanAccount : ILoanAccount
    {
        public NationalLoanAccount()
        {
            Console.WriteLine("This is National Loan Account.");
        }
    }

    public interface ICreditUnionFactory
    {
        ILoanAccount CreateLoanAccount();
        ISavingAccount CreateSavingAccount();
    }

    public class CITICreditUnionFactory : ICreditUnionFactory
    {
        public ILoanAccount CreateLoanAccount()
        {
            return new CITILoanAccount();        }

        public ISavingAccount CreateSavingAccount()
        {
            return new CITISavingAccount();
        }
    }

    public class NationalCreditUnionFactory : ICreditUnionFactory
    {
        public ILoanAccount CreateLoanAccount()
        {
            return new NationalLoanAccount();
        }

        public ISavingAccount CreateSavingAccount()
        {
            return new NationalSavingAccount();
        }
    }

    public class CreditUnionFactoryProvider
    {
        public static ICreditUnionFactory GetCreditUnionFactroy(string accountNo)
        {
            if (accountNo.Contains("CITI"))
            {
                return new CITICreditUnionFactory();
            }
            else if (accountNo.Contains("NATIONAL"))
            {
                return new NationalCreditUnionFactory();
            }
            else
            {
                return null;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<string> accounts = new List<string>();
            accounts.Add("CITI - 100");
            accounts.Add("NATIONAL - 200");

            foreach (var account in accounts)
            {
                ICreditUnionFactory factory = CreditUnionFactoryProvider.GetCreditUnionFactroy(account);

                factory.CreateLoanAccount();
                factory.CreateSavingAccount();

            }


            Console.ReadLine();
        }
    }
}

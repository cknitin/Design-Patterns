using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public interface ISavingAccount
    {
        void Balance();
    }

    public class CITISavingAccount : ISavingAccount
    {
        public void Balance()
        {
            Console.WriteLine("Citi saving account has $200.");
        }
    }

    public class NationalSavingAccount : ISavingAccount
    {
        public void Balance()
        {
            Console.WriteLine("National saving account has $300.");
        }
    }

    public interface ICreditUnionFatory
    {
        ISavingAccount Create(string AccountNumber);
    }

    public class CreaditUnionFatcory : ICreditUnionFatory
    {
        public ISavingAccount Create(string AccountNumber)
        {
            if (AccountNumber.Contains("CITI"))
            {
                return new CITISavingAccount();
            }
            else if (AccountNumber.Contains("National"))
            {
                return new NationalSavingAccount();
            }
            else
                throw new InvalidOperationException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ISavingAccount savingAccount = null;
            CreaditUnionFatcory obj = new CreaditUnionFatcory();
            savingAccount = obj.Create("CITI-100");
            savingAccount.Balance();
            savingAccount = obj.Create("National-100");
            savingAccount.Balance();

            Console.ReadLine();
        }
    }
}

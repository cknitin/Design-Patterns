using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class Policy
    {
        private int policyNo { get; set; } = 12345;
        private string Insured { get; set; } = "Peter Parker";
        public string GetInsuredName() => Insured;
        //private static Policy _instance;

        // Not Thread safe
        //public static Policy Instance
        //{
        //    get
        //    {
        //        if (_instance == null)
        //        {
        //            _instance = new Policy();
        //        }
        //        return _instance;
        //    }
        //}

        // Thread Safe
        //private static readonly object _lock = new object();
        //public static Policy Instance
        //{
        //    get
        //    {
        //        lock (_lock)
        //        {
        //            if (_instance == null)
        //            {
        //                _instance = new Policy();
        //            }
        //            return _instance;
        //        }
        //    }
        //}

        // Even Better Approch
        private static readonly Policy _instance = new Policy();

        private static readonly object _lock = new object();
        public static Policy Instance
        {
            get
            {
                    return _instance;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Policy policy = new Policy();
            string insured = policy.GetInsuredName();
            Console.WriteLine(insured);
            Console.ReadLine();
        }
    }
}

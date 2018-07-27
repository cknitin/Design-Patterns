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

        #region Basic approch
        private static Policy _instance;
        public static Policy Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Policy();
                }
                return _instance;
            }
        }
        #endregion


        #region other approch

        #region Thread Safe
        // private static Policy _instance;
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
        #endregion

        #region Double check & Thread Safe 
        //private static Policy _instance;
        // private static readonly object _lock = new object();
        //public static Policy Instance
        //{

        //    get
        //    {
        //        if (_instance == null)
        //        {
        //            lock (_lock)
        //            {
        //                if (_instance == null)
        //                {
        //                    _instance = new Policy();
        //                }

        //            }
        //        }
        //        return _instance;
        //    }

        //}
        #endregion

        #region Even Better Approch
        //private static readonly Policy _instance = new Policy();
        //public static Policy Instance
        //{
        //    get
        //    {
        //        return _instance.Value;
        //    }
        //}
        #endregion

        #region Lazy Initialization 
        //private static readonly Lazy<Policy> _instance = new Lazy<Policy>(() => new Policy());

        //public static Policy Instance
        //{
        //    get
        //    {
        //        return _instance.Value;
        //    }
        //}

        #endregion

        #endregion

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

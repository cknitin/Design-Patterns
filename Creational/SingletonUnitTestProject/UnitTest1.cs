using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Singleton;

namespace SingletonUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreSame(Policy.Instance, Policy.Instance);

        }
    }
}

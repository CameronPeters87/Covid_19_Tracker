using System;
using System.Threading.Tasks;
using CovidTracker.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CovidTracker.UnitTests
{
    [TestClass]
    public class CovidTest
    {
        [TestMethod]
        public void FormatIntToString_EnterInteger_ReturnStringAsync()
        {
            int test_number = 200000;
            string convertnum = test_number.ToString("N0");
            var result = Helper.FormatIntToString(test_number);

            Assert.AreEqual(result, convertnum);
        }
    }
}

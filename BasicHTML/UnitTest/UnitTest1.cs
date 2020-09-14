using System;
using System.Security.AccessControl;
using EddyNewHome.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CommonGetIp()
        {
            string expectedIp = "192.168.0.230";

            string actualIp = Commons.GetIPAdress();
            Assert.AreEqual(expectedIp, actualIp);
        }
    }
}

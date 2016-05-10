using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MIMS.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
namespace MIMS.Utilities.Tests
{
    [TestClass()]
    public class EncryptUtilsTests
    {
        [TestMethod()]
        //测试MD5
        public void MD5EncryptTest()
        {
            string password = "admin";
            string expected = "21232f297a57a5a743894a0e4a801fc3";
            string encrypted = EncryptUtils.MD5Encrypt(password);
            Assert.AreEqual(expected, encrypted);
            Debug.WriteLine(encrypted);
        }
    }
}

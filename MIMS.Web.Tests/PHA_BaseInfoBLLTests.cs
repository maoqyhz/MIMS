using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MIMS.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
namespace MIMS.Business.Tests
{
    [TestClass()]
    public class PHA_BaseInfoBLLTests
    {
        [TestMethod()]
        public void GetPageListTest()
        {
            PHA_BaseInfoBLL bll = new PHA_BaseInfoBLL();
            IList actual = null;
            int total = default(int);
            int expectedTotal = 55;
            int expectedCount = 20;
            actual = bll.GetPageList("","PhaCode","asc",1,20,ref total);

            Assert.AreEqual(expectedTotal, total);
            Assert.AreEqual(expectedCount,actual.Count);

        }
    }
}

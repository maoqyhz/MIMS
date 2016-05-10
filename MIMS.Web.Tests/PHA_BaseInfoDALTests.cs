using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MIMS.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MIMS.Entity.Model;
using System.Diagnostics;
namespace MIMS.Service.Tests
{
    [TestClass()]
    public class PHA_BaseInfoDALTests
    {
        PHA_BaseInfoDAL dal = new PHA_BaseInfoDAL();
        [TestMethod()]
        public void GetEntityTest()
        {
            //arrange
          
            PHA_BaseInfo expected = new PHA_BaseInfo();
            PHA_BaseInfo actual;
            expected.PhaCode = "X000001";
            //act
            actual = dal.GetEntity("X000001");
            //assert
            Debug.WriteLine(actual);
            Assert.AreEqual(expected.PhaCode, actual.PhaCode);
        }
    }
}

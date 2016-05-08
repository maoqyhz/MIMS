using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MIMS.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace MIMS.Business.Tests
{
    [TestClass()]
    public class PSS_InWarehouseDetailBLLTests
    {

        [TestMethod()]
        public void GetListTest()
        {
            //arrange
            Hashtable ht = new Hashtable();
            ht.Add("PinyinCode", "ABC");
            //act
            PSS_InWarehouseDetailBLL bll = new PSS_InWarehouseDetailBLL();
            IList list = bll.GetList(ht);
            //assert
            Assert.Fail();
        }
    }
}

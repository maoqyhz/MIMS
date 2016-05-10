using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MIMS.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Diagnostics;
namespace MIMS.Business.Tests
{
    [TestClass()]
    public class PSS_ExWarehouseDetailBLLTests
    {
        [TestMethod()]
        public void SearchPhaListByDateTest()
        {
            PSS_ExWarehouseDetailBLL bll = new PSS_ExWarehouseDetailBLL();
            Hashtable ht = new Hashtable();
            int total = default(int);
            IList actual = bll.SearchPhaListByDate("2016-04-08", "2016-05-12", ht, "PhaCode", "asc", 1, 20, ref total);
            Debug.WriteLine(total);
        }
    }
}

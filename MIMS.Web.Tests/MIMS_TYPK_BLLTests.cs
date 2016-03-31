using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MIMS.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
namespace MIMS.Business.Tests
{
    [TestClass()]
    public class MIMS_TYPK_BLLTests
    {
        [TestMethod()]
        public void GetListTest()
        {
            MIMS_TYPK_BLL bll = new MIMS_TYPK_BLL();
            Debug.WriteLine(bll.GetList().Count);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MIMS.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
namespace MIMS.Web.Controllers.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void CheckUserLoginTest()
        {
            string username = "admin";
            string password = "admin";
            string actual = string.Empty;
            UserController controller = new UserController();
            ContentResult result = controller.CheckUserLogin(username, password) as ContentResult;
            actual = result.Content;
            Assert.AreEqual("2",actual);
            Debug.WriteLine(actual);

        }
    }
}

using MIMS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MIMS.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [RoleActionFilter]
        public ActionResult Index(string username, string password)
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MIMS.Web.Controllers
{
    public class PSS_PurchasePlanController : Controller
    {
        // GET: PSS_PurchasePlan
        [RoleActionFilter]
        public ActionResult PurchasePlan()
        {
            return View();
        }
    }
}
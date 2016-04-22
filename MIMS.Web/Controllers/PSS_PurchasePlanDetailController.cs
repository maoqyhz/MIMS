using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MIMS.IBusiness;
using MIMS.Business;
using MIMS.Entity;
using Newtonsoft.Json;
using MIMS.Entity.Model;

namespace MIMS.Web.Controllers
{
    public class PSS_PurchasePlanDetailController : Controller
    {
        IPSS_PurchasePlanBLL ipss_purchaseplanbll = new PSS_PurchasePlanBLL();
        // GET: PSS_PurchasePlanDetail
        public ActionResult PurchasePlanDetail(string PurchaseNo)
        {
            PSS_PurchasePlan plan = ipss_purchaseplanbll.GetEntity(PurchaseNo);
            return View(plan);
        }
    }
}
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
    public class PSS_PurchasePlanController : Controller
    {
        IPSS_PurchasePlanBLL ipss_purchaseplanbll = new PSS_PurchasePlanBLL();
        // GET: PSS_PurchasePlan
        [RoleActionFilter]
        public ActionResult PurchasePlan()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoadList()
        {
            return Json(ipss_purchaseplanbll.GetList());
        }

        [HttpPost]
        public ActionResult LoadForm(string id)
        {
            if (!string.IsNullOrEmpty(id))
                return Json(ipss_purchaseplanbll.GetEntity(id));
            else
                return null;
        }

        [HttpPost]
        public ActionResult AcceptClick(PSS_PurchasePlan obj)
        {
            int isOk = default(int);
            PSS_PurchasePlan temp = ipss_purchaseplanbll.GetEntity(obj.PurchaseNo);
            if (temp == null)
            {
                HttpCookie cookie = Request.Cookies["user"];
                obj.OperateNo = cookie.Values["Code"];
                obj.OperateDate = DateTime.Now.ToString("G");
                isOk = ipss_purchaseplanbll.Insert(obj);
            }
            else
                isOk = -1;
            return Content(isOk.ToString());
        }

        [HttpPost]
        public ActionResult Del(string id)
        {
            if (!string.IsNullOrEmpty(id))
                return Content(ipss_purchaseplanbll.Delete(new PSS_PurchasePlan { PurchaseNo = id }).ToString());
            else
                return null;
        }
    }
}
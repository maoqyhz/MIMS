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
using System.Collections;

namespace MIMS.Web.Controllers
{
    public class PSS_PurchasePlanDetailController : Controller
    {
        IPSS_PurchasePlanBLL ipss_purchaseplanbll = new PSS_PurchasePlanBLL();
        IPSS_PurchasePlanDetailBLL ipss_purchaseplandetailbll = new PSS_PurchasePlanDetailBLL();
        // GET: PSS_PurchasePlanDetail
        [RoleActionFilter]
        public ActionResult PurchasePlanDetail(string PurchaseNo)
        {
            PSS_PurchasePlan plan = ipss_purchaseplanbll.GetEntity(PurchaseNo);
            return View(plan);
        }
        [HttpPost]
        public ActionResult LoadList(string rows, string page, string sort, string order, string query)
        {
            int count = default(int);
            IList list = ipss_purchaseplandetailbll.GetPageList(query, sort, order, int.Parse(page), int.Parse(rows), ref count);
            return Content(JsonConvert.SerializeObject(new
            {
                total = count,
                rows = list
            }));
        }

        [HttpPost]
        public ActionResult LoadForm(string id)
        {
            if (!string.IsNullOrEmpty(id))
                return Json(ipss_purchaseplandetailbll.GetEntity(id));
            else
                return null;
        }

        [HttpPost]
        public ActionResult AcceptClick(PSS_PurchasePlanDetail obj)
        {
            int isOk = default(int);
            isOk = ipss_purchaseplandetailbll.Insert(obj);
            return Content(isOk.ToString());
        }

        [HttpPost]
        public ActionResult Del(string id)
        {
            if (!string.IsNullOrEmpty(id))
                return Content(ipss_purchaseplandetailbll.Delete(new PSS_PurchasePlanDetail { ID = int.Parse(id) }).ToString());
            else
                return null;
        }
    }
}
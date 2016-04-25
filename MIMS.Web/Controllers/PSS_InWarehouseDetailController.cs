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
    public class PSS_InWarehouseDetailController : Controller
    {
        IPSS_InWarehouseDetailBLL ipss_inwarehousedetailbll = new PSS_InWarehouseDetailBLL();
        IPSS_InWarehouseBLL ipss_inwarehousebll = new PSS_InWarehouseBLL();
        // GET: PSS_InWarehouseDetail
        [RoleActionFilter]
        public ActionResult InWarehouseDetail(string IWID)
        {
            PSS_InWarehouse obj = ipss_inwarehousebll.GetEntity(IWID);
            return View(obj);
        }

        [HttpPost]
        public ActionResult LoadList(string rows, string page, string sort, string order, string query)
        {
            int count = default(int);
            IList list = ipss_inwarehousedetailbll.GetPageList(query, sort, order, int.Parse(page), int.Parse(rows), ref count);
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
                return Json(ipss_inwarehousedetailbll.GetEntity(id));
            else
                return null;
        }

        [HttpPost]
        public ActionResult AcceptClick(PSS_InWarehouseDetail obj)
        {
            int isOk = default(int);
            isOk = ipss_inwarehousedetailbll.Insert(obj);
            return Content(isOk.ToString());
        }

        [HttpPost]
        public ActionResult Del(string id)
        {
            if (!string.IsNullOrEmpty(id))
                return Content(ipss_inwarehousedetailbll.Delete(new PSS_InWarehouseDetail { ID = int.Parse(id) }).ToString());
            else
                return null;
        }
    }
}
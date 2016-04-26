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
    public class PSS_ExWarehouseDetailController : Controller
    {

        IPSS_ExWarehouseDetailBLL ipss_exwarehousedetailbll = new PSS_ExWarehouseDetailBLL();
        IPSS_ExWarehouseBLL ipss_exwarehousebll = new PSS_ExWarehouseBLL();
        // GET: PSS_ExWarehouseDetail
        [RoleActionFilter]
        public ActionResult ExWarehouseDetail(string EWID)
        {
            PSS_ExWarehouse obj = ipss_exwarehousebll.GetEntity(EWID);
            return View(obj);
        }
        [HttpPost]
        public ActionResult LoadList(string rows, string page, string sort, string order, string query)
        {
            int count = default(int);
            IList list = ipss_exwarehousedetailbll.GetPageList(query, sort, order, int.Parse(page), int.Parse(rows), ref count);
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
                return Json(ipss_exwarehousedetailbll.GetEntity(id));
            else
                return null;
        }

        [HttpPost]
        public ActionResult AcceptClick(PSS_ExWarehouseDetail obj)
        {
            int isOk = default(int);
            isOk = ipss_exwarehousedetailbll.Insert(obj);
            return Content(isOk.ToString());
        }

        [HttpPost]
        public ActionResult Del(string id)
        {
            if (!string.IsNullOrEmpty(id))
                return Content(ipss_exwarehousedetailbll.Delete(new PSS_ExWarehouseDetail { ID = int.Parse(id) }).ToString());
            else
                return null;
        }
    }
}
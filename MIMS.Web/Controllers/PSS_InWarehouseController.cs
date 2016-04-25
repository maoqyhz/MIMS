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
    public class PSS_InWarehouseController : Controller
    {
        IPSS_InWarehouseBLL ipss_inwarehousebll = new PSS_InWarehouseBLL();
        IPSS_InWarehouseModeBLL ipss_inwarehousemodebll = new PSS_InWarehouseModeBLL();

        // GET: PSS_InWarehouse
        [RoleActionFilter]
        public ActionResult InWarehouse()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoadList()
        {
            return Json(ipss_inwarehousebll.GetList());
        }

        [HttpPost]
        public ActionResult LoadForm(string id)
        {
            if (!string.IsNullOrEmpty(id))
                return Json(ipss_inwarehousebll.GetEntity(id));
            else
                return null;
        }

        [HttpPost]
        public ActionResult AcceptClick(PSS_InWarehouse obj)
        {
            string key = Request["key"];
            int isOk = default(int);
            //key表示是否编辑的标识，1表示处于编辑状态 0表示增加状态
            if (key == "1")
            {
                if (obj.IsIW == 1)
                    obj.IWDate = DateTime.Now.ToString("G");
                isOk = ipss_inwarehousebll.Update(obj);
            }

            else
            {
                PSS_InWarehouse temp = ipss_inwarehousebll.GetEntity(obj.IWID.ToString());
                if (temp == null)
                {
                    HttpCookie cookie = Request.Cookies["user"];
                    obj.OperateNo = cookie.Values["Code"];
                    // to-do
                    isOk = ipss_inwarehousebll.Insert(obj);
                }
                else
                    isOk = -1;
            }
            return Content(isOk.ToString());
        }

        [HttpPost]
        public ActionResult Del(string id)
        {
            if (!string.IsNullOrEmpty(id))
                return Content(ipss_inwarehousebll.Delete(new PSS_InWarehouse { IWID = id }).ToString());
            else
                return null;
        }

        [HttpPost]
        public ActionResult LoadSelectInwarehourseMode()
        {
            return Json(ipss_inwarehousemodebll.GetList());
        }
    }
}
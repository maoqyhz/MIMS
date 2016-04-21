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
    public class PSS_ExWarehouseModeController : Controller
    {
        IPSS_ExWarehouseModeBLL ipss_exwarehousemodebll = new PSS_ExWarehouseModeBLL();
        // GET: PSS_ExWarehouseMode
        [RoleActionFilter]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoadList()
        {
            return Json(ipss_exwarehousemodebll.GetList());
        }

        [HttpPost]
        public ActionResult LoadForm(string id)
        {
            if (!string.IsNullOrEmpty(id))
                return Json(ipss_exwarehousemodebll.GetEntity(id));
            else
                return null;

        }

        [HttpPost]
        public ActionResult AcceptClick(PSS_ExWarehouseMode obj)
        {
            int isOk = default(int);
            //判断ID的值，ID为0表示ID为默认值，插入记录。非0的ID代表数据库已存在记录，则修改
            if (obj.ID != 0)
                isOk = ipss_exwarehousemodebll.Update(obj);
            else
                isOk = ipss_exwarehousemodebll.Insert(obj);
            return Content(isOk.ToString());
        }

        [HttpPost]
        public ActionResult Del(string id)
        {
            if (!string.IsNullOrEmpty(id))
                return Content(ipss_exwarehousemodebll.Delete(new PSS_ExWarehouseMode { ID = int.Parse(id) }).ToString());
            else
                return null;
        }
    }
}
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
    public class PSS_PurchaseCompanyController : Controller
    {
        IPSS_PurchaseCompanyBLL ipss_purchasecompanybll = new PSS_PurchaseCompanyBLL();
        [RoleActionFilter]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoadList()
        {
            return Json(ipss_purchasecompanybll.GetList());
        }

        [HttpPost]
        public ActionResult LoadForm(string id)
        {
            if (!string.IsNullOrEmpty(id))
                return Json(ipss_purchasecompanybll.GetEntity(id));
            else
                return null;

        }

        [HttpPost]
        public ActionResult AcceptClick(PSS_PurchaseCompany obj)
        {
            int isOk = default(int);
            //判断ID的值，ID为0表示ID为默认值，插入记录。非0的ID代表数据库已存在记录，则修改
            if (obj.CompanyID != 0)
                isOk = ipss_purchasecompanybll.Update(obj);
            else
                isOk = ipss_purchasecompanybll.Insert(obj);
            return Content(isOk.ToString());
        }

        [HttpPost]
        public ActionResult Del(string id)
        {
            if (!string.IsNullOrEmpty(id))
                return Content(ipss_purchasecompanybll.Delete(new PSS_PurchaseCompany { CompanyID = int.Parse(id) }).ToString());
            else
                return null;
        }
    }
}
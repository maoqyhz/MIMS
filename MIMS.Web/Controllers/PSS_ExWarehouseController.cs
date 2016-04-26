using System;
using System.Collections.Generic;
using System.Collections;
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
    public class PSS_ExWarehouseController : Controller
    {
        IPSS_ExWarehouseBLL ipss_exwarehousebll = new PSS_ExWarehouseBLL();
        IPSS_ExWarehouseDetailBLL ipss_exwarehousedetailbll = new PSS_ExWarehouseDetailBLL();
        IPSS_ExWarehouseModeBLL ipss_exwarehousemodebll = new PSS_ExWarehouseModeBLL();
        IPHA_AccountsBLL ipha_accountsbll = new PHA_AccountsBLL();
        // GET: PSS_ExWarehouse
        [RoleActionFilter]
        public ActionResult ExWarehouse()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoadList()
        {
            return Json(ipss_exwarehousebll.GetList());
        }

        [HttpPost]
        public ActionResult LoadForm(string id)
        {
            if (!string.IsNullOrEmpty(id))
                return Json(ipss_exwarehousebll.GetEntity(id));
            else
                return null;
        }

        [HttpPost]
        public ActionResult AcceptClick(PSS_ExWarehouse obj)
        {
            string key = Request["key"];
            int old_isew = default(int);
            int.TryParse(Request["old_isew"], out old_isew);
            int isOk = default(int);
            //key表示是否编辑的标识，1表示处于编辑状态 0表示增加状态
            if (key == "1")
            {
                //由于出库状态是不可逆的，所以由未出库到出库时，会减少库存事务
                if (obj.IsEW == 1 && old_isew == 0)
                {
                    //添加出库时间
                    obj.EWDate = DateTime.Now.ToString("G");
                    //通过记录获得对应的出库药品信息
                    Hashtable ht = new Hashtable();
                    ht.Add("EWID", obj.EWID);
                    IList list = ipss_exwarehousedetailbll.GetList(ht);
                    //减少对应的库存
                    foreach (PSS_ExWarehouseDetail item in list)
                    {
                        PHA_Accounts a = ipha_accountsbll.GetEntity(item.PhaCode, item.OrginID.ToString());
                        a.Stock -= item.ExWarehouseNum;
                        ipha_accountsbll.Update(a);
                    }
                }
                isOk = ipss_exwarehousebll.Update(obj);
            }
            else
            {
                PSS_ExWarehouse temp = ipss_exwarehousebll.GetEntity(obj.EWID.ToString());
                if (temp == null)
                {
                    HttpCookie cookie = Request.Cookies["user"];
                    obj.OperateNo = cookie.Values["Code"];
                    obj.OperateDate = DateTime.Now.ToString("G");
                    isOk = ipss_exwarehousebll.Insert(obj);
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
                return Content(ipss_exwarehousebll.Delete(new PSS_ExWarehouse { EWID = id }).ToString());
            else
                return null;
        }

        [HttpPost]
        public ActionResult LoadSelectExwarehourseMode()
        {
            return Json(ipss_exwarehousemodebll.GetList());
        }
    }
}
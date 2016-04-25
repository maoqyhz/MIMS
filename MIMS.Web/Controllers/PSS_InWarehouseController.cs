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
    public class PSS_InWarehouseController : Controller
    {
        IPSS_InWarehouseBLL ipss_inwarehousebll = new PSS_InWarehouseBLL();
        IPSS_InWarehouseDetailBLL ipss_inwarehousedetailbll = new PSS_InWarehouseDetailBLL();
        IPSS_InWarehouseModeBLL ipss_inwarehousemodebll = new PSS_InWarehouseModeBLL();
        IPHA_AccountsBLL ipha_accountsbll = new PHA_AccountsBLL();

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
            int old_isiw = int.Parse(Request["old_isiw"]);
            int isOk = default(int);
            //key表示是否编辑的标识，1表示处于编辑状态 0表示增加状态
            if (key == "1")
            {
                //由于入库状态是不可逆的，所以由未入库到入库时，会增加库存事务
                if (obj.IsIW == 1 && old_isiw == 0)
                {
                    //添加入库时间
                    obj.IWDate = DateTime.Now.ToString("G");
                    //通过记录获得对应的入库药品信息
                    Hashtable ht = new Hashtable();
                    ht.Add("IWID", obj.IWID);
                    IList list = ipss_inwarehousedetailbll.GetList(ht);
                    //添加对应的库存
                    foreach (PSS_InWarehouseDetail item in list)
                    {
                        PHA_Accounts a = ipha_accountsbll.GetEntity(item.PhaCode, item.OrginID.ToString());
                        a.Stock += item.InWarehouseCount;
                        ipha_accountsbll.Update(a);
                    }
                }
                isOk = ipss_inwarehousebll.Update(obj);
            }
            else
            {
                PSS_InWarehouse temp = ipss_inwarehousebll.GetEntity(obj.IWID.ToString());
                if (temp == null)
                {
                    HttpCookie cookie = Request.Cookies["user"];
                    obj.OperateNo = cookie.Values["Code"];
                    obj.OperateDate = DateTime.Now.ToString("G");
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
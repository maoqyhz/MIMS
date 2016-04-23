using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MIMS.IBusiness;
using MIMS.Business;
using MIMS.Entity;
using Newtonsoft.Json;
using System.Collections;
using MIMS.Entity.Model;

namespace MIMS.Web.Controllers
{
    public class DrugManagementController : Controller
    {
        IPHA_BaseInfoBLL ipha_baseinfobll = new PHA_BaseInfoBLL();
        IPHA_DosageFormBLL ipha_dosageformbll = new PHA_DosageFormBLL();
        IPHA_RepositoryBLL ipha_repositorybll = new PHA_RepositoryBLL();
        IPHA_StorageConditionBLL ipha_storageconditionbll = new PHA_StorageConditionBLL();
        IPHA_PhaAttrBLL ipha_phaattrbll = new PHA_PhaAttrBLL();
        IPHA_DispenseWayBLL ipha_dispensewaybll = new PHA_DispenseWayBLL();
        // GET: DrugManagement
        [RoleActionFilter]
        public ActionResult DrugInfo()
        {
            return View();
        }

        /// <summary>
        /// datagrid数据绑定
        /// </summary>
        /// <param name="rows">每行显示的条数</param>
        /// <param name="page">当前页</param>
        /// <param name="sort">排序字段</param>
        /// <param name="order">排序方式</param>
        /// <param name="query">条件</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult LoadList(string rows, string page, string sort, string order, string query)
        {
            int count = default(int);
            IList list = ipha_baseinfobll.GetPageList(query, sort, order, int.Parse(page), int.Parse(rows), ref count);
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
                return Json(ipha_baseinfobll.GetEntity(id));
            else
                return null;
        }

        [HttpPost]
        public ActionResult LoadSelectDosageForm()
        {
            return Json(ipha_dosageformbll.GetList());
        }

        [HttpPost]

        public ActionResult LoadSelectRepo()
        {
            return Json(ipha_repositorybll.GetList());
        }

        [HttpPost]
        public ActionResult LoadSelectPhaAttr()
        {
            return Json(ipha_phaattrbll.GetList());
        }

        [HttpPost]
        public ActionResult LoadSelecSc()
        {
            return Json(ipha_storageconditionbll.GetList());
        }

        [HttpPost]
        public ActionResult LoadSelecDispenseWay()
        {
            return Json(ipha_dispensewaybll.GetList());
        }

        [HttpPost]
        public ActionResult AcceptClick(PHA_BaseInfo obj)
        {
            string key = Request["key"];
            int isOk = default(int);
            //key表示是否编辑的标识，1表示处于编辑状态 0表示增加状态
            if (key == "1")

                isOk = ipha_baseinfobll.Update(obj);
            else
            {
                PHA_BaseInfo temp = ipha_baseinfobll.GetEntity(obj.PhaCode);
                if (temp == null)
                    isOk = ipha_baseinfobll.Insert(obj);
                else
                    isOk = -1;         //存在相同的记录，出错。
            }
            return Content(isOk.ToString());
        }

        [HttpPost]
        public ActionResult Del(string id)
        {
            if (!string.IsNullOrEmpty(id))
                return Content(ipha_baseinfobll.Delete(new PHA_BaseInfo { PhaCode = id }).ToString());
            else
                return null;
        }
    }
}
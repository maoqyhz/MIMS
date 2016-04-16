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
        public ActionResult LoadForm(string id)
        {
            if (!string.IsNullOrEmpty(id))
                return Json(ipha_baseinfobll.GetEntity(id));
            else
                return null;
        }

        public ActionResult LoadSelectDosageForm()
        {
            return Json(ipha_dosageformbll.GetList());
        }
        public ActionResult LoadSelectRepo()
        {
            return Json(ipha_repositorybll.GetList());
        }
        public ActionResult LoadSelectPhaAttr()
        {
            return Json(ipha_phaattrbll.GetList());
        }
        public ActionResult LoadSelecSc()
        {
            return Json(ipha_storageconditionbll.GetList());
        }

        public ActionResult LoadSelecDispenseWay()
        {
            return Json(ipha_dispensewaybll.GetList());
        }

        public ActionResult AcceptClick(PHA_BaseInfo obj)
        {
            int isOk = default(int);
            PHA_BaseInfo temp = ipha_baseinfobll.GetEntity(obj.PhaCode);
            if (temp == null)
                isOk = ipha_baseinfobll.Insert(obj);
            else
            isOk = ipha_baseinfobll.Update(obj);
            return Content(isOk.ToString());
        }
        public ActionResult Del(string id)
        {
            if (!string.IsNullOrEmpty(id))
                return Content(ipha_baseinfobll.Delete(new PHA_BaseInfo { PhaCode = id }).ToString());
            else
                return null;
        }
    }
}
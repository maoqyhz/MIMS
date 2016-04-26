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
    public class ExHistoryController : Controller
    {
        IPSS_ExWarehouseDetailBLL ipss_exwarehousedetailbll = new PSS_ExWarehouseDetailBLL();
        // GET: ExHistory
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchPhaListByDate(string rows, string page, string sort, string order, string pinyin)
        {
            string startDate = Request["startDate"];
            string endDate = Request["endDate"];
            Hashtable ht = new Hashtable();
            ht.Add("PinyinCode", pinyin);
            int count = default(int);
            IList list = ipss_exwarehousedetailbll.SearchPhaListByDate(startDate, endDate, ht, sort, order, int.Parse(page), int.Parse(rows), ref count);
            return Content(JsonConvert.SerializeObject(new
            {
                total = count,
                rows = list
            }));
        }

        public ActionResult SearchDetailByPha(string PhaCode)
        {
            Hashtable ht = new Hashtable();
            ht.Add("PhaCode", PhaCode);
            return Json(ipss_exwarehousedetailbll.GetList(ht));
        }

    }
}
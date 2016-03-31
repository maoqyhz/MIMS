using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MIMS.IBusiness;
using MIMS.Business;
using MIMS.Entity;
using Newtonsoft.Json;

namespace MIMS.Web.Controllers
{
    public class DrugManagementController : Controller
    {
        IMIMS_TYPK_BLL bll = new MIMS_TYPK_BLL();

        // GET: DrugManagement
        public ActionResult DrugInfo()
        {
            return View();
        }
        public ActionResult LoadList()
        {
            return Content(JsonConvert.SerializeObject(bll.GetList()));
        }

    }
}
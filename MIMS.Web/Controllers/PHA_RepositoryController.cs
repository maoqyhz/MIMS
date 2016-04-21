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
    public class PHA_RepositoryController : Controller
    {
        IPHA_RepositoryBLL ipha_repositorybll = new PHA_RepositoryBLL();
        [RoleActionFilter]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoadList()
        {
            return Json(ipha_repositorybll.GetList());
        }

        [HttpPost]
        public ActionResult LoadForm(string id)
        {
            if (!string.IsNullOrEmpty(id))
                return Json(ipha_repositorybll.GetEntity(id));
            else
                return null;

        }

        [HttpPost]
        public ActionResult AcceptClick(PHA_Repository obj)
        {
            int isOk = default(int);
            PHA_Repository temp = ipha_repositorybll.GetEntity(obj.RepoID);
            if (temp == null)
                isOk = ipha_repositorybll.Insert(obj);
            else
                isOk = ipha_repositorybll.Update(obj);
            return Content(isOk.ToString());
        }

        [HttpPost]

        public ActionResult Del(string id)
        {
            if (!string.IsNullOrEmpty(id))
                return Content(ipha_repositorybll.Delete(new PHA_Repository { RepoID = id }).ToString());
            else
                return null;
        }
    }
}
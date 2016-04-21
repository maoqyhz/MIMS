using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MIMS.Web.Controllers
{
    /// <summary>
    /// 登录过滤器
    /// </summary>
    public class RoleActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            HttpContextBase context = filterContext.HttpContext;
            HttpCookie cookie = context.Request.Cookies["user"];
            if (cookie == null)
                context.Response.Redirect("../User/login");
        }
    }
}
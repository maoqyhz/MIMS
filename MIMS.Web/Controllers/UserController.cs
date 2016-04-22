using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MIMS.Business;
using MIMS.IBusiness;
using MIMS.Entity.Model;
using MIMS.Utilities;

namespace MIMS.Web.Controllers
{
    public class UserController : Controller
    {
        ICOM_UserBLL icom_userbll = new COM_UserBLL();
        // GET: User
        public ActionResult Login()
        {
            HttpCookie cookie = Request.Cookies["user"];
            if (cookie != null)
                return RedirectToAction("Index", "Home");
            else
                return View();
        }

        [HttpPost]
        public ActionResult CheckUserLogin(string username, string password)
        {
            string msg = string.Empty;
            COM_User user;
            username = HttpUtility.UrlEncode(username.Trim());
            password = password.Trim();
            HttpCookie cookie = new HttpCookie("user");
            user = icom_userbll.GetEntity(username);
            if (user == null)
                msg = "1";
            else if (user.Password == EncryptUtils.MD5Encrypt(password))
            {
                msg = "2";
                cookie.Values.Add("Username", user.Username);
                cookie.Values.Add("Code", user.Code);
                cookie.Values.Add("Name", user.Name);
                cookie.Values.Add("Tel", user.Tel);
                cookie.Values.Add("Role", user.Role);
                cookie.Values.Add("Address", user.Address);
                cookie.Values.Add("Department", user.Department);
                cookie.Values.Add("IP", user.IP);
                cookie.Expires = DateTime.Now.AddDays(7);
                Response.SetCookie(cookie);
            }
            else
                msg = "3";
            return Content(msg);
        }

        public ActionResult Logout()
        {
            HttpCookie cookie = Request.Cookies["user"];
            cookie.Expires = DateTime.Now;
            Response.Cookies.Add(cookie);
            return RedirectToAction("Login", "User");
        }
    }
}
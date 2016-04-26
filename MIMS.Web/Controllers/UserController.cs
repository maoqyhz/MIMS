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
                cookie.Values.Add("Username", HttpUtility.UrlEncode(user.Username));
                cookie.Values.Add("Code", user.Code);
                cookie.Values.Add("Name", HttpUtility.UrlEncode(user.Name));
                cookie.Values.Add("Tel", user.Tel);
                cookie.Values.Add("Role", HttpUtility.UrlEncode(user.Role));
                cookie.Values.Add("Address", HttpUtility.UrlEncode(user.Address));
                cookie.Values.Add("Department", HttpUtility.UrlEncode(user.Department));
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
        public ActionResult ModifyPassword(string Username, string Password, string newPassword)
        {
            int isOk = default(int);
            COM_User user = icom_userbll.GetEntity(Username);
            Password = EncryptUtils.MD5Encrypt(Password.Trim());

            if (user.Password == Password)
            {
                user.Password = EncryptUtils.MD5Encrypt(newPassword.Trim());
                isOk = icom_userbll.Update(user);
            }
            else
                isOk = -1;
            return Content(isOk.ToString());
        }
    }
}
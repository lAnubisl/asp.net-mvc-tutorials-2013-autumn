using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Lesson04.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username)
        {
            RegisterAuthCookie();
            return View();
        }

        private void RegisterAuthCookie()
        {
            var ticket = new FormsAuthenticationTicket("Alex", true, 3600);
            var hashCookies = FormsAuthentication.Encrypt(ticket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hashCookies) { Expires = DateTime.Now.AddYears(20) };
            Response.Cookies.Add(cookie);


            var cookie1 = new HttpCookie("key1", "Value1");
            Response.Cookies.Add(cookie1);
        }
    }
}

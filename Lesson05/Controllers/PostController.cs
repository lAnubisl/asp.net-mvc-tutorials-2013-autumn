using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lesson05.Controllers
{
    public class PostController : Controller
    {
        //
        // GET: /Post/

        public ActionResult Index(string seoUrl)
        {
            return View();
        }

    }
}

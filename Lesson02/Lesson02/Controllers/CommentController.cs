using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lesson02.Models;

namespace Lesson02.Controllers
{
    public class CommentController : Controller
    {
        //
        // GET: /Comment/

        public ActionResult Post()
        {
            return View(new Comment());
        }

        [HttpPost]
        public ActionResult Post(Comment model)
        {
            return View();
        }
    }
}

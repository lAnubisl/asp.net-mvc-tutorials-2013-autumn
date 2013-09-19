using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lesson02.Models;

namespace Lesson02.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/

        private string googlepattern = "https://www.google.by/?gws_rd=cr&ei=T9YxUpXgCeek4gS844GQDg#q={0} {1}";

        public ActionResult Buy()
        {
            return View(new Person() { FirstName = "Alex"});
        }

        [HttpPost]
        public ActionResult Buy(Person person)
        {
            if (ModelState.IsValid)
            {
                return Redirect(string.Format(googlepattern, person.FirstName, person.LastName));
            }

            return View(person);
        }
    }
}

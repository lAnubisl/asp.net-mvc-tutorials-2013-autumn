using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using Lesson01.Models;

namespace Lesson01.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cats()
        {
            var cats = new Collection<Cat>();
            var tom = new Cat("Tom");
            var bob = new Cat("Bob");
            cats.Add(tom);
            cats.Add(bob);
           
            return View(cats);
        }

        public ActionResult Dogs()
        {
            var dogs = new Collection<Dog>();
            var spike = new Dog("Spike");
            var mojo = new Dog("Mojo");
            dogs.Add(spike);
            dogs.Add(mojo);

            return View(dogs);
        }
    }
}

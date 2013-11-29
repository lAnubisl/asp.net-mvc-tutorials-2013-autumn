using NHibernate;
using NHibernate.Cfg;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using SysCfg = System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;

namespace Lesson06.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            // Открываем сессию
            ISession session = MvcApplication.GetSession();

            // Создаём кота
            Cat cat = new Cat();
            cat.Color = "Black";
            cat.Age = 3;
            
            // Сохраняем кота
            session.Save(cat);

            // Загружаем всех котов
            IList<Cat> cats = session.Query<Cat>().ToList();

            // Возвращаем котов на страницу
            return View(cats);
        }
	}
}
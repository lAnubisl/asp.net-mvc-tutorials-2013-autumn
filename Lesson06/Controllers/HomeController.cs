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
            // Создаём коллекцию настроек
            Dictionary<string, string> configurationSettings = new Dictionary<string, string>();
            configurationSettings.Add(NHibernate.Cfg.Environment.ConnectionString, SysCfg.ConfigurationManager.ConnectionStrings["default"].ConnectionString);
            configurationSettings.Add(NHibernate.Cfg.Environment.Dialect, typeof(NHibernate.Dialect.MsSql2012Dialect).FullName);

            // Создаём конфигурацию фабрики сессии NHibernate
            Configuration configuration = new Configuration();

            // Устанавливаем настройки
            configuration.SetProperties(configurationSettings);

            // Указываем сборку, в которой хранятся мапиинги NHibernate
            configuration.AddAssembly(Assembly.GetExecutingAssembly());

            // Создаём фабрику сессий
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();

            // Открываем сессию
            ISession session = sessionFactory.OpenSession();

            // Создаём кота
            Cat cat = new Cat();
            cat.Color = "Black";
            cat.Age = 3;
            
            // Сохраняем кота
            session.Save(cat);

            // Загружаем всех котов
            IList<Cat> cats = session.Query<Cat>().ToList();

            // Закрываем и освобождаем сессию
            session.Close();
            session.Dispose();

            // Возвращаем котов на страницу
            return View(cats);
        }
	}
}
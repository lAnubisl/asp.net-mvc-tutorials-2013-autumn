using Lesson06.Controllers;
using Microsoft.Practices.Unity;
using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Lesson06
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static ISessionFactory sessionFactory;

        public static ISession GetSession()
        {
            if (HttpContext.Current.Items["session"] == null)
            {
                HttpContext.Current.Items["session"] = 
                    sessionFactory.OpenSession();
            }

            return (ISession)HttpContext.Current.Items["session"];
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            sessionFactory = GetSessionFactory();
        }

        private ISessionFactory GetSessionFactory()
        {
            // Создаём коллекцию настроек
            Dictionary<string, string> configurationSettings = new Dictionary<string, string>();
            configurationSettings.Add(NHibernate.Cfg.Environment.ConnectionString, System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString);
            configurationSettings.Add(NHibernate.Cfg.Environment.Dialect, typeof(NHibernate.Dialect.MsSql2012Dialect).FullName);
            configurationSettings.Add(NHibernate.Cfg.Environment.ShowSql, "true");

            // Создаём конфигурацию фабрики сессии NHibernate
            Configuration configuration = new Configuration();

            // Устанавливаем настройки
            configuration.SetProperties(configurationSettings);

            // Указываем сборку, в которой хранятся мапиинги NHibernate
            configuration.AddAssembly(Assembly.GetExecutingAssembly());

            // Создаём фабрику сессий
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();

            return sessionFactory;
        }
    }
}

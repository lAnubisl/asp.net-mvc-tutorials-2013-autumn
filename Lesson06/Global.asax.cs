using Lesson06.Controllers;
using Microsoft.Practices.Unity;
using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
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
            if (ContextSession == null)
            {
                return (ContextSession = sessionFactory.OpenSession());
            }

            return ContextSession;
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            sessionFactory = GetSessionFactory();
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            var session = ContextSession;
            if (session != null)
            {
                if (session.IsOpen)
                {
                    session.Close();
                }

                session.Dispose();
            }
        }

        private static ISession ContextSession
        {
            get 
            {
                if (HttpContext.Current.Items["session"] != null)
                {
                    return (ISession)HttpContext.Current.Items["session"];
                }

                return null;
            }
            set 
            {
                HttpContext.Current.Items["session"] = value;
            }
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

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lesson03.Models;

namespace Lesson03.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var model = new MessageModel();

            model.Items = LoadItems();

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(MessageModel model)
        {
            if (ModelState.IsValid)
            {
                SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ConnectionString);
                conection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO [Message] VALUES (@email, @message)", conection);
                command.Parameters.Add(new SqlParameter("@email", model.PostModel.Email));
                command.Parameters.Add(new SqlParameter("@message", model.PostModel.Message));
                command.ExecuteNonQuery();
                conection.Close();
                conection.Dispose();
            }

            model.Items = LoadItems();

            return View(model);
        }

        private ICollection<MessageItemModel> LoadItems()
        {
            ICollection<MessageItemModel> items = new Collection<MessageItemModel>();
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ConnectionString);
            conection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM [Message]", conection);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string email = reader["Email"] as string;
                string message = reader["Message"] as string;
                items.Add(new MessageItemModel(email, message));
            }

            reader.Close();
            reader.Dispose();
            conection.Close();
            conection.Dispose();
            return items;
        } 

    }
}

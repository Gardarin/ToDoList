using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using ToDoList.Models; 

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HttpCookie cookie = Request.Cookies.Get("ToDoListAuthId");
            if (cookie == null)
            {
                return RedirectToAction("Registration");
            }
            return RedirectToAction("UsersToDoList");
        }

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisUser([Bind(Include = "Name, Email, Password")]User user)
        {
            user.AutId = Session.SessionID;
            user.Items = new List<Item>();
            HttpCookie cookie = new HttpCookie("ToDoListAuthId", user.AutId);
            WorkWithDb.Registration(user);
            Response.SetCookie(cookie);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public string SigIn(User user)
        {
            return "";
        }

        public ActionResult SigOut()
        {
            Response.Cookies.Remove("ToDoListAuthId");
            return RedirectToAction("Index");
        }

        public ActionResult UsersToDoList()
        {
            HttpCookie cookie = Request.Cookies.Get("ToDoListAuthId");
            if (cookie == null)
            {
                return View("Registration");
            }
            User user = WorkWithDb.GetUserByAuthId(cookie.Value);
            if (user == null)
            {
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public JsonResult GetItems()
        {
            HttpCookie cookie = Request.Cookies.Get("ToDoListAuthId");
            List<Item> items = new List<Item>();
            if (cookie != null)
            {
                var user = WorkWithDb.GetUserByAuthId(cookie.Value);
                if (user != null)
                {
                    items = user.Items;
                }
            }

            return Json(items);
        }

        [HttpPost]
        public bool AddItem([Bind(Include = "Name, Description, CheckedDate")]Item item)
        {
            HttpCookie cookie = Request.Cookies.Get("ToDoListAuthId");
            if (cookie != null)
            {
                item.CreationDate = DateTime.Now;
                item.IsChecked = false;

                WorkWithDb.AddItem(cookie.Value,item);
                return true;
            }
            return false;
        }
    }
}
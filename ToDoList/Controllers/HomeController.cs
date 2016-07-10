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
                return View();
            }
            WorkWithDb.GetUserByAuthId(cookie.Value);
            return View("UsersToDoList");
        }

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisUser([Bind(Include = "Name, Email, Password")]User user)
        {
            
            HttpCookie cookie = Request.Cookies.Get("ToDoListAuthId");
            var a= Request;
            if (cookie == null)
            {
                cookie = new HttpCookie("ToDoListAuthId", Session.SessionID);
                Response.SetCookie(cookie);
            }
            //user.AutId = cookie.Value;
            //WorkWithDb.Registration(user);
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
            return View();
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
    }
}
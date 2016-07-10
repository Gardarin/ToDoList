﻿using System;
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
                return RedirectToAction("SigInPage");
            }
            if (cookie.Value == "@@@@")
            {
                return RedirectToAction("SigInPage");
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
            return RedirectToAction("UsersToDoList");
        }

        public ActionResult SigInPage()
        {
            return View("SigIn");
        }

        [HttpPost]
        public ActionResult SigIn([Bind(Include = "Email, Password")]User user)
        {
            var authUser = WorkWithDb.GetUserBySigInInfo(user.Email, user.Password);
            if (authUser != null)
            {
                HttpCookie cookie = new HttpCookie("ToDoListAuthId", authUser.AutId);
                Response.SetCookie(cookie);
            }
            return RedirectToAction("SigInPage");
        }

        public ActionResult SigOut()
        {
            HttpCookie cookie = Request.Cookies.Get("ToDoListAuthId");
            if (cookie != null)
            {
                cookie.Value = "@@@@";
                Response.Cookies.Set(cookie);
            }
            return RedirectToAction("SigInPage");
        }

        public ActionResult UsersToDoList()
        {
            HttpCookie cookie = Request.Cookies.Get("ToDoListAuthId");
            if (cookie == null)
            {
                return RedirectToAction("SigInPage");
            }
            User user = WorkWithDb.GetUserByAuthId(cookie.Value);
            if (user == null)
            {
                return RedirectToAction("SigInPage");
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

            return Json(items,JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public bool CheckItem(int id)
        {
            HttpCookie cookie = Request.Cookies.Get("ToDoListAuthId");
            if (cookie != null)
            {
                WorkWithDb.CheckItem(cookie.Value, id);
                return true;
            }
            return false;
        }

        [HttpPost]
        public bool RemoveItem(int id)
        {
            HttpCookie cookie = Request.Cookies.Get("ToDoListAuthId");
            if (cookie != null)
            {
                WorkWithDb.RemoveItem(cookie.Value, id);
                return true;
            }
            return false;
        }

        [HttpPost]
        public bool EditItem(Item item)
        {
            HttpCookie cookie = Request.Cookies.Get("ToDoListAuthId");
            if (cookie != null)
            {
                WorkWithDb.EditItem(cookie.Value, item);
                return true;
            }
            return false;
        }
    }
}
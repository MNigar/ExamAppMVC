using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using ExamAppMvc.Context;
using ExamAppMvc.Models.DbModel;

namespace ExamAppMvc.Controllers
{
    public class UsersController : Controller
    {
        private ExamContext db = new ExamContext();

  
        public ActionResult Index()
        {  
            if (Session["username"].ToString() == "admin")
            {
                return View("~/Areas/Manage/Views/Home/Index.cshtml");
            }
            return View();
        }

       
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,Password,Name")] User user)
        {
            if (ModelState.IsValid)
            {
                user.Password = Crypto.HashPassword(user.Password);

                var check = db.Users.Where(u => u.Email == user.Email).FirstOrDefault();
                if (check == null)
                {

                    db.Users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }

                else
                {
                    Session["RegisterError"] = true;
                    return RedirectToAction("Create");

                }
            }

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Id,Email,Password,Name")] User user)
        {
             if (ModelState.IsValid)
                {
                    var check = db.Users.Where(u => u.Email == user.Email).FirstOrDefault();
                    if (check != null)
                    {


                        if (Crypto.VerifyHashedPassword(check.Password, user.Password))
                        {
                            Session["email"] = check.Email;
                            Session["username"] = check.Name;
                        return RedirectToAction("Index", "Users");
                        }

                    }
                    else
                    {
                        Session["LoginError"] = true;


                        //ViewBag.Error = "Yoxdur";
                        return View("Login");
                    }
                }
            return View();           
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

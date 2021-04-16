using ExamAppMvc.Context;
using ExamAppMvc.Models.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ExamAppMvc.Controllers
{
    public class AdminController : Controller
    {
        ExamContext db = new ExamContext();
        // GET: Admin
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
                    Session["email"] = check.Email;
                    Session["username"] = check.Name;


                    if (Crypto.VerifyHashedPassword(check.Password, user.Password))
                    {
                       
                        if (Session["username"].ToString() == "admin")
                        {
                            return View("~/Areas/Manage/Views/Home/Index.cshtml");
                        }
                        else
                        {
                            return RedirectToAction("Login", "Admin");
                        }

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
      
            [HttpGet]
            public ActionResult Logout()
            {
                Session["email"] = null;
                Session["username"] = null;
                return RedirectToAction("Login", "Admin");
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
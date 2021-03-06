using ExamAppMvc.Context;
using ExamAppMvc.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamAppMvc.Controllers
{   
    public class MenuController : Controller
    {
        // GET: Menu
        private ExamContext db = new ExamContext();

        // GET: Manage/Menu
        public ActionResult Index()
        {
            ViewBag.Subject = db.Subjects.ToList();
            return View();
        }
        public ActionResult SubMenu(int? id)
        {
            ViewBag.Class = db.SubjectClassTopics.Where(x => x.SubjectId == id).ToList().Select(x => x.Class).Distinct();
           
            return View();
        }
        public ActionResult Topic(int? id)
        {
            ViewBag.Topic = db.SubjectClassTopics.Where(x => x.ClassId == id).ToList();
            
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
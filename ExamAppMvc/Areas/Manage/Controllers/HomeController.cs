using ExamAppMvc.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamAppMvc.Areas.Manage.Controllers
{
    public class HomeController : Controller
    {
        [Auth]
        // GET: Manage/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}
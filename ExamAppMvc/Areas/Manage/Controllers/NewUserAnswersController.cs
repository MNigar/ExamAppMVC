using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExamAppMvc.Context;
using ExamAppMvc.Models.DbModel;

namespace ExamAppMvc.Areas.Manage.Controllers
{
    public class NewUserAnswersController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: Manage/NewUserAnswers
        public ActionResult Index()
        {
            var newUserAnswers = db.NewUserAnswers.Include(n => n.QuestionAnswer).Include(n => n.User);
            return View(newUserAnswers.ToList());
        }

        // GET: Manage/NewUserAnswers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewUserAnswer newUserAnswer = db.NewUserAnswers.Find(id);
            if (newUserAnswer == null)
            {
                return HttpNotFound();
            }
            return View(newUserAnswer);
        }

        // GET: Manage/NewUserAnswers/Create
        public ActionResult Create()
        {
            ViewBag.QuestionAnswerId = new SelectList(db.QuestionAnswers, "ID", "Text");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: Manage/NewUserAnswers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,SelectedAnswer,QuestionAnswerId,IsTure")] NewUserAnswer newUserAnswer)
        {
            if (ModelState.IsValid)
            {
                db.NewUserAnswers.Add(newUserAnswer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.QuestionAnswerId = new SelectList(db.QuestionAnswers, "ID", "Text", newUserAnswer.QuestionAnswerId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", newUserAnswer.UserId);
            return View(newUserAnswer);
        }

        // GET: Manage/NewUserAnswers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewUserAnswer newUserAnswer = db.NewUserAnswers.Find(id);
            if (newUserAnswer == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuestionAnswerId = new SelectList(db.QuestionAnswers, "ID", "Text", newUserAnswer.QuestionAnswerId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", newUserAnswer.UserId);
            return View(newUserAnswer);
        }

        // POST: Manage/NewUserAnswers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,SelectedAnswer,QuestionAnswerId,IsTure")] NewUserAnswer newUserAnswer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newUserAnswer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QuestionAnswerId = new SelectList(db.QuestionAnswers, "ID", "Text", newUserAnswer.QuestionAnswerId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", newUserAnswer.UserId);
            return View(newUserAnswer);
        }

        // GET: Manage/NewUserAnswers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewUserAnswer newUserAnswer = db.NewUserAnswers.Find(id);
            if (newUserAnswer == null)
            {
                return HttpNotFound();
            }
            return View(newUserAnswer);
        }

        // POST: Manage/NewUserAnswers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewUserAnswer newUserAnswer = db.NewUserAnswers.Find(id);
            db.NewUserAnswers.Remove(newUserAnswer);
            db.SaveChanges();
            return RedirectToAction("Index");
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

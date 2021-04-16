using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExamAppMvc.Context;
using ExamAppMvc.Filter;
using ExamAppMvc.Models.DbModel;

namespace ExamAppMvc.Areas.Manage.Controllers
{
    [AuthForAdmin]
    public class QuestionAnswersController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: Manage/QuestionAnswers
        public ActionResult Index()
        {
            var questionAnswer = db.QuestionAnswers.Include(q => q.SubjectClassTopic);
            return View(questionAnswer.ToList());
        }

        // GET: Manage/QuestionAnswers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionAnswer questionAnswer = db.QuestionAnswers.Find(id);
            if (questionAnswer == null)
            {
                return HttpNotFound();
            }
            return View(questionAnswer);
        }

        // GET: Manage/QuestionAnswers/Create
        public ActionResult Create(/*int id*/)
        {
            ViewBag.Topic = db.SubjectClassTopics.ToList();

            return View();
        }

        // POST: Manage/QuestionAnswers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( QuestionAnswer questionAnswer)
        {
            if (ModelState.IsValid)
            {
              
                db.QuestionAnswers.Add(questionAnswer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.SubjectClassTopicId1 = new SelectList(db.SubjectClassTopics, "Id", "Topic");

           
            ViewBag.SubjectClassTopicId = new SelectList(db.SubjectClassTopics, "Id", "Topic", questionAnswer.SubjectClassTopicId);
            return View(questionAnswer);
        }

        // GET: Manage/QuestionAnswers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionAnswer questionAnswer = db.QuestionAnswers.Find(id);
            if (questionAnswer == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubjectClassTopicId = new SelectList(db.SubjectClassTopics, "Id", "Topic", questionAnswer.SubjectClassTopicId);
            return View(questionAnswer);
        }

        // POST: Manage/QuestionAnswers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Text,Answer1,Answer2,Answer3,TrueAnswer,SubjectClassTopicId")] QuestionAnswer questionAnswer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(questionAnswer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubjectClassTopicId = new SelectList(db.SubjectClassTopics, "Id", "Topic", questionAnswer.SubjectClassTopicId);
            return View(questionAnswer);
        }

        // GET: Manage/QuestionAnswers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionAnswer questionAnswer = db.QuestionAnswers.Find(id);
            if (questionAnswer == null)
            {
                return HttpNotFound();
            }
            return View(questionAnswer);
        }

        // POST: Manage/QuestionAnswers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuestionAnswer questionAnswer = db.QuestionAnswers.Find(id);
            db.QuestionAnswers.Remove(questionAnswer);
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

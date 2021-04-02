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
using ExamAppMvc.Models.ViewModel;

namespace ExamAppMvc.Areas.Manage.Controllers
{
    public class QuestionsController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: Manage/Questions
        public ActionResult Index()
        {
            var questions = db.Questions.Include(q => q.SubjectClassTopic);
            return View(questions.ToList());
        }

        // GET: Manage/Questions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }
       
        // GET: Manage/Questions/Create
        public ActionResult Create(int id)
        {
            ViewBag.SubjectClassTopicId = db.SubjectClassTopics.Where(x => x.Id == id).FirstOrDefault();
            QuestionAnswerViewModel model = new QuestionAnswerViewModel();
            ViewBag.AnswerList = new List<Answer>();
            var variant = "ABCD";
            ViewBag.variant = variant.ToList();
            ViewBag.Subject = id;
            return View(model);
        }

        // POST: Manage/Questions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public ActionResult Create( QuestionAnswerViewModel question)
        {
            

            if (ModelState.IsValid)
            {
              
                db.Questions.Add(question.Question);
                db.SaveChanges();
        


                //foreach (var i in ViewBag.variant)
                //{
                //    question.Answer.QuestionId = question.Question.Id;
                //    db.Answers.Add(question.Answer);
                //    db.SaveChanges();

                //}

                return RedirectToAction("Index");
            }

            ViewBag.SubjectClassTopicId = new SelectList(db.SubjectClassTopics, "Id", "Topic", question.Question.SubjectClassTopicId);
            return View(question);
        }

        // GET: Manage/Questions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubjectClassTopicId = new SelectList(db.SubjectClassTopics, "Id", "Topic", question.SubjectClassTopicId);
            return View(question);
        }

        // POST: Manage/Questions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Text,SubjectClassTopicId")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubjectClassTopicId = new SelectList(db.SubjectClassTopics, "Id", "Topic", question.SubjectClassTopicId);
            return View(question);
        }

        // GET: Manage/Questions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Manage/Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Question question = db.Questions.Find(id);
            db.Questions.Remove(question);
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

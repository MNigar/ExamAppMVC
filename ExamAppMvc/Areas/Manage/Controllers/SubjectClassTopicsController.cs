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
    public class SubjectClassTopicsController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: Manage/SubjectClassTopics
        public ActionResult Index()
        {
            var subjectClassTopics = db.SubjectClassTopics.Include(s => s.Class).Include(s => s.Subject);
            return View(subjectClassTopics.ToList());
        }

        // GET: Manage/SubjectClassTopics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectClassTopic subjectClassTopic = db.SubjectClassTopics.Find(id);
            if (subjectClassTopic == null)
            {
                return HttpNotFound();
            }
            return View(subjectClassTopic);
        }

        // GET: Manage/SubjectClassTopics/Create
        public ActionResult Create()
        {
            ViewBag.ClassId = new SelectList(db.Classes, "Id", "Name");
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name");
            return View();
        }

        // POST: Manage/SubjectClassTopics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Topic,SubjectId,ClassId")] SubjectClassTopic subjectClassTopic)
        {
            if (ModelState.IsValid)
            {
                Topic topic = new Topic();
                topic.Name = subjectClassTopic.Topic;
                db.SubjectClassTopics.Add(subjectClassTopic);
                db.Topics.Add(topic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassId = new SelectList(db.Classes, "Id", "Name", subjectClassTopic.ClassId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", subjectClassTopic.SubjectId);
            return View(subjectClassTopic);
        }

        // GET: Manage/SubjectClassTopics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectClassTopic subjectClassTopic = db.SubjectClassTopics.Find(id);
            if (subjectClassTopic == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassId = new SelectList(db.Classes, "Id", "Name", subjectClassTopic.ClassId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", subjectClassTopic.SubjectId);
            return View(subjectClassTopic);
        }

        // POST: Manage/SubjectClassTopics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Topic,SubjectId,ClassId")] SubjectClassTopic subjectClassTopic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subjectClassTopic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassId = new SelectList(db.Classes, "Id", "Name", subjectClassTopic.ClassId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", subjectClassTopic.SubjectId);
            return View(subjectClassTopic);
        }

        // GET: Manage/SubjectClassTopics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectClassTopic subjectClassTopic = db.SubjectClassTopics.Find(id);
            if (subjectClassTopic == null)
            {
                return HttpNotFound();
            }
            return View(subjectClassTopic);
        }

        // POST: Manage/SubjectClassTopics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubjectClassTopic subjectClassTopic = db.SubjectClassTopics.Find(id);
            db.SubjectClassTopics.Remove(subjectClassTopic);
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

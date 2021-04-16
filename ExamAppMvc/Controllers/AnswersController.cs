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

namespace ExamAppMvc.Controllers
{
    public class AnswersController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: Answers
        public ActionResult Index(int? id)
        {
            //var answers = db.Answers.Include(a => a.Question).Where(x=>x.Question.SubjectClassTopicId==id);
            //ViewBag.Question = db.Questions.Where(x=>x.SubjectClassTopicId==id).ToList();
            if (Session["username"] == null)
            {
                TempData["Message"] = "Please login for exam";
                return RedirectToAction("Login", "Users");
            }
            SubjectClassTopic topic = db.SubjectClassTopics.Find(id);
            if (topic == null)
            {
                return HttpNotFound();
            }
            return View(topic);
          
        }
        [HttpPost]
        public ActionResult Index(Answer answer)
        {   
            UserAnswer userAnswer = new UserAnswer();
            var userid = Session["username"].ToString();
            userAnswer.UserId = db.Users.Where(x => x.Name == userid).FirstOrDefault().Id;
            //foreach(var answer in answers)
            //{
                userAnswer.AnswerId = answer.Id;
                var check = db.Answers.Where(x => x.Id == answer.Id).FirstOrDefault().IsTrueAnswer;
                userAnswer.IsTure = check;
                db.UserAnswers.Add(userAnswer);
                db.SaveChanges();
            //}
           
            return RedirectToAction("Index");
        }

        // GET: Answers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Answer answer = db.Answers.Find(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            return View(answer);
        }

        // GET: Answers/Create
        public ActionResult Create()
        {
            ViewBag.QuestionId = new SelectList(db.Questions, "Id", "Text");
            return View();
        }

        // POST: Answers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Text,IsTrueAnswer,QuestionId")] Answer answer)
        {
            if (ModelState.IsValid)
            {
                db.Answers.Add(answer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.QuestionId = new SelectList(db.Questions, "Id", "Text", answer.QuestionId);
            return View(answer);
        }

        // GET: Answers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Answer answer = db.Answers.Find(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuestionId = new SelectList(db.Questions, "Id", "Text", answer.QuestionId);
            return View(answer);
        }

        // POST: Answers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Text,IsTrueAnswer,QuestionId")] Answer answer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(answer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QuestionId = new SelectList(db.Questions, "Id", "Text", answer.QuestionId);
            return View(answer);
        }

        // GET: Answers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Answer answer = db.Answers.Find(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            return View(answer);
        }

        // POST: Answers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Answer answer = db.Answers.Find(id);
            db.Answers.Remove(answer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Result(int id,Dictionary<string,object> sual)
        {
            SubjectClassTopic topic = db.SubjectClassTopics.Find(id);
                
           


            var path=Request.FilePath;
            var method = Request.HttpMethod;      
            var y = Request.Headers.Count;



            Request.Form.CopyTo(sual);
            Result result = new Result();
            //Dictionary<string, string> sual = new Dictionary<string, string>();
            //foreach (string key in HttpContext.Request.Form.Keys)
            //{
            //    sual.Add(key, Request.Form.Get(key));
            //}
            string email = Session["email"].ToString();
            int userId = db.Users.Where(x => x.Email == email).FirstOrDefault().Id;
            foreach (QuestionAnswer question in topic.QuestionAnswer.ToList())
            {
                result.QuestionId = question.ID;
                result.SubjectId = topic.SubjectId;
                result.SubjectClassTopicId = topic.Id;
                result.UserId = userId;
                if (sual.ContainsKey(question.ID.ToString()))
                {
                   
                    if (sual[question.ID.ToString()].ToString() == question.TrueAnswer)
                    {
                        result.TrueAnswers++;
                        result.TotalPoint += question.Point;
                    }
                    else
                    {
                        result.FalseAnswers++;
                    }
                }

                else
                {
                    result.EmptyAnswers++;
                }
                                          
                db.Results.Add(result);
                db.SaveChanges();
            }
            
            int totalWrong= (result.FalseAnswers + result.EmptyAnswers) / 4;
            if (totalWrong >= 1)
            {
                ViewBag.Total = result.TotalPoint - 1 * totalWrong;
                if (ViewBag.Total < 0)
                {
                    ViewBag.Total = 0;
                }
            }
            else
            {
                ViewBag.Total = result.TotalPoint;
            }

           

            var fullName = db.Users.Where(x => x.Id == userId).FirstOrDefault();
            ViewBag.FullName = fullName.Name + " " + fullName.Surname;
            return View(result);
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

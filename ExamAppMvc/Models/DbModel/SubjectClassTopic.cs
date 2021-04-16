using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamAppMvc.Models.DbModel
{
    public class SubjectClassTopic
    {   public SubjectClassTopic()
        {
            UserSubjectTopicClasses = new List<Exam>();
            //Questions = new List<Question>();
            QuestionAnswer = new List<QuestionAnswer>();
            Results = new List<Result>();
        }
        [Key]
        public int Id { get; set; }
        public string Topic { get; set; }
        public int SubjectId { get; set; }
        public int ClassId { get; set; }
        
        public virtual Subject Subject { get; set; }
        public virtual Class Class { get; set; }
        public List<Result> Results { get; set; }
        public virtual List<Exam> UserSubjectTopicClasses { get; set; }
        //public virtual List<Question> Questions { get; set; }
        public virtual List<QuestionAnswer> QuestionAnswer { get; set; }
    }
}
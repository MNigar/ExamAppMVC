using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamAppMvc.Models.DbModel
{
    public class Question
    {   public Question()
        {
            Answers = new List<Answer>();
            //UserAnswers = new List<UserAnswer>();
        }
         [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public int SubjectClassTopicId { get; set; }
        //public int ClassId { get; set; }
        //public int SubjectId { get; set; }
        //public Class Class { get; set; }
        //public Subject Subject { get; set; }
        public virtual SubjectClassTopic SubjectClassTopic { get; set; }
        public virtual List<Answer> Answers { get; set; }
        //public virtual List<UserAnswer> UserAnswers { get; set; }


    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamAppMvc.Models.DbModel
{
    public class Result
    {[Key]
        public int Id { get; set; }
        public int SubjectClassTopicId { get; set; }
        public int UserId { get; set; }
        public int SubjectId { get; set; }
        public int QuestionId { get; set; } 
       
        public virtual SubjectClassTopic SubjectClassTopic { get; set; }
       
        public int TrueAnswers { get; set; }
        public int FalseAnswers { get; set; }
        public int EmptyAnswers { get; set; }
        public int TotalPoint { get; set; }
    }
}
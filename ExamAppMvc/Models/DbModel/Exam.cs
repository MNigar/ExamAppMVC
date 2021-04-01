using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamAppMvc.Models.DbModel
{
    public class Exam
    {   
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SubjectTopicLassId { get; set; }
        public virtual User User { get; set; }
        public virtual SubjectClassTopic SubjectClassTopic{get;set;}
        public int TrueAnswer { get; set; }
        public int WrongAnswer { get; set; }
        public int NotAnswer { get; set; }

    }
}
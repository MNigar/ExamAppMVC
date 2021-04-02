using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamAppMvc.Models.DbModel
{
    public class QuestionAnswer
    {  
       
        [Key]
        public int ID { get; set; }
        public string Text { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string TrueAnswer { get; set; }
        public int SubjectClassTopicId { get; set; }
        public virtual SubjectClassTopic SubjectClassTopic { get; set; }

    }
}
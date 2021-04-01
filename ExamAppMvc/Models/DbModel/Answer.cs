using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamAppMvc.Models.DbModel
{
    public class Answer
    {   public Answer()
        {
            UserAnswers = new List<UserAnswer>();
        }
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsTrueAnswer { get; set; }
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
        public virtual List<UserAnswer> UserAnswers { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamAppMvc.Models.DbModel
{
    public class UserAnswer
    {
        public int id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
        public int AnswerId { get; set; }
        public virtual Answer Answer { get; set; }
        public bool IsTure { get; set; }
        
    }
}
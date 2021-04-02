using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamAppMvc.Models.DbModel
{
    public class NewUserAnswer
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public string SelectedAnswer { get; set; }
        public int QuestionAnswerId { get; set; }       
        public virtual QuestionAnswer QuestionAnswer { get; set; }
        public bool IsTure { get; set; }
    }
}
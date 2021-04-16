using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamAppMvc.Models.DbModel
{
    public class User:BaseClass
    {  public User()
        {
            UserSubjectTopicClasses = new List<Exam>();
            UserAnswers = new List<UserAnswer>();
            NewUserAnswers = new List<NewUserAnswer>();
        }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
                  
        public string Surname { get; set; }
        [Required]
        public string Password { get; set; }

        public virtual List <Exam> UserSubjectTopicClasses { get; set; }
        public virtual List<UserAnswer> UserAnswers { get; set; }
        public virtual List<NewUserAnswer> NewUserAnswers { get; set; }


    }
}
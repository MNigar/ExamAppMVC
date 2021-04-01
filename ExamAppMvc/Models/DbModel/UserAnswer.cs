using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExamAppMvc.Models.DbModel
{
    public class UserAnswer
    {   [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
       

        public int AnswerId { get; set; }
        [ForeignKey("AnswerId")]
        public virtual Answer Answer { get; set; }
        public bool IsTure { get; set; }
        
    }
}
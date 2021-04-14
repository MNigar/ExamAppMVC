using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamAppMvc.Models.DbModel
{
    public class Result
    {   [Key]
        public int Id { get; set; }
        public int TrueAnswers { get; set; }
        public int FalseAnswers { get; set; }
        public int EmptyAnswers { get; set; }
        public int TotalPoint { get; set; }
    }
}
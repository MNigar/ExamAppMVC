using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExamAppMvc.Models.DbModel;
namespace ExamAppMvc.Models.ViewModel
{
    public class QuestionAnswerViewModel
    {
        public Question Question { get; set; }
        public Answer Answer { get; set; }
    }
}
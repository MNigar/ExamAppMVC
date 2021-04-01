using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamAppMvc.Models.DbModel
{
    public class Subject:BaseClass
    {
        public Subject()
        {
            SubjectClassTopics = new List<SubjectClassTopic>();
        }
        public virtual List<SubjectClassTopic> SubjectClassTopics { get; set; }

    }
}
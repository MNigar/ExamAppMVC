using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamAppMvc.Models.DbModel
{
    public class Class:BaseClass
    {  
        public Class()
         {
            SubjectClassTopics = new List<SubjectClassTopic>();
         }
    
        public virtual List<SubjectClassTopic> SubjectClassTopics { get; set; }

}
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamAppMvc.Models.DbModel
{
    public class SubjectClassTopic
    {   public SubjectClassTopic()
        {
            UserSubjectTopicClasses = new List<Exam>();
        }
        [Key]
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int ClassId { get; set; }
        public int TopicId { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Class Class { get; set; }
        public virtual Topic Topic { get; set; }
        public virtual List<Exam> UserSubjectTopicClasses { get; set; }


    }
}
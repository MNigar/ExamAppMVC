using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamAppMvc.Models.DbModel
{
    public class SubjectClass
    {   public int Id { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
    }
}
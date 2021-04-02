using ExamAppMvc.Models.DbModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ExamAppMvc.Context
{
    public class ExamContext:DbContext
    {
        public ExamContext() : base("ExamApp1") { }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<SubjectClassTopic> SubjectClassTopics { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<UserAnswer> UserAnswers { get; set; }


    }
}
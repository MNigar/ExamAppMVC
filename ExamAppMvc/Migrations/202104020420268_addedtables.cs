namespace ExamAppMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedtables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        IsTrueAnswer = c.Boolean(nullable: false),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        SubjectClassTopicId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SubjectClassTopics", t => t.SubjectClassTopicId, cascadeDelete: true)
                .Index(t => t.SubjectClassTopicId);
            
            CreateTable(
                "dbo.SubjectClassTopics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Topic = c.String(),
                        SubjectId = c.Int(nullable: false),
                        ClassId = c.Int(nullable: false),
                        Topic_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.ClassId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Topics", t => t.Topic_Id)
                .Index(t => t.SubjectId)
                .Index(t => t.ClassId)
                .Index(t => t.Topic_Id);
            
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        SubjectTopicLassId = c.Int(nullable: false),
                        TrueAnswer = c.Int(nullable: false),
                        WrongAnswer = c.Int(nullable: false),
                        NotAnswer = c.Int(nullable: false),
                        SubjectClassTopic_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SubjectClassTopics", t => t.SubjectClassTopic_Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.SubjectClassTopic_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        AnswerId = c.Int(nullable: false),
                        IsTure = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Answers", t => t.AnswerId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.AnswerId);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubjectClassTopics", "Topic_Id", "dbo.Topics");
            DropForeignKey("dbo.Exams", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserAnswers", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserAnswers", "AnswerId", "dbo.Answers");
            DropForeignKey("dbo.Exams", "SubjectClassTopic_Id", "dbo.SubjectClassTopics");
            DropForeignKey("dbo.SubjectClassTopics", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Questions", "SubjectClassTopicId", "dbo.SubjectClassTopics");
            DropForeignKey("dbo.SubjectClassTopics", "ClassId", "dbo.Classes");
            DropForeignKey("dbo.Answers", "QuestionId", "dbo.Questions");
            DropIndex("dbo.UserAnswers", new[] { "AnswerId" });
            DropIndex("dbo.UserAnswers", new[] { "UserId" });
            DropIndex("dbo.Exams", new[] { "SubjectClassTopic_Id" });
            DropIndex("dbo.Exams", new[] { "UserId" });
            DropIndex("dbo.SubjectClassTopics", new[] { "Topic_Id" });
            DropIndex("dbo.SubjectClassTopics", new[] { "ClassId" });
            DropIndex("dbo.SubjectClassTopics", new[] { "SubjectId" });
            DropIndex("dbo.Questions", new[] { "SubjectClassTopicId" });
            DropIndex("dbo.Answers", new[] { "QuestionId" });
            DropTable("dbo.Topics");
            DropTable("dbo.UserAnswers");
            DropTable("dbo.Users");
            DropTable("dbo.Exams");
            DropTable("dbo.Subjects");
            DropTable("dbo.Classes");
            DropTable("dbo.SubjectClassTopics");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
        }
    }
}

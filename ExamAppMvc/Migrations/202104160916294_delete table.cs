namespace ExamAppMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletetable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Answers", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Questions", "SubjectClassTopicId", "dbo.SubjectClassTopics");
            DropForeignKey("dbo.NewUserAnswers", "QuestionAnswerId", "dbo.QuestionAnswers");
            DropForeignKey("dbo.NewUserAnswers", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserAnswers", "AnswerId", "dbo.Answers");
            DropForeignKey("dbo.UserAnswers", "UserId", "dbo.Users");
            DropIndex("dbo.Answers", new[] { "QuestionId" });
            DropIndex("dbo.Questions", new[] { "SubjectClassTopicId" });
            DropIndex("dbo.NewUserAnswers", new[] { "UserId" });
            DropIndex("dbo.NewUserAnswers", new[] { "QuestionAnswerId" });
            DropIndex("dbo.UserAnswers", new[] { "UserId" });
            DropIndex("dbo.UserAnswers", new[] { "AnswerId" });
            DropTable("dbo.Answers");
            DropTable("dbo.Questions");
            DropTable("dbo.NewUserAnswers");
            DropTable("dbo.UserAnswers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        AnswerId = c.Int(nullable: false),
                        IsTure = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NewUserAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        SelectedAnswer = c.String(),
                        QuestionAnswerId = c.Int(nullable: false),
                        IsTure = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        SubjectClassTopicId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        IsTrueAnswer = c.Boolean(nullable: false),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.UserAnswers", "AnswerId");
            CreateIndex("dbo.UserAnswers", "UserId");
            CreateIndex("dbo.NewUserAnswers", "QuestionAnswerId");
            CreateIndex("dbo.NewUserAnswers", "UserId");
            CreateIndex("dbo.Questions", "SubjectClassTopicId");
            CreateIndex("dbo.Answers", "QuestionId");
            AddForeignKey("dbo.UserAnswers", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserAnswers", "AnswerId", "dbo.Answers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.NewUserAnswers", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.NewUserAnswers", "QuestionAnswerId", "dbo.QuestionAnswers", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Questions", "SubjectClassTopicId", "dbo.SubjectClassTopics", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Answers", "QuestionId", "dbo.Questions", "Id", cascadeDelete: true);
        }
    }
}

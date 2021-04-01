namespace ExamAppMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedtable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Answers", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.UserAnswers", "QuestionId", "dbo.Questions");
            DropIndex("dbo.Answers", new[] { "Question_Id" });
            DropIndex("dbo.UserAnswers", new[] { "QuestionId" });
            RenameColumn(table: "dbo.Answers", name: "Question_Id", newName: "QuestionId");
            RenameColumn(table: "dbo.UserAnswers", name: "QuestionId", newName: "Question_Id");
            AlterColumn("dbo.Answers", "QuestionId", c => c.Int(nullable: false));
            AlterColumn("dbo.UserAnswers", "Question_Id", c => c.Int());
            CreateIndex("dbo.Answers", "QuestionId");
            CreateIndex("dbo.UserAnswers", "Question_Id");
            AddForeignKey("dbo.Answers", "QuestionId", "dbo.Questions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserAnswers", "Question_Id", "dbo.Questions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAnswers", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.Answers", "QuestionId", "dbo.Questions");
            DropIndex("dbo.UserAnswers", new[] { "Question_Id" });
            DropIndex("dbo.Answers", new[] { "QuestionId" });
            AlterColumn("dbo.UserAnswers", "Question_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Answers", "QuestionId", c => c.Int());
            RenameColumn(table: "dbo.UserAnswers", name: "Question_Id", newName: "QuestionId");
            RenameColumn(table: "dbo.Answers", name: "QuestionId", newName: "Question_Id");
            CreateIndex("dbo.UserAnswers", "QuestionId");
            CreateIndex("dbo.Answers", "Question_Id");
            AddForeignKey("dbo.UserAnswers", "QuestionId", "dbo.Questions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Answers", "Question_Id", "dbo.Questions", "Id");
        }
    }
}

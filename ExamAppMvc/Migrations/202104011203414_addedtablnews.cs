namespace ExamAppMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedtablnews : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserAnswers", "Question_Id", "dbo.Questions");
            DropIndex("dbo.UserAnswers", new[] { "Question_Id" });
            DropColumn("dbo.UserAnswers", "Question_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserAnswers", "Question_Id", c => c.Int());
            CreateIndex("dbo.UserAnswers", "Question_Id");
            AddForeignKey("dbo.UserAnswers", "Question_Id", "dbo.Questions", "Id");
        }
    }
}

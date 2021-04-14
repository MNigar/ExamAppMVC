namespace ExamAppMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedfields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.QuestionAnswers", "A", c => c.String());
            AddColumn("dbo.QuestionAnswers", "B", c => c.String());
            AddColumn("dbo.QuestionAnswers", "C", c => c.String());
            AddColumn("dbo.QuestionAnswers", "D", c => c.String());
            DropColumn("dbo.QuestionAnswers", "Answer1");
            DropColumn("dbo.QuestionAnswers", "Answer2");
            DropColumn("dbo.QuestionAnswers", "Answer3");
        }
        
        public override void Down()
        {
            AddColumn("dbo.QuestionAnswers", "Answer3", c => c.String());
            AddColumn("dbo.QuestionAnswers", "Answer2", c => c.String());
            AddColumn("dbo.QuestionAnswers", "Answer1", c => c.String());
            DropColumn("dbo.QuestionAnswers", "D");
            DropColumn("dbo.QuestionAnswers", "C");
            DropColumn("dbo.QuestionAnswers", "B");
            DropColumn("dbo.QuestionAnswers", "A");
        }
    }
}

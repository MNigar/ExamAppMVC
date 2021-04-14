namespace ExamAppMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedpointfield : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.QuestionAnswers", "Point", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.QuestionAnswers", "Point");
        }
    }
}

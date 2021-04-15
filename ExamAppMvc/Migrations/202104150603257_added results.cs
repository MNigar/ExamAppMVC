namespace ExamAppMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedresults : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Results", "SubjectClassTopicId", c => c.Int(nullable: false));
            AddColumn("dbo.Results", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Results", "SubjectId", c => c.Int(nullable: false));
            AddColumn("dbo.Results", "QuestionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Results", "SubjectClassTopicId");
            AddForeignKey("dbo.Results", "SubjectClassTopicId", "dbo.SubjectClassTopics", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Results", "SubjectClassTopicId", "dbo.SubjectClassTopics");
            DropIndex("dbo.Results", new[] { "SubjectClassTopicId" });
            DropColumn("dbo.Results", "QuestionId");
            DropColumn("dbo.Results", "SubjectId");
            DropColumn("dbo.Results", "UserId");
            DropColumn("dbo.Results", "SubjectClassTopicId");
        }
    }
}

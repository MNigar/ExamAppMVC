namespace ExamAppMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tbale : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "SubjectClassTopicId", "dbo.SubjectClassTopics");
            DropIndex("dbo.Questions", new[] { "SubjectClassTopicId" });
            AddColumn("dbo.Questions", "TopicId", c => c.Int(nullable: false));
            AddColumn("dbo.Questions", "ClassId", c => c.Int(nullable: false));
            AddColumn("dbo.Questions", "SubjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.Questions", "TopicId");
            CreateIndex("dbo.Questions", "ClassId");
            CreateIndex("dbo.Questions", "SubjectId");
            AddForeignKey("dbo.Questions", "ClassId", "dbo.Classes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Questions", "SubjectId", "dbo.Subjects", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Questions", "TopicId", "dbo.Topics", "Id", cascadeDelete: true);
            DropColumn("dbo.Questions", "SubjectClassTopicId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "SubjectClassTopicId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Questions", "TopicId", "dbo.Topics");
            DropForeignKey("dbo.Questions", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Questions", "ClassId", "dbo.Classes");
            DropIndex("dbo.Questions", new[] { "SubjectId" });
            DropIndex("dbo.Questions", new[] { "ClassId" });
            DropIndex("dbo.Questions", new[] { "TopicId" });
            DropColumn("dbo.Questions", "SubjectId");
            DropColumn("dbo.Questions", "ClassId");
            DropColumn("dbo.Questions", "TopicId");
            CreateIndex("dbo.Questions", "SubjectClassTopicId");
            AddForeignKey("dbo.Questions", "SubjectClassTopicId", "dbo.SubjectClassTopics", "Id", cascadeDelete: true);
        }
    }
}

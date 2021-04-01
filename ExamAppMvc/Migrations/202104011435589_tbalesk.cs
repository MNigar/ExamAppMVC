namespace ExamAppMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tbalesk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "ClassId", "dbo.Classes");
            DropForeignKey("dbo.Questions", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Questions", "TopicId", "dbo.Topics");
            DropIndex("dbo.Questions", new[] { "TopicId" });
            DropIndex("dbo.Questions", new[] { "ClassId" });
            DropIndex("dbo.Questions", new[] { "SubjectId" });
            AddColumn("dbo.Questions", "SubjectClassTopicId", c => c.Int(nullable: false));
            CreateIndex("dbo.Questions", "SubjectClassTopicId");
            AddForeignKey("dbo.Questions", "SubjectClassTopicId", "dbo.SubjectClassTopics", "Id", cascadeDelete: true);
            DropColumn("dbo.Questions", "TopicId");
            DropColumn("dbo.Questions", "ClassId");
            DropColumn("dbo.Questions", "SubjectId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "SubjectId", c => c.Int(nullable: false));
            AddColumn("dbo.Questions", "ClassId", c => c.Int(nullable: false));
            AddColumn("dbo.Questions", "TopicId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Questions", "SubjectClassTopicId", "dbo.SubjectClassTopics");
            DropIndex("dbo.Questions", new[] { "SubjectClassTopicId" });
            DropColumn("dbo.Questions", "SubjectClassTopicId");
            CreateIndex("dbo.Questions", "SubjectId");
            CreateIndex("dbo.Questions", "ClassId");
            CreateIndex("dbo.Questions", "TopicId");
            AddForeignKey("dbo.Questions", "TopicId", "dbo.Topics", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Questions", "SubjectId", "dbo.Subjects", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Questions", "ClassId", "dbo.Classes", "Id", cascadeDelete: true);
        }
    }
}

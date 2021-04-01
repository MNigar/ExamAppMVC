namespace ExamAppMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletetopictable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubjectClassTopics", "TopicId", "dbo.Topics");
            DropIndex("dbo.SubjectClassTopics", new[] { "TopicId" });
            RenameColumn(table: "dbo.SubjectClassTopics", name: "TopicId", newName: "Topic_Id");
            AddColumn("dbo.SubjectClassTopics", "Topic", c => c.String());
            AlterColumn("dbo.SubjectClassTopics", "Topic_Id", c => c.Int());
            CreateIndex("dbo.SubjectClassTopics", "Topic_Id");
            AddForeignKey("dbo.SubjectClassTopics", "Topic_Id", "dbo.Topics", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubjectClassTopics", "Topic_Id", "dbo.Topics");
            DropIndex("dbo.SubjectClassTopics", new[] { "Topic_Id" });
            AlterColumn("dbo.SubjectClassTopics", "Topic_Id", c => c.Int(nullable: false));
            DropColumn("dbo.SubjectClassTopics", "Topic");
            RenameColumn(table: "dbo.SubjectClassTopics", name: "Topic_Id", newName: "TopicId");
            CreateIndex("dbo.SubjectClassTopics", "TopicId");
            AddForeignKey("dbo.SubjectClassTopics", "TopicId", "dbo.Topics", "Id", cascadeDelete: true);
        }
    }
}

namespace ExamAppMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedquestionanswerg : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.QuestionAnswers", "SubjectClassTopic_Id", "dbo.SubjectClassTopics");
            DropIndex("dbo.QuestionAnswers", new[] { "SubjectClassTopic_Id" });
            RenameColumn(table: "dbo.QuestionAnswers", name: "SubjectClassTopic_Id", newName: "SubjectClassTopicId");
            AlterColumn("dbo.QuestionAnswers", "SubjectClassTopicId", c => c.Int(nullable: false));
            CreateIndex("dbo.QuestionAnswers", "SubjectClassTopicId");
            AddForeignKey("dbo.QuestionAnswers", "SubjectClassTopicId", "dbo.SubjectClassTopics", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionAnswers", "SubjectClassTopicId", "dbo.SubjectClassTopics");
            DropIndex("dbo.QuestionAnswers", new[] { "SubjectClassTopicId" });
            AlterColumn("dbo.QuestionAnswers", "SubjectClassTopicId", c => c.Int());
            RenameColumn(table: "dbo.QuestionAnswers", name: "SubjectClassTopicId", newName: "SubjectClassTopic_Id");
            CreateIndex("dbo.QuestionAnswers", "SubjectClassTopic_Id");
            AddForeignKey("dbo.QuestionAnswers", "SubjectClassTopic_Id", "dbo.SubjectClassTopics", "Id");
        }
    }
}

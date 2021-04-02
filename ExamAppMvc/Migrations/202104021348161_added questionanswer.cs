namespace ExamAppMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedquestionanswer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuestionAnswers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Answer1 = c.String(),
                        Answer2 = c.String(),
                        Answer3 = c.String(),
                        TrueAnswer = c.String(),
                        SubjectClassTopic_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SubjectClassTopics", t => t.SubjectClassTopic_Id)
                .Index(t => t.SubjectClassTopic_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionAnswers", "SubjectClassTopic_Id", "dbo.SubjectClassTopics");
            DropIndex("dbo.QuestionAnswers", new[] { "SubjectClassTopic_Id" });
            DropTable("dbo.QuestionAnswers");
        }
    }
}

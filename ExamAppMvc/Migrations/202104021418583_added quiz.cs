namespace ExamAppMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedquiz : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewUserAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        SelectedAnswer = c.String(),
                        QuestionAnswerId = c.Int(nullable: false),
                        IsTure = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuestionAnswers", t => t.QuestionAnswerId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.QuestionAnswerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NewUserAnswers", "UserId", "dbo.Users");
            DropForeignKey("dbo.NewUserAnswers", "QuestionAnswerId", "dbo.QuestionAnswers");
            DropIndex("dbo.NewUserAnswers", new[] { "QuestionAnswerId" });
            DropIndex("dbo.NewUserAnswers", new[] { "UserId" });
            DropTable("dbo.NewUserAnswers");
        }
    }
}

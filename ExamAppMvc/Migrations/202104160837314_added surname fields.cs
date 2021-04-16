namespace ExamAppMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedsurnamefields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Surname", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Surname", c => c.String(nullable: false));
        }
    }
}

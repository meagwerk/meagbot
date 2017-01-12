namespace meagbot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialNew : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Self = c.String(),
                    })
                .PrimaryKey(t => t.QuestionId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Questions");
        }
    }
}

namespace SOLID.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSecond : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Second",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        First_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.First", t => t.First_Id)
                .Index(t => t.First_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Second", "First_Id", "dbo.First");
            DropIndex("dbo.Second", new[] { "First_Id" });
            DropTable("dbo.Second");
        }
    }
}

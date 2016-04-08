namespace SOLID.Context.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddFirst : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.First",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.First");
        }
    }
}

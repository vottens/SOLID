namespace SOLID.Context.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class UpdateFirst : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.First", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.First", "Description");
        }
    }
}

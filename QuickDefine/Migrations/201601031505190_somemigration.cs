namespace QuickDefine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class somemigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Definitions", "type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Definitions", "type");
        }
    }
}

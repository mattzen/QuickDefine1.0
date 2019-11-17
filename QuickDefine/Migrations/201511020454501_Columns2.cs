namespace QuickDefine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Columns2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Words", "type", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Words", "type", c => c.String(maxLength: 50));
        }
    }
}

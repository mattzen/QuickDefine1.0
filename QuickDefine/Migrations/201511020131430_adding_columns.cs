namespace QuickDefine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adding_columns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PolishWords", "type", c => c.String(maxLength: 50));
            AddColumn("dbo.Words", "type", c => c.String(maxLength: 50));
            AlterColumn("dbo.Words", "word", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Words", "word", c => c.String());
            DropColumn("dbo.Words", "type");
            DropColumn("dbo.PolishWords", "type");
        }
    }
}

namespace QuickDefine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            
            
           /* CreateTable(
                "dbo.PolishWords",
                c => new
                    {
                        polwordId = c.Int(nullable: false, identity: true),
                        word = c.String(),
                        wordId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.polwordId)
                .ForeignKey("dbo.Words", t => t.wordId, cascadeDelete: true)
                .Index(t => t.wordId);
            */
            AddColumn("dbo.Words", "type", c => c.String());
            AddColumn("dbo.PolishWords", "type", c => c.String());
            
        }
        
        public override void Down()
        {

        }
    }
}

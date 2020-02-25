namespace Loan_Comp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedClicksTable : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Clicks");
            AddColumn("dbo.Clicks", "ClickId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Clicks", "UserId", c => c.String());
            AddPrimaryKey("dbo.Clicks", "ClickId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Clicks");
            AlterColumn("dbo.Clicks", "UserId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Clicks", "ClickId");
            AddPrimaryKey("dbo.Clicks", "UserId");
        }
    }
}

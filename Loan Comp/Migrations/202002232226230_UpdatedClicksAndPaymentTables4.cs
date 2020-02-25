namespace Loan_Comp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedClicksAndPaymentTables4 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Clicks");
            AlterColumn("dbo.Clicks", "UserId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Clicks", "UserId");
            DropColumn("dbo.Clicks", "ClickId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clicks", "ClickId", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.Clicks");
            AlterColumn("dbo.Clicks", "UserId", c => c.String());
            AddPrimaryKey("dbo.Clicks", "ClickId");
        }
    }
}

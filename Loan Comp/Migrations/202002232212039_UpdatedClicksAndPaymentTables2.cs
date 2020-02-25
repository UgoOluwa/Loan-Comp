namespace Loan_Comp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedClicksAndPaymentTables2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Clicks");
            DropPrimaryKey("dbo.Payments");
            AddColumn("dbo.Clicks", "ClickId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Payments", "PaymentId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Clicks", "UserId", c => c.String());
            AlterColumn("dbo.Payments", "UserId", c => c.String());
            AddPrimaryKey("dbo.Clicks", "ClickId");
            AddPrimaryKey("dbo.Payments", "PaymentId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Payments");
            DropPrimaryKey("dbo.Clicks");
            AlterColumn("dbo.Payments", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Clicks", "UserId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Payments", "PaymentId");
            DropColumn("dbo.Clicks", "ClickId");
            AddPrimaryKey("dbo.Payments", "UserId");
            AddPrimaryKey("dbo.Clicks", "UserId");
        }
    }
}

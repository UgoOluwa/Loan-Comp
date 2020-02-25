namespace Loan_Comp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedClicksAndPaymentTables : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Clicks");
            DropPrimaryKey("dbo.Payments");
            AlterColumn("dbo.Clicks", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Payments", "UserId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Clicks", "UserId");
            AddPrimaryKey("dbo.Payments", "UserId");
            DropColumn("dbo.Clicks", "ClickId");
            DropColumn("dbo.Payments", "PaymentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Payments", "PaymentId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Clicks", "ClickId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Payments");
            DropPrimaryKey("dbo.Clicks");
            AlterColumn("dbo.Payments", "UserId", c => c.String());
            AlterColumn("dbo.Clicks", "UserId", c => c.String());
            AddPrimaryKey("dbo.Payments", "PaymentId");
            AddPrimaryKey("dbo.Clicks", "ClickId");
        }
    }
}

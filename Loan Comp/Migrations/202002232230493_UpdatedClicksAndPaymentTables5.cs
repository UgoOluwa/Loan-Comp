namespace Loan_Comp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedClicksAndPaymentTables5 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Payments");
            AlterColumn("dbo.Payments", "UserId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Payments", "UserId");
            DropColumn("dbo.Payments", "PaymentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Payments", "PaymentId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Payments");
            AlterColumn("dbo.Payments", "UserId", c => c.String());
            AddPrimaryKey("dbo.Payments", "PaymentId");
        }
    }
}

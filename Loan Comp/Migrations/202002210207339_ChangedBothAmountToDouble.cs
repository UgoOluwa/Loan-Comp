namespace Loan_Comp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedBothAmountToDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CompanyViewModels", "MinimumAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.CompanyViewModels", "MaximumAmount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CompanyViewModels", "MaximumAmount", c => c.Single(nullable: false));
            AlterColumn("dbo.CompanyViewModels", "MinimumAmount", c => c.Single(nullable: false));
        }
    }
}

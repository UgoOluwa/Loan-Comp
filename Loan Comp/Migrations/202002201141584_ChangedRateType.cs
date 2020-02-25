namespace Loan_Comp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedRateType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CompanyViewModels", "Rate", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CompanyViewModels", "Rate", c => c.String());
        }
    }
}

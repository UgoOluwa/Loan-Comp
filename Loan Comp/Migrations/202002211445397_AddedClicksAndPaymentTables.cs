namespace Loan_Comp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedClicksAndPaymentTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CompanyViewModels", "Count", c => c.Int(nullable: false));
            AddColumn("dbo.CompanyViewModels", "UniqueCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CompanyViewModels", "UniqueCount");
            DropColumn("dbo.CompanyViewModels", "Count");
        }
    }
}

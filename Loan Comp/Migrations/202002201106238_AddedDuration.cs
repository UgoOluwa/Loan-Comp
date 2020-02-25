namespace Loan_Comp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDuration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CompanyViewModels", "Duration", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CompanyViewModels", "Duration");
        }
    }
}

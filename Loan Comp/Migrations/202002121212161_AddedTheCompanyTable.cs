namespace Loan_Comp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTheCompanyTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompanyViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MinimumAmount = c.Single(nullable: false),
                        Name = c.String(),
                        Terms = c.String(),
                        Rate = c.String(),
                        LoanPurpose = c.String(nullable: false),
                        Link = c.String(),
                        MaximumAmount = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CompanyViewModels");
        }
    }
}

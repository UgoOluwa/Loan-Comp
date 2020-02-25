namespace Loan_Comp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedClicksAndPaymentTables1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clicks",
                c => new
                    {
                        ClickId = c.Int(nullable: false, identity: true),
                        Company_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ClickId)
                .ForeignKey("dbo.CompanyViewModels", t => t.Company_Id)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.Company_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentId = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PaymentId)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "User_Id", "dbo.User");
            DropForeignKey("dbo.Clicks", "User_Id", "dbo.User");
            DropForeignKey("dbo.Clicks", "Company_Id", "dbo.CompanyViewModels");
            DropIndex("dbo.Payments", new[] { "User_Id" });
            DropIndex("dbo.Clicks", new[] { "User_Id" });
            DropIndex("dbo.Clicks", new[] { "Company_Id" });
            DropTable("dbo.Payments");
            DropTable("dbo.Clicks");
        }
    }
}

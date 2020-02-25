namespace Loan_Comp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedUserAndCompanyIds : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clicks", "Company_Id", "dbo.CompanyViewModels");
            DropForeignKey("dbo.Clicks", "User_Id", "dbo.User");
            DropIndex("dbo.Clicks", new[] { "Company_Id" });
            DropIndex("dbo.Clicks", new[] { "User_Id" });
            AddColumn("dbo.Clicks", "UserId", c => c.String());
            AddColumn("dbo.Clicks", "CompanyId", c => c.Int(nullable: false));
            DropColumn("dbo.Clicks", "Company_Id");
            DropColumn("dbo.Clicks", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clicks", "User_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Clicks", "Company_Id", c => c.Int());
            DropColumn("dbo.Clicks", "CompanyId");
            DropColumn("dbo.Clicks", "UserId");
            CreateIndex("dbo.Clicks", "User_Id");
            CreateIndex("dbo.Clicks", "Company_Id");
            AddForeignKey("dbo.Clicks", "User_Id", "dbo.User", "UserId");
            AddForeignKey("dbo.Clicks", "Company_Id", "dbo.CompanyViewModels", "Id");
        }
    }
}

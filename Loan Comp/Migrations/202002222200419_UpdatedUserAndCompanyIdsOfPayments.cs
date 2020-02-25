namespace Loan_Comp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedUserAndCompanyIdsOfPayments : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Payments", "User_Id", "dbo.User");
            DropIndex("dbo.Payments", new[] { "User_Id" });
            AddColumn("dbo.Payments", "UserId", c => c.String());
            DropColumn("dbo.Payments", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Payments", "User_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Payments", "UserId");
            CreateIndex("dbo.Payments", "User_Id");
            AddForeignKey("dbo.Payments", "User_Id", "dbo.User", "UserId");
        }
    }
}

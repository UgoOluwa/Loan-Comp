namespace Loan_Comp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTheInfoTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Infoes",
                c => new
                    {
                        InfoId = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        Amount = c.Double(nullable: false),
                        Duration = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.InfoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Infoes");
        }
    }
}

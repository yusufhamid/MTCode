namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Person", "CreditEarned", c => c.Int());
            AddColumn("dbo.Person", "GPA", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Person", "Address_ID", c => c.Int());
            CreateIndex("dbo.Person", "Address_ID");
            AddForeignKey("dbo.Person", "Address_ID", "dbo.Address", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Person", "Address_ID", "dbo.Address");
            DropIndex("dbo.Person", new[] { "Address_ID" });
            DropColumn("dbo.Person", "Address_ID");
            DropColumn("dbo.Person", "GPA");
            DropColumn("dbo.Person", "CreditEarned");
            DropTable("dbo.Address");
        }
    }
}

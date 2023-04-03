namespace WebBike.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUser4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        userId = c.String(maxLength: 128),
                        bikeName = c.String(),
                        bikeImage = c.String(),
                        price = c.Int(nullable: false),
                        number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.userId)
                .Index(t => t.userId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "userId", "dbo.AspNetUsers");
            DropIndex("dbo.Carts", new[] { "userId" });
            DropTable("dbo.Carts");
        }
    }
}

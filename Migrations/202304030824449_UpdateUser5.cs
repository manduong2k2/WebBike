namespace WebBike.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUser5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "userId", "dbo.AspNetUsers");
            DropIndex("dbo.Carts", new[] { "userId" });
            DropColumn("dbo.Carts", "userId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carts", "userId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Carts", "userId");
            AddForeignKey("dbo.Carts", "userId", "dbo.AspNetUsers", "Id");
        }
    }
}

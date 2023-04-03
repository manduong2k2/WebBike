namespace WebBike.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUser : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "type", c => c.Int(nullable: false));
        }
    }
}

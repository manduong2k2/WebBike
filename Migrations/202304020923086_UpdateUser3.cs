﻿namespace WebBike.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUser3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "type");
        }
    }
}

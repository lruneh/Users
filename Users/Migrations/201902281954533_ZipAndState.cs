namespace Users.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ZipAndState : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ZipCode", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "State", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "State");
            DropColumn("dbo.AspNetUsers", "ZipCode");
        }
    }
}

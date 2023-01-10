namespace _02_KT.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IslemIdDrop : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Kitaps", "IslemId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Kitaps", "IslemId", c => c.Int(nullable: false));
        }
    }
}

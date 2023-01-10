namespace _02_KT.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnKitapAdiToKitapTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kitaps", "KitapAdi", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Kitaps", "KitapAdi");
        }
    }
}

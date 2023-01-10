namespace _02_KT.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_DatabaseForYazarSoyadUpdated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Yazars", "YazarAd", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Yazars", "YazarAd", c => c.String(nullable: false));
        }
    }
}

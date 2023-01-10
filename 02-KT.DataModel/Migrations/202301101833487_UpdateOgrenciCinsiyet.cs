namespace _02_KT.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOgrenciCinsiyet : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ogrencis", "Cinsiyet", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ogrencis", "Cinsiyet", c => c.Boolean(nullable: false));
        }
    }
}

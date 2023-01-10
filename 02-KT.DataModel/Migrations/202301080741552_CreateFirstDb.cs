namespace _02_KT.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateFirstDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Islems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OgrenciId = c.String(nullable: false),
                        kitapId = c.String(nullable: false),
                        ATarih = c.DateTime(nullable: false),
                        VTarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Kitaps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IslemId = c.Int(nullable: false),
                        YazaId = c.Int(nullable: false),
                        TurId = c.Int(nullable: false),
                        SayfaSayisi = c.Single(nullable: false),
                        Puan = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ogrencis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OgrenciAd = c.String(nullable: false, maxLength: 50),
                        OgrenciSoyad = c.String(nullable: false, maxLength: 50),
                        Cinsiyet = c.Boolean(nullable: false),
                        DogumTarih = c.DateTime(nullable: false),
                        Sinif = c.String(nullable: false, maxLength: 10),
                        Puan = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Turs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TurAdi = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Yazars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        YazarAd = c.String(nullable: false),
                        YazarSoyad = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Yazars");
            DropTable("dbo.Turs");
            DropTable("dbo.Ogrencis");
            DropTable("dbo.Kitaps");
            DropTable("dbo.Islems");
        }
    }
}

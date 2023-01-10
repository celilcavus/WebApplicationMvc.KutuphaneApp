using _01_KT.Entity.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace _02_KT.DataModel.Model
{
    public class AppDbContext : DbContext
    {
        public DbSet<Islem> Islems { get; set; }
        public DbSet<Kitap> Kitaps { get; set; }
        public DbSet<Ogrenci> Ogrenci { get; set; }
        public DbSet<Tur> Tur { get; set; }
        public DbSet<Yazar> yazars { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            #region Islem Entity & Fluent Api
            modelBuilder.Entity<Islem>()
               .HasKey(x => x.Id)
               .Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Islem>().Property(x => x.OgrenciId).IsRequired();
            modelBuilder.Entity<Islem>().Property(x => x.kitapId).IsRequired();
            #endregion

            #region Kitap Entity & Fluent Api
            modelBuilder.Entity<Kitap>()
                .HasKey(x => x.Id).Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //modelBuilder.Entity<Kitap>().Property(x => x.IslemId).IsRequired();
            modelBuilder.Entity<Kitap>().Property(x => x.KitapAdi).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Kitap>().Property(x => x.YazaId).IsRequired();
            modelBuilder.Entity<Kitap>().Property(x => x.TurId).IsRequired();
            modelBuilder.Entity<Kitap>().Property(x => x.SayfaSayisi).IsRequired();
            #endregion

            #region Ogrenci Entity & Fluent Api
            modelBuilder.Entity<Ogrenci>()
                .HasKey(x => x.Id)
                .Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            ///
            modelBuilder.Entity<Ogrenci>().Property(x => x.OgrenciAd)
                .HasMaxLength(50)
                .IsRequired();
            ///
            modelBuilder.Entity<Ogrenci>().Property(x => x.OgrenciSoyad)
                .HasMaxLength(50)
                .IsRequired();
            ///
            modelBuilder.Entity<Ogrenci>().Property(x => x.Cinsiyet).IsRequired();
            ///
            modelBuilder.Entity<Ogrenci>().Property(x => x.Sinif).IsRequired()
                .HasMaxLength(10);
            ///
            modelBuilder.Entity<Ogrenci>().Property(x => x.Puan).IsRequired();
            #endregion

            #region Tur Entity & Fluent Api
            modelBuilder.Entity<Tur>().HasKey(x => x.Id)
                .Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            ///
            modelBuilder.Entity<Tur>().Property(x => x.TurAdi).IsRequired().HasMaxLength(25);
            #endregion

            #region Yazar Entity & Fluent Api
            modelBuilder.Entity<Yazar>()
                .HasKey(x => x.Id)
                .Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            ///
            modelBuilder.Entity<Yazar>()
                .Property(x => x.YazarAd)
                .IsRequired()
                .HasMaxLength(20);
            ///
            modelBuilder.Entity<Yazar>()
                .Property(x => x.YazarSoyad)
                .IsRequired()
                .HasMaxLength(20);
            #endregion

        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}

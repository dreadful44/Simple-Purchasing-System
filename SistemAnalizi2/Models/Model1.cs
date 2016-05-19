namespace SistemAnalizi2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model11")
        {
        }

        public virtual DbSet<adre> adres { get; set; }
        public virtual DbSet<ilceler> ilcelers { get; set; }
        public virtual DbSet<iller> illers { get; set; }
        public virtual DbSet<kargoFirmalari> kargoFirmalaris { get; set; }
        public virtual DbSet<kategori> kategoris { get; set; }
        public virtual DbSet<markalar> markalars { get; set; }
        public virtual DbSet<musteriler> musterilers { get; set; }
        public virtual DbSet<odemeTurleri> odemeTurleris { get; set; }
        public virtual DbSet<siparisler> siparislers { get; set; }
        public virtual DbSet<siparisTakibi> siparisTakibis { get; set; }
        public virtual DbSet<siparisUrunleri> siparisUrunleris { get; set; }
        public virtual DbSet<stokBilgisi> stokBilgisis { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<urunler> urunlers { get; set; }
        public virtual DbSet<yoneticiler> yoneticilers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<adre>()
                .Property(e => e.adresTipi)
                .IsUnicode(false);

            modelBuilder.Entity<adre>()
                .Property(e => e.adres)
                .IsUnicode(false);

            modelBuilder.Entity<ilceler>()
                .Property(e => e.ilceAdi)
                .IsUnicode(false);

            modelBuilder.Entity<ilceler>()
                .HasMany(e => e.adres)
                .WithRequired(e => e.ilceler)
                .HasForeignKey(e => e.ilceler_ilcelerID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<iller>()
                .Property(e => e.ilAdi)
                .IsUnicode(false);

            modelBuilder.Entity<iller>()
                .HasMany(e => e.ilcelers)
                .WithRequired(e => e.iller)
                .HasForeignKey(e => e.iller_illerID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<kargoFirmalari>()
                .Property(e => e.firmaAdi)
                .IsUnicode(false);

            modelBuilder.Entity<kargoFirmalari>()
                .HasMany(e => e.siparisTakibis)
                .WithRequired(e => e.kargoFirmalari)
                .HasForeignKey(e => e.KargoFirmalari_KargoFirmalariID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<kategori>()
                .Property(e => e.kategoriAdi)
                .IsUnicode(false);

            modelBuilder.Entity<kategori>()
                .HasMany(e => e.urunlers)
                .WithRequired(e => e.kategori)
                .HasForeignKey(e => e.kategori_kategoriID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<markalar>()
                .Property(e => e.markaAdi)
                .IsUnicode(false);

            modelBuilder.Entity<markalar>()
                .HasMany(e => e.urunlers)
                .WithRequired(e => e.markalar)
                .HasForeignKey(e => e.markalar_markaID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<musteriler>()
                .Property(e => e.adi)
                .IsUnicode(false);

            modelBuilder.Entity<musteriler>()
                .Property(e => e.soyadi)
                .IsUnicode(false);

            modelBuilder.Entity<musteriler>()
                .Property(e => e.telefon)
                .IsUnicode(false);

            modelBuilder.Entity<musteriler>()
                .Property(e => e.kullaniciAdi)
                .IsUnicode(false);

            modelBuilder.Entity<musteriler>()
                .Property(e => e.sifre)
                .IsUnicode(false);

            modelBuilder.Entity<musteriler>()
                .Property(e => e.eposta)
                .IsUnicode(false);

            modelBuilder.Entity<musteriler>()
                .HasMany(e => e.adres)
                .WithRequired(e => e.musteriler)
                .HasForeignKey(e => e.musteriler_musterilerID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<musteriler>()
                .HasMany(e => e.siparislers)
                .WithRequired(e => e.musteriler)
                .HasForeignKey(e => e.musteriler_musterilerID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<odemeTurleri>()
                .Property(e => e.tipAdi)
                .IsUnicode(false);

            modelBuilder.Entity<odemeTurleri>()
                .HasMany(e => e.siparislers)
                .WithRequired(e => e.odemeTurleri)
                .HasForeignKey(e => e.odemeTurleri_odemeTurleriID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<siparisler>()
                .Property(e => e.toplamFiyat)
                .IsUnicode(false);

            modelBuilder.Entity<siparisler>()
                .HasMany(e => e.siparisUrunleris)
                .WithRequired(e => e.siparisler)
                .HasForeignKey(e => e.siparisler_siparislerID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<siparisTakibi>()
                .Property(e => e.siparisDurumu)
                .IsUnicode(false);

            modelBuilder.Entity<siparisTakibi>()
                .Property(e => e.siparisTarihi)
                .IsUnicode(false);

            modelBuilder.Entity<siparisTakibi>()
                .Property(e => e.tahminiTeslimTarihi)
                .IsUnicode(false);

            modelBuilder.Entity<siparisTakibi>()
                .Property(e => e.teslimTarihi)
                .IsUnicode(false);

            modelBuilder.Entity<siparisTakibi>()
                .HasMany(e => e.siparislers)
                .WithRequired(e => e.siparisTakibi)
                .HasForeignKey(e => e.siparisTakibi_kargolamaID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<siparisUrunleri>()
                .Property(e => e.adet)
                .IsUnicode(false);

            modelBuilder.Entity<stokBilgisi>()
                .Property(e => e.stokSayisi)
                .IsUnicode(false);

            modelBuilder.Entity<stokBilgisi>()
                .HasMany(e => e.urunlers)
                .WithRequired(e => e.stokBilgisi)
                .HasForeignKey(e => e.stokBilgisi_stokID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<urunler>()
                .Property(e => e.urunAdi)
                .IsUnicode(false);

            modelBuilder.Entity<urunler>()
                .Property(e => e.fiyati)
                .IsUnicode(false);

            modelBuilder.Entity<urunler>()
                .HasMany(e => e.siparisUrunleris)
                .WithRequired(e => e.urunler)
                .HasForeignKey(e => e.urunler_urunlerID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<yoneticiler>()
                .Property(e => e.adi)
                .IsUnicode(false);

            modelBuilder.Entity<yoneticiler>()
                .Property(e => e.soyadi)
                .IsUnicode(false);

            modelBuilder.Entity<yoneticiler>()
                .Property(e => e.telefon)
                .IsUnicode(false);

            modelBuilder.Entity<yoneticiler>()
                .Property(e => e.kullaniciAdi)
                .IsUnicode(false);

            modelBuilder.Entity<yoneticiler>()
                .Property(e => e.sifre)
                .IsUnicode(false);

            modelBuilder.Entity<yoneticiler>()
                .Property(e => e.eposta)
                .IsUnicode(false);
        }
    }
}

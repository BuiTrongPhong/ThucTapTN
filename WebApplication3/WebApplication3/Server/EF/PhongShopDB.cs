using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebApplication3.Server.EF
{
    public partial class PhongShopDB : DbContext
    {
        public PhongShopDB()
            : base("name=PhongShopDB")
        {
        }

        public virtual DbSet<BinhLuan> BinhLuans { get; set; }
        public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<ShippingMethod> ShippingMethods { get; set; }
        public virtual DbSet<SlideNewProduct> SlideNewProducts { get; set; }
        public virtual DbSet<SlideSearchTrending> SlideSearchTrendings { get; set; }
        public virtual DbSet<SlideTopSeller> SlideTopSellers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<SystemConfig> SystemConfigs { get; set; }
        public virtual DbSet<TheLoai> TheLoais { get; set; }
        public virtual DbSet<TinTuc> TinTucs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BinhLuan>()
                .Property(e => e.maKH)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietDonHang>()
                .Property(e => e.price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Discount>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.confirmPassword)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.size)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.type)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.createdBy)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.material)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.comparePrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.promotion)
                .IsUnicode(false);

            modelBuilder.Entity<ShippingMethod>()
                .Property(e => e.price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SlideSearchTrending>()
                .Property(e => e.spId)
                .IsUnicode(false);

            modelBuilder.Entity<SlideTopSeller>()
                .Property(e => e.spId)
                .IsUnicode(false);

            modelBuilder.Entity<TheLoai>()
                .Property(e => e.createdBy)
                .IsUnicode(false);

            modelBuilder.Entity<TinTuc>()
                .Property(e => e.createdBy)
                .IsUnicode(false);

            modelBuilder.Entity<TinTuc>()
                .Property(e => e.link)
                .IsUnicode(false);

            modelBuilder.Entity<TinTuc>()
                .Property(e => e.status)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DAL_QLBH.Models;

#nullable disable

namespace DAL_QLBH.Context
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<HoaDonCt> HoaDonCts { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-NPEJLEB\\SQLEXPRESS;Initial Catalog=DAM1;User ID=btn1;Password=123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.Property(e => e.MaKh).IsUnicode(false);

                entity.Property(e => e.MaNv).IsUnicode(false);

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.MaKh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HoaDon_KhachHang");

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.MaNv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HoaDon_NhanVien");
            });

            modelBuilder.Entity<HoaDonCt>(entity =>
            {
                entity.HasKey(e => new { e.MaHd, e.MaSp });

                entity.Property(e => e.MaHd).ValueGeneratedOnAdd();

                entity.Property(e => e.MaSp).IsUnicode(false);

                entity.HasOne(d => d.MaHdNavigation)
                    .WithMany(p => p.HoaDonCts)
                    .HasForeignKey(d => d.MaHd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HoaDonCT_HoaDon");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.HoaDonCts)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HoaDonCT_SanPham");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.Property(e => e.MaKh).IsUnicode(false);

                entity.Property(e => e.Dienthoai).IsUnicode(false);

                entity.Property(e => e.MaNv).IsUnicode(false);

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.KhachHangs)
                    .HasForeignKey(d => d.MaNv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KhachHang_NhanVien");
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.Property(e => e.MaNv).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Matkhau).IsUnicode(false);
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.Property(e => e.MaSp).IsUnicode(false);

                entity.Property(e => e.MaNv).IsUnicode(false);

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.MaNv)
                    .HasConstraintName("FK_SanPham_NhanVien");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

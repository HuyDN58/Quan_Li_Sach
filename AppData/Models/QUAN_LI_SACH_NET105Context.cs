using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AppData.Models
{
    public partial class QUAN_LI_SACH_NET105Context : DbContext
    {
        public QUAN_LI_SACH_NET105Context()
        {
        }

        public QUAN_LI_SACH_NET105Context(DbContextOptions<QUAN_LI_SACH_NET105Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<GioHang> GioHangs { get; set; } = null!;
        public virtual DbSet<GioHangCt> GioHangCts { get; set; } = null!;
        public virtual DbSet<HoaDon> HoaDons { get; set; } = null!;
        public virtual DbSet<HoaDonCt> HoaDonCts { get; set; } = null!;
        public virtual DbSet<KhachHang> KhachHangs { get; set; } = null!;
        public virtual DbSet<KhuyenMai> KhuyenMais { get; set; } = null!;
        public virtual DbSet<NhanVien> NhanViens { get; set; } = null!;
        public virtual DbSet<Nxb> Nxbs { get; set; } = null!;
        public virtual DbSet<SanPham> SanPhams { get; set; } = null!;
        public virtual DbSet<SanPhamCt> SanPhamCts { get; set; } = null!;
        public virtual DbSet<TacGia> TacGia { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=IMac\SQLEXPRESS;Initial Catalog=QUAN_LI_SACH_NET105;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.IdnguoiDung)
                    .HasName("PK__Account__FCD7DB097A961C94");

                entity.ToTable("Account");

                entity.HasIndex(e => e.TaiKhoan, "UQ__Account__D5B8C7F0938C33AA")
                    .IsUnique();

                entity.Property(e => e.IdnguoiDung)
                    .HasColumnName("IDNguoiDung")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.MatKhau).HasMaxLength(50);

                entity.Property(e => e.TaiKhoan)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GioHang>(entity =>
            {
                entity.HasKey(e => e.Idgh)
                    .HasName("PK__GioHang__B87DE222D100450C");

                entity.ToTable("GioHang");

                entity.Property(e => e.Idgh)
                    .HasColumnName("IDGH")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Idkh).HasColumnName("IDKH");

                entity.HasOne(d => d.IdkhNavigation)
                    .WithMany(p => p.GioHangs)
                    .HasForeignKey(d => d.Idkh)
                    .HasConstraintName("FK__GioHang__IDKH__7F2BE32F");
            });

            modelBuilder.Entity<GioHangCt>(entity =>
            {
                entity.HasKey(e => e.Idghct)
                    .HasName("PK__GioHangC__D592581F54369A12");

                entity.ToTable("GioHangCT");

                entity.Property(e => e.Idghct)
                    .HasColumnName("IDGHCT")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Idgh).HasColumnName("IDGH");

                entity.Property(e => e.Idspct).HasColumnName("IDSPCT");

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdghNavigation)
                    .WithMany(p => p.GioHangCts)
                    .HasForeignKey(d => d.Idgh)
                    .HasConstraintName("FK__GioHangCT__IDGH__7E37BEF6");

                entity.HasOne(d => d.IdspctNavigation)
                    .WithMany(p => p.GioHangCts)
                    .HasForeignKey(d => d.Idspct)
                    .HasConstraintName("FK__GioHangCT__IDSPC__7D439ABD");
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.HasKey(e => e.Idhd)
                    .HasName("PK__HoaDon__B87C1A07599CB17A");

                entity.ToTable("HoaDon");

                entity.HasIndex(e => e.MaHd, "UQ__HoaDon__2725A6E11AE619B6")
                    .IsUnique();

                entity.Property(e => e.Idhd)
                    .HasColumnName("IDHD")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Idkh).HasColumnName("IDKH");

                entity.Property(e => e.Idkm).HasColumnName("IDKM");

                entity.Property(e => e.Idnv).HasColumnName("IDNV");

                entity.Property(e => e.MaHd)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MaHD");

                entity.Property(e => e.NgayTao).HasColumnType("date");

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdkhNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.Idkh)
                    .HasConstraintName("FK__HoaDon__IDKH__797309D9");

                entity.HasOne(d => d.IdkmNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.Idkm)
                    .HasConstraintName("FK__HoaDon__IDKM__7B5B524B");

                entity.HasOne(d => d.IdnvNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.Idnv)
                    .HasConstraintName("FK__HoaDon__IDNV__7A672E12");
            });

            modelBuilder.Entity<HoaDonCt>(entity =>
            {
                entity.HasKey(e => e.Idhdct)
                    .HasName("PK__HoaDonCT__F8B33677718DB99B");

                entity.ToTable("HoaDonCT");

                entity.HasIndex(e => e.SoLuong, "UQ__HoaDonCT__556FA067A5B4F8EF")
                    .IsUnique();

                entity.Property(e => e.Idhdct)
                    .HasColumnName("IDHDCT")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Idhd).HasColumnName("IDHD");

                entity.Property(e => e.Idspct).HasColumnName("IDSPCT");

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdhdNavigation)
                    .WithMany(p => p.HoaDonCts)
                    .HasForeignKey(d => d.Idhd)
                    .HasConstraintName("FK__HoaDonCT__IDHD__76969D2E");

                entity.HasOne(d => d.IdspctNavigation)
                    .WithMany(p => p.HoaDonCts)
                    .HasForeignKey(d => d.Idspct)
                    .HasConstraintName("FK__HoaDonCT__IDSPCT__778AC167");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.Idkh)
                    .HasName("PK__KhachHan__B87DC1A74AD4F6F2");

                entity.ToTable("KhachHang");

                entity.HasIndex(e => e.Ma, "UQ__KhachHan__3214CC9E87525964")
                    .IsUnique();

                entity.Property(e => e.Idkh)
                    .HasColumnName("IDKH")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.DiaChi).HasMaxLength(100);

                entity.Property(e => e.IdnguoiDung).HasColumnName("IDNguoiDung");

                entity.Property(e => e.Ma)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Sdt)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("SDT");

                entity.Property(e => e.TenKh)
                    .HasMaxLength(30)
                    .HasColumnName("TenKH");

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdnguoiDungNavigation)
                    .WithMany(p => p.KhachHangs)
                    .HasForeignKey(d => d.IdnguoiDung)
                    .HasConstraintName("FK__KhachHang__IDNgu__7C4F7684");
            });

            modelBuilder.Entity<KhuyenMai>(entity =>
            {
                entity.HasKey(e => e.Idkm)
                    .HasName("PK__KhuyenMa__B87DC1AAD1E6023E");

                entity.ToTable("KhuyenMai");

                entity.HasIndex(e => e.MaKm, "UQ__KhuyenMa__2725CF1420F347DB")
                    .IsUnique();

                entity.Property(e => e.Idkm)
                    .HasColumnName("IDKM")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.MaKm)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MaKM");

                entity.Property(e => e.NgayBd)
                    .HasColumnType("date")
                    .HasColumnName("NgayBD");

                entity.Property(e => e.NgayKt)
                    .HasColumnType("date")
                    .HasColumnName("NgayKT");

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.Idnv)
                    .HasName("PK__NhanVien__B87DC9B209D9DF83");

                entity.ToTable("NhanVien");

                entity.HasIndex(e => e.MaNv, "UQ__NhanVien__2725D70B6E95CB40")
                    .IsUnique();

                entity.Property(e => e.Idnv)
                    .HasColumnName("IDNV")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.DiaChi).HasMaxLength(100);

                entity.Property(e => e.IdnguoiDung).HasColumnName("IDNguoiDung");

                entity.Property(e => e.MaNv)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MaNV");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("SDT");

                entity.Property(e => e.TenNv)
                    .HasMaxLength(30)
                    .HasColumnName("TenNV");

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdnguoiDungNavigation)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.IdnguoiDung)
                    .HasConstraintName("FK__NhanVien__IDNguo__787EE5A0");
            });

            modelBuilder.Entity<Nxb>(entity =>
            {
                entity.HasKey(e => e.Idnxb)
                    .HasName("PK__NXB__945B98FB6E74D8C6");

                entity.ToTable("NXB");

                entity.HasIndex(e => e.Mansx, "UQ__NXB__7ABD278C2C5293DF")
                    .IsUnique();

                entity.Property(e => e.Idnxb)
                    .HasColumnName("IDNXB")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Mansx)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MANSX");

                entity.Property(e => e.TenNxb)
                    .HasMaxLength(30)
                    .HasColumnName("TenNXB");
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.Idsp)
                    .HasName("PK__SanPham__B87C02A5E1DD8D57");

                entity.ToTable("SanPham");

                entity.HasIndex(e => e.MaSp, "UQ__SanPham__2725081DD7C2DF5F")
                    .IsUnique();

                entity.Property(e => e.Idsp)
                    .HasColumnName("IDSP")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.MaSp)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MaSP");

                entity.Property(e => e.TenSp)
                    .HasMaxLength(50)
                    .HasColumnName("TenSP");
            });

            modelBuilder.Entity<SanPhamCt>(entity =>
            {
                entity.HasKey(e => e.Idspct)
                    .HasName("PK__SanPhamC__83F7208FA954EE61");

                entity.ToTable("SanPhamCT");

                entity.Property(e => e.Idspct)
                    .HasColumnName("IDSPCT")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.GiaBan)
                    .HasColumnType("decimal(20, 0)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GiaNhap)
                    .HasColumnType("decimal(20, 0)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Idnxb).HasColumnName("IDNXB");

                entity.Property(e => e.Idsp).HasColumnName("IDSP");

                entity.Property(e => e.Idtg).HasColumnName("IDTG");

                entity.Property(e => e.MoTa).HasMaxLength(50);

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdnxbNavigation)
                    .WithMany(p => p.SanPhamCts)
                    .HasForeignKey(d => d.Idnxb)
                    .HasConstraintName("FK__SanPhamCT__IDNXB__75A278F5");

                entity.HasOne(d => d.IdspNavigation)
                    .WithMany(p => p.SanPhamCts)
                    .HasForeignKey(d => d.Idsp)
                    .HasConstraintName("FK__SanPhamCT__IDSP__73BA3083");

                entity.HasOne(d => d.IdtgNavigation)
                    .WithMany(p => p.SanPhamCts)
                    .HasForeignKey(d => d.Idtg)
                    .HasConstraintName("FK__SanPhamCT__IDTG__74AE54BC");
            });

            modelBuilder.Entity<TacGia>(entity =>
            {
                entity.HasKey(e => e.Idtg)
                    .HasName("PK__TacGia__B87C3A8F63E83118");

                entity.HasIndex(e => e.Matg, "UQ__TacGia__6023721B761EEB4A")
                    .IsUnique();

                entity.Property(e => e.Idtg)
                    .HasColumnName("IDTG")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Matg)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MATG");

                entity.Property(e => e.TenTg)
                    .HasMaxLength(30)
                    .HasColumnName("TenTG");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

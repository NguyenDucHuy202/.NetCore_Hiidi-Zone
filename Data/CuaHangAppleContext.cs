using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Hiidi_Zone_Ecommerce.Data;

public partial class CuaHangAppleContext : DbContext
{
    public CuaHangAppleContext()
    {
    }

    public CuaHangAppleContext(DbContextOptions<CuaHangAppleContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChiTietDanhSachYeuThich> ChiTietDanhSachYeuThiches { get; set; }

    public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }

    public virtual DbSet<ChiTietGioHang> ChiTietGioHangs { get; set; }

    public virtual DbSet<DanhGium> DanhGia { get; set; }

    public virtual DbSet<DanhMuc> DanhMucs { get; set; }

    public virtual DbSet<DanhSachYeuThich> DanhSachYeuThiches { get; set; }

    public virtual DbSet<DiaChiNguoiDung> DiaChiNguoiDungs { get; set; }

    public virtual DbSet<DonHang> DonHangs { get; set; }

    public virtual DbSet<GioHang> GioHangs { get; set; }

    public virtual DbSet<HinhAnhSanPham> HinhAnhSanPhams { get; set; }

    public virtual DbSet<LichSuThanhToan> LichSuThanhToans { get; set; }

    public virtual DbSet<MaGiamGium> MaGiamGia { get; set; }

    public virtual DbSet<NguoiDung> NguoiDungs { get; set; }

    public virtual DbSet<QuanTriVien> QuanTriViens { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    public virtual DbSet<ThanhToan> ThanhToans { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=DUCQUI;Initial Catalog=CuaHangApple;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChiTietDanhSachYeuThich>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ChiTietD__3214EC07E33588D7");

            entity.ToTable("ChiTietDanhSachYeuThich");

            entity.Property(e => e.NgayThem)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.DanhSachYeuThich).WithMany(p => p.ChiTietDanhSachYeuThiches)
                .HasForeignKey(d => d.DanhSachYeuThichId)
                .HasConstraintName("FK__ChiTietDa__DanhS__76969D2E");

            entity.HasOne(d => d.SanPham).WithMany(p => p.ChiTietDanhSachYeuThiches)
                .HasForeignKey(d => d.SanPhamId)
                .HasConstraintName("FK__ChiTietDa__SanPh__778AC167");
        });

        modelBuilder.Entity<ChiTietDonHang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ChiTietD__3214EC076612C66D");

            entity.ToTable("ChiTietDonHang");

            entity.Property(e => e.Gia).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.DonHang).WithMany(p => p.ChiTietDonHangs)
                .HasForeignKey(d => d.DonHangId)
                .HasConstraintName("FK__ChiTietDo__DonHa__5DCAEF64");

            entity.HasOne(d => d.SanPham).WithMany(p => p.ChiTietDonHangs)
                .HasForeignKey(d => d.SanPhamId)
                .HasConstraintName("FK__ChiTietDo__SanPh__5EBF139D");
        });

        modelBuilder.Entity<ChiTietGioHang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ChiTietG__3214EC07B4945E97");

            entity.ToTable("ChiTietGioHang");

            entity.Property(e => e.SoLuong).HasDefaultValue(1);

            entity.HasOne(d => d.GioHang).WithMany(p => p.ChiTietGioHangs)
                .HasForeignKey(d => d.GioHangId)
                .HasConstraintName("FK__ChiTietGi__GioHa__7F2BE32F");

            entity.HasOne(d => d.SanPham).WithMany(p => p.ChiTietGioHangs)
                .HasForeignKey(d => d.SanPhamId)
                .HasConstraintName("FK__ChiTietGi__SanPh__00200768");
        });

        modelBuilder.Entity<DanhGium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DanhGia__3214EC07D8484EEE");

            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.NguoiDung).WithMany(p => p.DanhGia)
                .HasForeignKey(d => d.NguoiDungId)
                .HasConstraintName("FK__DanhGia__NguoiDu__5165187F");

            entity.HasOne(d => d.SanPham).WithMany(p => p.DanhGia)
                .HasForeignKey(d => d.SanPhamId)
                .HasConstraintName("FK__DanhGia__SanPham__52593CB8");
        });

        modelBuilder.Entity<DanhMuc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DanhMuc__3214EC07BB075774");

            entity.ToTable("DanhMuc");

            entity.HasIndex(e => e.Ten, "UQ__DanhMuc__C451FA83D277EE5C").IsUnique();

            entity.Property(e => e.Ten).HasMaxLength(255);
        });

        modelBuilder.Entity<DanhSachYeuThich>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DanhSach__3214EC07A279DE21");

            entity.ToTable("DanhSachYeuThich");

            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.NguoiDung).WithMany(p => p.DanhSachYeuThiches)
                .HasForeignKey(d => d.NguoiDungId)
                .HasConstraintName("FK__DanhSachY__Nguoi__72C60C4A");
        });

        modelBuilder.Entity<DiaChiNguoiDung>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DiaChiNg__3214EC07F38D7D67");

            entity.ToTable("DiaChiNguoiDung");

            entity.Property(e => e.MaBuuChinh).HasMaxLength(20);
            entity.Property(e => e.QuocGia).HasMaxLength(255);
            entity.Property(e => e.ThanhPho).HasMaxLength(255);

            entity.HasOne(d => d.NguoiDung).WithMany(p => p.DiaChiNguoiDungs)
                .HasForeignKey(d => d.NguoiDungId)
                .HasConstraintName("FK__DiaChiNgu__Nguoi__3C69FB99");
        });

        modelBuilder.Entity<DonHang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DonHang__3214EC07624251DE");

            entity.ToTable("DonHang");

            entity.HasIndex(e => e.NguoiDungId, "IDX_DonHang_NguoiDungId");

            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TongGia).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(50)
                .HasDefaultValue("Cho xu ly");
            entity.Property(e => e.TrangThaiThanhToan)
                .HasMaxLength(50)
                .HasDefaultValue("Chua thanh toan");

            entity.HasOne(d => d.NguoiDung).WithMany(p => p.DonHangs)
                .HasForeignKey(d => d.NguoiDungId)
                .HasConstraintName("FK__DonHang__NguoiDu__59063A47");
        });

        modelBuilder.Entity<GioHang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GioHang__3214EC0706C0B405");

            entity.ToTable("GioHang");

            entity.HasOne(d => d.NguoiDung).WithMany(p => p.GioHangs)
                .HasForeignKey(d => d.NguoiDungId)
                .HasConstraintName("FK__GioHang__NguoiDu__7A672E12");
        });

        modelBuilder.Entity<HinhAnhSanPham>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HinhAnhS__3214EC07A44E8448");

            entity.ToTable("HinhAnhSanPham");

            entity.Property(e => e.DuongDan).HasMaxLength(255);

            entity.HasOne(d => d.SanPham).WithMany(p => p.HinhAnhSanPhams)
                .HasForeignKey(d => d.SanPhamId)
                .HasConstraintName("FK__HinhAnhSa__SanPh__4CA06362");
        });

        modelBuilder.Entity<LichSuThanhToan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LichSuTh__3214EC0769395B02");

            entity.ToTable("LichSuThanhToan");

            entity.Property(e => e.NgayThanhToan)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SoTien).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.DonHang).WithMany(p => p.LichSuThanhToans)
                .HasForeignKey(d => d.DonHangId)
                .HasConstraintName("FK__LichSuTha__DonHa__68487DD7");
        });

        modelBuilder.Entity<MaGiamGium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MaGiamGi__3214EC07B0158D0F");

            entity.HasIndex(e => e.Ma, "UQ__MaGiamGi__3214CC9E6BA297A2").IsUnique();

            entity.Property(e => e.Giam).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Ma).HasMaxLength(50);
            entity.Property(e => e.NgayHetHan).HasColumnType("datetime");
            entity.Property(e => e.SoLuong).HasDefaultValue(0);
            entity.Property(e => e.TrangThai)
                .HasMaxLength(50)
                .HasDefaultValue("Hoat dong");
        });

        modelBuilder.Entity<NguoiDung>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NguoiDun__3214EC07F3B52E08");

            entity.ToTable("NguoiDung");

            entity.HasIndex(e => e.Email, "IDX_NguoiDung_Email");

            entity.HasIndex(e => e.SoDienThoai, "UQ__NguoiDun__0389B7BD6E294947").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__NguoiDun__A9D10534BD71FF62").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.MatKhau).HasMaxLength(255);
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SoDienThoai).HasMaxLength(20);
            entity.Property(e => e.Ten).HasMaxLength(255);
        });

        modelBuilder.Entity<QuanTriVien>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__QuanTriV__3214EC075BA82FF4");

            entity.ToTable("QuanTriVien");

            entity.HasIndex(e => e.TenDangNhap, "UQ__QuanTriV__55F68FC035E5EDC1").IsUnique();

            entity.Property(e => e.MatKhau).HasMaxLength(255);
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TenDangNhap).HasMaxLength(255);
            entity.Property(e => e.VaiTro)
                .HasMaxLength(50)
                .HasDefaultValue("admin");
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SanPham__3214EC07DBAC9537");

            entity.ToTable("SanPham");

            entity.HasIndex(e => e.Ten, "IDX_SanPham_Ten");

            entity.Property(e => e.Gia).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Ten).HasMaxLength(255);

            entity.HasOne(d => d.DanhMuc).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.DanhMucId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__SanPham__DanhMuc__49C3F6B7");
        });

        modelBuilder.Entity<ThanhToan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ThanhToa__3214EC07123B613B");

            entity.ToTable("ThanhToan");

            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PhuongThucThanhToan).HasMaxLength(50);
            entity.Property(e => e.TrangThaiThanhToan)
                .HasMaxLength(50)
                .HasDefaultValue("Cho xu ly");

            entity.HasOne(d => d.DonHang).WithMany(p => p.ThanhToans)
                .HasForeignKey(d => d.DonHangId)
                .HasConstraintName("FK__ThanhToan__DonHa__6383C8BA");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

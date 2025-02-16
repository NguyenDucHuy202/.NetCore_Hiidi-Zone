using System;
using System.Collections.Generic;

namespace Hiidi_Zone_Ecommerce.Data;

public partial class SanPham
{
    public int Id { get; set; }

    public string Ten { get; set; } = null!;

    public string? MoTa { get; set; }

    public decimal Gia { get; set; }

    public int TonKho { get; set; }

    public int? DanhMucId { get; set; }

    public DateTime? NgayTao { get; set; }

    public virtual ICollection<ChiTietDanhSachYeuThich> ChiTietDanhSachYeuThiches { get; set; } = new List<ChiTietDanhSachYeuThich>();

    public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; } = new List<ChiTietDonHang>();

    public virtual ICollection<ChiTietGioHang> ChiTietGioHangs { get; set; } = new List<ChiTietGioHang>();

    public virtual ICollection<DanhGium> DanhGia { get; set; } = new List<DanhGium>();

    public virtual DanhMuc? DanhMuc { get; set; }

    public virtual ICollection<HinhAnhSanPham> HinhAnhSanPhams { get; set; } = new List<HinhAnhSanPham>();
}

using System;
using System.Collections.Generic;

namespace Hiidi_Zone_Ecommerce.Data;

public partial class NguoiDung
{
    public int Id { get; set; }

    public string Ten { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public string? SoDienThoai { get; set; }

    public DateTime? NgayTao { get; set; }

    public virtual ICollection<DanhGium> DanhGia { get; set; } = new List<DanhGium>();

    public virtual ICollection<DanhSachYeuThich> DanhSachYeuThiches { get; set; } = new List<DanhSachYeuThich>();

    public virtual ICollection<DiaChiNguoiDung> DiaChiNguoiDungs { get; set; } = new List<DiaChiNguoiDung>();

    public virtual ICollection<DonHang> DonHangs { get; set; } = new List<DonHang>();

    public virtual ICollection<GioHang> GioHangs { get; set; } = new List<GioHang>();
}

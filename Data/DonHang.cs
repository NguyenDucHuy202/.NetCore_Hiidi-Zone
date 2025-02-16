using System;
using System.Collections.Generic;

namespace Hiidi_Zone_Ecommerce.Data;

public partial class DonHang
{
    public int Id { get; set; }

    public int NguoiDungId { get; set; }

    public decimal TongGia { get; set; }

    public string? TrangThai { get; set; }

    public string? TrangThaiThanhToan { get; set; }

    public DateTime? NgayTao { get; set; }

    public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; } = new List<ChiTietDonHang>();

    public virtual ICollection<LichSuThanhToan> LichSuThanhToans { get; set; } = new List<LichSuThanhToan>();

    public virtual NguoiDung NguoiDung { get; set; } = null!;

    public virtual ICollection<ThanhToan> ThanhToans { get; set; } = new List<ThanhToan>();
}

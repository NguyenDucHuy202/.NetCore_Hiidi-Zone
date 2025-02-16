using System;
using System.Collections.Generic;

namespace Hiidi_Zone_Ecommerce.Data;

public partial class DanhGium
{
    public int Id { get; set; }

    public int NguoiDungId { get; set; }

    public int SanPhamId { get; set; }

    public int? XepHang { get; set; }

    public string? BinhLuan { get; set; }

    public DateTime? NgayTao { get; set; }

    public virtual NguoiDung NguoiDung { get; set; } = null!;

    public virtual SanPham SanPham { get; set; } = null!;
}

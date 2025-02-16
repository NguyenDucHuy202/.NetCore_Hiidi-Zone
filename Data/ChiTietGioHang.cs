using System;
using System.Collections.Generic;

namespace Hiidi_Zone_Ecommerce.Data;

public partial class ChiTietGioHang
{
    public int Id { get; set; }

    public int GioHangId { get; set; }

    public int SanPhamId { get; set; }

    public int SoLuong { get; set; }

    public virtual GioHang GioHang { get; set; } = null!;

    public virtual SanPham SanPham { get; set; } = null!;
}

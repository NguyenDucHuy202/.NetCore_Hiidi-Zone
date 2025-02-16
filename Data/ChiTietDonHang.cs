using System;
using System.Collections.Generic;

namespace Hiidi_Zone_Ecommerce.Data;

public partial class ChiTietDonHang
{
    public int Id { get; set; }

    public int DonHangId { get; set; }

    public int SanPhamId { get; set; }

    public int SoLuong { get; set; }

    public decimal Gia { get; set; }

    public virtual DonHang DonHang { get; set; } = null!;

    public virtual SanPham SanPham { get; set; } = null!;
}

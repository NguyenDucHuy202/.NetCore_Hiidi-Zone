using System;
using System.Collections.Generic;

namespace Hiidi_Zone_Ecommerce.Data;

public partial class LichSuThanhToan
{
    public int Id { get; set; }

    public int DonHangId { get; set; }

    public decimal SoTien { get; set; }

    public DateTime? NgayThanhToan { get; set; }

    public virtual DonHang DonHang { get; set; } = null!;
}

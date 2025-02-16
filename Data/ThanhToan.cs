using System;
using System.Collections.Generic;

namespace Hiidi_Zone_Ecommerce.Data;

public partial class ThanhToan
{
    public int Id { get; set; }

    public int DonHangId { get; set; }

    public string PhuongThucThanhToan { get; set; } = null!;

    public string? TrangThaiThanhToan { get; set; }

    public DateTime? NgayTao { get; set; }

    public virtual DonHang DonHang { get; set; } = null!;
}

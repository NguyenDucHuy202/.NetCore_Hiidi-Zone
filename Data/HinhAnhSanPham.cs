using System;
using System.Collections.Generic;

namespace Hiidi_Zone_Ecommerce.Data;

public partial class HinhAnhSanPham
{
    public int Id { get; set; }

    public int SanPhamId { get; set; }

    public string DuongDan { get; set; } = null!;

    public virtual SanPham SanPham { get; set; } = null!;
}

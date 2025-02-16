using System;
using System.Collections.Generic;

namespace Hiidi_Zone_Ecommerce.Data;

public partial class MaGiamGium
{
    public int Id { get; set; }

    public string Ma { get; set; } = null!;

    public decimal Giam { get; set; }

    public DateTime NgayHetHan { get; set; }

    public int? SoLuong { get; set; }

    public string? TrangThai { get; set; }
}

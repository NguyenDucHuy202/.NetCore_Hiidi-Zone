using System;
using System.Collections.Generic;

namespace Hiidi_Zone_Ecommerce.Data;

public partial class ChiTietDanhSachYeuThich
{
    public int Id { get; set; }

    public int DanhSachYeuThichId { get; set; }

    public int SanPhamId { get; set; }

    public DateTime? NgayThem { get; set; }

    public virtual DanhSachYeuThich DanhSachYeuThich { get; set; } = null!;

    public virtual SanPham SanPham { get; set; } = null!;
}

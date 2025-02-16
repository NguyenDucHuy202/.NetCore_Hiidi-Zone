using System;
using System.Collections.Generic;

namespace Hiidi_Zone_Ecommerce.Data;

public partial class DanhSachYeuThich
{
    public int Id { get; set; }

    public int NguoiDungId { get; set; }

    public DateTime? NgayTao { get; set; }

    public virtual ICollection<ChiTietDanhSachYeuThich> ChiTietDanhSachYeuThiches { get; set; } = new List<ChiTietDanhSachYeuThich>();

    public virtual NguoiDung NguoiDung { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace Hiidi_Zone_Ecommerce.Data;

public partial class DiaChiNguoiDung
{
    public int Id { get; set; }

    public int NguoiDungId { get; set; }

    public string DiaChi { get; set; } = null!;

    public string? ThanhPho { get; set; }

    public string? QuocGia { get; set; }

    public string? MaBuuChinh { get; set; }

    public virtual NguoiDung NguoiDung { get; set; } = null!;
}

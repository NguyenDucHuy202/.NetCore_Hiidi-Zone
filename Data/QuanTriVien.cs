using System;
using System.Collections.Generic;

namespace Hiidi_Zone_Ecommerce.Data;

public partial class QuanTriVien
{
    public int Id { get; set; }

    public string TenDangNhap { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public string? VaiTro { get; set; }

    public DateTime? NgayTao { get; set; }
}

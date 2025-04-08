using Hiidi_Zone_Ecommerce.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Hiidi_Zone_Ecommerce.Controllers.User
{
    public class GioHangController : Controller
    {
        private readonly CuaHangAppleContext _context;

        public GioHangController(CuaHangAppleContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult ThemVaoGioHang(int id)
        {
            // lấy thông tin người dùng
            var UserId = HttpContext.Session.GetInt32("UserId");
            if (UserId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Tìm giỏ hàng của user
            var gioHang = _context.GioHangs
                .Include(g => g.ChiTietGioHangs)
                .FirstOrDefault(g => g.NguoiDungId == UserId);

            if (gioHang == null)
            {
                gioHang = new GioHang
                {
                    NguoiDungId = UserId.Value,
                    ChiTietGioHangs = new List<ChiTietGioHang>()
                };
                _context.GioHangs.Add(gioHang);
                _context.SaveChanges(); // Lưu vào database để sinh Id
            }

            // Kiểm tra Id sau khi tạo
            Console.WriteLine($"GioHang Id: {gioHang.Id}");

            // Tìm sản phẩm
            var sanPham = _context.SanPhams.Find(id);
            if (sanPham == null)
            {
                return NotFound("Không tìm thấy sản phẩm");
            }

            // Kiểm tra sản phẩm đã thêm chưa
            var chiTietGioHang = gioHang.ChiTietGioHangs.FirstOrDefault(c => c.SanPhamId == id);

            if (chiTietGioHang == null)
            {
                chiTietGioHang = new ChiTietGioHang
                {
                    GioHangId = gioHang.Id,
                    SanPhamId = id,
                    SoLuong = 1
                };
                _context.ChiTietGioHangs.Add(chiTietGioHang);
            }
            else
            {
                chiTietGioHang.SoLuong++;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "SanPhams");
        }

        public async Task<IActionResult> XemGioHang()
        {
            var UserId = HttpContext.Session.GetInt32("UserId");
            if (UserId == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var gioHang = await _context.GioHangs
                .Include(g => g.ChiTietGioHangs)
                    .ThenInclude(c => c.SanPham)
                        .ThenInclude(sp => sp.DanhMuc) // Bao gồm danh mục sản phẩm
                .Include(g => g.ChiTietGioHangs)
                    .ThenInclude(c => c.SanPham)
                        .ThenInclude(sp => sp.HinhAnhSanPhams) // Bao gồm hình ảnh sản phẩm
                .Include(g => g.NguoiDung)
                    .ThenInclude(nd => nd.DiaChiNguoiDungs) // Bao gồm địa chỉ người dùng
                .FirstOrDefaultAsync(g => g.NguoiDungId == UserId.Value);

            return View(gioHang);
        }

        [HttpPost]
        public async Task<IActionResult> TaoDonHang(double TongGia, bool trangThaiThanhToan)
        {
            var UserId = HttpContext.Session.GetInt32("UserId");
            if (UserId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var gioHang = await _context.GioHangs
                .Include(g => g.ChiTietGioHangs)
                .ThenInclude(c => c.SanPham) // Đảm bảo lấy thông tin sản phẩm
                .FirstOrDefaultAsync(g => g.NguoiDungId == UserId.Value);

            if (gioHang == null || !gioHang.ChiTietGioHangs.Any())
            {
                return BadRequest("Giỏ hàng trống");
            }

            double tongGia = TongGia;
            var donHang = new DonHang
            {
                NguoiDungId = UserId.Value,
                TongGia = (decimal)tongGia,
                TrangThai = "Chờ xác nhận",
                TrangThaiThanhToan = trangThaiThanhToan ? "Đã thanh toán" : "Chưa thanh toán",
                NgayTao = DateTime.Now
            };

            _context.DonHangs.Add(donHang);
            await _context.SaveChangesAsync(); // Lưu để có ID của đơn hàng

            // Thêm chi tiết đơn hàng từ giỏ hàng
            foreach (var item in gioHang.ChiTietGioHangs)
            {
                var chiTietDonHang = new ChiTietDonHang
                {
                    DonHangId = donHang.Id,
                    SanPhamId = item.SanPhamId,
                    SoLuong = item.SoLuong,
                    Gia = item.SanPham.Gia, // Giá từ sản phẩm
                    
                };
                _context.ChiTietDonHangs.Add(chiTietDonHang);
            }

            // Xóa giỏ hàng sau khi tạo đơn hàng
            _context.GioHangs.Remove(gioHang);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "SanPhams");
        }

    }
}

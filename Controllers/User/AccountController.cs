using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;
using Hiidi_Zone_Ecommerce.Data;
using Hiidi_Zone_Ecommerce.Models;
using Microsoft.CodeAnalysis.Scripting;

namespace Hiidi_Zone_Ecommerce.Controllers.User
{
    public class AccountController : Controller
    {
        private readonly CuaHangAppleContext _context;

        public AccountController(CuaHangAppleContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var nguoiDung = await _context.NguoiDungs
        .FirstOrDefaultAsync(u => u.Email == email);

            if (nguoiDung == null || !BCrypt.Net.BCrypt.Verify(password, nguoiDung.MatKhau))
            {
                ViewData["ErrorMessage"] = "Email hoặc mật khẩu không đúng.";
                return View();
            }

            // Tạo session cho user
            HttpContext.Session.SetString("UserName", nguoiDung.Ten);
            HttpContext.Session.SetString("UserEmail", nguoiDung.Email);
            HttpContext.Session.SetString("UserPhone", nguoiDung.SoDienThoai);
            HttpContext.Session.SetInt32("UserId", nguoiDung.Id);
            return RedirectToAction("Index", "SanPhams");
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string hoTen, string email, string soDienThoai, string password)
        {
            // Kiểm tra email đã tồn tại chưa
            if (_context.NguoiDungs.Any(u => u.Email == email))
            {
                ViewData["ErrorMessage"] = "Email đã được sử dụng.";
                return View();
            }

            // Tạo người dùng mới
            var nguoiDung = new NguoiDung
            {
                Ten = hoTen,
                Email = email,
                SoDienThoai = soDienThoai,
                MatKhau = HashPassword(password)
            };

            _context.NguoiDungs.Add(nguoiDung);
            await _context.SaveChangesAsync();

            // Lưu UserId vào Session sau khi đăng ký thành công
            HttpContext.Session.SetInt32("UserId", nguoiDung.Id);

            return RedirectToAction("Login", "Account");
        }
        // Existing code
        private string HashPassword(string password)
        {
            // Băm mật khẩu với BCrypt, mặc định work factor là 12
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        [HttpGet]
        public async Task<IActionResult> UserProfile()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue)
            {
                return RedirectToAction("Login", "Account");
            }

            var nguoiDung = await _context.NguoiDungs
                .Include(u => u.DiaChiNguoiDungs) // Load danh sách địa chỉ
                .FirstOrDefaultAsync(u => u.Id == userId.Value);

            if (nguoiDung == null)
            {
                return NotFound("User not found.");
            }

            // Đảm bảo danh sách địa chỉ không bị null để tránh lỗi
            nguoiDung.DiaChiNguoiDungs ??= new List<DiaChiNguoiDung>();

            return View(nguoiDung);
        }
        [HttpGet]
        public async Task<IActionResult> XemDonHang()
        {
            var UserId = HttpContext.Session.GetInt32("UserId");
            if (UserId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var donHangs = await _context.DonHangs
                .Where(d => d.NguoiDungId == UserId.Value)
                .Include(d => d.NguoiDung) // Include NguoiDung
                .Include(d => d.ChiTietDonHangs)
                .ThenInclude(c => c.SanPham)
                .OrderByDescending(d => d.NgayTao) // Sắp xếp đơn hàng mới nhất lên trước
                .ToListAsync();

            return View(donHangs);
        }

        public async Task<IActionResult> ChiTietDonHang(int id)
        {
            var donHang = await _context.DonHangs
                .Include(d => d.NguoiDung)
                .Include(d => d.ChiTietDonHangs)
                    .ThenInclude(cd => cd.SanPham)
                        .ThenInclude(sp => sp.HinhAnhSanPhams)
                .Include(d => d.ChiTietDonHangs)
                    .ThenInclude(cd => cd.SanPham)
                        .ThenInclude(sp => sp.DanhMuc)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (donHang == null)
            {
                return NotFound();
            }

            return View(donHang);
        }



    }
}

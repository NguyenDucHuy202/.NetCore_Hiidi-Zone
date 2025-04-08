using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hiidi_Zone_Ecommerce.Data;

namespace Hiidi_Zone_Ecommerce.Controllers.User
{
    public class SanPhamsController : Controller
    {
        private readonly CuaHangAppleContext _context;

        public SanPhamsController(CuaHangAppleContext context)
        {
            _context = context;
        }

        // GET: SanPhams
        public async Task<IActionResult> Index()
        {
            var cuaHangAppleContext = _context.DanhMucs
        .Include(d => d.SanPhams) // Bao gồm danh sách sản phẩm của danh mục
        .ThenInclude(s => s.HinhAnhSanPhams); // Bao gồm danh sách hình ảnh của sản phẩm

            return View(await cuaHangAppleContext.ToListAsync());

        }

        // GET: SanPhams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams
                .Include(s => s.HinhAnhSanPhams)
                .Include(s => s.DanhMuc)
                
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // GET: SanPhams/Create
        public IActionResult Create()
        {
            ViewData["DanhMucId"] = new SelectList(_context.DanhMucs, "Id", "Id");
            return View();
        }

        // POST: SanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ten,MoTa,Gia,TonKho,DanhMucId,NgayTao")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sanPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DanhMucId"] = new SelectList(_context.DanhMucs, "Id", "Id", sanPham.DanhMucId);
            return View(sanPham);
        }

        // GET: SanPhams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams.FindAsync(id);
            if (sanPham == null)
            {
                return NotFound();
            }
            ViewData["DanhMucId"] = new SelectList(_context.DanhMucs, "Id", "Id", sanPham.DanhMucId);
            return View(sanPham);
        }

        // POST: SanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ten,MoTa,Gia,TonKho,DanhMucId,NgayTao")] SanPham sanPham)
        {
            if (id != sanPham.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanPhamExists(sanPham.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DanhMucId"] = new SelectList(_context.DanhMucs, "Id", "Id", sanPham.DanhMucId);
            return View(sanPham);
        }

        // GET: SanPhams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams
                .Include(s => s.DanhMuc)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // POST: SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sanPham = await _context.SanPhams.FindAsync(id);
            if (sanPham != null)
            {
                _context.SanPhams.Remove(sanPham);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanPhamExists(int id)
        {
            return _context.SanPhams.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Index_Iphone()
        {
            var cuaHangAppleContext = _context.DanhMucs
        .Include(d => d.SanPhams) // Bao gồm danh sách sản phẩm của danh mục
        .ThenInclude(s => s.HinhAnhSanPhams); // Bao gồm danh sách hình ảnh của sản phẩm

            return View(await cuaHangAppleContext.ToListAsync());

        }
        public async Task<IActionResult> Index_Mac()
        {
            var cuaHangAppleContext = _context.DanhMucs
        .Include(d => d.SanPhams) // Bao gồm danh sách sản phẩm của danh mục
        .ThenInclude(s => s.HinhAnhSanPhams); // Bao gồm danh sách hình ảnh của sản phẩm

            return View(await cuaHangAppleContext.ToListAsync());

        }

        public async Task<IActionResult> Index_Ipad()
        {
            var cuaHangAppleContext = _context.DanhMucs
        .Include(d => d.SanPhams) // Bao gồm danh sách sản phẩm của danh mục
        .ThenInclude(s => s.HinhAnhSanPhams); // Bao gồm danh sách hình ảnh của sản phẩm

            return View(await cuaHangAppleContext.ToListAsync());

        }

        public async Task<IActionResult> Index_PhuKien()
        {
            var cuaHangAppleContext = _context.DanhMucs
        .Include(d => d.SanPhams) // Bao gồm danh sách sản phẩm của danh mục
        .ThenInclude(s => s.HinhAnhSanPhams); // Bao gồm danh sách hình ảnh của sản phẩm

            return View(await cuaHangAppleContext.ToListAsync());

        }
        public async Task<IActionResult> Index_AppW()
        {
            var cuaHangAppleContext = _context.DanhMucs
        .Include(d => d.SanPhams) // Bao gồm danh sách sản phẩm của danh mục
        .ThenInclude(s => s.HinhAnhSanPhams); // Bao gồm danh sách hình ảnh của sản phẩm

            return View(await cuaHangAppleContext.ToListAsync());

        }
        public async Task<IActionResult> Index_AirPods()
        {
            var cuaHangAppleContext = _context.DanhMucs
        .Include(d => d.SanPhams) // Bao gồm danh sách sản phẩm của danh mục
        .ThenInclude(s => s.HinhAnhSanPhams); // Bao gồm danh sách hình ảnh của sản phẩm

            return View(await cuaHangAppleContext.ToListAsync());

        }
    }
}

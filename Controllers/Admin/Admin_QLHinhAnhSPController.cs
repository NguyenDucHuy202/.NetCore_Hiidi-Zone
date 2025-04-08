using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hiidi_Zone_Ecommerce.Data;

namespace Hiidi_Zone_Ecommerce.Controllers.Admin
{
    public class Admin_QLHinhAnhSPController : Controller
    {
        private readonly CuaHangAppleContext _context;

        public Admin_QLHinhAnhSPController(CuaHangAppleContext context)
        {
            _context = context;
        }

        // GET: Admin_QLHinhAnhSP
        public async Task<IActionResult> Index()
        {
            var cuaHangAppleContext = _context.HinhAnhSanPhams.Include(h => h.SanPham).Include(d => d.SanPham.DanhMuc);
            return View(await cuaHangAppleContext.ToListAsync());
        }

        // GET: Admin_QLHinhAnhSP/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hinhAnhSanPham = await _context.HinhAnhSanPhams
                .Include(h => h.SanPham)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hinhAnhSanPham == null)
            {
                return NotFound();
            }

            return View(hinhAnhSanPham);
        }

        // GET: Admin_QLHinhAnhSP/Create
        public IActionResult Create()
        {
            ViewData["SanPhamId"] = new SelectList(_context.SanPhams, "Id", "Ten");
            return View();
        }

        // POST: Admin_QLHinhAnhSP/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SanPhamId,DuongDan")] HinhAnhSanPham hinhAnhSanPham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hinhAnhSanPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SanPhamId"] = new SelectList(_context.SanPhams, "Id", "Id", hinhAnhSanPham.SanPhamId);
            return View(hinhAnhSanPham);
        }

        // GET: Admin_QLHinhAnhSP/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hinhAnhSanPham = await _context.HinhAnhSanPhams.FindAsync(id);
            if (hinhAnhSanPham == null)
            {
                return NotFound();
            }
            ViewData["SanPhamId"] = new SelectList(_context.SanPhams, "Id", "Ten", hinhAnhSanPham.SanPhamId);
            return View(hinhAnhSanPham);
        }

        // POST: Admin_QLHinhAnhSP/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SanPhamId,DuongDan")] HinhAnhSanPham hinhAnhSanPham)
        {
            if (id != hinhAnhSanPham.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hinhAnhSanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HinhAnhSanPhamExists(hinhAnhSanPham.Id))
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
            ViewData["SanPhamId"] = new SelectList(_context.SanPhams, "Id", "Id", hinhAnhSanPham.SanPhamId);
            return View(hinhAnhSanPham);
        }

        // GET: Admin_QLHinhAnhSP/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hinhAnhSanPham = await _context.HinhAnhSanPhams
                .Include(h => h.SanPham)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hinhAnhSanPham == null)
            {
                return NotFound();
            }

            return View(hinhAnhSanPham);
        }

        // POST: Admin_QLHinhAnhSP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hinhAnhSanPham = await _context.HinhAnhSanPhams.FindAsync(id);
            if (hinhAnhSanPham != null)
            {
                _context.HinhAnhSanPhams.Remove(hinhAnhSanPham);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HinhAnhSanPhamExists(int id)
        {
            return _context.HinhAnhSanPhams.Any(e => e.Id == id);
        }
    }
}

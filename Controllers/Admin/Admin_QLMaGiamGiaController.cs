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
    public class Admin_QLMaGiamGiaController : Controller
    {
        private readonly CuaHangAppleContext _context;

        public Admin_QLMaGiamGiaController(CuaHangAppleContext context)
        {
            _context = context;
        }

        // GET: Admin_QLMaGiamGia
        public async Task<IActionResult> Index()
        {
            return View(await _context.MaGiamGia.ToListAsync());
        }

        // GET: Admin_QLMaGiamGia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maGiamGium = await _context.MaGiamGia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (maGiamGium == null)
            {
                return NotFound();
            }

            return View(maGiamGium);
        }

        // GET: Admin_QLMaGiamGia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin_QLMaGiamGia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ma,Giam,NgayHetHan,SoLuong,TrangThai")] MaGiamGium maGiamGium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(maGiamGium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(maGiamGium);
        }

        // GET: Admin_QLMaGiamGia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maGiamGium = await _context.MaGiamGia.FindAsync(id);
            if (maGiamGium == null)
            {
                return NotFound();
            }
            return View(maGiamGium);
        }

        // POST: Admin_QLMaGiamGia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ma,Giam,NgayHetHan,SoLuong,TrangThai")] MaGiamGium maGiamGium)
        {
            if (id != maGiamGium.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(maGiamGium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaGiamGiumExists(maGiamGium.Id))
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
            return View(maGiamGium);
        }

        // GET: Admin_QLMaGiamGia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maGiamGium = await _context.MaGiamGia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (maGiamGium == null)
            {
                return NotFound();
            }

            return View(maGiamGium);
        }

        // POST: Admin_QLMaGiamGia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var maGiamGium = await _context.MaGiamGia.FindAsync(id);
            if (maGiamGium != null)
            {
                _context.MaGiamGia.Remove(maGiamGium);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaGiamGiumExists(int id)
        {
            return _context.MaGiamGia.Any(e => e.Id == id);
        }
    }
}

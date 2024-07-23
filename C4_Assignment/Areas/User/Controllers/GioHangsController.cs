using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C4_Assignment.Data;
using C4_Assignment.Models;

namespace C4_Assignment.Areas.User.Controllers
{
    [Area("User")]
    public class GioHangsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public GioHangsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: User/GioHangs
        public async Task<IActionResult> Index()
        {
            var applicationDBContext = _context.GioHangs.Include(g => g.TaiKhoan).Include(g => g.sanPham);
            return View(await applicationDBContext.ToListAsync());
        }

        // GET: User/GioHangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GioHangs == null)
            {
                return NotFound();
            }

            var gioHang = await _context.GioHangs
                .Include(g => g.TaiKhoan)
                .Include(g => g.sanPham)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gioHang == null)
            {
                return NotFound();
            }

            return View(gioHang);
        }

        // GET: User/GioHangs/Create
        public IActionResult Create()
        {
            ViewData["TaiKhoanID"] = new SelectList(_context.TaiKhoans, "TaiKhoanID", "TaiKhoanID");
            ViewData["SanPhamID"] = new SelectList(_context.SanPhams, "SanPhamID", "SanPhamID");
            return View();
        }

        // POST: User/GioHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,soluong,TaiKhoanID,SanPhamID")] GioHang gioHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gioHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TaiKhoanID"] = new SelectList(_context.TaiKhoans, "TaiKhoanID", "TaiKhoanID", gioHang.TaiKhoanID);
            ViewData["SanPhamID"] = new SelectList(_context.SanPhams, "SanPhamID", "SanPhamID", gioHang.SanPhamID);
            return View(gioHang);
        }

        // GET: User/GioHangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GioHangs == null)
            {
                return NotFound();
            }

            var gioHang = await _context.GioHangs.FindAsync(id);
            if (gioHang == null)
            {
                return NotFound();
            }
            ViewData["TaiKhoanID"] = new SelectList(_context.TaiKhoans, "TaiKhoanID", "TaiKhoanID", gioHang.TaiKhoanID);
            ViewData["SanPhamID"] = new SelectList(_context.SanPhams, "SanPhamID", "SanPhamID", gioHang.SanPhamID);
            return View(gioHang);
        }

        // POST: User/GioHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,soluong,TaiKhoanID,SanPhamID")] GioHang gioHang)
        {
            if (id != gioHang.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gioHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GioHangExists(gioHang.Id))
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
            ViewData["TaiKhoanID"] = new SelectList(_context.TaiKhoans, "TaiKhoanID", "TaiKhoanID", gioHang.TaiKhoanID);
            ViewData["SanPhamID"] = new SelectList(_context.SanPhams, "SanPhamID", "SanPhamID", gioHang.SanPhamID);
            return View(gioHang);
        }

        // GET: User/GioHangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GioHangs == null)
            {
                return NotFound();
            }

            var gioHang = await _context.GioHangs
                .Include(g => g.TaiKhoan)
                .Include(g => g.sanPham)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gioHang == null)
            {
                return NotFound();
            }

            return View(gioHang);
        }

        // POST: User/GioHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GioHangs == null)
            {
                return Problem("Entity set 'ApplicationDBContext.GioHangs'  is null.");
            }
            var gioHang = await _context.GioHangs.FindAsync(id);
            if (gioHang != null)
            {
                _context.GioHangs.Remove(gioHang);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GioHangExists(int id)
        {
          return (_context.GioHangs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

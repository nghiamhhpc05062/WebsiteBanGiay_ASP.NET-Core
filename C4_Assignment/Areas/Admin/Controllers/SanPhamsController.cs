using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C4_Assignment.Data;
using C4_Assignment.Models;

namespace C4_Assignment.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SanPhamsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public SanPhamsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Admin/SanPhams
        public async Task<IActionResult> Index()
        {
            var applicationDBContext = _context.SanPhams.Include(s => s.CungCap).Include(s => s.DanhMuc);
            return View(await applicationDBContext.ToListAsync());
        }

        // GET: Admin/SanPhams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SanPhams == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams
                .Include(s => s.CungCap)
                .Include(s => s.DanhMuc)
                .FirstOrDefaultAsync(m => m.SanPhamID == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // GET: Admin/SanPhams/Create
        public IActionResult Create()
        {
            ViewData["CungCapID"] = new SelectList(_context.CungCaps, "CungCapID", "CungCapID");
            ViewData["DanhMucID"] = new SelectList(_context.DanhMucss, "DanhMucID", "DanhMucID");
            return View();
        }

        // POST: Admin/SanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SanPhamID,TenSanPham,HinhAnh,GhiChu,Gia,MauSac,KichThuoc,DanhMucID,CungCapID")] SanPham sanPham)
        {
            ViewData["CungCapID"] = new SelectList(_context.CungCaps, "CungCapID", "CungCapID", sanPham.CungCapID);
            ViewData["DanhMucID"] = new SelectList(_context.DanhMucss, "DanhMucID", "DanhMucID", sanPham.DanhMucID);

            //if (ModelState.IsValid)
            //{
            //    _context.Add(sanPham);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            _context.Add(sanPham);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            //return View(sanPham);
        }

        // GET: Admin/SanPhams/Edit/1
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SanPhams == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams.FindAsync(id);
            if (sanPham == null)
            {
                return NotFound();
            }
            ViewData["CungCapID"] = new SelectList(_context.CungCaps, "CungCapID", "CungCapID", sanPham.CungCapID);
            ViewData["DanhMucID"] = new SelectList(_context.DanhMucss, "DanhMucID", "DanhMucID", sanPham.DanhMucID);
            return View(sanPham);
        }

        // POST: Admin/SanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SanPhamID,TenSanPham,HinhAnh,GhiChu,Gia,MauSac,KichThuoc,DanhMucID,CungCapID")] SanPham sanPham)
        {
            if (id != sanPham.SanPhamID)
            {
                return NotFound();
            }

            ViewData["CungCapID"] = new SelectList(_context.CungCaps, "CungCapID", "CungCapID", sanPham.CungCapID);
            ViewData["DanhMucID"] = new SelectList(_context.DanhMucss, "DanhMucID", "DanhMucID", sanPham.DanhMucID);

            try
            {
                _context.Update(sanPham);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SanPhamExists(sanPham.SanPhamID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
            //return View(sanPham);
        }

        // GET: Admin/SanPhams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SanPhams == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams
                .Include(s => s.CungCap)
                .Include(s => s.DanhMuc)
                .FirstOrDefaultAsync(m => m.SanPhamID == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // POST: Admin/SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SanPhams == null)
            {
                return Problem("Entity set 'ApplicationDBContext.SanPhams'  is null.");
            }
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
          return (_context.SanPhams?.Any(e => e.SanPhamID == id)).GetValueOrDefault();
        }
    }
}

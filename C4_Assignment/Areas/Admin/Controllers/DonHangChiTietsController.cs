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
    public class DonHangChiTietsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public DonHangChiTietsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Admin/DonHangChiTiets
        public async Task<IActionResult> Index()
        {
            var applicationDBContext = _context.DonHangChiTiets.Include(d => d.DonHang).Include(d => d.SanPham);
            return View(await applicationDBContext.ToListAsync());
        }

        // GET: Admin/DonHangChiTiets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DonHangChiTiets == null)
            {
                return NotFound();
            }

            var donHangChiTiet = await _context.DonHangChiTiets
                .Include(d => d.DonHang)
                .Include(d => d.SanPham)
                .FirstOrDefaultAsync(m => m.DonHangChiTietID == id);
            if (donHangChiTiet == null)
            {
                return NotFound();
            }

            return View(donHangChiTiet);
        }

        // GET: Admin/DonHangChiTiets/Create
        public IActionResult Create()
        {
            ViewData["DonHangID"] = new SelectList(_context.DonHangs, "DonHangID", "DonHangID");
            ViewData["SanPhamID"] = new SelectList(_context.SanPhams, "SanPhamID", "SanPhamID");
            return View();
        }

        // POST: Admin/DonHangChiTiets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DonHangChiTietID,SanPhamID,DonHangID,SoLuong")] DonHangChiTiet donHangChiTiet)
        {
            //if (ModelState.IsValid)
            //{
            //    _context.Add(donHangChiTiet);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            ViewData["DonHangID"] = new SelectList(_context.DonHangs, "DonHangID", "DonHangID", donHangChiTiet.DonHangID);
            ViewData["SanPhamID"] = new SelectList(_context.SanPhams, "SanPhamID", "SanPhamID", donHangChiTiet.SanPhamID);
            _context.Add(donHangChiTiet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            //return View(donHangChiTiet);
        }

        // GET: Admin/DonHangChiTiets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DonHangChiTiets == null)
            {
                return NotFound();
            }

            var donHangChiTiet = await _context.DonHangChiTiets.FindAsync(id);
            if (donHangChiTiet == null)
            {
                return NotFound();
            }
            ViewData["DonHangID"] = new SelectList(_context.DonHangs, "DonHangID", "DonHangID", donHangChiTiet.DonHangID);
            ViewData["SanPhamID"] = new SelectList(_context.SanPhams, "SanPhamID", "SanPhamID", donHangChiTiet.SanPhamID);
            return View(donHangChiTiet);
        }

        // POST: Admin/DonHangChiTiets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DonHangChiTietID,SanPhamID,DonHangID,SoLuong")] DonHangChiTiet donHangChiTiet)
        {
            if (id != donHangChiTiet.DonHangChiTietID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donHangChiTiet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonHangChiTietExists(donHangChiTiet.DonHangChiTietID))
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
            ViewData["DonHangID"] = new SelectList(_context.DonHangs, "DonHangID", "DonHangID", donHangChiTiet.DonHangID);
            ViewData["SanPhamID"] = new SelectList(_context.SanPhams, "SanPhamID", "SanPhamID", donHangChiTiet.SanPhamID);
            return View(donHangChiTiet);
        }

        // GET: Admin/DonHangChiTiets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DonHangChiTiets == null)
            {
                return NotFound();
            }

            var donHangChiTiet = await _context.DonHangChiTiets
                .Include(d => d.DonHang)
                .Include(d => d.SanPham)
                .FirstOrDefaultAsync(m => m.DonHangChiTietID == id);
            if (donHangChiTiet == null)
            {
                return NotFound();
            }

            return View(donHangChiTiet);
        }

        // POST: Admin/DonHangChiTiets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DonHangChiTiets == null)
            {
                return Problem("Entity set 'ApplicationDBContext.DonHangChiTiets'  is null.");
            }
            var donHangChiTiet = await _context.DonHangChiTiets.FindAsync(id);
            if (donHangChiTiet != null)
            {
                _context.DonHangChiTiets.Remove(donHangChiTiet);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonHangChiTietExists(int id)
        {
          return (_context.DonHangChiTiets?.Any(e => e.DonHangChiTietID == id)).GetValueOrDefault();
        }
    }
}

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
    public class DonHangsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public DonHangsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Admin/DonHangs
        public async Task<IActionResult> Index()
        {
            var applicationDBContext = _context.DonHangs.Include(d => d.KhachHang).Include(d => d.NhanVien);
            return View(await applicationDBContext.ToListAsync());
        }

        // GET: Admin/DonHangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DonHangs == null)
            {
                return NotFound();
            }

            var donHang = await _context.DonHangs
                .Include(d => d.KhachHang)
                .Include(d => d.NhanVien)
                .FirstOrDefaultAsync(m => m.DonHangID == id);
            if (donHang == null)
            {
                return NotFound();
            }

            return View(donHang);
        }

        // GET: Admin/DonHangs/Create
        public IActionResult Create()
        {
            ViewData["KhachHangID"] = new SelectList(_context.KhachHangs, "KhachHangID", "KhachHangID");
            ViewData["NhanVienID"] = new SelectList(_context.NhanViens, "NhanVienID", "NhanVienID");
            return View();
        }

        // POST: Admin/DonHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DonHangID,NgayDatHang,TrangThai,KhachHangID,NhanVienID")] DonHang donHang)
        {
            //if (ModelState.IsValid)
            //{
            //    _context.Add(donHang);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            ViewData["KhachHangID"] = new SelectList(_context.KhachHangs, "KhachHangID", "KhachHangID", donHang.KhachHangID);
            ViewData["NhanVienID"] = new SelectList(_context.NhanViens, "NhanVienID", "NhanVienID", donHang.NhanVienID);
            _context.Add(donHang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            //return View(donHang);
        }

        // GET: Admin/DonHangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DonHangs == null)
            {
                return NotFound();
            }

            var donHang = await _context.DonHangs.FindAsync(id);
            if (donHang == null)
            {
                return NotFound();
            }
            ViewData["KhachHangID"] = new SelectList(_context.KhachHangs, "KhachHangID", "KhachHangID", donHang.KhachHangID);
            ViewData["NhanVienID"] = new SelectList(_context.NhanViens, "NhanVienID", "NhanVienID", donHang.NhanVienID);
            return View(donHang);
        }

        // POST: Admin/DonHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DonHangID,NgayDatHang,TrangThai,KhachHangID,NhanVienID")] DonHang donHang)
        {
            if (id != donHang.DonHangID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonHangExists(donHang.DonHangID))
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
            ViewData["KhachHangID"] = new SelectList(_context.KhachHangs, "KhachHangID", "KhachHangID", donHang.KhachHangID);
            ViewData["NhanVienID"] = new SelectList(_context.NhanViens, "NhanVienID", "NhanVienID", donHang.NhanVienID);
            return View(donHang);
        }

        // GET: Admin/DonHangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DonHangs == null)
            {
                return NotFound();
            }

            var donHang = await _context.DonHangs
                .Include(d => d.KhachHang)
                .Include(d => d.NhanVien)
                .FirstOrDefaultAsync(m => m.DonHangID == id);
            if (donHang == null)
            {
                return NotFound();
            }

            return View(donHang);
        }

        // POST: Admin/DonHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DonHangs == null)
            {
                return Problem("Entity set 'ApplicationDBContext.DonHangs'  is null.");
            }
            var donHang = await _context.DonHangs.FindAsync(id);
            if (donHang != null)
            {
                _context.DonHangs.Remove(donHang);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonHangExists(int id)
        {
          return (_context.DonHangs?.Any(e => e.DonHangID == id)).GetValueOrDefault();
        }
    }
}

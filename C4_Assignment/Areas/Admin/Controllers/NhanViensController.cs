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
    public class NhanViensController : Controller
    {
        private readonly ApplicationDBContext _context;

        public NhanViensController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Admin/NhanViens
        public async Task<IActionResult> Index()
        {
              return _context.NhanViens != null ? 
                          View(await _context.NhanViens.ToListAsync()) :
                          Problem("Entity set 'ApplicationDBContext.NhanViens'  is null.");
        }

        // GET: Admin/NhanViens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NhanViens == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanViens
                .FirstOrDefaultAsync(m => m.NhanVienID == id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            return View(nhanVien);
        }

        // GET: Admin/NhanViens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/NhanViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NhanVienID,Username,Anh,HoTen,NgayVaoLam,ChucVu")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhanVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nhanVien);
        }

        // GET: Admin/NhanViens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NhanViens == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanViens.FindAsync(id);
            if (nhanVien == null)
            {
                return NotFound();
            }
            return View(nhanVien);
        }

        // POST: Admin/NhanViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NhanVienID,Username,Anh,HoTen,NgayVaoLam,ChucVu")] NhanVien nhanVien)
        {
            if (id != nhanVien.NhanVienID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhanVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanVienExists(nhanVien.NhanVienID))
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
            return View(nhanVien);
        }

        // GET: Admin/NhanViens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NhanViens == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanViens
                .FirstOrDefaultAsync(m => m.NhanVienID == id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            return View(nhanVien);
        }

        // POST: Admin/NhanViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NhanViens == null)
            {
                return Problem("Entity set 'ApplicationDBContext.NhanViens'  is null.");
            }
            var nhanVien = await _context.NhanViens.FindAsync(id);
            if (nhanVien != null)
            {
                _context.NhanViens.Remove(nhanVien);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhanVienExists(int id)
        {
          return (_context.NhanViens?.Any(e => e.NhanVienID == id)).GetValueOrDefault();
        }
    }
}

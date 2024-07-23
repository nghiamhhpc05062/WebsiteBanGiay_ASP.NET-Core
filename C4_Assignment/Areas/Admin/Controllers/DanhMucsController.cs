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
    public class DanhMucsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public DanhMucsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Admin/DanhMucs
        public async Task<IActionResult> Index()
        {
              return _context.DanhMucss != null ? 
                          View(await _context.DanhMucss.ToListAsync()) :
                          Problem("Entity set 'ApplicationDBContext.DanhMucss'  is null.");
        }

        // GET: Admin/DanhMucs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DanhMucss == null)
            {
                return NotFound();
            }

            var danhMuc = await _context.DanhMucss
                .FirstOrDefaultAsync(m => m.DanhMucID == id);
            if (danhMuc == null)
            {
                return NotFound();
            }

            return View(danhMuc);
        }

        // GET: Admin/DanhMucs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/DanhMucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DanhMucID,TenDanhMuc,HinhAnh")] DanhMuc danhMuc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(danhMuc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(danhMuc);
        }

        // GET: Admin/DanhMucs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DanhMucss == null)
            {
                return NotFound();
            }

            var danhMuc = await _context.DanhMucss.FindAsync(id);
            if (danhMuc == null)
            {
                return NotFound();
            }
            return View(danhMuc);
        }

        // POST: Admin/DanhMucs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DanhMucID,TenDanhMuc,HinhAnh")] DanhMuc danhMuc)
        {
            if (id != danhMuc.DanhMucID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(danhMuc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanhMucExists(danhMuc.DanhMucID))
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
            return View(danhMuc);
        }

        // GET: Admin/DanhMucs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DanhMucss == null)
            {
                return NotFound();
            }

            var danhMuc = await _context.DanhMucss
                .FirstOrDefaultAsync(m => m.DanhMucID == id);
            if (danhMuc == null)
            {
                return NotFound();
            }

            return View(danhMuc);
        }

        // POST: Admin/DanhMucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DanhMucss == null)
            {
                return Problem("Entity set 'ApplicationDBContext.DanhMucss'  is null.");
            }
            var danhMuc = await _context.DanhMucss.FindAsync(id);
            if (danhMuc != null)
            {
                _context.DanhMucss.Remove(danhMuc);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DanhMucExists(int id)
        {
          return (_context.DanhMucss?.Any(e => e.DanhMucID == id)).GetValueOrDefault();
        }
    }
}
